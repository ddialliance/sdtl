##############################################################
####  Read read JSON-LD and write Turtle ttl
##############################################################

import pandas as pd
import io
import os
import json
import csv
import tkinter as tk
from tkinter import filedialog
from rdflib import Graph, plugin
from rdflib.serializer import Serializer
from rdflib import Namespace
import rdflib
root = tk.Tk()
root.withdraw()

########  prompt for working directory #########
qpath = filedialog.askdirectory(title="Select output directory")

## -- Prompt for JSON file ---
file_path = filedialog.askopenfilename(title="Select JSON-LD file")
print(file_path)

## -- Read JSON file ---
with open(file_path) as f:
      fl3 = json.load(f)

## -- extract file name from .json file
fn1 = file_path[ len(qpath) + 1:]
fn2 = fn1[:-5]

## -- dump JSON file into a string --
f4 = json.dumps(fl3)

## -- parse string as JSON-LD --
fld = Graph()      
fld.parse(data=f4,format="json-ld")

print("**** graph *****")
print("Number of triples: ", len(fld) , "\n")

print("\n\n**** turtle *****")
print(fld.serialize(format="turtle"))


####### write turtle file  ######
with open(f"{qpath}/{fn2}_turtle.ttl", 'w') as qttl:
    qttl.write(fld.serialize(format="turtle"))
