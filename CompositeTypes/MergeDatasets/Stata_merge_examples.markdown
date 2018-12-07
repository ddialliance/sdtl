====================  EXAMPLE 1   ====================================

```
use "mergedat1.dta", clear
merge 1:1 _n using "mergedat4.dta"
list _all

{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"FileName": "Active file",
        "MergeType": "sequential",
        "Overlap": "master",
        "MergeFlagVariable":"_merge"},
    "MergeFileDescription":
        {"FileName": "mergedat4.dta",
        "MergeType": "sequential",
        "Overlap": "merge"}
        ]
    }
``` 
====================  EXAMPLE 2   ====================================
```
use "mergedat1.dta", clear
drop if id==3
merge 1:1 id using "mergedat3c.dta" ,  update  assert(match using match_conflict) gener(matchVar)
list _all

{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"FileName": "Active file",
        "MergeType": "1:1",
        "Overlap": "update",
        "MergeFlagVariable":"matchVar",
        "NewRow":"False"},
    "MergeFileDescription":
        {"FileName": "mergedat3c.dta",
        "MergeType": "1:1",
        "Overlap": "merge",
        "NewRow":"True"}
        ],      
    "MergeByVariables": {"$type": "VariableSymbolExpression",
                            "VariableName":"id"}
    }
```
====================  EXAMPLE 3   ====================================
``` 
use "mergedat1.dta", clear
drop if id==2
merge 1:1 id using "mergedat3b.dta" , update replace assert(using match match_update) keepusing(var4) 


{"command": "MergeDatasets",
    "MergeFiles": [
    "MergeFileDescription":
        {"FileName": "Active file",
        "MergeType": "1:1",
        "Overlap": "merge",
        "MergeFlagVariable":"matchVar",
        "NewRow":"False"},
    "MergeFileDescription":
        {"FileName": "mergedat3b.dta",
        "MergeType": "1:1",
        "Overlap": "master",
        "NewRow":"True",
        "KeepVariables":{"$type": "VariableSymbolExpression",
                            "VariableName":"var4"}
        }
        ],
    "MergeByVariables":{"$type": "VariableSymbolExpression",
                            "VariableName":"id"}
    }
```

