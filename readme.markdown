### Structured Data Transform Language

A model for describing data transformations.

[SDTL Documentation and Downloads](http://c2metadata.gitlab.io/sdtl-docs)


### Example JSON Instances

Some example JSON instances are created by the SPSS to SDTL tools every time
an update is made to those tools.

* [CPS transforms example](http://ci.appveyor.com/api/projects/JeremyIverson/sdtl-reader/artifacts/src/C2Metadata.SpssToSdtl.Cli/cps-demo.sdtl.json)
* [Expression example](http://ci.appveyor.com/api/projects/JeremyIverson/sdtl-reader/artifacts/src/C2Metadata.SpssToSdtl.Cli/expression-demo.sdtl.json)

### Changelog

#### 2018-09-07

Changes since August 2018.

- Allow VariableSymbols and Variable Ranges to be intermixed. 
- Use VariableSymbol whenever a single variable is referred to, instead of string.
- Separate types for invalid, unsupported, and analysis commands 
- Remove Type property from concrete expression types. TypeName (serialized as $type) is on the base
- Add Messages to Program, for reporting errors 
