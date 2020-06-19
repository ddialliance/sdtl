**Collapse: Handling of Non-numeric Variables**

George Alter

May 18, 2020

1. Stata

   a. The Stata Collapse command only accepts numeric variables

   b. If a non-numeric variable is in a variable list, Stata generates a
      “type mismatch” error, even if the statistic to be generated does
      not require a numeric variable (e.g. Count).

2. SPSS

   a. In SPSS only the SUM, MEAN, and SD aggregation functions require
      numeric variables

   b. SPSS produces an error when a function requiring a numeric
      variable is applied to a text variable:

..

   >Error # 10938. Command name: AGGREGATE

   >A function which requires a numeric variable has been used with a
   string

   >variable.

   >Execution of this command stops.

   >Existing variable txt1 caused the error.

3. SAS

   a. Proc MEAN is used for aggreration in SAS

   b. If a text variable is explicitly included in a variable list for a
      numeric function, Proc Mean will display an error.

   c. If a text variable is in a variable range, Proc Mean will ignore
      it and only process the numeric variables

   d. 

4. R

   a. If a text variable is included with a numeric function, R issues a
      warning and sets the result to NA

..

   > cdata %>% summarize_at( vars(num1, txt1, num2), mean )

   # A tibble: 1 x 3

   num1 txt1 num2

   <dbl> <dbl> <dbl>

   1 0.35 NA 350

   Warning message:

   In mean.default(txt1) : argument is not numeric or logical: returning
   NA

5. Python

   a. The Pandas “Dataframe.aggregate” command operates on both numeric
      and text variables.

   b. If the aggregate function is numeric, “aggregate” ignores text
      variables without generating a warning.
