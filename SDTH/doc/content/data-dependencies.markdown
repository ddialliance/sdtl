# Programs modified by data content

Data transformation programs may include program steps that depend upon the contents of a datafile in complex ways.  We propose ways of handling two common examples of data-dependent programs.

## Iterative operations
Data transformation programs may include iterative operations, where the number of iterations depends upon an aspect of the data such as the number of rows, columns (variables), or unique values of a variable.  

Iterative operations may be described in SDTH by making an iterative loop an sdth:ProgramStep composed of more granular sdth:ProgramSteps.  The more granular sdth:ProgramSteps can treat index variables (sdtl:IteratorSymbolExpressions) created for the duration of the loop as sdth:VariableInstances. sdth:ProgramStep can be nested to describe nested loops.

## Data-dependent variable generation
Programs may create variables during execution that depend upon the content of the data.  A common example is the transformation of a dataset from 'long' to 'wide'.  In a 'long' format, such as the Entity-Attribute-Value model, every row in a dataframe contains only one value per row.  The value in a row is associated with a characteristic of a specific entity (i.e., a person, nation, year, experiment, etc.) by identifier columns (e.g., 'EntityID', 'AttributeID').  In 'long' format each entity has a row for every attribute and multiple rows for every entity.  A 'wide' format dataframe has only one row for each entity and the values of attributes are in separate columns. Thus, when a 'long' format dataframe is transposed to 'wide' format, the identifiers for attributes become variable (column) names. The number of variables in the 'wide' format dataframe depends upon the data values in the 'long' format dataframe.

Example 'long' format dataframe:
| Name       | Attribute   | Value     |
| ---------- | ----------- | --------- |
| Abraham    | Age         | 151       |
| Abraham    | Occupation  | Shepherd  |
| Abraham    | Birthplace  | Ur        |
| Solomon    | Age         | 76        |
| Solomon    | Occupation  | King      |
| Solomon    | Birthplace  | Jerusalem |

Example 'wide' format dataframe:
| Name       | Age    | Occupation  | Birthplace |
| ---------- | ------ | ----------- | ---------- |
| Abraham    | 151    | Shepherd    | Ur         |
| Solomon    | 76     | King        | Jerusalem  |

When the content of input data affects the structure of dataframes and files created by a program, SDTH should be created during the execution of the program.   