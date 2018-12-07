
====================  EXAMPLE 1   ====================================
```
MATCH FILES  
    /FILE='merge_1.sav'
   /file='merge_2.sav'
    .


{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"FileName": "merge_1.sav",
        "MergeType": "sequential"
        },
    "MergeFileDescription":
        {"FileName": "merge_2.sav",
        "MergeType": "sequential"
        }
        ]
    }
```
    
====================  EXAMPLE 2   ====================================
```
MATCH FILES  
    /FILE='merge_1.sav'
   /in=from_f1
   /file='merge_4.sav'
   /in=from_f3
   /RENAME= (VAR3=VARx)
   /KEEP= id VAR2 VARx
   /by id
   /first=firstvar
   /last=lastvar
  .
```

```
  
{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"FileName": "merge_1.sav",
        "MergeType": "1:1 duplicates unmatched",
        "MergeFlagVariable":"from_f1",
        {"RenamePair":
            {"OldVariable":"VAR3","NewVariable":"VARx"}
            }
        },
    "MergeFileDescription":
        {"FileName": "merge_2.sav",
        "MergeType": "1:1 duplicates unmatched",
        "MergeFlagVariable":"from_f3",
        },
    "MergeByVariables": {"$type": "VariableSymbolExpression",
                            "VariableName":"id"}
        ],
    "FirstVariable": "firstvar",
    "LastVariable": "lastvar",
    "KeepVariables": {"$type": "VariableListExpression",
                        "Variables":
                        [ {"$type": "VariableSymbolExpression",
                            "VariableName":"id"},
                            {"$type": "VariableSymbolExpression",
                            "VariableName":"VAR2"},
                            {"$type": "VariableSymbolExpression",
                            "VariableName":"VARx"}
                            ] }
        }
  ```