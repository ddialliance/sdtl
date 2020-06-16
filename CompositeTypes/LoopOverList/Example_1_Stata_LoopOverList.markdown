```
foreach partyidk of varlist PARTYID1 PARTYID2 PARTYID3 {
    replace democrats=democrats+1 if `partyidk'==1 
    }

```

```
{"Command": "LoopOverList",
      "sourceInformation": {
         "originalSourceText": "foreach partyidk of varlist PARTYID1 PARTYID2 PARTYID3 {
								replace democrats=democrats+1 if `partyidk'==1 }"
							},
"Iterators": [
		{"IteratorSymbolName": "partyidk",
		"IteratorValues":
			{"$type": "VariableListExpression",
			"Variables": [
				{"$type":"VariableSymbolExpression", "VariableName": "PARTYID1" },
				{"$type":"VariableSymbolExpression", "VariableName": "PARTYID2" },
				{"$type":"VariableSymbolExpression", "VariableName": "PARTYID3" },
				]
			}
	},
    ],
"IteratorCommands:" [
	   {"Command": "compute",
        "VariableName": 
			{"$type": "VariableSymbolExpression",  "VariableName": "democrats"},
		"Expression": 
		{"$type":"FunctionCallExpression",
		   "Function": "Addition",
		   "IsSDTLName":"True",
		   "Arguments": [
				{"ArgumentName": "EXP1",
				"ArgumentValue": 
					{"$type": "VariableSymbolExpression",  "VariableName": "democrats"}
				},
				{"ArgumentName": "EXP2",
				"ArgumentValue": 
						{"$type": "NumericConstantExpression", "Value": "1"}
				}
			]
		},
		"Condition":
			{"FunctionCallExpression":
				{"$type":"FunctionCallExpression",
		   "Function": "eq",
		   "IsSDTLName":"True",
		   "Arguments": [
				{"ArgumentName": "EXP1",
				"ArgumentValue": 
					{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "partyidk"}
				},
				{"ArgumentName": "EXP2",
				"ArgumentValue": 
					{"$type": "NumericConstantExpression", "Value": "1"}
				}
			]
		}
		}
    ],
"Commands":[
********* Commands expanded in SDTL  here ************
	]
}

```	
