SDTL Cut Functions
==================

November 13, 2020

George Alter

Stata, R, and Python include a function called “cut” that is used to
convert a numerical variable into a set of categories. In each of these
languages the “cut” function operates in two different modes, and there
are actually three different modes. For this reason, SDTL has three
different cut functions. The Python Pandas qcut function provides one
mode overlapping with Stata as well as an additional mode.

cut_list( ) -- uses a list of break-points to divide cases into groups 
(Stata egen, R, Python)

cut_range( ) -- divides rows into k groups by dividing the range of the
reference variable into groups of equal widths (R, Python)

cut_freq ( ) -- divides rows into k groups with equal numbers of rows in
each (Stata egen, Python qcut)

cut_quant( ) -- divides rows into groups based on a list of quantile
boundaries (Python qcut)

+-----------------+---------------------------------------------------+--------------+-----------------+
| **cut_list( )** |                                                   |  isRequired  |  defaultValue   |
+-----------------+---------------------------------------------------+--------------+-----------------+
| EXP1            | VariableSymbolExpression for variable used in     |     true     |                 +
|                 | assigning rows to groups                          |              |                 +
+-----------------+---------------------------------------------------+--------------+-----------------+
| EXP2            | ValueListExpression -- list of break-points       |     true     |                 +
+-----------------+---------------------------------------------------+--------------+-----------------+
| EXP3            | “Right” if intervals are closed on the right;     |     false    |   "Right"       +
|                 | “Left” if intervals are closed on the left        |              |                 +
+-----------------+---------------------------------------------------+--------------+-----------------+
| EXP4            | Boolean “True” if EXP3=”Right” and lowest group   |     false    |                 +
|                 | is inclusive on the left.  See R example          |              |                 +
+-----------------+---------------------------------------------------+--------------+-----------------+
| EXP5            | Type of coding:                                   |     false    |   "Left"        +
|                 |                                                   |              |                 +
|                 | “Left” -- Minimum value of group                  |              |                 +
|                 |                                                   |              |                 +
|                 | “Int_code” -- Integer codes are assigned to each  |              |                 +
|                 | group                                             |              |                 +
|                 |                                                   |              |                 +
|                 | Note: Labels assigned to groups are defined in a  |              |                 +
|                 | separate SDTL SetValueLabels command              |              |                 +
+-----------------+---------------------------------------------------+--------------+-----------------+

================================================== ==== ===============
Stata: egen cut1 = cut(varX), at( -999, 3, 9, 999)      
**cut_list( )**                                    EXP1 varX
\                                                  EXP2 -999, 3, 9, 999
\                                                  EXP3 “Left”
\                                                  EXP4 Null
\                                                  EXP5 “Left”
================================================== ==== ===============

+-------------------------------------------+------+-----------------+
| Stata: egen cut1 = cut(varX), at( -999,   |      |                 |
| 3, 9, 999) icodes                         |      |                 |
+-------------------------------------------+------+-----------------+
| **cut_list( )**                           | EXP1 | varX            |
+-------------------------------------------+------+-----------------+
|                                           | EXP2 | -999, 3, 9, 999 |
+-------------------------------------------+------+-----------------+
|                                           | EXP3 | “Left”          |
+-------------------------------------------+------+-----------------+
|                                           | EXP4 | Null            |
+-------------------------------------------+------+-----------------+
|                                           | EXP5 | “Int_code”      |
+-------------------------------------------+------+-----------------+

+-------------------------------------------+------+-----------------+
| R: cut(cdata$varX, c( -999, 3, 9, 999),   |      |                 |
| include_lowest=TRUE )                     |      |                 |
|                                           |      |                 |
| Note: The new variable in R is a factor   |      |                 |
| except when “labels=FALSE” which results  |      |                 |
| in an integer vector of level codes. The  |      |                 |
| resulting variable type should be         |      |                 |
| declared with an SDTL SetDataType         |      |                 |
| command.                                  |      |                 |
|                                           |      |                 |
| R assigns the range of each group as a    |      |                 |
| value label, which should be assigned in  |      |                 |
| a SetValueLabels command.                 |      |                 |
+-------------------------------------------+------+-----------------+
| **cut_list( )**                           | EXP1 | varX            |
+-------------------------------------------+------+-----------------+
|                                           | EXP2 | -999, 3, 9, 999 |
+-------------------------------------------+------+-----------------+
|                                           | EXP3 | “Right”         |
+-------------------------------------------+------+-----------------+
|                                           | EXP4 | “True”          |
+-------------------------------------------+------+-----------------+
|                                           | EXP5 | “Int_code”      |
+-------------------------------------------+------+-----------------+
| {"$type": "SetValueLabels",               |      |                 |
|                                           |      |                 |
| "command": "setValueLabels",              |      |                 |
|                                           |      |                 |
| "variables": [                            |      |                 |
|                                           |      |                 |
| {"$type": "VariableSymbolExpression",     |      |                 |
|                                           |      |                 |
| "variableName": "cut1" }                  |      |                 |
|                                           |      |                 |
| ],                                        |      |                 |
|                                           |      |                 |
| "labels": [                               |      |                 |
|                                           |      |                 |
| {"value": "1", "label": "(-999,3]"},      |      |                 |
|                                           |      |                 |
| {"value": "2", "label": "(3.9]"},         |      |                 |
|                                           |      |                 |
| {"value": "3", "label": "(9,999]"}        |      |                 |
|                                           |      |                 |
| ]                                         |      |                 |
|                                           |      |                 |
| },                                        |      |                 |
+-------------------------------------------+------+-----------------+

+-------------------------------------------+------+-----------------+
| R: cut(cdata$varX, c( -999, 3, 9, 999),   |      |                 |
| right=FALSE )                             |      |                 |
|                                           |      |                 |
| Note: The new variable in R is a factor   |      |                 |
| except when “labels=FALSE” which results  |      |                 |
| in an integer vector of level codes. The  |      |                 |
| resulting variable type should be         |      |                 |
| declared with an SDTL SetDataType         |      |                 |
| command.                                  |      |                 |
+-------------------------------------------+------+-----------------+
| **cut_list( )**                           | EXP1 | varX            |
+-------------------------------------------+------+-----------------+
|                                           | EXP2 | -999, 3, 9, 999 |
+-------------------------------------------+------+-----------------+
|                                           | EXP3 | “Left”          |
+-------------------------------------------+------+-----------------+
|                                           | EXP4 | null            |
+-------------------------------------------+------+-----------------+
|                                           | EXP5 | “Int_code”      |
+-------------------------------------------+------+-----------------+
| {"$type": "SetValueLabels",               |      |                 |
|                                           |      |                 |
| "command": "setValueLabels",              |      |                 |
|                                           |      |                 |
| "variables": [                            |      |                 |
|                                           |      |                 |
| {"$type": "VariableSymbolExpression",     |      |                 |
|                                           |      |                 |
| "variableName": "cut1" }                  |      |                 |
|                                           |      |                 |
| ],                                        |      |                 |
|                                           |      |                 |
| "labels": [                               |      |                 |
|                                           |      |                 |
| {"value": "1", "label": "[-999,3)"},      |      |                 |
|                                           |      |                 |
| {"value": "2", "label": "[3.9)"},         |      |                 |
|                                           |      |                 |
| {"value": "3", "label": "[9,999)"}        |      |                 |
|                                           |      |                 |
| ]                                         |      |                 |
|                                           |      |                 |
| },                                        |      |                 |
+-------------------------------------------+------+-----------------+

+-------------------------------------------+------+-----------------+
| Python (pandas): pd.cut(cdata.varX,       |      |                 |
| [-999, 3, 9, 999], include_lowest=True)   |      |                 |
|                                           |      |                 |
| Note: Pandas assigns the range of each    |      |                 |
| group as a value label. Use the SDTL      |      |                 |
| SetValueLabels command for value labels.  |      |                 |
+-------------------------------------------+------+-----------------+
| **cut_list( )**                           | EXP1 | varX            |
+-------------------------------------------+------+-----------------+
|                                           | EXP2 | -999, 3, 9, 999 |
+-------------------------------------------+------+-----------------+
|                                           | EXP3 | “Right”         |
+-------------------------------------------+------+-----------------+
|                                           | EXP4 | “True”          |
+-------------------------------------------+------+-----------------+
|                                           | EXP5 | “Int_code”      |
+-------------------------------------------+------+-----------------+
| {"$type": "SetValueLabels",               |      |                 |
|                                           |      |                 |
| "command": "setValueLabels",              |      |                 |
|                                           |      |                 |
| "variables": [                            |      |                 |
|                                           |      |                 |
| {"$type": "VariableSymbolExpression",     |      |                 |
|                                           |      |                 |
| "variableName": "cut1d" }                 |      |                 |
|                                           |      |                 |
| ],                                        |      |                 |
|                                           |      |                 |
| "labels": [                               |      |                 |
|                                           |      |                 |
| {"value": "0", "label": "(-999.001,       |      |                 |
| 3.0]"},                                   |      |                 |
|                                           |      |                 |
| {"value": "1", "label": "(3.0, 9.0]"},    |      |                 |
|                                           |      |                 |
| {"value": "2", "label": "(9.0, 999.0]"}   |      |                 |
|                                           |      |                 |
| ]                                         |      |                 |
|                                           |      |                 |
| },                                        |      |                 |
+-------------------------------------------+------+-----------------+

+-------------------------------------------+------+-----------------+
| Python (pandas): pd.cut(cdata.varX,       |      |                 |
| [-999, 3, 9, 999], right=False,           |      |                 |
| labels=['low', 'med', 'hi'] )             |      |                 |
|                                           |      |                 |
| Note: Use the SDTL SetValueLabels command |      |                 |
| for value labels.                         |      |                 |
+-------------------------------------------+------+-----------------+
| **cut_list( )**                           | EXP1 | varX            |
+-------------------------------------------+------+-----------------+
|                                           | EXP2 | -999, 3, 9, 999 |
+-------------------------------------------+------+-----------------+
|                                           | EXP3 | “Left”          |
+-------------------------------------------+------+-----------------+
|                                           | EXP4 | null            |
+-------------------------------------------+------+-----------------+
|                                           | EXP5 | “Int_code”      |
+-------------------------------------------+------+-----------------+
| {"$type": "SetValueLabels",               |      |                 |
|                                           |      |                 |
| "command": "setValueLabels",              |      |                 |
|                                           |      |                 |
| "variables": [                            |      |                 |
|                                           |      |                 |
| {"$type": "VariableSymbolExpression",     |      |                 |
|                                           |      |                 |
| "variableName": "cut1b" }                 |      |                 |
|                                           |      |                 |
| ],                                        |      |                 |
|                                           |      |                 |
| "labels": [                               |      |                 |
|                                           |      |                 |
| {"value": "0", "label": "low"},           |      |                 |
|                                           |      |                 |
| {"value": "1", "label": "med"},           |      |                 |
|                                           |      |                 |
| {"value": "2", "label": "hi"}             |      |                 |
|                                           |      |                 |
| ]                                         |      |                 |
|                                           |      |                 |
| },                                        |      |                 |
+-------------------------------------------+------+-----------------+

+------------------+--------------------------------------------------+--------------+-----------------+
| **cut_range( )** |                                                  |  isRequired  |  defaultValue   |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP1             | VariableSymbolExpression for variable used in    |  true        |                 |
|                  | assigning rows to groups                         |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP2             | Number of groups to create by dividing the range |  true        |                 |
|                  | of EXP1 into equal segments                      |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP3             | “Right” if intervals are closed on the right;    |  false       +   "Right"       |
|                  | “Left” if intervals are closed on the left       |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP4             | Boolean “True” if EXP3=”Right” and lowest group  |  false       |    False        | 
|                  | is inclusive on the left                         |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+

+---------------------------------------------------+------+---------+
| R: cut(cdata$varX, 3, include.lowest = TRUE,      |      |         |
| dig.lab=4)                                        |      |         |
|                                                   |      |         |
| Note: Output of the cut function is a factor.     |      |         |
|                                                   |      |         |
| Default value labels are boundaries of the group, |      |         |
| e.g. “(3.83, 6.67)”, which should be set with the |      |         |
| SetValueLabels command if the values are known.   |      |         |
|                                                   |      |         |
| “dig.lab” sets the number of decimal places shown |      |         |
| in the group label. Since “dig.lab” affects       |      |         |
| labels not data, it affects the SetValueLabels    |      |         |
| command when labels are known.                    |      |         |
+---------------------------------------------------+------+---------+
| **cut_range( )**                                  | EXP1 | varX    |
+---------------------------------------------------+------+---------+
|                                                   | EXP2 | 3       |
+---------------------------------------------------+------+---------+
|                                                   | EXP3 | “Right” |
+---------------------------------------------------+------+---------+
|                                                   | EXP4 |  True   |
+---------------------------------------------------+------+---------+

+----------------------------------------------------+------+--------+
| R: cut(cdata$varX, 3 , right=FALSE,                |      |        |
| labels=c('low', 'med', 'hi'))                      |      |        |
+----------------------------------------------------+------+--------+
| **cut_range( )**                                   | EXP1 | varX   |
+----------------------------------------------------+------+--------+
|                                                    | EXP2 | 3      |
+----------------------------------------------------+------+--------+
|                                                    | EXP3 | “Left” |
+----------------------------------------------------+------+--------+
|                                                    | EXP4 | null   |
+----------------------------------------------------+------+--------+
| {"$type": "SetValueLabels",                        |      |        |
|                                                    |      |        |
| "command": "setValueLabels",                       |      |        |
|                                                    |      |        |
| "variables": [                                     |      |        |
|                                                    |      |        |
| {"$type": "VariableSymbolExpression",              |      |        |
|                                                    |      |        |
| "variableName": "cut2" }                           |      |        |
|                                                    |      |        |
| ],                                                 |      |        |
|                                                    |      |        |
| "labels": [                                        |      |        |
|                                                    |      |        |
| {"value": "1", "label": "low"},                    |      |        |
|                                                    |      |        |
| {"value": "2", "label": "med"},                    |      |        |
|                                                    |      |        |
| {"value": "3", "label": "hi"}                      |      |        |
|                                                    |      |        |
| ]                                                  |      |        |
|                                                    |      |        |
| },                                                 |      |        |
+----------------------------------------------------+------+--------+

+---------------------------------------------------+------+---------+
| Python (pandas): pd.cut(cdata.varX, 3,            |      |         |
| precision=4)                                      |      |         |
|                                                   |      |         |
| Note:                                             |      |         |
|                                                   |      |         |
| Default value labels are boundaries of the group, |      |         |
| e.g. “(0.992, 3.833]”, which should be set with   |      |         |
| the SetValueLabels command if they are known.     |      |         |
|                                                   |      |         |
| “precision” sets the number of decimal places     |      |         |
| shown in the group label. Since “precision”       |      |         |
| affects labels not data, it affects the           |      |         |
| SetValueLabels command when labels are known.     |      |         |
+---------------------------------------------------+------+---------+
| **cut_range( )**                                  | EXP1 | varX    |
+---------------------------------------------------+------+---------+
|                                                   | EXP2 | 3       |
+---------------------------------------------------+------+---------+
|                                                   | EXP3 | “Right” |
+---------------------------------------------------+------+---------+
|                                                   | EXP4 | null    |
+---------------------------------------------------+------+---------+

+---------------------------------------------------+------+---------+
| Python (pandas): pd.cut(cdata.varX, 3,            |      |         |
| labels=False)                                     |      |         |
|                                                   |      |         |
| Note: “labels=False” assigns only integer         |      |         |
| indicators of the bins, instead of labels.        |      |         |
+---------------------------------------------------+------+---------+
| **cut_range( )**                                  | EXP1 | varX    |
+---------------------------------------------------+------+---------+
|                                                   | EXP2 | 3       |
+---------------------------------------------------+------+---------+
|                                                   | EXP3 | “Right” |
+---------------------------------------------------+------+---------+
|                                                   | EXP4 | null    |
+---------------------------------------------------+------+---------+

+------------------+--------------------------------------------------+--------------+-----------------+
| **cut_freq ( )** |                                                  |  isRequired  |  defaultValue   |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP1             | VariableSymbolExpression for variable used in    |  true        |                 |
|                  | assigning rows to groups                         |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP2             | Number of groups with equal numbers of rows in   |  true        |                 |
|                  | each group. Rows are assigned to groups by       |              |                 |
|                  | sorting on EXP1                                  |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP3             | “Right” if intervals are closed on the right;    |  false       |   "Right"       |
|                  | “Left” if intervals are closed on the left       |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP4             | Boolean “True” if EXP3=”Right” and lowest group  |  false       |   False         |
|                  | is inclusive on the left                         |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+

====================================== ==== ======
Stata: egen cut2 = cut(varX), group(3)      
**cut_freq ( )**                       EXP1 varX
\                                      EXP2 3
\                                      EXP3 “Left”
\                                      EXP4 null
====================================== ==== ======

+----------------------------------------------------+------+--------+
| Stata: egen cut2a = cut(varX), group(3) label      |      |        |
|                                                    |      |        |
| Note: “label” creates value labels with the        |      |        |
| left-hand ends of the groups, such as “3.5-”.      |      |        |
| Labels should be set with the SetValueLabels       |      |        |
| command.                                           |      |        |
|                                                    |      |        |
| Since the boundaries of the groups depend on the   |      |        |
| data, a SetValueLabels is not possible.            |      |        |
+----------------------------------------------------+------+--------+
| **cut_freq ( )**                                   | EXP1 | varX   |
+----------------------------------------------------+------+--------+
|                                                    | EXP2 | 3      |
+----------------------------------------------------+------+--------+
|                                                    | EXP3 | “Left” |
+----------------------------------------------------+------+--------+
|                                                    | EXP4 | null   |
+----------------------------------------------------+------+--------+

==================================================== ==== =======
Python (pandas): pd.qcut(cdata.varX, 3)                   
                                                          
Note: The values of cut points depend upon the data.      
**cut_freq ( )**                                     EXP1 varX
\                                                    EXP2 3
\                                                    EXP3 “Right”
\                                                    EXP4 null
==================================================== ==== =======

+------------------+--------------------------------------------------+--------------+-----------------+
| **cut_quant( )** |                                                  |  isRequired  |  defaultValue   |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP1             | VariableSymbolExpression for variable used in    |  true        |                 |
|                  | assigning rows to groups                         |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP2             | ValueListExpression with boundaries of groups    |  true        |                 |
|                  | defined by quantiles, e.g. [0, .25, .75, 1]      |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+
| EXP3             | “Right” if intervals are closed on the right;    |  false       |   "Right"       |
|                  | “Left” if intervals are closed on the left       |              |                 |
+------------------+--------------------------------------------------+--------------+-----------------+

======================================= ==== ==============
Python (pandas): pd.qcut(cdata.varX, 3)      
**cut_quant( )**                        EXP1 varX
\                                       EXP2 [0, .4, .8, 1]
\                                       EXP3 “Right”
======================================= ==== ==============

References
----------

Stata: https://www.stata.com/help.cgi?egen

R:
https://www.rdocumentation.org/packages/base/versions/3.6.2/topics/cut

Python:

pandas.cut
https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.cut.html

pandas.qcut: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.qcut.html
