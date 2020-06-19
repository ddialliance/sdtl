Revised: 5 June 2020

This document shows how data with hierarchical indexes (aka data cubes
aka Ncubes aka multi-indexes) may be described in SDTL. Properties have
been included in the SDTL **DataframeDescription** type to describe
hierarchical indexes. SDTL describes data with hierarchical indexes in a
general way intended to facilitate sharing data among different
statistical software applications. Functionality for assuring the
integrity of these indexes must be in the software used to create and
use them. Although operations on hierarchically indexed data often
involve specialized syntax and processing procedures, these operations
can be described by standard SDTL commands.

Data cubes are often used to speed the analysis of large databases. Data
cubes are defined by “dimensions,” which represent attributes used for
classification of the data, and “measures,” which are often aggregations
like counts and means. Although data cubes may have any number of
dimensions, we show below that they can be represented as
two-dimensional data matrices.

The Python language allows dataframes to have multiple hierarchical
indexes -- multi-indexes. In Python both rows and columns can be
multi-indexed, which differs from the Ncube model where only rows have
hierarchical indexes. Some data transformations in Python, notably
aggregation (SDTL **Collapse**), produce dataframes with multi-indexes.

Figure 1 shows a multi-index created by the Python commands:

   fruitprice = prices.groupby(['Fruit', 'Color']).agg( { 'Price' :
   ['mean', 'count'] } )

   fruitprice[ ('Total','sum')] = fruitprice['Price','mean'] \*
   fruitprice['Price','count']

The dataframe produced by these commands has two row dimensions (Fruit,
Color) and two column dimensions (Price, Total).

Figure 1. A multi-index in Python\ |image0|

   |image1|

   Figure 2. Multi-index saved to CSV file

When this dataframe is saved as a CSV file, it is rendered as in Figure
2. Notice that the row dimensions (Fruit, Color) are now columns, and
that “Price” has been added to the column headers for both “mean” and
“count”.

|image2|

Figure 3. Multi-index saved to Stata dta file

When the Python dataframe is saved to a Stata .dta file, we get Figure
3. Since Stata does not allow hierarchical indexes, variables are given
compound names that include both parts of the column index, such as
“Price_mean” and “Price_count”.

This example shows that data with hierarchical indexes can be
represented as rectangular datasets. Row indexes are variables. Column
indexes can be replaced by compound variable names.

Hierarchical indexes do provide additional functionality to languages
like Python. For example, this expression returns only the row where
“Fruit”=”Apple” and “Color”=”Red”:

fruitprice.loc['Apple', 'Red']

We can select the columns “mean” and “count” by referring to the “Price”
index, like this

   Fruit price[ 'Price']

Notice that selection of rows and columns operates differently. Rows are
selected by specifying a value. Columns are selected by using one or
more index names. In other words, as the translation to Stata shows,
column indexes are variable names.

Solutions for SDTL:

1. Syntax for referring to columns in a multi-index

..

   The levels in a column index can be treated as a variable name

   The recommended syntax for combining indexes into variable names is:

   “index1.index2.variablename”.

   Using the example above, the columns would be:

   “Price.mean”, “Price.count”, “Total.sum”

2. Defining hierarchical indexes

..

   Use SDTL element: **DataframeDescription**

   Properties:

i.  **rowDimensions**: an ordered list of variables used as row indexes

ii. **columnDimensions**: an ordered list of variable names created from
       column indexes

..

   The example above would be represented as

   {“$type”: “DataframeDescription”,

   “dataframeName”: “fruitprice”,

   “variableInventory”: [“Price.mean”, “Price.count”, “Total.sum”].

   “rowDimensions”: [“Fruit”, “Color”],

   “columnDimensions”:[“Price”, “Total”]

   }

3. Selecting by row indexes is the same as a selecting using the values
      of variables in an SDTL **IfRows** command

+----------------------+----------------------+----------------------+
| Python syntax        | SPSS                 | SDTL                 |
+======================+======================+======================+
| fru                  | IF (Fruit='Apple')   | { "$type": "IfRows", |
| itprice.loc['Apple', | varX=2.              |                      |
| ('varX')] = 2        |                      | "command": "ifRows", |
|                      |                      |                      |
|                      |                      | "condition": {       |
|                      |                      |                      |
|                      |                      | "$type":             |
|                      |                      | "Func                |
|                      |                      | tionCallExpression", |
|                      |                      |                      |
|                      |                      | "function": "eq",    |
|                      |                      |                      |
|                      |                      | "isSdtlName": true,  |
|                      |                      |                      |
|                      |                      | "arguments": [       |
|                      |                      |                      |
|                      |                      | {type":              |
|                      |                      | "FunctionArgument",  |
|                      |                      |                      |
|                      |                      | "argumentValue": {   |
|                      |                      |                      |
|                      |                      | "$type":             |
|                      |                      | "Variab              |
|                      |                      | leSymbolExpression", |
|                      |                      |                      |
|                      |                      | "variableName":      |
|                      |                      | "Fruit" }            |
|                      |                      |                      |
|                      |                      | },                   |
|                      |                      |                      |
|                      |                      | {type":              |
|                      |                      | "FunctionArgument",  |
|                      |                      |                      |
|                      |                      | "argumentValue": {   |
|                      |                      |                      |
|                      |                      | "$type":             |
|                      |                      | "String              |
|                      |                      | ConstantExpression", |
|                      |                      |                      |
|                      |                      | "value": "Apple" }   |
|                      |                      |                      |
|                      |                      | }                    |
|                      |                      |                      |
|                      |                      | ]                    |
|                      |                      |                      |
|                      |                      | },                   |
|                      |                      |                      |
|                      |                      | "thenCommands": [    |
|                      |                      |                      |
|                      |                      | { type": "Compute",  |
|                      |                      |                      |
|                      |                      | "command":           |
|                      |                      | "compute",           |
|                      |                      |                      |
|                      |                      | "                    |
|                      |                      | originalSourceText": |
|                      |                      | "IF (Fruit='Apple')  |
|                      |                      | varX=2."             |
|                      |                      |                      |
|                      |                      | },                   |
|                      |                      |                      |
|                      |                      | "variable": {type":  |
|                      |                      | "Variab              |
|                      |                      | leSymbolExpression", |
|                      |                      |                      |
|                      |                      | "variableName":      |
|                      |                      | "varX" },            |
|                      |                      |                      |
|                      |                      | "expression": {      |
|                      |                      | type":               |
|                      |                      | "Numeric             |
|                      |                      | ConstantExpression", |
|                      |                      |                      |
|                      |                      | "value": "2",        |
|                      |                      |                      |
|                      |                      | "numericType": "int" |
|                      |                      | }                    |
|                      |                      |                      |
|                      |                      | }                    |
|                      |                      |                      |
|                      |                      | ]                    |
|                      |                      |                      |
|                      |                      | }                    |
+----------------------+----------------------+----------------------+

4. Selecting columns is the same as a **VariableRange** expression in
      SDTL

+----------------------+----------------------+----------------------+
| Python syntax        | SPSS                 | SDTL                 |
+======================+======================+======================+
| fruitprice[ 'Price'] | Price_mean to        | {type":              |
|                      | Price_count          | "Varia               |
|                      |                      | bleRangeExpression", |
|                      |                      |                      |
|                      |                      | "first":             |
|                      |                      | "Price.mean",        |
|                      |                      |                      |
|                      |                      | "last":              |
|                      |                      | "Price.count"        |
|                      |                      |                      |
|                      |                      | }                    |
+----------------------+----------------------+----------------------+

.. |image0| image:: media/image1.png
   :width: 3.11458in
   :height: 1.48958in
.. |image1| image:: media/image3.png
   :width: 3.34375in
   :height: 1.67708in
.. |image2| image:: media/image2.png
   :width: 6.5in
   :height: 1.48611in
