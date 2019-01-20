======== Stata EXAMPLE ===============
```
while `i'<40 {
	gen newvar`i' = runiform()
	local i=`i'+1
	}
```
	
```
{"Command": "LoopWhile",
      "sourceInformation": {
         "originalSourceText": "while `i'<40 {
								gen newvar`i' = runiform()
								local i=`i'+1
								}"
							},
"Condition": 
				{"$type":"FunctionCallExpression",
				"Function": "lt",
				"IsSDTLName":"True",
				"Arguments": [
					{"ArgumentName": "EXP1",
					"ArgumentValue": 
						{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "i"}
					},
					{"ArgumentName": "EXP2",
					"ArgumentValue": 
						{"$type": "NumericConstantExpression",  "Value": "40"}
					}
				]
				},
"IteratorCommands:" [
	   {"Command": "compute",
        "VariableName": 
			{"CompositeVariableName": 
				{"Stub": "newvar",
				 "Postfix": 
					{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "i"}
					}
				},
		"Expression": 
		{"$type":"FunctionCallExpression",
		   "Function": "random_variable_uniform",
		   "IsSDTLName":"True",
		   "Arguments": [
		   {"ArgumentName": "EXP1",
		   "ArgumentValue": 
				{"$type": "NumericConstantExpression",  "Value": "0"},
				},
		   {"ArgumentName": "EXP2",
		   "ArgumentValue": 
				{"$type": "NumericConstantExpression",  "Value": "1"}
			}
			]
		}
		}
    ]

}

```

