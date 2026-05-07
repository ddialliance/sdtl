# Inferring Derivations
The central purpose of SDTH is the reconstruction of the lineages of data objects created by program code and scripts for statistical analysis software.  The specifications for sdth:hasDataInstance and sdth:hasVariableInstance above emphasize the importance of enumerating all subsidiary data objects, such as VariableInstances in a DataframeInstance, whenever a new DataInstance is created.  However, it may be impossible to enumerate all data objects if we rely only on a program code or script without information gathered during its execution.  

A Program may not provide enough information to describe the derivation of all of the data objects that it uses and creates.  

- Data objects affected by the execution of a program are often not identified.  For example, when a  DataframeInstance is loaded into memory from a FileInstance, it may include many VariableInstances that are never mentioned in the program. Unidentified VariableInstances will be included in most of the DataframeInstances derived from the original DataframeInstance.  

- When more than one file is loaded, the origins of data objects may be ambiguous.  For example, if two FileInstances are loaded into memory, it may be unclear which FileInstance is the source of a particular DataInstance mentioned later in the Program.  

- Some programming languages allow multiple ways of referring to a variable.  For example, in R a column in a dataframe (i.e., sdth:VariableInstance) may be referenced by name or by column number in a variety of syntaxes.

- In some programming languages, the names of data objects can be assigned dynamically during execution of the program.

- Data objects created or changed during execution of a program may  depend upon data.  When a dataframe is "reshaped" from "long" to "wide", the number of columns in the resulting "wide" dataframe depends upon the data.  A program may include loops or branches depending on logical conditions evaluated during execution that add or delete columns in a dataframe.  

There are several ways to make unmentioned or dynamically created data objects visible, so that they are correctly described in SDTH.

1. A Program can include commands that write lists of data objects to a log file when a Program is executed.  For example, the colnames() function in R lists the names of columns (i.e., variables) in a dataframe in order.  In Python, df.columns.tolist() will create a list of all VariableInstances in a DataframeInstance.  

2. The contents of a FileInstance can be described in a metadata file in a standard format, such as Data Documentation Initiative (DDI) and Ecological Metadata Language (EML).  Most data repositories use a standard metadata language to describe their holdings.

3. In languages that allow multiple ways to reference a data object these references should be resolved to a single SDTH DataInstance with a name (sdth:hasName) in SDTH. For example, a column in a dataframe in R (i.e., an sdth:VariableInstance) may be referenced by its index number or by its name. 

When the available information is incomplete or ambiguous, only derivation relationships that can be made with high confidence should be included SDTH. 