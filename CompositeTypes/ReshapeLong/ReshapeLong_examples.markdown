=========  SPSS Example =================
```
varstocases 
 /make name "Full Name" from named namem
 /make income from incd incm
 /index dadmom "Parent" 
 /id=id1
 /drop= var88 to var99
 /null= KEEP
 /count= casecount "Number of rows from original case" .
 
{"command": "ReshapeLong",
    "MakeItems": [
            "ReshapeItemDescription":
                {"TargetVariableName": "name",
                "TargetVariableLabel": "Full Name",
                "SourceVariables": 
                    {"$type": "VariableListExpression",
                    "Variables": [
                        {"$type": "VariableSymbolExpression", "VariableName": "named"},
                        {"$type": "VariableSymbolExpression", "VariableName": "namem"}
                        ]   },
                "IndexVariable": "dadmom",
                "IndexVariableLabel": "Parent"},
            "ReshapeItemDescription":
                {"TargetVariable": "income",
                "SourceVariables": 
                    {"$type": "VariableListExpression",
                    "Variables": [
                        {"$type": "VariableSymbolExpression", "VariableName": "incd"},
                        {"$type": "VariableSymbolExpression", "VariableName": "incm"}
                        ]   },
            "IndexVariable": "dadmom"}
            ],
    "CaseNumberVariable":"id1",
     "DropVariables": [
                    {"$type": "VariableRangeExpression",
                    "First":"var88",
                    "Last":"var99"}
                    ],
    "KeepNullCases":"True",
    "CountByID": "casecount",
    "CountByIDLabel": "Number of rows from original case"
    }
```        
============  Stata Example 1 ==================
```                            
 
reshape long inc ue, i(region id) j(year)
 
{"command": "ReshapeLong",
    "MakeItems": [
            "ReshapeItemDescription":
                {"TargetVariableName": "inc",
                "Stub": "inc",
                "IndexVariableName": "year"},
            "ReshapeItemDescription":
                {"TargetVariableName": "ue",
                "Stub": "ue",
                "IndexVariableName": "year"}
            ],
    "IDVariables": [ 
                {"$type": "VariableSymbolExpression","VariableName": "region"},
                {"$type": "VariableSymbolExpression","VariableName": "id"}
                ]
        }
```        


============  Stata Example 2 ==================
```                            
reshape long inc, i(id) j(sex "male" "female") string
 
 {"command": "ReshapeLong",
    "MakeItems": [
            "ReshapeItemDescription":
                {"TargetVariableName": "inc",
                "Stub": "inc",
                "IndexVariableName": "sex",
                "IndexValues": [
                    {"$type":"StringListExpression",
                        "Values": [
                            {"$type": "StringConstantExpression", "Value": "male"},
                            {"$type": "StringConstantExpression", "Value": "female"}
                            ]
                        }
                    ],
                }
            ],
    "IDVariables": [ 
                {"$type": "VariableSymbolExpression","VariableName": "region"},
                {"$type": "VariableSymbolExpression","VariableName": "id"}
                ]
        }
