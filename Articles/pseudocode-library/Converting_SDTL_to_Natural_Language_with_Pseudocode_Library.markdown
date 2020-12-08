Converting SDTL to Natural Language Using the Pseudocode Library
================================================================

George Alter

June 27, 2020

This document gives a step by step example of converting SDTL to human
readable text using the Pseudocode Library. The Pseudocode Library
consists of templates for SDTL types showing how to embed the values of
SDTL properties into explanatory text. Property names are specified with
curly brackets, like {variableName}. Since SDTL types may be nested
inside other types, the replacement process begins with the innermost
type and moves outward.

Step 0. SDTL for a Stata command

Source code in Stata:

recode fam\_size (0/3=1 \"Small\") (4/max=9 \"Large\") ,
gener(fam\_groups)

SDTL:
```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {
      "source" : "fam_size",
      "target" : "fam_groups"
    } ],
    "rules" : [ 
      {"$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "numberRangeStart" : {
          "$type" : "NumericConstantExpression",
          "value" : 0
        },
        "NumberRangeEnd" : {
          "$type" : "NumericConstantExpression",
          "value" : 3
        },        
      "to" : {
        "$type" : "NumericConstantExpression",
        "Value" : 1
      },
      "label" : "Small"    }, 
      {"$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "numberRangeStart" : {
          "$type" : "NumericConstantExpression",
          "value" : 4
        },
        "numberRangeEnd" : {
          "$type" : "NumericMaximumValueExpression"
        },        
      "to" : {
        "$type" : "NumericConstantExpression",
        "value" : 9
      },
      "label" : "Large"  }
      ],
```


Step 1. Replace NumericConstantExpression

Pseudocode Template for NumericConstantExpression: "{value}"

```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {
      "source" : "fam_size",
      "target" : "fam_groups"
    } ],
    "rules" : [ {
      "$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "NumberRangeStart" : {0},
        "NumberRangeEnd" : {3},        
      "to" : {1},
      "label" : "Small"      }, 
      {"$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "numberRangeStart" : {4},
        "numberRangeEnd" : {
          "$type" : "NumericMaximumValueExpression"
        },        
      "to" : {9},
      "label" : "Large"  }
    ]
```

Step 2. Replace NumericMaximumValueExpression

Pseudocode Template for NumericMaximumValueExpression "the highest
value"

```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {
      "source" : "fam_size",
      "target" : "fam_groups"
    } ],
    "rules" : [ {
      "$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "NumberRangeStart" : {0},
        "NumberRangeEnd" : {3},        
      "to" : {1},
      "label" : "Small"   }, 
      {"$type" : "RecodeRule",
      "fromValue" : {
        "$type" : "NumberRangeExpression",
        "numberRangeStart" : {4},
        "numberRangeEnd" : {“the highest value”} ,        
      "to" : {9},
      "label" : "Large"    }
       ]
```

Step 3. Replace NumberRangeExpression

Pseudocode Template for NumberRangeExpression "from {numberRangeStart}
to {numberRangeEnd}"

```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {
      "source" : "fam_size",
      "target" : "fam_groups"
    } ],
    "rules" : [ 
      {"$type" : "RecodeRule",
      "fromValue" : {“from 0 to 3”},        
      "to" : {1},
      "label" : "Small"    }, 
      {"$type" : "RecodeRule",
      "fromValue" : {“from 4 to the highest value” },        
      "to" : {9},
      "label" : "Large"    }
	 ]
```

Step 4. Replace RecodeRule

Pseudocode Template for RecodeRule "change values {fromValue} to
{toValue} with label {label}"


```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {
      "source" : "fam_size",
      "target" : "fam_groups"
    } ],
    "rules" : [ {“change values from 0 to 3 to 1 with label Small”}, 
	{“change values from 4 to the highest value to 9 with label Large” } ]
```

Step 5. Replace RecodeVariable

Pseudocode Template for RecodeVariable "{source} into {target}"

Note: The \$type tag is not used for RecodeVariable in the Recode
command, because the recodedVariable property must be a RecodeVariable
type.

```
"$type" : "Recode",
    "command" : "recode",
    "recodedVariables" : [ {“fam_size into fam_groups”} ],
    "rules" : [ {“change values from 0 to 3 to 1 with label Small”}, 
	{“change values from 4 to the highest value to 9 with label Large” } ]

```

Step 6. Replace Recode

Pseudocode Template for Recode "Recode these variables:
{recodedVariables} using rule {rules}"

```
Recode these variables:  
	fam_size into fam_groups using rule 
		change values from 0 to 3 to 1 with label Small, 
		change values from 4 to the highest value to 9 with label Large
```
