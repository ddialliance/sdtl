# SDTH Namespace and Vocabulary

The SDTH namespace URI is:

- http://rdf-vocabulary.ddialliance.org/SDTH#

The prefix `SDTH` will be associated to this namespace in all this specification.

The SDTH vocabulary is a set of URIs, given in the left-hand column in the table below. The right hand column indicates in which section below the corresponding term is explained in more detail.

<table class="simple" border="0">
  <caption>Table 1. SDTH Vocabulary</caption>
  <thead>
    <tr>
      <th>URI</th>
      <th>Definition</th>
    </tr>
</thead>
<tbody>
<tr>
<td id="Program">SDTH:Program</td>
<td>[[[#model-programs]]]</td>
</tr>
<tr>
<td id="ProgramStep">SDTH:ProgramStep</td>
<td>[[[#model-programs]]]</a></td>
</tr>
<tr>
<td id="FileInstance">SDTH:FileInstance</td>
<td>[[[#model-data-entities]]]</a></td>
</tr>
<tr>
<td id="DataframeInstance">SDTH:DataframeInstance</td>
<td>[[[#model-data-entities]]]</a></td>
</tr>
<tr>
<td id="VariableInstance">SDTH:VariableInstance</td>
<td>[[[#model-data-entities]]]</td>
</tr>
<tr>
<td id="loadsFile">SDTH:loadsFile</td>
<td>[[[#model-usage]]]</td>
</tr>
<tr>
<td id="savesFile">SDTH:savesFile</td>
<td>[[[#model-usage]]]</td>
</tr>
<tr>
<td id="consumesDataframe">SDTH:consumesDataframe</td>
<td><[[[#model-usage]]]</td>
</tr>
<tr>
<td id="producesDataframe">SDTH:producesDataframe</td>
<td>[[[#model-usage]]]</td>
</tr>
<tr>
<td id="usesVariable">SDTH:usesVariable</td>
<td>[[[#model-usage]]]</td>
</tr>
<tr>
<td id="assignsVariable">SDTH:assignsVariable</td>
<td>[[[#model-usage]]]</td>
</tr>
<tr>
<td id="wasDerivedFrom">SDTH:wasDerivedFrom</td>
<td>[[[#model-derivation]]]</td>
</tr>
<tr>
<td id="elaborationOf">SDTH:elaborationOf</td>
<td>[[[#model-derivation]]]</td>
</tr>
<tr>
<tr>
<td id="hasProgramStep">SDTH:hasProgramStep</td>
<td>[[[#model-names]]]</td>
</tr>
<tr>
<td id="hasSourceCode">SDTH:hasSourceCode</td>
<td>[[[#model-names]]]</td>
</tr>
<tr>
<td id="hasSDTL">SDTH:hasSDTL</td>
<td>[[[#model-names]]]</td>
</tr>
<td id="hasName">SDTH:hasName</td>
<td>[[[#model-names]]]</td>
</tr>
<tr>
<td id="hasVarInstance">SDTH:hasVarInstance</td>
<td>[[[#model-names]]]</td>
</tr>
</tbody>
</table>

<figure id="sdth-relationships">
  <img src="assets\sdth_diagram.png" alt="sdth relationships" />
  <figcaption>shows relationships among the elements of SDTH</figcaption>
</figure>

Other vocabularies used in this document are listed in the table below, with their namespaces and associated prefixes.


<table class="simple">
    <caption>Table 2. Other vocabularies used in this document</caption>
    <thead>
        <tr>
            <th>Prefix</th>
            <th>URI</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>dcterms</td>
            <td>http://purl.org/dc/terms/</td>
            <td>Dublin Core Metadata Initiative Metadata Terms ([[DC-TERMS]])</td>
        </tr>        
    </tbody>
</table>

RDF, RDFS and OWL vocabularies are also used, with their usual URIs and prefixes. Information on these standards can be found on the W3C web site.

The RDF examples are expressed with the Terse RDF Triple language (Turtle) [[TURTLE]]. Unless otherwise specified, these examples use http://example.org/ns/ as a base namespace; resource names between angle brackets represent URIs in this namespace. Note however that individual resource names used as examples are entirely fictious.