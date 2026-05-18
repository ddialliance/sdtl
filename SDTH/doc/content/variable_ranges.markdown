# Variable Ranges

Some programming and statistical languages treat variable names as an ordered list, which allows operations on a group of consecutive variables by referencing the first and last variables in the group. For example, in Stata the command 'drop Var04-VarAA' will delete Var04, VarAA, and all of the columns between them.  The same command in Python is 'df = df.drop( list(df.loc[:, "Var04":"VarAA"]), axis=1 )'.  

SDTH does not recognize the order of columns in a dataframe.  Consequently, variable ranges in program code MUST be converted to fully enumerated lists of variables in SDTH.