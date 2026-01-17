# SDTH Namespace and Vocabulary

The SDTH namespace URI is:

- http://rdf-vocabulary.ddialliance.org/SDTH#

The prefix `SDTH` will be associated to this namespace in all this specification.

The SDTH vocabulary is a set of URIs, given in the left-hand column in the table below. The right hand column indicates in which section below the corresponding term is explained in more detail.

# SDTH Entities


<table class="simple" border="1">
  <caption>Table 1. SDTH Entities</caption>
  <thead>
    <tr>
      <th>Name</th>
      <th>Domain of</th>
      <th>Range of</th>
      <th>Subclass of</th>
    </tr>
</thead>
<tbody>
<tr>
<td id="Program">[[[#model-program]]]</td>
<td>sdth:hasName, sdth:hasProgramStep</td>
<td></td>
<td>prov:Entity, prov:Plan, provone:Program</td>
</tr>
<tr>
<td id="ProgramStep">[[[#model-programstep]]]</td>
<td>sdth:hasProgramStep, sdth:loadsFile, sdth:savesFile, sdth:producesData, sdth:consumesData, sdth:usesVariableInstance, sdth:assignsVariableInstance </td>
<td>sdth:hasProgramStep</td>
<td>prov:Activity, provone:Program</td>
</tr>
<tr>
<td id="DataInstance">[[[#model-datainstance]]]</td>
<td>sdth:hasName, sdth:wasDerivedFrom, sdth:elaborationOf, sdth:hasDataInstance, sdth:hasVariableInstance </td>
<td>sdth:hasDataInstance, sdth:producesData, sdth:consumesData, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>prov:Entity, provone:Data</td>
</tr>
<tr>
<td id="FileInstance">[[[#model-fileinstance]]]</td>
<td>sdth:hasName, sdth:hasDataInstance, sdth:hasVariableInstance, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>sdth:loadsFile, sdth:savesFile, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>prov:Entity, provone:Data</td>
</tr>
<tr>
<td id="DataframeInstance">[[[#model-dataframeinstance]]]</td>
<td>sdth:hasName, sdth:hasVariableInstance, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>sdth:hasDataInstance, sdth:producesData, sdth:consumesData, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>prov:Entity, provone:Data, sdth:DataInstance</td>
</tr>
<tr>
<td id="VariableInstance">[[[#model-variableinstance]]]</td>
<td>sdth:hasName, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>sdth:hasVariableInstance, sdth:usesVariableInstance, sdth:assignsVariableInstance, sdth:wasDerivedFrom, sdth:elaborationOf</td>
<td>prov:Entity, provone:Data, sdth:DataInstance</td>
</tr>
<td id="TextInstance">[[[#model-textinstance]]]</td>
<td>sdth:hasName, sdth:wasDerivedFrom</td>
<td>sdth:producesData, sdth:consumesData, sdth:wasDerivedFrom</td>
<td>prov:Entity, provone:Data, sdth:DataInstance</td>
</tr>
<td id="ImageInstance">[[[#model-imageinstance]]]</td>
<td>sdth:hasName, sdth:wasDerivedFrom</td>
<td>sdth:producesData, sdth:consumesData, sdth:wasDerivedFrom</td>
<td>prov:Entity, provone:Data, sdth:DataInstance</td>
</tr>
</tbody>
</table>


# SDTH Properties

<table class="simple" border="1">
  <caption>Table 2. SDTH Properties</caption>
  <thead>
    <tr>
      <th>Name</th>
      <th>Domain</th>
      <th>Range</th>
      <th>Subclass of</th>
    </tr>
</thead>
<tr>
<td id="hasProgramStep">[[[#model-hasprogramstep]]]</td>
<td>sdth:Program, sdth:hasProgramStep</td>
<td>sdth:hasProgramStep</td>
<td>provone:hasSubProgram</td>
</tr>

<tr>
<td id="hasSourceCode">[[[#model-hassourcecode]]]</td>
<td>sdth:Program, sdth:hasProgramStep</td>
<td>xsd:string</td>
<td></td>
</tr>
<tr>
<td id="hasSDTL">[[[#model-hassdtl]]]</td>
<td>sdth:Program, sdth:hasProgramStep</td>
<td>xsd:string</td>
<td></td>
</tr>
<tr>
<td id="hasName">[[[#model-hasname]]]</td>
<td>sdth:Program, sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance, sdth:VariableInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td>xsd:string</td>
<td></td>
</tr>
<tr>
<td id="loadsFile">[[[#model-loadsfile]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:FileInstance</td>
<td></td>
</tr>
<tr>
<td id="savesFile">[[[#model-savesfile]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:FileInstance</td>
<td></td>
</tr>

<tr>
<td id="consumesData">[[[#model-consumesdata]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:DataInstance, sdth:DataframeInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td></td>
</tr>
<tr>
<td id="producesData">[[[#model-producesdata]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:DataInstance, sdth:DataframeInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td></td>
</tr>

<tr>
<td id="hasDataInstance">[[[#model-hasDataInstance]]]</td>
<td>sdth:DataInstance</td>
<td>sdth:DataInstance, sdth:DataframeInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td></td>
</tr>
<tr>
<td id="hasVariableInstance">[[[#model-hasVariableInstance]]]</td>
<td>sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance</td>
<td>sdth:VariableInstance</td>
<td>sdth:hasDataInstance</td>
</tr>
<tr>
<td id="usesVariableInstance">[[[#model-usesvariable]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:VariableInstance</td>
<td>sdth:consumesData</td>
</tr>
<tr>
<td id="assignsVariableInstance">[[[#model-assignsvariable]]]</td>
<td>sdth:ProgramStep</td>
<td>sdth:VariableInstance</td>
<td>sdth:producesData</td>
</tr>
<tr>
<td id="wasDerivedFrom">[[[#model-wasderivedfrom]]]</td>
<td>sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance, sdth:VariableInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td>sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance, sdth:VariableInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td>prov:wasDerivedFrom</td>
</tr>
<tr>
<td id="elaborationOf">[[[#model-elaborationof]]]</td>
<td>sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance, sdth:VariableInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td>sdth:FileInstance, sdth:DataInstance, sdth:DataframeInstance, sdth:VariableInstance, sdth:TextInstance, sdth:ImageInstance</td>
<td>prov:wasDerivedFrom</td>
</tr>

</tbody>
</table>

# Other Vocabularies

Other vocabularies used in this document are listed in the table below, with their namespaces and associated prefixes.


<table class="simple">
    <caption>Table 3. Other vocabularies used in this document</caption>
    <thead>
        <tr>
            <th>Prefix</th>
            <th>URI</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
  <!--       <tr>
            <td>dcterms</td>
            <td><a href="http://purl.org/dc/terms/">http://purl.org/dc/terms/</a></td>
            <td>Dublin Core Metadata Initiative Metadata Terms ([[DC-TERMS]])</td>
        </tr> 
 -->        <tr>
            <td>prov</td>
            <td><a href="http://www.w3.org/ns/prov#">http://www.w3.org/ns/prov#</a></td>
            <td>The PROV namespace ([[prov-o]]) </td>   
        </tr> 
        <tr>
            <td>provone</td>
            <td><a href="http://purl.dataone.org/provone/2015/01/15/ontology#">http://purl.dataone.org/provone/2015/01/15/ontology#</a></td>
            <td>The ProvONE namespace ([[ProvONE]])</td>   
        </tr>    
    </tbody>
</table>


RDF, RDFS and OWL vocabularies are also used, with their usual URIs and prefixes. Information on these standards can be found on the W3C web site.

The RDF examples are expressed with the Terse RDF Triple language (Turtle) [[TURTLE]]. Unless otherwise specified, these examples use http://example.org/ns/ as a base namespace; resource names between angle brackets represent URIs in this namespace. Note however that individual resource names used as examples are entirely fictious.

