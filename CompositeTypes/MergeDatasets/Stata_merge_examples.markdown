```
NOTE:  These Stata Merge options are not represented in SDTL:  
	noreport   
	nolabel   
	nonotes   
	sorted   
```

====================  EXAMPLE 1   ====================================

```
use "mergedat1.dta", clear
merge 1:1 _n using "mergedat4.dta"
list _all

{"command": "MergeDatasets",
    "mergeFiles": [
    "mergeFileDescription":
        {"fileName": "Active file",
        "mergeType": "Sequential",
        "newRow": TRUE,
        "mergeFlagVariable":"_merge"},
    "mergeFileDescription":
        {"fileName": "mergedat4.dta",
        "mergeType": "Sequential",
        "newRow": TRUE}
        ]
    },
{"$type": "SetValueLabels",
	"command": "SetValueLabels",
	"variables": [
			{"$type": "VariableSymbolExpression",
				"variableName", "_merge"}
			],		
	"labels": [
			{"value": 1,	"label": "master"}
			{"value": 2,	"label": "using"}
			{"value": 3,	"label": "match"}
			{"value": 4,	"label": "match_update"}
			{"value": 5,	"label": "match_conflict"}
			]
	}	
``` 
====================  EXAMPLE 2   ====================================
```
use "mergedat1.dta", clear
merge 1:1 id using "mergedat3b.dta" ,  update  gener(matchVar)
list _all

{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"fileName": "Active Dataframe",
        "mergeType": "1:1",
        "update": "Master",
        "mergeFlagVariable":"matchVar",
        "newRow": TRUE},
    "MergeFileDescription":
        {"fileName": "mergedat3c.dta",
        "mergeType": "1:1",
        "update": "UpdateMissing",
        "newRow":TRUE}
        ],      
    "MergeByVariables": {"$type": "VariableSymbolExpression",
                            "VariableName":"id"}
    },
{"$type": "SetValueLabels",
	"command": "SetValueLabels",
	"variables": [
			{"$type": "VariableSymbolExpression",
				"variableName", "matchVar"}
			],		
	"labels": [
			{"value": 1,	"label": "master"}
			{"value": 2,	"label": "using"}
			{"value": 3,	"label": "match"}
			{"value": 4,	"label": "match_update"}
			{"value": 5,	"label": "match_conflict"}
			]
	}
```
====================  EXAMPLE 3   ====================================
``` 
use "mergedat1.dta", clear
merge 1:1 id using "mergedat3b.dta" , update replace  keepusing(lastname) 


{"command": "MergeDatasets",
	"$type": "MergeDatasets",
    "mergeByVariables":{"$type": "VariableSymbolExpression",
                            "variableName":"id"},
    "mergeFiles": [
    "mergeFileDescription":
        {"mileName": "Active file",
        "mergeType": "1:1",
        "update": "UpdateMissing",
        "mergeFlagVariable":"matchVar",
        "newRow":"False"},
    "mergeFileDescription":
        {"fileName": "mergedat3b.dta",
        "mergeType": "1:1",
        "update": "Master",
        "newRow":"True",
        "keepVariables":{"$type": "VariableSymbolExpression",
                            "variableName":"lastname"}
        }
        ]
    },
{"$type": "SetValueLabels",
	"command": "SetValueLabels",
	"variables": [
			{"$type": "VariableSymbolExpression",
				"variableName", "_merge"}
			],		
	"labels": [
			{"value": 1,	"label": "master"}
			{"value": 2,	"label": "using"}
			{"value": 3,	"label": "match"}
			{"value": 4,	"label": "match_update"}
			{"value": 5,	"label": "match_conflict"}
			]
	}
```

