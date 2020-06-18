Version 1.0

George Alter [1]_, Darrell Donakowski\ :sup:`1`, Jack Gager [2]_, Pascal
Heus\ :sup:`2`, Carson Hunter\ :sup:`2`, Sanda Ionescu\ :sup:`1`, Jeremy
Iverson [3]_, Hosagrahar V Jagadish\ :sup:`1`, Carl Lagoze\ :sup:`1`,
Jared Lyle\ :sup:`1`, Alexander Mueller\ :sup:`1`, Sigbjorn
Revheim [4]_, Matthew A. Richardson\ :sup:`1`, Ornulf Risnes\ :sup:`4`,
Karunakara Seelam\ :sup:`1`, Dan Smith\ :sup:`3`, Tom Smith [5]_, Jie
Song\ :sup:`1`, Yashas Jaydeep Vaidya\ :sup:`1`, Ole Voldsater\ :sup:`4`

Acknowledgment

The Continuous Capture of Metadata for Statistical Data Project is
funded by National Science Foundation grant ACI-1640575.


Summary
=======



Structured Data Transformation Language (SDTL) provides a structured
format for describing data processing steps in scripts used with
statistical analysis software. SDTL creates a machine-actionable
representation of the script showing which variables were affected by
each command. SDTL can be embedded in DDI metadata files to provide
variable- and file-level derivation histories (provenance) for use in
data catalogs, codebooks, and other documentation. SDTL operates at a
more granular level than most previous data provenance tools, which
treat each program as a black box that reads and writes files. SDTL has
been defined in JSON schemas for common operations, such as RECODE,
MERGE FILES, and VARIABLE LABELS. The C\ :sup:`2`\ Metadata Project
(http://c2metadata.org/) has developed software that automates the
creation of SDTL from program scripts in five leading statistical
analysis packages: SPSS, SAS, Stata, R, and Python. SDTL can also be
translated into natural language, such as “Set the value of varX to the
natural logarithm of varY.”

Benefits of SDTL:

-  SDTL fills a gap in DDI standards (Codebook, Lifecycle, Cross Domain
   Integration). DDI standards include places to insert provenance
   information, but there has been no standard way to describe how
   variables are computed, recoded, aggregated, etc.

-  SDTL can be translated into natural language, so that data users do
   not need to understand the programming language that transformed the
   data.

-  SDTL is machine actionable. Application developers can easily add
   SDTL to existing applications, like data catalogs and codebooks.
   Future applications can use SDTL to visualize, analyze, and validate
   the working of data transformation programs. For example, if there is
   a question about the quality of a question in a survey, SDTL will
   reveal all of the variables derived from that question.

-  The C\ :sup:`2`\ Metadata Project has produced software that
   automates the creation of SDTL from program scripts in five leading
   statistical analysis packages: SPSS, SAS, Stata, R, and Python.

-  SDTL-based tools can be used by both large data collection and
   distribution projects and by individual researchers. The latter can
   quickly create annotated codebooks to satisfy data and code
   documentation requirements of journals.


.. [1]
   University of Michigan

.. [2]
   Metadata Technologies North America

.. [3]
   Colectica

.. [4]
   Norwegian Centre for Research Data

.. [5]
   NORC
