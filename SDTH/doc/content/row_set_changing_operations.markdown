##Row-set-changing operations
A row-set-changing operation is any operation that changes the number of rows, identity of rows, or order of rows for every variable in a dataframe. This includes, but is not limited to, filtering rows, selecting cases, dropping rows, adding rows, sorting rows, deduplicating rows, joins/merges that add or remove rows, sampling rows, and aggregations/collapses.
For every row-set-changing operation:

  - A new sdth:DataframeInstance MUST be minted for the output dataframe.
  - A new sdth:VariableInstance MUST be minted for every column present in the output dataframe, even if the column’s name and apparent values are otherwise unchanged.
  - The output sdth:DataframeInstance MUST enumerate all of its output variables using sdth:hasVariableInstance.
  - Each new output sdth:VariableInstance MUST have sdth:hasName equal to the corresponding output column name.
  - Each new output sdth:VariableInstance MUST be linked with sdth:wasDerivedFrom to the prior sdth:VariableInstance for the same logical column in the input dataframe.
  - The sdth:ProgramStep MUST use sdth:consumesData for the input dataframe and sdth:producesData for the output dataframe.
  - The sdth:ProgramStep MUST use sdth:assignsVariable for every newly minted output sdth:VariableInstance.
  - The sdth:ProgramStep MUST use sdth:usesVariable for every variable referenced in the row-selection, sorting, joining, grouping, or other row-set-changing expression.
  - **Previous sdth:VariableInstances MUST NOT be reused as members of the new output sdth:DataframeInstance after a row-set-changing operation.**