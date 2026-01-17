# Overview of SDTH

In the spirit of PROV, SDTH has a small number of elements. (See Figure 1.) SDTH includes only eight entities: two entities to describe programs (Program and ProgramStep), a generic entity to describe data stored externally (FileInstance), a generic entity to describe data (DataInstance), and four specializations of DataInstance (DataframeInstance, VariableInstance, TextInstance, and ImageInstance).  DataInstances may exist only in computer memory during the execution of a Program, or they may be saved to a FileInstance for storage and reuse.  FileInstances are persistent data objects that reside on external media.  The DataInstances in a FileInstance are loaded into memory to be acted on by a Program.  

ProgramSteps act upon data entities, and a ProgramStep has both input and output data entities.  Each type of data entity has a pair of predicates describing its role in a ProgramStep: loadsFile/savesFile, consumesData/producesData, usesVariable/assignsVariable.  

DataInstance describes any data object residing in memory or in a file. Since the focus of SDTH is statistical analysis, we have added subclasses of DataInstance for the most common data structures used in statistical computing. A DataFrameInstance is a rectangular data matrix consisting of rows and columns. A VariableInstance is a column of values in a DataFrameInstance. A ProgramStep may change only one of the VariableInstances in a DataFrameInstance, or it may change all of VariableInstances at the same time.  As their names imply, TextInstance and ImageInstance are data objects intended for output to a human-readable device. Other data structures (e.g., lists, arrays, datacubes, dictionaries) are described as DataInstances in SDTH. Additional subclasses of DataInstance can be defined to describe data structures used in other types of computing.  

Every SDTH entity is connected to the original source code by an object property.  We use hasSourceCode and hasSDTL to link a Program or ProgramStep to the source code in its original language or in SDTL.  Data entities are linked to data objects in the source code by the hasName property.

SDTH was designed to trace the lineages of data entities. There are two ways that a new instance of a data entity may be related to an earlier instance.  When any of the data values in the new instance are different from the previous instance, they are related by the wasDerivedFrom predicate.  If the data values are exactly the same but metadata, such as a data format or label, has changed, we use the elaborationOf predicate.  As noted above, SDTH does not capture the order of ProgramSteps, but this order is implicit in the derivation and elaboration relationships between data instances.  


<figure id="sdth-relationships">
  <img src="assets\sdth_diagram.png" alt="sdth relationships" />
  <figcaption>Elements of SDTH</figcaption>
</figure>

Figure 1 is a simplified diagram of the elements of SDTH.  Readers should note that VariableInstance, DataframeInstance, TextInstance, and ImageInstance are all subclasses of DataInstance.  All of the properties associated with DataInstance can be applied to its subclasses.  For example, a VariableInstance can be derivedFrom another VariableInstance.
