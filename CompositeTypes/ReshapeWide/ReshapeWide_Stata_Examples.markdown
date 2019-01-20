Example 1:
``` 
reshape wide inc ue, i(region id) j(year)
 
{"command": "ReshapeWide",
    "MakeItems": [
            "ReshapeItemDescription":
                {"$type": "ReshapeItemDescription",
                "SourceVariableName": "inc",
                "Stub": "inc",
				"IndexVariableName":"year",
                "IndexValues": 
                {"$type":"NumberRangeExpression",
                        "From": "80",
                        "To": "83",
                        "By": "1"}
                    },
            "ReshapeItemDescription":
                {"$type": "ReshapeItemDescription",
                "SourceVariableName": "ue",
                "Stub": "ue",
                "IndexValues": 
                {"$type":"NumberRangeExpression",
                        "From": "80",
                        "To": "83",
                        "By": "1"}
                    }
            ],
    "IDVariables": [ 
                {"$type": "VariableSymbolExpression","VariableName": "region"},
                {"$type": "VariableSymbolExpression","VariableName": "id"}
                ],
        }
```        
    
	   
	   
******************************     
Example 2:
```
Long format             
Centre  MetricTable                 QMetric         Status        Records
PX001   RawCombinedResidencyfile    Starts          legal           50
PX001   RawCombinedResidencyfile    Starts          illegal         10
PX001   RawCombinedResidencyfile    Transitions     legal           57
PX001   RawCombinedResidencyfile    Transitions     illegal         3
PX001   RawCombinedResidencyfile    Ends            legal           60
PX001   RawCombinedResidencyfile    Ends            illegal         0
PX001   RawCombinedResidencyfile    SexValues       legal           60
PX001   RawCombinedResidencyfile    SexValues       illegal         0
PX001   RawCombinedResidencyfile    DoBValues       legal           60
PX001   RawCombinedResidencyfile    DoBValues       illegal         0
                
Wide format             
Centre  MetricTable                 QMetric         Illegal     Legal
PX001   RawCombinedResidencyfile    Starts          10          50
PX001   RawCombinedResidencyfile    Transitions     3           57
PX001   RawCombinedResidencyfile    Ends            0           60
PX001   RawCombinedResidencyfile    SexValues       0           60
PX001   RawCombinedResidencyfile    DoBValues       0           60
```

Stata: reshape wide records, i(Centre MetricTable QMetric) j(Status)

```
{"command":"ReshapeWide",
	"MakeItems":[
		"ReshapeItemDescription":
		{"SourceVariableName":"Records",
			"Stub":"",
			"IndexVariableName":"Status",
			"IndexValues":
			{"$type":"StringListExpression",
				"values":[ "illegal", "legal"]
				}
				}
			],
	"IDVariables":[
		{"$type": "VariableSymbolExpression","VariableName":"Centre"},
		{"$type": "VariableSymbolExpression","VariableName":"MetricTable"},
		{"$type": "VariableSymbolExpression","VariableName":"QMetric"}
		]
	}

```
		
		
