```
SET MXLOOPS 10
LOOP . 
COMPUTE X=X+1.
END LOOP.

```

```
{"Command": "LoopOverList",
      "sourceInformation": {
         "originalSourceText": "SET MXLOOPS 10
								LOOP . 
								COMPUTE X=X+1.
								END LOOP."
							},
"Iterators": [
    {"IteratorSymbolName": "",
	"IteratorValues":
    {"$type":"NumberRangeExpression",
        "From": "1",
        "To": "10",
        "By": "1"}
    }
    ],
"IteratorCommands:" [
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
		],
"Commands":[
********* Commands expanded in SDTL  here ************
	]
}

```