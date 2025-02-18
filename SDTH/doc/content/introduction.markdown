# Introduction

## SDTH and PROV

## Instances of data objects

SDTH requires a change in the way that one thinks about a computer program.  We usually think of variables and dataframes as containers into which we put digital representations of numbers, text, or logical values.  As the program is executed, the values assigned to a variable or dataframe change, but its identity remains the same.  We may think of these sets of values as states of the variable/dataframe.  Since variables and dataframes can change, they do not qualify as entities in the PROV framework.  SDTH focuses on the contents of data objects, not their containers.  

We call the set of values assigned to a variable or dataframe at a moment time an “instance” of a data object.  Every time a command in a program changes the contents of a data object, a new instance is created.  Many instances of data objects created during the execution of a program are ephemeral and disappear when the program ends.   Only instances of data objects preserved on non-volatile media, which SDTH calls “files”, persist after the program has executed.

The connection between references to data objects in the program and instances of these objects in SDTH is maintained by making variable and dataframe names properties of entities in SDTH.  Queries of SDTH can report variable/dataframe names, instances, or both.
