The NewDataframe command copies or creates a new dataframe.  It can be used in two ways.    
    
An existing dataframe can be copied to a new dataframe by using the consumesDataframe and producesDataframe properties of NewDataframe.  The new dataframe will be a "deep" copy in the sense used in R and Python.      
   
NewDataframe can also be used to create an empty dataframe of a specific size.  In Stata, the "set obs #" command will create a dataframe with a user-defined number of rows.  All values are assumed to be missing.  This may be used in simulations to preset a number of simulated observations, which are then filled with randomly generated data.



