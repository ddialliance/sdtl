SDTL Pseudocode Library Schema
==============================

A Pseudocode Library is a set of templates used to translate SDTL into
natural language, which is represented in a JSON file. Table 1 describes
the JSON properties in the Pseudocode Library. Every $type in the SDTL
schema is described by a template identified with a corresponding
“SDTLname” in the Pseudocode Library.

The Pseudocode Library provides templates with locations to be filled
with the values of properties in the SDTL command. For example, the
template for the SDTL Compute command is:

   Set {variable} to {expression}.

The bracketed words refer to properties of the Compute command:
“variable” and “expression”. In the example described below “variable”
is equal to “pvar1” and “expression” is equal to “10”. When we put these
values into the template, we get:

   Set pvar1 to 10.

Figure 1 shows the Pseudocode Library JSON for the SDTL Compute command
as well as the NumericConstantExpression and VariableSymbolExpression
SDTL types. As often happens in SDTL, the properties of the Compute
command are expressed as other SDTL elements. Figure 2 shows how
NumericConstantExpression and VariableSymbolExpression are nested in the
SDTL Compute command.

The schema for the Pseudocode Library is described in Table 1. Every
element in SDTL is identified by an “SDTLname”. The basic template for
an element is given in the “baseText” property, which may only consist
of a reference to a property within the element.

Table 1. Properties of the Pseudocode Library JSON File    

+----------------------+----------------------+----------------------+
| SDTLname             | Name of the $type in |                      |
|                      | SDTL                 |                      |
+----------------------+----------------------+----------------------+
| baseText             | Basic template for   |                      |
|                      | this SDTL element    |                      |
+----------------------+----------------------+----------------------+
| notes                | Guidance about this  |                      |
|                      | template             |                      |
+----------------------+----------------------+----------------------+
| parameters           | Properties of this   |                      |
|                      | SDTL $type           |                      |
+----------------------+----------------------+----------------------+
|                      | propertyName         | Name of the property |
+----------------------+----------------------+----------------------+
|                      | repeated             | If “yes”, this       |
|                      |                      | property may be      |
|                      |                      | repeated             |
+----------------------+----------------------+----------------------+
|                      | reqType              | May be the $type of  |
|                      |                      | an SDTL element used |
|                      |                      | for this property or |
|                      |                      | “boolean”            |
+----------------------+----------------------+----------------------+
|                      | text                 | Template for use     |
|                      |                      | with this property   |
+----------------------+----------------------+----------------------+

Properties of an SDTL element are described in the “parameters” array of
the Pseudocode Library. All properties have names, which are found in
the schema for SDTL. The “text” property of a “parameter” provides a
template that is only used if the property is present or takes the value
TRUE for boolean types. If “text” is present, it follows the “baseText”.

The “reqType” property of a “parameter” fulfills two functions. First,
SDTL includes elements that are not explicitly identified with a “$type”
parameter. For example, a script can use one SDTL Rename command to
change the names of more than one variable. Variables to be renamed are
described in the “renames” array. Each element in the “renames” array is
an SDTL RenamePair type consisting of an “oldVariable” and a
“newVariable”. Since the elements in the “renames” array must be of
“$type” RenamePair, the “$type” property can be omitted. We use the
“reqType” property in the Pseudocode Library to specify when a
particular SDTL “$type” is required. This simplifies the task of the
Pseudocode Translator by eliminating the need to lookup the “$type” of
elements in the “renames” array in the SDTL schema.

Second, some properties in SDTL take boolean (true/false) values. When a
“reqType” is declared as “boolean”, the “text” associated with that
“parameter” is only used when its value is “true”.

Figure 1. Extract from the Pseudocode Library

.. code:: json

    {
      "PseudocodeLibrary": [
        {
          "SDTLname": "Compute",
          "BaseText": "Set {variable} to {expression}",
          "notes": null,
          "parameters": [
            {
              "PropertyName": "variable",
              "Repeated": "No",
              "reqType": null,
              "text": null
            },
            {
              "PropertyName": "expression",
              "Repeated": "No",
              "reqType": null,
              "text": null
            },
            {
              "PropertyName": "messageText",
              "Repeated": "Yes",
              "reqType": null,
              "text": "\\n **** {message} *****"
            }
          ]
        },
        {
          "SDTLname": "NumericConstantExpression",
          "BaseText": "{value}",
          "notes": null,
          "parameters": [
            {
              "PropertyName": "value",
              "Repeated": "No",
              "reqType": null,
              "text": null
            },
            {
              "PropertyName": "numericType",
              "Repeated": " of type {numericType}",
              "reqType": null,
              "text": null
            }
          ]
        },
        {
          "SDTLname": "VariableSymbolExpression",
          "BaseText": "{variableName}",
          "notes": null,
          "parameters": [
            {
              "PropertyName": "variableName",
              "Repeated": "No",
              "reqType": null,
              "text": null
            }
          ]
        }
      ]
    }

Figure 2. Extract from SDTL JSON file: Compute command.

.. code:: json

   {
      "$type": "Compute",
      "command": "compute",
      "sourceInformation": {
          "originalSourceText": "compute pvar1 = 10." 
      }, 
      "variable": {
          "$type": "VariableSymbolExpression",
          "variableName": "pvar1"
      },
      "expression": {
          "$type": "NumericConstantExpression",
          "value": "10",
          "numericType": "int"
      }
   }
