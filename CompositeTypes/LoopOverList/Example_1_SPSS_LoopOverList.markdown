```
DO REPEAT existVar=firstVar TO var5
         /newVar=new1 TO new5
         /value=1 TO 5.
COMPUTE newVar=existVar*value.
END REPEAT.
```

```
{"Command": "LoopOverList",
      "sourceInformation": {
         "originalSourceText": "DO REPEAT existVar=firstVar TO var5
							/newVar=new1 TO new5
							/value=1 TO 5.
							COMPUTE newVar=existVar*value.
							END REPEAT."
							},
"Iterators": [
    {"IteratorType": "Variable",
	"IteratorSymbolName": "existVar",
	"IteratorValues":
    {"$type":"VariableRangeExpression",
        "First": "firstVar",
        "Last": "var5"}
	},
    {"IteratorType": "Variable",
	"IteratorSymbolName": "newVar",
	"IteratorValues":
    {"$type": "VariableListExpression",
    "Variables": [
        {"$type":"VariableRangeExpression",
        "First": "new1",
        "Last": "new5"}
        ]
        }
    },
    {"IteratorType": "Numeric",
	"IteratorSymbolName": "value",
	"IteratorValues":
    {"$type": "NumberListExpression",
    "Variables": [
        {"$type":"NumberRangeExpression",
        "From": "1",
        "To": "5",
        "By": "1"}
        ]
        }
    }
    ],
"IteratorCommands:" [
	   {"Command": "compute",
        "VariableName": 
			{"$type": "IteratorSymbolExpression",  "IteratorSymbolName": "newVar"},
        "Expression": 
		{"$type":"FunctionCallExpression",
		   "Function": "Multiplication",
		   "IsSDTLName":"True",
		   "Arguments": [
		   {"ArgumentName": "EXP1",
		   "ArgumentValue": 
				{"$type": "IteratorSymbolExpression",
				"IteratorSymbolName": "existVar"}
				},
		   {"ArgumentName": "EXP2",
		   "ArgumentValue": 
				{"$type": "IteratorSymbolExpression",
				"IteratorSymbolName": "value"}
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