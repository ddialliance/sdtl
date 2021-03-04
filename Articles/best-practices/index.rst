SDTL Best Practices and Conventions
===================================

This section provides information on best practices for using SDTL.

1. **“$type” and “command” properties.** Commands and other items in
   SDTL are usually identified by the “$type” property. There are two
   important exceptions.

   a. Both “$type” and “command” are required in CommandBase. SDTL
      commands in CommandBase inherit the “command” property, which
      gives the name of the SDTL command. Even though the command name
      is also given in the “$type” property, both “$type” and “command”
      are required. This redundancy is due to a limitation in JSON, and
      it is needed to be sure that SDTL JSON is rendered correctly in
      other formats, such as XML.     

   b. Command names should be spelled the same way in both "$type" 
      and "command" properties, including capitalization.  
   
   c. “$type” can be omitted when only one SDTL type is allowed. A
      number of SDTL types are used to specify complex properties of
      commands. If only one SDTL type can be used in a property, “$type”
      may be omitted. For example, the Rename command has a property
      called “renames” which is an array of “RenamePair”. Since only a
      “RenamePair” can be used in a “Rename.renames” property, the
      “$type”: “RenamePair” may be omitted.

2. **Execute**. Some statistical packages require an explicit command to
   “execute” or “run” a group of commands. Execute is included in SDTL
   for information, but it has no functions at this time.

3. **Data Types and Formats.** SDTL does not have a feature for setting
   default data types and display formats. The SetDataType and Set
   DisplayFormat should be used whenever the type or format are known.

4. **Lists and Ranges**

   a. Many commands involve lists of variables or values. SDTL includes
      types for representing lists and ranges of variables and values.
      For example, a SetDisplayFormat command may declare that a long
      list of variables should be displayed with two decimal places.

   b. A “variable range” refers to a group of variables in consecutive
      columns, such as “varC to varK”. A list may include both
      individual variables/values and ranges of variables/values.

   c. A list or a range is considered a single element in SDTL. For
      example, most languages have a “max” function that returns the
      maximum value from a list of variables. The SDTL “max” function
      has only one parameter which must be a VariableListExpression.
      Although the SPSS expression “MAX( varX, varY, varZ)” appears to
      have three parameters, it is translated into a
      VariableListExpression pointing to “varX, varY, varZ”, which is
      one parameter in SDTL.

5. **Loops and Macros**

   a. Most loops have an index parameter that changes in each pass
      through the loop. The index parameter may be controlled by a list
      of variable names or by a list of values.

   b. Whenever possible, loops should be expanded in SDTL scripts by
      repeating commands within the loop with each value of a parameter
      that changes. In general, it is much easier to expand loops over
      variables than loops over values, because the latter may depend on
      the state of the dataset.

   c. Even if a loop is expanded, an SDTL version of the loop should be
      provided for reference, and the original code of the full loop
      should be given in the SourceInformation parameter
      originalSourceText.

   d. When loops have been expanded, the “processedSourceText'' in the
      sourceInformation property is used to identify source code after
      expansion. Comparison of the “originalSourceText” and
      “processedSourceText” shows how the macro or loop has been
      expanded.

6. **DoIf**

   a. Used when the logical expression is evaluated once for the entire
      dataset before execution of the enclosed commands.

   b. SourceInformation includes the entire If/Else group of commands.
      SourceInformation for subcommands in both the Then block and the
      Else block describe only one command.

7. **IfRows**,

   a. Used when the logical expression is evaluated once on each row.
      Commands are executed row by row.

   b. SourceInformation includes the entire If/Else group of commands.
      SourceInformation for subcommands in both the Then block and the
      Else block describe only one command.

8. **MergeDatasets**
   Examples of MergeDatasets can be found in the SDTL Merge Gallery:
       .. _Spreadsheet:   :doc:`/CompositeTypes/MergeDatasets/SDTL_Merge_Gallery.xlsx'
	   .. _PDF:   :doc:`/CompositeTypes/MergeDatasets/SDTL_Merge_Gallery.pdf'

9.  **MergeFileDescription**

    Options for **MergeFileDescription** are also in this :: _document:  :doc:`/CompositeTypes/MergeDatasets/Merge_options.markdown` 

    a. **mergeType**

       i.   Sequential: Match rows from each input dataframe in
            sequential order.

       ii.  OneToOne: Create one row for each value of the
            **mergeByVariables**. If a combination of the
            **mergeByVariables** is repeated, only one row is matched.
            Rows with repeated combinations of the MergeByVariables may
            or may not be included in the output file depending on the
            **newRow** property.

       iii. OneToMany: Create a row in the output dataframe by matching
            rows in this dataframe to every row in other dataframes with
            the same value of MergeByVariables. Note that OneToMany
            implies that one of the other input datarames is set to
            ManyToOne.

       iv.  ManyToOne: Create a row in the output dataframe by matching
            all rows in this dataframe to the one row in the other
            dataframe with the same value of MergeByVariables.

       v.   Cartesian: Create a new row in the output dataframe for
            every possible combination of rows having the same value of
            MergeByVariables. This is equivalent to a many to many
            merge. R and Python use a model derived from SQL, which is
            based on Cartesian joins.

       vi.  Unmatched: Create a new row for every row that cannot be
            matched on the MergeByVariables

       vii. SASmatchMerge: SAS uses a merging approach that combines
            matching keys and sequential merges within groups.

    b. **update**

       i.   Master: This dataframe is the Master dataframe.

       ii.  Ignore: If a column with the same name exists in the Master
            dataframe, ignore the values in this dataframe.

       iii. FillNew: If a column with the same name exists in the Master
            dataframe, use the values from this dataframe only in new
            rows created from this dataframe.

       iv.  UpdateMissing: If a column with the same name exists in the
            Master dataframe, use values from this dataframe when the
            value in the Master dataframe is missing. Rows not in the
            Master dataframe are filled from this dataframe.

       v.   Replace: If a column with the same name exists in the Master
            dataframe, use values from this dataframe.

    c. **newRow**

       i.  TRUE: Every row in the dataframe generates a new row in the
           output dataframe.

       ii. FALSE: Only rows that are matched generate a new row in the
           output dataframe.

    d. **mergeFlagVariable**

       i.   **mergeFlagVariable** creates a new variable describing
            whether a row was derived from this file.

       ii.  SPSS creates separate merge flag variables for each input
            file. These variables are binary (0,1).

       iii. Stata and Python create a categorical variable indicating
            which files contributed to each row.

10. **Use of VariableListExpression in the Function Library**. The
    Function Library operates by mapping parameters from other languages
    to a common set of parameters for the SDTL version of the function.
    Some functions operate on a list of variables, such as “mean(varX,
    varY, varZ). It would be impossible to specify parameters in the
    Function Library if every variable in a list was considered a
    parameter. So, VariableListExpression allows us to use one SDTL
    parameter for a list of variables.

11. **Character strings in statistical packages.**
    There are two different ways that statistical packages handle
    variables consisting of text. SPSS and SAS operate primarily on
    fixed length character variables. If the user assigns a string
    shorter than the declared length of the variable, it is padded
    with blanks on the right side. Stata, R, and Python were designed
    to work with string variables that vary in length.

12. **FunctionCallExpression: argumentName property required**.

    a. The **argumentName property** in a **FunctionCallExpression** 
    must be present.

13. **Commands versus Functions**
    Some source language commands may be translated as functions in
    SDTL and vice versa. For example, the Python function
    “df.rename()” renames variables. In SDTL Rename is a command not
    a function.
	   
14. **Parsing Comments**
	Comments in the source languages are delimited by certain special 
	characters which may differ depending on the language; some languages 
	also differentiate between single-line and multi-line comments with a 
	different set of delimiting characters (for example, in Python, a 
	single-line comment starts with a # symbol and ends with a new line, 
	but a multi-line comment starts and ends with three quotation marks). 
	Parsers should take care not to include comment delimiting characters 
	in the commentText property of the corresponding SDTL Comment command 
	because not all source languages use the same characters for that 
	purpose and a comment delimiting character in one language may have 
	an unintended side effect if the SDTL is used to translate the comment 
	into another source language.
	
15. **variableInventory**

   a. **variableInventory**, a property of **DataframeDescription**, is
      used to provide an ordered list of the variables in a dataframe.
      All SDTL commands include **variableInventory**, because it is a
      sub-property of both **consumesDataframe** and 
      **producesDataframe**, which are inherited from **CommandBase**.
		
   b. Parsers are encouraged to use **variableInventory** after any
      command that changes the number or order of variables in a dataframe.
      Most source languages allow variable ranges (SDTL 
      **VariableRangeExpression**) in various commands. Since a variable
      range depends upon the order of variables in a dataframe, the parser
      should include that information in the SDTL script for use by
      updaters and other applications. 

16. **Collapse** and **Aggregate**

   Some aggregation functions (e.g. mean) cannot be performed on text variables. 
   However, users may apply these functions to a range of variables that 
   includes text variables.  Our tests in several source languages suggest that 
   parsers can transfer the variable range in the user-supplied script to SDTL 
   even when it includes text variables.  When this happens, the statistical 
   packages will either ignore text variables and aggregate only the numeric 
   variables, or it will halt with an error message.  
	
   See :doc:`Collapse: Handling of Non-numeric Variables </CompositeTypes/Collapse/Collapse_Nonnumeric_Variables.rst>`

17. **Variable names in case-insensitive languages**

   a. If the source language is case insensitive, the parser will change all 
   variable names to either all caps or all lower case.  The 
   originalSourceText property of the SourceInformation element will 
   show capitalization as it appears in the original script.  
   
   b. A Message command at the beginning of the SDTL script should say 
   that variable names have been standardized.

   c. Standardization of variable names is necessary for compatibility 
   between case sensitive and insensitive languages.

18. **Omitting optional properties in SDTL JSON**

   There are three acceptable ways of omitting an optional property
   from an SDTL JSON file:

      i. The property is omitted -- used for single objects or arrays  

      ii. "property":null  -- used for single objects or arrays   

      iii. "property":[]  -- only used for arrays  

19. **sourceInformation is an array**
   The **sourceInformation** property in **CommandBase** is an array, 
   which can describe more than one command in the source script.  This 
   supports cases where two or more commands in the source script  
   contribute to a single SDTL command.


	
