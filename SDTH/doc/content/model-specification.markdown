# SDTH Model Specification
## Programs and Program Steps {#model-programs}
### sdth:Program {#model-program} 
An sdth:Program is a set of instructions that modify data.   An sdth:Program consists of sdth:ProgramSteps.
sdth:Program is a sub-class of prov:entity, prov:plan, and provone:Program. 

**has super-class**
- prov:Entity, prov:Plan, provone:Program

**is in domain of**
- sdth:hasProgramStep


###  sdth:ProgramStep {#model-programstep}
An sdth:ProgramStep is an operation in an sdth:Program.  An sdth:ProgramStep may be associated with a single command in a program or script.   However, sdth:ProgramStep is recursive, which means that an sdth:ProgramStep may be linked to other sdth:ProgramSteps using sdth:hasProgramStep. This allows complex operations to be represented as a set of simpler operations.
sdth:ProgramStep is a subclass of prov:Activity

**has super-class**
- prov:Entity, prov:Plan, provone:Program

**is in domain of**
- sdth:hasProgramStep, sdth:loadsFile, sdth:savesFile, sdth:producesDataframe, sdth:consumesDataframe, sdth:hasVarInstance, dth:usesVariable, sdth:assignsVariable

**is in range of**
- sdth:hasProgramStep


###  sdth:hasProgramStep {#model-hasprogramstep}
sdth:hasProgramStep specifies sdth:ProgramSteps within an sdth:Program or sdth:ProgramStep.

**has domain**
- sdth:Program, sdth:hasProgramStep

**has range**
- sdth:hasProgramStep


###  sdth:hasSourceCode {#model-hassourcecode}
sdth:hasSourceCode specifies the original program code represented by an sdth:Program or sdth:ProgramStep.

**has domain**
- sdth:Program, sdth:hasProgramStep

**has range**
- xsd:string


###  sdth:hasSDTL {#model-hassdtl}
sdth:hasSDTL provides a version of program code represented by an sdth:Program or sdth:ProgramStep translated into the SDTL schema. 

**has domain**
- sdth:Program, sdth:hasProgramStep

**has range**
- xsd:string

 
## Data Entities {#model-data-entities}

### sdth:DataInstance {#model-datainstance}
An sdth:DataInstance is a collection of values created in a computer memory during the execution of an sdth:Program.  An sdth:DataInstance may be any kind of data collection, including arrays, matrices, lists, and datacubes.  SDTH pays special attention to instances of dataframes and variables, which are the data collections most often used in statistical analysis.  The sdth:DataframeInstance and sdth:VariableInstance described below are sub-classes of sdth:DataInstance.

**has super-class**
- prov:Entity, provone:Data

**is in domain of**
- sdth:hasName, sdth:wasDerivedFrom

**is in range of**
- sdth:producesData, sdth:consumesData, sdth:wasDerivedFrom


###  sdth:FileInstance {#model-fileinstance}
An sdth:FileInstance is a persistent object stored on a medium, such as a disk, tape, CD-ROM, or non-volatile memory storage device.  sdth:FileInstances may be in any format.  File formats used by statistical analysis programs to store dataframes usually include some metadata about variables, such as data type and label.  Simple formats, like comma-separated values (CSV), which contain very little metadata describing the meaning and attributes of values, may be accompanied by a separate metadata file. 

An sdth:FileInstance is created by an sdth:ProgramStep that executes an operation represented as an sdth:savesFile. 

When an sdth:loadsFile is executed, the contents of sdth:FileInstance becomes an sdth:DataframeInstance.
The sdth:VariableInstances in an sdth:FileInstance are enumerated using sdth:hasVarInstance.

**has super-class**
- prov:Entity, provone:Data, sdth:DataInstance

**is in domain of**
- sdth:hasName, sdth:hasVarInstance, sdth:wasDerivedFrom, sdth:elaborationOf

**is in range of**
- sdth:loadsFile, sdth:savesFile, sdth:wasDerivedFrom, sdth:elaborationOf


###  sdth:DataframeInstance {#model-dataframeinstance} 
An sdth:DataframeInstance is a two-dimensional matrix of data values created in a computer memory during the execution of an sdth:Program.  An sdth:DataframeInstance is a transient object that disappears when execution of the sdth:Program ends.
sdth:DataframeInstances consist of columns and rows.  The columns in an sdth:DataframeInstance are sdth:VariableInstances.  The rows may be considered observations or cases. 

An sdth:DataframeInstance may be created by an sdth:ProgramStep that executes an sdth:loadsFile or an sdth:producesDataframe.

Any change in one of the sdth:VariableInstances in an sdth:DataframeInstance  procudes a new sdth:producesDataframe.

The sdth:VariableInstances in an sdth:DataframeInstance are enumerated using sdth:hasVarInstance.


**has super-class**
- prov:Entity, provone:Data

**is in domain of**
- sdth:hasName, sdth:hasVarInstance, sdth:wasDerivedFrom, sdth:elaborationOf

**is in range of**
- sdth:producesDataframe, sdth:consumesDataframe, sdth:wasDerivedFrom, sdth:elaborationOf


 
###  sdth:VariableInstance  {#model-variableinstance}
An sdth:VariableInstance refers to a set of values and their associated metadata appearing in a column of an sdth:DataframeInstance or sdth:FileInstance.  Metadata associated with an sdth:VariableInstance can include data type (text, numeric, etc.), number of decimal places, or a value schema for a categorical variable.  The order of observations in an sdth:DataframeInstance or sdth:FileInstance is also an attribute of every sdth:VariableInstance.

An sdth:VariableInstance is immutable. When a data transformation command changes any aspect of an sdth:VariableInstance, it generates a new sdth:VariableInstance.  This includes changing any of the values in an sdth:DataframeInstance or any of the attributes of those values.  Sorting an sdth:DataframeInstance also results in a new set of sdth:VariableInstances.   This is necessary, because some data transformation commands use the order of rows in a dataframe in computations, such as the lag() function in statistical analysis programs like SAS and Stata.

An sdth:VariableInstance may appear in more than one sdth:DataframeInstance or sdth:FileInstance.  For example, if one value in an sdth:VariableInstance changes, a new sdth:DataframeInstance is generated, but the new sdth:DataframeInstance contains all of the sdth:VariableInstances in the previous sdth:DataframeInstance except the one that was changed.  When an sdth:DataframeInstance is saved to an sdth:FileInstance, the sdth:VariableInstances in the sdth:FileInstance are the same as those in the sdth:DataframeInstance. 

The sdth:VariableInstance is a specialization of the PROV entity. Although PROV does not require all aspects of a prov:entity to be fixed, the purposes of SDTH require complete immutability.

The SDTH definition of an sdth:VariableInstance is synonymous with the definition of an “Instance Variable” in GSIM [[gsim]] and a “Variable” in DDI Life Cycle [[ddiLifecycle]]. 

An sdth:VariableInstance is an instantiation of the ddi-cdi:InstanceVariable and is associated with a specific set of DDI-CDI “datums” [[ddicdi]].  A ddi-cdi:InstanceVariable specifies attributes of the values of a variable, such as a data type and value schema, but it is not limited to a specific set of values.  

**has super-class**
- prov:Entity, provone:Data

**is in domain of**
- sdth:hasName, sdth:wasDerivedFrom, sdth:elaborationOf

**is in range of**
- sdth:hasVarInstance, sdth:wasDerivedFrom, sdth:elaborationOf


###  sdth:hasName  {#model-hasname}
sdth:hasName specifies a name for a data entity.  All data entities in SDTH are expected to have names.  A name links an SDTH data entity to the object that it represents in a script or program code. 

**has domain**
- sdth:FileInstance, sdth:DataframeInstance, sdth:VariableInstance

**has range**
- xsd:string

 
## File and Dataframe Operations {#model-files}
### sdth:loadsFile {#model-loadsfile}
When a sdth:ProgramStep executes an sdth:loadsFile operation, an external sdth:FileInstance is loaded into the active workspace as a DataframeInstance.  A sdth:ProgramStep that executes a sdth:loadsFile command also performs an sdth:producesDataframe operation. 

**has domain**
- sdth:ProgramStep

**has range**
- sdth:FileInstance

 
### sdth:savesFile {#model-savesfile}
When a sdth:ProgramStep executes an sdth:savesFile operation, an external sdth:FileInstance is created.  A sdth:ProgramStep that executes a sdth:savesFile command also performs an sdth:consumesDataframe operation.

**has domain**
- sdth:ProgramStep

**has range**
- sdth:FileInstance


 
### sdth:producesDataframe {#model-producesdataframe}
An sdth:producesDataframe is used when an sdth:ProgramStep results in a new sdth:DataframeInstance.  This occurs when data are read from an external file or when data in an existing sdth:DataframeInstance is modified.  

**has domain**
- sdth:ProgramStep

**has range**
- sdth:DataframeInstance


 
### sdth:consumesDataframe {#model-consumesdataframe}
An sdth:consumesDataframe is used when an sdth:ProgramStep uses data from an existing sdth:DataframeInstance.  This occurs when data are saved to an external file or when data in an existing sdth:DataframeInstance is modified.  

**has domain**
- sdth:ProgramStep

**has range**
- sdth:DataframeInstance


 
### sdth:hasVarInstance {#model-hasvarinstance}
sdth:hasVarInstance is used to enumerate the sdth:VariableInstances in an sdth:DataframeInstance or an sdth:FileInstance.

**has domain**
- sdth:FileInstance, sdth:DataframeInstance

**has range**
- sdth:VariableInstance

 

## Usage and Assignment of a VariableInstance {#model-usage}

###  sdth:usesVariable  {#model-usesvariable}

sdth:usesVariable specifies an sdth:VariableInstance that affects the outcome of an sdth:ProgramStep.  

**has domain**
- sdth:ProgramStep

**has range**
- sdth:VariableInstance

 
###  sdth:assignsVariable {#model-assignsvariable}
sdth:assignsVariable specifies that an sdth:VariableInstance is an outcome of an sdth:ProgramStep 

**has domain**
- sdth:ProgramStep

**has range**
- sdth:VariableInstance


 
## Derivation and Elaboration {#model-derivation}
Derivation and Elaboration describe the lineage of a data entity.  Derivation is used when values in a data entity were changed to derive a new data entity.  Elaboration is used when metadata about a data entity changed, but its values remained the same.  


###  sdth:wasDerivedFrom {#model-wasderivedfrom}
sdth:wasDerivedFrom is used when the values of data in a data entity have changed.  sdth:wasDerivedFrom links a data entity to a pre-existing data entity that affected it.  

**has domain**
- sdth:FileInstance, sdth:DataframeInstance, sdth:VariableInstance

**has range**
- sdth:FileInstance, sdth:DataframeInstance, sdth:VariableInstance


 
###  sdth:elaborationOf {#model-elaborationof}
sdth:elaborationOf is used when an attribute of a data entity, such as a data format or name, has changed, but the values in the data entity have not changed.  sdth:elaborationOf specifies links a data entity to a pre-existing data entity with the same data values but different attributes.


**has domain**
- sdth:FileInstance, sdth:DataframeInstance, sdth:VariableInstance

**has range**
- sdth:FileInstance, sdth:DataframeInstance, sdth:VariableInstance

 
