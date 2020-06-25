Properties and Options of MergeFileDescription
==============================================
    
+----------------------+----------------------------------------------+
|Property name         | Description                                  |
+======================+==============================================+
| FileName             | The names of the files to be merged.         |
|                      | \"Active file\" means the file current       |
|                      | active dataset.                              |
+----------------------+----------------------------------------------+
|  _                   |                                              | 
+----------------------+----------------------------------------------+
| MergeType            | Describes the type of merge performed.       |
+----------------------+----------------------------------------------+
|                      | > Sequential: Match rows from each input     |
|                      | > dataframe in sequential order.             |
|                      | >                                            |
|                      | > OneToOne: Create one row for each value of |
|                      | > the **mergeByVariables**. If a combination |
|                      | > of the **mergeByVariables** is repeated,   |
|                      | > only one row is matched. Rows with         |
|                      | > repeated combinations of the               |
|                      | > MergeByVariables may or may not be         |
|                      | > included in the output file depending on   |
|                      | > the **newRow** property.                   |
|                      | >                                            |
|                      | > OneToMany: Create a row in the output      |
|                      | > dataframe by matching rows in this         |
|                      | > dataframe to every row in other dataframes |
|                      | > with the same value of MergeByVariables.   |
|                      | > Note that OneToMany implies that one of    |
|                      | > the other input datarames is set to        |
|                      | > ManyToOne.                                 |
|                      | >                                            |
|                      | > ManyToOne: Create a row in the output      |
|                      | > dataframe by matching all rows in this     |
|                      | > dataframe to the one row in the other      |
|                      | > dataframe with the same value of           |
|                      | > MergeByVariables.                          |
|                      | >                                            |
|                      | > Cartesian: Create a new row in the output  |
|                      | > dataframe for every possible combination   |
|                      | > of rows having the same value of           |
|                      | > MergeByVariables. This is equivalent to a  |
|                      | > many to many merge. R and Python use a     |
|                      | > model derived from SQL, which is based on  |
|                      | > Cartesian joins.                           |
|                      | >                                            |
|                      | > Unmatched: Create a new row for every row  |
|                      | > that cannot be matched on the              |
|                      | > MergeByVariables                           |
|                      | >                                            |
|                      | > SASmatchMerge: SAS uses a merging approach |
|                      | > that combines matching keys and sequential |
|                      | > merges within groups.                      |
+----------------------+----------------------------------------------+
| MergeFlagVariable    | Creates a new variable indicating whether    |
|                      | the row came from this file or a different   |
|                      | input file.                                  |
+----------------------+----------------------------------------------+
| RenameVariables      | Variables to be renamed                      |
+----------------------+----------------------------------------------+
| _                    |                                              | 
+----------------------+----------------------------------------------+
| Update               | Describes outcome when a variable exists in  |
|                      | both this file and another file.             |
+----------------------+----------------------------------------------+
|                      | > Master: This dataframe is the Master       |
|                      | > dataframe.                                 |
|                      | >                                            |
|                      | > Ignore: If a column with the same name     |
|                      | > exists in the Master dataframe, ignore the |
|                      | > values in this dataframe.                  |
|                      | >                                            |
|                      | > FillNew: If a column with the same name    |
|                      | > exists in the Master dataframe, use the    |
|                      | > values from this dataframe only in new     |
|                      | > rows created from this dataframe.          |
|                      | >                                            |
|                      | > UpdateMissing: If a column with the same   |
|                      | > name exists in the Master dataframe, use   |
|                      | > values from this dataframe when the value  |
|                      | > in the Master dataframe is missing. Rows   |
|                      | > not in the Master dataframe are filled     |
|                      | > from this dataframe.                       |
|                      | >                                            |
|                      | > Replace: If a column with the same name    |
|                      | > exists in the Master dataframe, use values |
|                      | > from this dataframe.                       |
+----------------------+----------------------------------------------+
| NewRow               | When TRUE, generates a new row when not      |
|                      | matched to other files                       |
+----------------------+----------------------------------------------+
| KeepVariables        | List of variables to keep                    |
+----------------------+----------------------------------------------+
| DropVariables        | List of variables to drop                    |
+----------------------+----------------------------------------------+
| KeepCasesCondition   | Logical condition for keeping rows.          |
+----------------------+----------------------------------------------+
| DropCasesCondition   | Logical condition for dropping rows.         |
+----------------------+----------------------------------------------+
