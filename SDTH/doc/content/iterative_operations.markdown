# Iterative operations

Data transformation programs may include iterative operations, where the number of iterations depends upon an aspect of the data such as the number of rows, columns (variables), or unique values of a variable.  

Iterative operations may be described in SDTH by making an iterative loop an sdth:ProgramStep composed of more granular sdth:ProgramSteps.  The more granular sdth:ProgramSteps can treat index variables (sdtl:IteratorSymbolExpressions) created for the duration of the loop as sdth:VariableInstances. sdth:ProgramStep can be nested to describe nested loops.
