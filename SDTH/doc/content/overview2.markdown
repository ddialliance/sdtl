# Overview of SDTH

In the spirit of PROV, SDTH has a small number of elements.  SDTH includes only eight entities: two entities to describe programs (Program and ProgramStep), two entities to describe data (FileInstance and DataInstance), and four specializations of DataInstance (DataframeInstance, VariableInstance, TextInstance, and ImageInstance).  FileInstances are persistent data objects that reside on external media.  DataInstances exist only in computer memory, and they disappear at the end of a Program.  FileInstances are loaded into memory as DataInstances to be acted on by a Program, and DataInstances are saved to FileInstances for persistent storage. 

ProgramSteps act upon data entities, and a ProgramStep has both input and output data entities.  Each type of data entity has a pair of predicates describing its role in a ProgramStep: loadsFile/savesFile, consumesData/producesData, usesVariable/assignsVariable. 

DataInstance describes any data object residing in memory, but we have added subclasses of DataInstance for the special cases of statistical computing and data analysis. A DataFrameInstance is a rectangular data matrix consisting of rows and columns which is used in most statistical analysis. A VariableInstance is a column of values in a DataFrameInstance. A ProgramStep may change only one of the VariableInstances in a DataFrameInstance, or it may change all of VariableInstances at the same time.

As their names imply, TextInstance and ImageInstance are data objects intended for output to a human-readable device. 

Every SDTH entity is connected to the original source code by an object property.  We use hasSourceCode and hasSDTL to link a Program or ProgramStep to the source code in its original language or in SDTL.  Data entities are linked to data objects in the source code by the hasName property.

SDTH was designed to trace the lineages of data entities. There are two ways that a new instance of a data entity may be related to an earlier instance.  When any of the data values in the new instance are different from the previous instance, they are related by the wasDerivedFrom predicate.  If the data values are exactly the same but metadata, such as a data format or label, has changed, we use the elaborationOf predicate.  As noted above, SDTH does not capture the order of ProgramSteps, but theis order is implicit in the derivation and elaboration relationships between data instances.  
