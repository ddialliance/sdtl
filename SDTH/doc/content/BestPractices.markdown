# Best Practices

1. The SDTH type (i.e., sdth:Program, sdth:ProgramStep, sdth:DataInstance,...) of every entity must be explicitly declared.  
1. If a ProgramStep changes data or metadata, it creates a new DataframeInstance and/or FileInstance
1. If a VariableInstance is not changed by a ProgramStep, it passes to the next DataFrameInstance or FileInstance with the same @id
    - This means that a VariableInstance can exist in more than one DataFrameInstance at the same time.

1. Every Program and ProgramStep must have:
    - @id 
    - hasSourceCode or hasSDTL
1. Every FileInstance must have:
    - @id 
    - hasName
    - loadsFile or savesFile
1. Every DataInstance, DataframeInstance, TextInstance, ImageInstance, and VariableInstance must have:
    - @id 
    - hasName
    - wasDerivedFrom or elaborationOf
1. Every DataframeInstance must have at least one hasVariableInstance
    - A full enumeration of all VariableInstances in a DataframeInstance should always be created whenever a DataframeInstance is loaded from or saved into a FileInstance.
1. wasDerivedFrom is used for ProgramSteps that 
    - change values in a data object 
    - change the number of rows or columns in a data object
    - change the order of rows or columns in a data object
1. elaborationOf is used when metadata associated with a data object changes, but the values do not.  
Examples are:
    - Labels for variables or values
    - Data type
    - Author
    - Title
    - Description
1. A new VariableInstance is created when:
    - One or more values are changed
    - One or more rows are deleted
    - One or more rows are added
    - The order of rows is changed by sorting
    - An attribute of the variable is changed, such as 
        - Data type (numeric, text, etc.)
        - Description
        - Value labels

