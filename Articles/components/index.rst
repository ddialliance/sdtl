Components of SDTL
==================

SDTL Command Language
------------------------

There are 71 SDTL composite types, which fall into four groups.

-  Transformation commands

-  Informational commands

-  Expressions

-  Complex properties

SDTL has been implemented in JSON schemas, but it can be serialized to
XML and other formats. The SDTL Command Language is available in several
formats at http://c2metadata.gitlab.io/sdtl-docs/. For documentation of
each element in SDTL see:
http://c2metadata.gitlab.io/sdtl-docs/master/composite-types/ .

SDTL Function Library
------------------------

Like most computer languages, SDTL uses functions for common
computations, such as trigonometric (sine, cosine, etc.) and statistical
(normal, binomial, gamma, etc.) functions. The Function Library provides
a crosswalk between the SDTL version of each function and the same
function in each source language. These crosswalks allow applications
that translate source languages into SDTL to apply the same code to
almost all functions. The Function Library is provided in a JSON schema,
which is available for download at
https://gitlab.com/c2metadata/SDTL-translation-libraries.

SDTL Pseudocode Library Schema
---------------------------------

The Pseudocode Library Schema provides a simple way to translate SDTL
JSON into natural language. A Pseudocode Library consists of templates
providing text that should surround the properties of each SDTL type. An
SDTL command is translated by resolving each property into text and
inserting it in the template. For example, the template for the SDTL
Compute command is:

   Set {variable} to {expression}.

The {variable} property resolves to a variable name, and the
{expression} property resolves to an expression, which may include
variables, numeric constants, and mathematical or string functions. The
result of inserting values for {variable} and {expression} into the
template will be something like:

   Set varY to the natural logarithm of varX.

   The current version of the Pseudocode Library is available at:
   https://gitlab.com/c2metadata/SDTL-translation-libraries