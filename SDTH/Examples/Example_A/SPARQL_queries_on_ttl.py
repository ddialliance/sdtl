##############################################################
####   Read ttl file and run SPARQL queries
####   Prompts for working directory and ttl file
####   Queries are in this program
##############################################################
import pandas as pd
import io
import os
import json
import csv
import tkinter as tk
from tkinter import filedialog
from rdflib import Graph, plugin
from rdflib.serializer import Serializer
from rdflib import Namespace
import rdflib

root = tk.Tk()
root.withdraw()

########  prompt for working directory #########
qpath = filedialog.askdirectory(title="Select output directory")

## -- Prompt for ttl file ---
file_path = filedialog.askopenfilename(title="Select ttl file")
print(file_path)

fld = Graph()


## -- Read ttl file ---
##with open(file_path) as f:
fld.parse(file_path)

#### -- extract file name from .ttl file
fn1 = file_path[ len(qpath) + 1:]
fn2 = fn1[:-4]

##print("**** graph *****")
print("Number of triples: ", len(fld) , "\n")


###### Open query output file ##########
with open(f"{qpath}/{fn2}_SPARQL_results.txt", 'w') as qoutput:

    ####################
    print("\n\n********* Object Names     *******************")
    qoutput.write("\n\n*********  Object Names    *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?s ?sname
    WHERE {
 		?s  sdth:hasName ?sname .
       }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.s} has name {row.sname} " )
        qoutput.write(f"{row.s} has name {row.sname} \n")
 
    ##########    


    ####################
    print("\n\n********* 5.1 What variables affected the values of variable HHcateg? *******************")
    qoutput.write("\n\n*********  5.1 What variables affected the values of variable HHcateg?   *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?sname ?oname
    WHERE {
        ?s  sdth:wasDerivedFrom+ ?o .
		?s  sdth:hasName ?sname .
		?o  sdth:hasName ?oname .
        FILTER (?sname = "HHcateg")
        }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.sname} is derived from {row.oname} " )
        qoutput.write(f"{row.sname} is derived from {row.oname} \n")

    ##########    

    ####################
    print("\n\n********* 5.2 What variables were affected by variable PPHHSIZE?  *******************")
    qoutput.write("\n\n*********  5.2 What variables were affected by variable PPHHSIZE?  *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?sname ?oname
    WHERE {
        ?s  sdth:wasDerivedFrom+ ?o .
		?s  sdth:hasName ?sname .
		?o  sdth:hasName ?oname .
        FILTER (?oname = "PPHHSIZE")
        }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.oname} has an impact on {row.sname} " )
        qoutput.write(f"{row.oname} has an impact on {row.sname} \n" )

    ##########    

    print("\n\n*********  5.3 What commands affected the values of variable HHcateg?  *******************")
    qoutput.write("\n\n*********  5.3 What commands affected the values of variable HHcateg?  *******************\n")
    #### This query is a union of 3 subqueries
    #### The 1st subquery finds program steps where the target variable wasDerivedFrom or elaborationOf
    #### The 2nd subquery finds program steps that changed variables that the target variable wasDerivedFrom or elaborationOf
    #### The 3rd subquery finds program steps with subprograms that change the target variable

    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT DISTINCT ?xname ?yname  ?pscode
    WHERE {
   
        {?x  ( sdth:wasDerivedFrom |sdth:elaborationOf) ?y .
                ?x  sdth:hasName ?xname .
                ?y  sdth:hasName ?yname .
        ?pstep sdth:assignsVariable ?x .
        ?pstep sdth:hasSourceCode  ?pscode.}

        UNION
         {?x  ( sdth:wasDerivedFrom+ |sdth:elaborationOf+) ?y .
                ?x  sdth:hasName ?xname .
                ?y  sdth:hasName ?yname .
        ?pstep sdth:assignsVariable ?y .
        ?pstep sdth:hasSourceCode  ?pscode.
            MINUS { ?pstep sdth:usesVariable ?y . }
             }           

        UNION
        {?pstep sdth:hasProgramStep ?psub.
        ?psub sdth:assignsVariable ?x .
        ?pstep sdth:hasSourceCode ?pscode.
        ?x  sdth:hasName ?xname .
        ?x  ( sdth:wasDerivedFrom+ |sdth:elaborationOf+) ?y .
        ?y  sdth:hasName ?yname . }
     
    
    FILTER (?xname = "HHcateg")
    }
    ORDER BY ?pstep

     """

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.xname} is affected by {row.yname} in command [{row.pscode}]  " )
        qoutput.write(f"{row.xname} is affected by {row.yname} in command [{row.pscode}]  \n" )
    ##########


    ##########    

    print("\n\n*********  Variables indirectly affected by ProgramStep ProgStep004 *******************")
    qoutput.write("\n\n*********  Variables indirectly affected by ProgramStep ProgStep004*******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?sname ?oname ?pscode 
    WHERE {
        ?s  sdth:wasDerivedFrom+ ?o .
		?s  sdth:hasName ?sname .
		?o  sdth:hasName ?oname .
		
        {SELECT ?o  ?pscode
        WHERE {
            ?pstep sdth:assignsVariable ?o.
            ?pstep sdth:hasSourceCode ?pscode.
            FILTER (?pstep = sdtest:ProgStep004 )
         }
         }

    }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.sname} is affected by {row.oname}, which is modified in command [{row.pscode}]" )
        qoutput.write(f"{row.sname} is affected by {row.oname}, which is modified in command [{row.pscode}]\n" )
    ##########    
####################
    print("\n\n********* Find a File containing variable PPHHSIZE that is Loaded in the Program      *******************")
    qoutput.write("\n\n********* Find a File containing variable PPHHSIZE that is Loaded in the Program      *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?sname ?pscode 
    WHERE {
                ?s  sdth:hasVarInstance ?v .
                ?v  sdth:hasName 'PPHHSIZE' .
                ?ps  sdth:loadsFile ?s .
                ?ps sdth:hasSourceCode ?pscode .
                ?s sdth:hasName ?sname .
       }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"Command [{row.pscode}] loads {row.sname} containing variable 'PPHHSIZE' " )
        qoutput.write(f"Command [{row.pscode}] loads {row.sname} containing variable 'PPHHSIZE' \n" )
##########    

####################
    print("\n\n*********  elaborationOf query for variable name HHcateg *******************")
    qoutput.write("\n\n*********  elaborationOf query for variable name HHcateg   *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct ?s ?o ?sname ?oname ?pscode
    WHERE {
        ?s  sdth:elaborationOf+ ?o .
		?s  sdth:hasName ?sname .
		?o  sdth:hasName ?oname .
	?pstep sdth:usesVariable ?o.
            ?pstep sdth:hasSDTL ?pscode.

        FILTER (?sname = "HHcateg")
        }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"{row.s} named {row.sname} is elaboration of {row.o} named  {row.oname} in command {row.pscode} " )
        qoutput.write(f"{row.s} named {row.sname} was Based On {row.o} named {row.oname}  in command {row.pscode} \n")

    ##########   
    ####################
    print("\n\n*********  usesVariable query for variable name PPHHSIZE *******************")
    qoutput.write("\n\n*********  usesVariable query for variable name PPHHSIZE   *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?psource ?oname
    WHERE {
        ?pstep  sdth:usesVariable+ ?o .
		?pstep  sdth:hasSourceCode ?psource .
		?o  sdth:hasName ?oname .
        FILTER (?oname = "PPHHSIZE")
        }"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"Command [{row.psource}] is affected by {row.oname} " )
        qoutput.write(f"Command [{row.psource}] is affected by {row.oname} \n")

    ##########
        
    ####################################################    
    print("\n\n*********  usesVariable query for indirect effects of variable name PPHHSIZE   *******************")
    qoutput.write("\n\n*********  usesVariable query for indirect effects of variable name PPHHSIZE  *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct  ?psource ?sname ?oname
    WHERE {
        ?pstep  sdth:usesVariable+ ?s .
		?pstep  sdth:hasSourceCode ?psource .
	  
		{SELECT distinct  ?s  ?sname ?oname
		WHERE {
			?s  sdth:wasDerivedFrom+ ?o .
			?s  sdth:hasName ?sname .
			?o  sdth:hasName ?oname .
			FILTER (?oname = "PPHHSIZE" )  
			}
			}
		}"""

    qres = fld.query(query_txt)
    for row in qres:
        print(f"Command [{row.psource}] is affected by {row.sname} which is affected by {row.oname} " )
        qoutput.write(f"Command [{row.psource}] is affected by {row.sname} which is affected by {row.oname} \n" )
    ##########


    ####################
    print("\n\n*********  5.4 What commands were affected by variable PPHHSIZE? *******************")
    qoutput.write("\n\n*********  5.4 What commands were affected by variable PPHHSIZE?   *******************\n")
    query_txt = """
    PREFIX sdth: <http://DDI/SDTH/>
    PREFIX sdtest: <http://test/#>	

    SELECT distinct ?pstep  ?psource ?oname ?tname

		WHERE {

		{
			?pstep  sdth:usesVariable+ ?o .
			?pstep  sdth:hasSourceCode ?psource .
			?o  sdth:hasName ?tname .
			?o  sdth:hasName ?oname .
			FILTER (?tname = "PPHHSIZE")
			}
				
		UNION

		{
			?pstep  sdth:usesVariable+ ?s2 .
			?pstep  sdth:hasSourceCode ?psource .
		  
			{SELECT distinct  ?s2   ?oname   ?tname
			WHERE {
				?s2  (sdth:wasDerivedFrom+  | sdth:elaborationOf+ )+ ?o2 .
				?s2  sdth:hasName ?oname .
				?o2  sdth:hasName ?tname .
				FILTER (?tname = "PPHHSIZE" )  
				}
				}
			}
                UNION

		{       ?pstep sdth:hasProgramStep ?psub.
                        ?pstep sdth:hasSourceCode ?psource.

                        {   SELECT DISTINCT    ?s   ?tname  ?t  ?oname ?psub
                                        WHERE {
                                                ?s   (sdth:wasDerivedFrom+ | sdth:elaborationOf+ )+ ?t .
                                                ?s  sdth:hasName ?oname .
                                                ?t  sdth:hasName ?tname .
                                                ?psub (sdth:usesVariable+ | sdth:assignsVariable+) ?s .
                                                FILTER (?tname = "PPHHSIZE" )
                                        }	
                                }       
                        }
		}
    ORDER BY ?pstep
     """
  
    qres = fld.query(query_txt)
    for row in qres:
        print(f" Variable {row.tname} affects command [{row.psource}] through variable {row.oname} " )
        qoutput.write(f"Variable {row.tname} affects command [{row.psource}] through variable {row.oname} \n" )
    ##########

