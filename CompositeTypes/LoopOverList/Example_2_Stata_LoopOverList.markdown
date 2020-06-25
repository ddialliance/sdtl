```
forvalues k = 0/9  {
   replace idealfam=`k' if `k'==chldidel
    }

```

```
{"Command": "LoopOverList",
      "sourceInformation": {
         "originalSourceText": "forvalues k = 0/9  {
								replace idealfam=`k' if `k'==chldidel }"
							},
"Iterators": [
		{"IteratorSymbolName": "k",
		"IteratorValues":
			{"$type": "NumberRangeExpression",
				"From": "0",
				"To": "9",
				"By": "1"
			}
	},
    ],
"IteratorCommands:" [
	   {"Command": "compute",
        "VariableName": 
			{"$type": "VariableSymbolExpression",  "VariableName": "idealfam"},
		"Expression": 
			{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "k"}
		},
		"Condition":
				{"$type":"FunctionCallExpression",
				"Function": "eq",
				"IsSDTLName":"True",
				"Arguments": [
					{"ArgumentName": "EXP1",
					"ArgumentValue": 
						{"$type": "VariableSymbolExpression",  "VariableName": "chldidel"}
					},
					{"ArgumentName": "EXP2",
					"ArgumentValue": 
						{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "k"}
					}
				]
				}
			
    ],
"Commands":[
********* Commands expanded in SDTL  here ************
	]
}

```	
