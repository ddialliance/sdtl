# Best Practices

1. If a ProgramStep changes data or metadata, it creates a new DataframeInstance and/or FileInstance
2. If a VariableInstance is not changed by a ProgramStep, it passes to the next DataFrameInstance or FileInstance with the same @id
    - This means that a VariableInstance can exist in more than one DataFrameInstance at the same time.

3. Every Program and ProgramStep should have:
    - @id 
    - hasSourceCode or hasSDTL
4. Every FileInstance, DataframeInstance, and VariableInstance should have:
    - @id 
    - hasName
    - wasDerivedFrom or elaborationOf
5. Every DataframeInstance and FileInstance should have at least one hasVariableInstance
6. wasDerivedFrom is used for ProgramSteps that 
    - change values in a data object 
    - change the number of rows or columns in a data object
    - change the order of rows or columns in a data object
7. elaborationOf is used when metadata associated with a data object changes, but the values do not.  
Examples are:
    - Labels for variables or values
    - Data type
    - Author
    - Title
    - Description
8. A VariableInstance is an ordered set of data points
    - The order of data points is important, because operations on dataframes often use data points from preceding (lag) or following (lead) rows 
9. A new VariableInstance is created when:
    - One or more values are changed
    - One or more rows are deleted
    - One or more rows are added
    - The order of rows is changed by sorting
    - An attribute of the variable is changed, such as 
        - Data type (numeric, text, etc.)
        - Description
        - Value labels

