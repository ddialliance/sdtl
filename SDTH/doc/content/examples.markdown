# Examples

Figure 2 shows part of an SDTH graph consisting of two program steps (dark blue rectangles with white text) that create new variables. (Due to space limitations, the example program and related files are available on Gitlab at https://gitlab.com/c2metadata/sdth-example.) Three variable instances are represented by red ovals. Each variable is linked to its name in the source code. 

<figure id="sdth-example">
  <img src="assets\ProgramStepRecursion_005a.png" alt="sdth example" />
  <figcaption>Graph of excerpt from an example of SDTH</figcaption>
</figure>

In effect, relationships between variable names and values in SDTH are the opposite of those in programming languages. In a programming language we use the name to refer to the values of a variable. In SDTH the values (i.e., the VariableInstance) have their own ID, and the name is an attribute of the VariableInstance. Similarly, ProgramSteps are accessed by their IDs, but a Program step can have source code and SDTL code as an attribute. As the example below shows, the output of an SDTH query can be displayed in terms of variable names and program code rather than as instances and steps.

The lineage of variable “HHcateg” is clearly defined in Figure 1 by the derivedFrom predicates linking it to “HHsize” and “PHHSIZE,” but the program steps that created “HHcateg” and “HHsize” are not linked to each other. This means that in SDTH there is no way to reconstruct the order of program steps from the program steps alone. The order of program steps can be inferred, however, because they are linked to VariableInstances, which are clearly ordered by the
derivedFrom predicates. 

This example also shows that ProgramSteps can be composed of other ProgramSteps.  The Python command represented by ID #ProgStep005 uses a complex function, cut().  In SDTL this command is divided into three steps, the first of which (#ProgStep005a) is shown in Figure 1.  The Python command is tied to all three SDTL commands by the hasProgramStep predicate.
