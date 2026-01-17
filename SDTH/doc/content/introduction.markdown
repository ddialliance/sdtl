# Introduction

The principles of Open Science and FAIR (Findable, Accessible, Reusable, Interoperable) data imply that the management and analysis of data should be transparent. However, transparency is difficult to achieve when data are processed by programs and scripts written for statistical software, databases, or other systems. Even when these scripts are openly available, they are often long, complex, and difficult to understand. SDTH offers a simple way to ask basic questions about a program, like:

1. What variables affected the values of variable X?  
2. What variables were affected by variable X?  
3. What commands affected the values of variable X?  
4. What commands were affected by variable X?  
  
SDTH is designed to answer these questions.  
  
SDTH also provides a bridge between computer programs and PROV [[prov-dm]], a W3C standard for storing and querying provenance metadata.  SDTH applies the PROV approach to computer programs that modify data.  Most previous applications of PROV have been designed to describe workflows.  Programs are treated as black boxes. Their inputs and outputs are described, but the operations within a program are not examined.  SDTH traces data modifications to program steps within programs.  

## SDTH and SDTL

SDTH came out of the same project team that created Structured Data Transformation Language (SDTL).  Both SDTH and SDTL describe the workings of data transformation programs written for statistical analysis software, but they serve very different purposes.  SDTH and Structured Data Transformation Language (SDTL) are different kinds of provenance, and SDTH is much more than a simplification of SDTL. 

SDTL grew out of the need for a common language that could express commands in five widely used statistical analysis packages (SPSS, SAS, Stata, R, and Python).  These languages were developed independently, and each one has its own syntax and vocabulary.  Someone familiar with SPSS may have difficulty understanding R. SDTL serves as a common intermediate language, and the most common commands in all five source languages can be translated into SDTL without loss of information.  In addition, SDTL is in a 'structured' format (e.g., JSON, XML, RDF) that can be easily read by computer software.  All of the other languages require a 'parser' to extract information from a command according to its particular syntax. In contrast, SDTL has minimal syntax, because the parts of an SDTL command are unambiguously identified by tags and delimiters.

SDTH was developed to make it easier to answer simple questions about computer programs. The features that make SDTL precise and machine actionable also make it verbose and difficult to search. The details available in SDTL are not required to answer questions like those above. For example, Question 1 does not ask **how** variable X was affected by other variables.  It asks **which** variables affected variable X.  The detail in SDTL makes answering this question very complicated.  

SDTH and SDTL work very well together. SDTL commands can be included in SDTH using the sdth:hasSDTL predicate, and there are reasons to create SDTH from SDTL, rather than translating other languages directly into SDTH.  First, SDTL decomposes complex commands in other languages into simpler steps, which are easier to follow and understand.  Second, SDTL has the advantages of being a common intermediate language that does not require a parser, and prototype code for translating several languages into SDTL already exists.  

## SDTH and PROV

SDTH is an extension of the PROV data model [[prov-dm]], a World Wide Web Consortium (W3C) standard for provenance metadata.  PROV is a very sparse model that was meant to be extended for specific applications.  SDTH adds data structures (files, dataframes, and variables) and command-level descriptions of operations within programs. 

PROV is based upon three central concepts: entities, activities, and agents.  Entities are things, which may be physical, digital, or conceptual. Activities are processes that generate entities. Agents play a role in the generation of an entity.  Agents may be persons, organizations, computer software, or inanimate objects.  Entities may have attributes that are described in PROV.

For our purposes, a key aspect of PROV is that entities have some immutable properties. This means that some aspects of a PROV entity cannot be changed.  In this respect SDTH is more strict than PROV, and entities in SDTH are fully immutable.  Any change in an SDTH entity results in the generation of a new entity.  As the next section explains, the immutability of entities is a central difference between SDTH and programming languages, including SDTL.

## Instances of data objects

SDTH requires a change in the way that one thinks about a computer program.  We usually think of variables and dataframes as containers into which we put digital representations of numbers, text, or logical values.  As the program is executed, the values assigned to a variable change, but its identity remains the same.  We may think of these sets of values as states of the variable or dataframe.  Since variables and dataframes can change, they do not qualify as entities in the PROV framework.  In contrast, SDTH focuses on the contents of data objects, not their containers.  

We call the set of values assigned to a variable or dataframe at a moment in time an “instance” of a data object.  Every time a command in a program changes the contents of a data object, a new instance is created.  Many instances of data objects created during the execution of a program are ephemeral and disappear when the program ends. Only instances of data objects preserved on non-volatile media, which SDTH calls “files”, persist after the program has executed.

The connection between references to data objects in the program and instances of these objects in SDTH is maintained by making file, variable, and dataframe names properties of entities in SDTH.  Queries of SDTH can report file/variable/dataframe names, instances, or both.

Like PROV, SDTH describes a program as a graph in which “entities” (files, dataframes, and variables) are affected by “activities” (program steps), but these “activities” are not explicitly ordered. SDTH does not encode the sequence of steps in a program. Rather, program steps are implicitly ordered by the links between “entities,” which are instances of variables, dataframes, and files.  SDTH describes lineages of variables and dataframes by linking the instances of data entities with two implicitly ordered phrases: "derived from" and "elaboration of".  

Most other DDI standards, like DDI-Codebook and DDI-Lifecycle, describe data at rest.  These datasets are "files" in SDTH, and a variable described in DDI-Codebook or DDI-Lifecycle is a "variable instance" included in a "file instance" in SDTH.  SDTH describes how "variable instances" and "file instances" are created from earlier "variable instances" and "file instances."
