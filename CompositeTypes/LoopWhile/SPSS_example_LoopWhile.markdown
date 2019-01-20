========= SPSS EXAMPLE ================

LOOP IF (Y GT 10). 
COMPUTE X=X+1.
END LOOP IF (X EQ 5). 


```
{"Command": "LoopWhile",
      "sourceInformation": {
         "originalSourceText": "LOOP IF (Y GT 10). 
								COMPUTE X=X+1.
								END LOOP IF (X EQ 5). "
							},
"Condition": 
				{"$type":"FunctionCallExpression",
				"Function": "gt",
				"IsSDTLName":"True",
				"Arguments": [
					{"ArgumentName": "EXP1",
					"ArgumentValue": 
						{"$type": "VariableSymbolExpression",  "VariableName": "Y"}
					},
					{"ArgumentName": "EXP2",
					"ArgumentValue": 
						{"$type": "NumericConstantExpression",  "Value": "10"}
					}
				]
				},
"EndCondition":
				{"$type":"FunctionCallExpression",
				"Function": "eq",
				"IsSDTLName":"True",
				"Arguments": [
					{"ArgumentName": "EXP1",
					"ArgumentValue": 
						{"$type": "VariableSymbolExpression",  "VariableName": "X"}
					},
					{"ArgumentName": "EXP2",
					"ArgumentValue": 
						{"$type": "NumericConstantExpression",  "IteratorSymbolName": "5"}
					}
				]
				},
"IteratorCommands:" [
	   {"Command": "compute",
        "VariableName": 
			{"$type": "VariableSymbolExpression",  "VariableName": "X"},
        "Expression": 
		{"$type":"FunctionCallExpression",
		   "Function": "Addition",
		   "IsSDTLName":"True",
		   "Arguments": [
		   {"ArgumentName": "EXP1",
		   "ArgumentValue": 
				{"$type": "VariableSymbolExpression",  "VariableName": "X"},
				},
		   {"ArgumentName": "EXP2",
		   "ArgumentValue": 
				{"$type": "NumericConstantExpression",  "IteratorSymbolName": "1"}
			}
			]
		}
		}
    ]

}

```




