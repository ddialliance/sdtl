SDTL Function Library
=====================

The function library is stored in a JSON file that describes how to
translate functions in various source languages into their SDTL
equivalents.

Functions are frequently used in statistical languages to perform common
calculations. Most functions require at least one parameter or argument
used in the calculation, which may be specified as a variable name or a
constant. Functions are usually specified as a function name followed by
a list of parameters surrounded by parentheses, like “log(x)”.
Parameters may be identified by the order in which they appear, by
preceding the value with a name (e.g. “cut(groups=4)”), or a combination
of position and names.

SDTL uses functions to describe arithmetic operations (addition,
subtraction, etc.) and logical comparisons (“x>y”).

SDTL functions are grouped into four types shown in Table 1.
“Horizontal” functions return a value for each row in a dataframe by
using constants or variables found on the same row. “Vertical” functions
are used in the SDTL Aggregate command, which adds new variables to
every row in a group without changing the number of rows in the
dataframe. The SDTL Collapse command also aggregates across rows, but it
returns only one row per group. Although every function in SDTL has a
unique name, source languages sometimes use the same function name in
more than one way. For example, “mean()” may be used to compute the
average of several variables on each row (horizontal) or to compute the
mean of a single variable across groups of rows (vertical or collapse).

Table 1. SDTL function types

+-------------------------------+-------------------------------------+
| horizontal                    | Horizontal functions perform        |
|                               | actions on one or more variables on |
|                               | each row.                           |
+-------------------------------+-------------------------------------+
| vertical                      | Vertical functions create a new     |
|                               | variable by acting upon multiple    |
|                               | rows in an SDTL **Aggregate**       |
|                               | command. A new variable is added to |
|                               | every row in the dataframe within   |
|                               | groups specified by a               |
|                               | **groupByVariables** property.      |
+-------------------------------+-------------------------------------+
| collapse                      | Collapse functions create a new     |
|                               | variable by acting upon multiple    |
|                               | rows in an SDTL **Collapse**        |
|                               | command. A new dataframe is created |
|                               | with one row per group as defined   |
|                               | by a **groupByVariables** property. |
+-------------------------------+-------------------------------------+
| logical                       | Logical functions are used in       |
|                               | conditions.                         |
+-------------------------------+-------------------------------------+

The Function Library maps the SDTL version of a function to the same
function in various source languages. Table 2 shows the JSON properties
used to describe the SDTL version of a function. The “pseudocode”
property is used to translate an SDTL function into natural language.
For example, the SDTL modulo function is described as “Remainder of EXP1
divided by EXP2”. “EXP1” and “EXP2” are names of parameters that will be
replaced by variable names or values. For example, if “mod(varX,3)” is
found in a source script, the natural language translation will be:
“Remainder of varX divided by 3.” “ReturnType” is the data type of the
result of the function.

Each parameter in the SDTL version of a command is described by three
properties. “Param” is the name of the property in SDTL. For
convenience, we use EXP1, EXP2, etc. for parameter names. The “type” of
an SDTL parameter may be a data type, like numeric or string, or it may
be the type of an element in SDTL. SDTL types VariableListExpression and
ValueListExpression play an important role in the Function Library,
which is discussed below.

Table 2. SDTL properties in the Function Library

+----------------------+----------------------+----------------------+
| SDTLname             | Name of the function |                      |
|                      | in SDTL              |                      |
+----------------------+----------------------+----------------------+
| Pseudocode           | A template for       |                      |
|                      | representing this    |                      |
|                      | function in natural  |                      |
|                      | language             |                      |
+----------------------+----------------------+----------------------+
| definition           | A description of the |                      |
|                      | computation          |                      |
|                      | performed by the     |                      |
|                      | function             |                      |
+----------------------+----------------------+----------------------+
| notes                | Notes about using    |                      |
|                      | the function         |                      |
+----------------------+----------------------+----------------------+
| n_arguments          | Number of parameters |                      |
+----------------------+----------------------+----------------------+
| returnType           | Data type returned   |                      |
|                      | by this function:    |                      |
|                      | numeric, string,     |                      |
|                      | boolean              |                      |
+----------------------+----------------------+----------------------+
| parameters           | Parameters used in   |                      |
|                      | the function. Each   |                      |
|                      | parameter is         |                      |
|                      | described by these   |                      |
|                      | properties:          |                      |
+----------------------+----------------------+----------------------+
|                      | param                | parameter name:      |
|                      |                      | EXP1, EXP2, ...      |
+----------------------+----------------------+----------------------+
|                      | required             | Whether this         |
|                      |                      | parameter must be    |
|                      |                      | present (“yes”,      |
|                      |                      | “no”) or a default   |
|                      |                      | value. The default   |
|                      |                      | value is used when a |
|                      |                      | value of this        |
|                      |                      | parameter is null.   |
+----------------------+----------------------+----------------------+
|                      | type                 | The type may be a    |
|                      |                      | data type (numeric,  |
|                      |                      | string, boolean) or  |
|                      |                      | a class of $types in |
|                      |                      | SDTL                 |
|                      |                      | (ExpressionBase,     |
|                      |                      | Va                   |
|                      |                      | riableReferenceBase, |
|                      |                      | Var                  |
|                      |                      | iableListExpression, |
|                      |                      | ValueListExpression) |
+----------------------+----------------------+----------------------+

The SDTL properties of a function are followed by arrays of source
language functions in each of the supported source languages: SPSS,
Stata, SAS, R, and Python. Every SDTL function may correspond to one or
more functions in each source language. Properties defining a source
language function are shown in Table 3.

+----------------------+----------------------+----------------------+
| Table 3. Properties  |                      |                      |
| of Source Language   |                      |                      |
| function definitions |                      |                      |
| in the Function      |                      |                      |
| Library              |                      |                      |
+----------------------+----------------------+----------------------+
| "function_name"      | Name of the function |                      |
|                      | in the source        |                      |
|                      | language.            |                      |
+----------------------+----------------------+----------------------+
| "syntax"             | Syntax used in the   |                      |
|                      | source language.     |                      |
+----------------------+----------------------+----------------------+
| "URL"                | URL of a description |                      |
|                      | of the function in a |                      |
|                      | source language.     |                      |
+----------------------+----------------------+----------------------+
| "parameters"         | A list of parameters |                      |
|                      | used in the          |                      |
|                      | function. Each       |                      |
|                      | parameter has the    |                      |
|                      | following            |                      |
|                      | properties:          |                      |
+----------------------+----------------------+----------------------+
|                      | required             | This parameter is    |
|                      |                      | required in the      |
|                      |                      | source language:     |
|                      |                      | “yes”, “no”, or      |
|                      |                      | default value. Note  |
|                      |                      | that “true” and      |
|                      |                      | “false” are default  |
|                      |                      | values used for      |
|                      |                      | boolean variables.   |
+----------------------+----------------------+----------------------+
|                      | param                | Name of the          |
|                      |                      | parameter in SDTL:   |
|                      |                      | EXP1, EXP2, … in the |
|                      |                      | order specified in   |
|                      |                      | SDTL.                |
+----------------------+----------------------+----------------------+
|                      | name                 | Name of the          |
|                      |                      | parameter in the     |
|                      |                      | source language.     |
|                      |                      | Omitted or set to    |
|                      |                      | null for parameters  |
|                      |                      | identified by        |
|                      |                      | position only.       |
+----------------------+----------------------+----------------------+
|                      | position             | Position of the      |
|                      |                      | parameter in the     |
|                      |                      | source language. May |
|                      |                      | be omitted or set to |
|                      |                      | null for parameters  |
|                      |                      | identified by name   |
|                      |                      | only.                |
+----------------------+----------------------+----------------------+
|                      | index_offset         | Used with Python to  |
|                      |                      | indicate when the    |
|                      |                      | parameter must be    |
|                      |                      | converted from       |
|                      |                      | 0-indexing to        |
|                      |                      | 1-indexing.          |
+----------------------+----------------------+----------------------+

The name of the function in the source language is given in the
“function_name” property.

The “syntax” and “URL” properties are included as aids to programmers.
We use “syntax” to provide a template for translating the source
language function into its SDTL equivalent, such as “RND(EXP1, EXP2)”.

Parameters used in the source language versions of functions are
described with four properties: “required”, “param”, “name”, “position”.
“Param” is the SDTL name for the parameter (EXP1, EXP2, etc.), which is
used to match it to the SDTL version of the command. The “required”
property describes whether the parameter is required for conversion to
SDTL. When a parameter takes a default value if it is omitted, the
“required” property is set to the default value. Parameters are always
given in the order specified in SDTL (EXP1, EXP2, EXP3…), and the
“position” property is used to show the order in the source language.

Function arguments in source languages may be identified by the order in
which they appear, by name, or both. In Python, parameters to functions
may be identified by position or name, but references by position may
not follow references by name. For example, we can generate a random
number between .5 and .7 using the numpy library of Python with either
“numpy.random.uniform(.5,.7)” or “numpy.random.uniform(low=.5,high=.7)”.

Some functions operate on a list of variables or values, which are
described in SDTL with **VariableListExpression** or
**ValueListExpression**. For example, the Stata command

   egen varAvg =rowmean(varA - var99)

sets varAvg equal to the average of all variables from varA to var99.
The number of variables included in the average depends upon the number
and ordering of variables in the data set. It would be impossible to
specify this function in SDTL if every variable was considered a
parameter. In SDTL a list of variables of any length can be described by
a **VariableListExpression**, which allows us to treat variable lists as
a single parameter in the Function Library.

Table 4 illustrates in tabular form the description of a complicated
function in the R language, which corresponds to the SDTL "str_replace"
function.

-  Note that the order of the parameters in R is different from the
   order in SDTL. We can see this in the “syntax” property, which begins
   “sub(EXP2, EXP3, EXP1, …”. Parameters are given in SDTL order in the
   Function Library, but the “position” properties show that the order
   in R is different.

-  The “required” property shows that EXP4 and EXP5 have default values
   that are used in SDTL when these parameters are omitted in the R
   script.

-  Parameters EXP4 and EXP5 are named properties in R, “ignore.case=”
   and “fixed=” respectively.

-  The syntax field shows that the R function has two parameters
   (“perl=” and “useBytes=”) that are not currently implemented in SDTL.

-  Note that the value “true” for “required” in parameter EXP5 is a
   default value to be used if the “fixed=” parameter is omitted in the
   R script. We use “yes” and “no” as values for “required”, because
   “true” and “false” are used as default values for boolean variables.

Table 4. Example Source Language function definitions

+-----------+-----------+--------+--------+-----------+---------+
| "funct    | “sub”     |        |        |           |         |
| ion_name" |           |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+
| "syntax"  | “         |        |        |           |         |
|           | sub(EXP2, |        |        |           |         |
|           | EXP3,     |        |        |           |         |
|           | EXP1,     |        |        |           |         |
|           | ig        |        |        |           |         |
|           | nore.case |        |        |           |         |
|           | = EXP4,   |        |        |           |         |
|           | perl =    |        |        |           |         |
|           | FALSE,    |        |        |           |         |
|           | fixed =   |        |        |           |         |
|           | EXP5,     |        |        |           |         |
|           | useBytes  |        |        |           |         |
|           | = FALSE)” |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+
| "URL"     | “         |        |        |           |         |
|           | https://w |        |        |           |         |
|           | ww.rdocum |        |        |           |         |
|           | entation. |        |        |           |         |
|           | org/packa |        |        |           |         |
|           | ges/base/ |        |        |           |         |
|           | versions/ |        |        |           |         |
|           | 3.6.2/top |        |        |           |         |
|           | ics/grep” |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+
| "pa       |           |        |        |           |         |
| rameters" |           |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+
| “         | “yes”     | “yes”  | “yes”  | “false”   | “true”  |
| required” |           |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+
| “param”   | “EXP1”    | “EXP2” | “EXP3” | “EXP4”    | “EXP5”  |
+-----------+-----------+--------+--------+-----------+---------+
| “name”    | null      | null   | null   | “ign      | “fixed” |
|           |           |        |        | ore.case” |         |
+-----------+-----------+--------+--------+-----------+---------+
| “         | 3         | 1      | 2      | 4         | 6       |
| position” |           |        |        |           |         |
+-----------+-----------+--------+--------+-----------+---------+

Python differs from the other languages in the way that it refers to
elements in sequences. Python is “0 indexed,” which means that the index
of the first element in a sequence is 0. The other languages use 1 for
the first element in a sequence. In addition, ranges of elements in
Python, such as “4:7”, are inclusive on the left and exclusive on the
right, where other languages are inclusive on both sides. The SDTL
function “substr_by_position” illustrates this difference. Substring is
a common function used to extract part of a larger string. In R
“str_sub("ABCDEFGH", 4,7)” will return the part of the string "ABCDEFGH"
beginning at position 4 and ending at position 7, i.e. “DEFG”. The
equivalent function in Python “str.slice(start=4, stop=7)” returns
“EFG”. In Python the “A” in “ABCDEFGH” is at position 0, which puts “E”
in position 4, and “stop=7” tells Python to exclude the letter at
position 7. We signal this difference in Python by adding an
**index_offset** property that may be used with any parameter in the
Python section of the Function Library.

Example: Random Number Functions in SDTL, SPSS, and Python 
----------------------------------------------------------

.. code:: json

    {
        "horizontal": [
            {
                "SDTLname": "random_variable_uniform",
                "Pseudocode": "random number between EXP1 and EXP2 with a uniform distribution",
                "n_arguments": "2",
                "returnType": "numeric",
                "parameters": [
                    {
                        "param": "EXP1",
                        "required": "YES",
                        "type": "num"
                    },
                    {
                        "param": "EXP2",
                        "required": "YES",
                        "type": "num"
                    }
                ],
                "SPSS": [
                    {
                        "function_name": "RAND_NUM",
                        "syntax": "RAND_NUM(EXP1, EXP2)",
                        "URL": null,
                        "parameters": [
                            {
                                "required": "YES",
                                "param": "EXP1",
                                "name": null,
                                "position": "1"
                            },
                            {
                                "required": "YES",
                                "param": "EXP2",
                                "name": null,
                                "position": "2"
                            }
                        ]
                    },
                    {
                        "function_name": "RV.UNIFORM",
                        "syntax": "RV.UNIFORM(EXP1, EXP2)",
                        "URL": null,
                        "parameters": [
                            {
                                "required": "YES",
                                "param": "EXP1",
                                "name": null,
                                "position": "1"
                            },
                            {
                                "required": "YES",
                                "param": "EXP2",
                                "name": null,
                                "position": "2"
                            }
                        ]
                    }
                ],
                "Python": [
                    {
                        "function_name": "numpy.random.uniform",
                        "syntax": "numpy.random.uniform(low=EXP1, high=EXP2)",
                        "URL": "https://numpy.org/devdocs/reference/random/generated/numpy.random.uniform.html#numpy.random.uniform",
                        "parameters": [
                            {
                                "required": "0",
                                "param": "EXP1",
                                "name": "low",
                                "position": "1"
                            },
                            {
                                "required": "1",
                                "param": "EXP2",
                                "name": "high",
                                "position": "2"
                            }
                        ]
                    }
                ]
            }
        ],
        "vertical": [
            "..."
        ],
        "collapse": [
            "..."
        ],
        "logical": [
            "..."
        ]
    }