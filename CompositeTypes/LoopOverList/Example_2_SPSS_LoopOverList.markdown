```
LOOP #I=1 TO 5 IF (Y GT 10). 
COMPUTE X=X+1.
END LOOP.

```

```
{"Command": "LoopOverList",
      "sourceInformation": {
         "originalSourceText": "LOOP #I=1 TO 5 IF (Y GT 10). 
								COMPUTE X=X+1.
								END LOOP."
							},
"Iterators": [
    {"IteratorType": "Numeric",
	"IteratorSymbolName": "#I",
	"IteratorValues":
    {"$type": "NumberListExpression",
    "Values": [
        {"$type":"NumberRangeExpression",
        "From": "1",
        "To": "5",
        "By": "1"}
        ]
        }
    }
    ],
"IteratorCommands:" [
		{"Command": "DoIf",
		"Condition":
		{"$type":"FunctionCallExpression",
		   "Function": "gt",
		   "IsSDTLName":"True",
		   "Arguments": [
		   {"ArgumentName": "EXP1",
		   "ArgumentValue": 
				{""$type": "VariableSymbolExpression",  "VariableName": "Y"}
				},
		   {"ArgumentName": "EXP2",
		   "ArgumentValue": 
				{"$type": "NumericConstantExpression",
				"Value": "10"}
					}
					]	
		"Commands": [

	   {"Command": "compute",
        "VariableName": 
			{"$type": "VariableSymbolExpression",  "VariableName": "X"},
      "expression": 
		{"$type":"FunctionCallExpression",
		   "Function": "Addition",
		   "IsSDTLName":"True",
		   "Arguments": [
		   {"ArgumentName": "EXP1",
		   "ArgumentValue": 
				{""$type": "VariableSymbolExpression",  "VariableName": "X"}
				},
		   {"ArgumentName": "EXP2",
		   "ArgumentValue": 
				{"$type": "NumericConstantExpression",
				"Value": "1"}
			}
			]
		}
		}
		]

		],
"Commands":[
********* Commands expanded in SDTL  here ************
	]
}

```