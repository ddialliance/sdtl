
====================  EXAMPLE 1   ====================================
```
MATCH FILES  
    /FILE='merge_1.sav'
   /file='merge_2.sav'
    .


{"command": "MergeDatasets",
	"$type": "MergeDatasets",
    "MergeFiles": [
    "mergeFileDescription":
        {"fileName": "merge_1.sav",
        "mergeType": "Sequential",
		"newRow": TRUE
        },
    "MergeFileDescription":
        {"fileName": "merge_2.sav",
        "mergeType": "Sequential"
		"newRow": TRUE
        }
        ]
    }
```
    
====================  EXAMPLE 2   ====================================
```
MATCH FILES  
    /FILE='merge_1.sav'
   /in=from_f1
   /file='merge_3.sav'
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
	"$type": "MergeDatasets",
    "mergeByVariables": [ {"$type": "VariableSymbolExpression",
                            "VariableName":"id"}      ],
    "firstVariable": "firstvar",
    "lastVariable": "lastvar",
	"mergeFiles": [
	   "mergeFileDescription":
			{"fileName": "merge_1.sav",
			"mergeType": "OneToOne",
			"mergeFlagVariable":"from_f1",
			"renameVariable":["RenamePair":
				{"OldVariable":"VAR3","NewVariable":"VARx"}  ],
			"newRow": TRUE		
			},
		"mergeFileDescription":
			{"fileName": "merge_3.sav",
			"mergeType": "OneToOne",
			"mergeFlagVariable":"from_f3",
			"newRow": FALSE
			}
        },
{"command": "KeepVariables",
		"$type": "KeepVariables",
		"variables": {"$type": "VariableListExpression",
				"variables":
					[ {"$type": "VariableSymbolExpression",
						"VariableName":"id"},
						{"$type": "VariableSymbolExpression",
						"VariableName":"VAR2"},
						{"$type": "VariableSymbolExpression",
						"VariableName":"VARx"}
						]
					},
		"messageText": "NOTE: This KeepVariables command is after the MergeDatasets command, because it applies to the output dataframe."
		}
  ```