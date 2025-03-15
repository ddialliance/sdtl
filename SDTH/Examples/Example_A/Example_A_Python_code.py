##############################################################
####   Example of a data transformation script in Python 
##############################################################
import pandas as pd

PoliticalData = pd.read_csv("SmallTestPolitical.csv")

PersonalData = pd.read_csv("SmallTestPersonal.csv")

PersonalData   = PersonalData.assign(HHsize=PersonalData['PPHHSIZE'] )

PersonalData['HHcateg'] = pd.cut(PersonalData['HHsize'], [1, 2, 3, 5, 7, 10, 999], include_lowest=True, right=False, labels=['1', '2', '3-4', '5-6', '7-9', '10+'] )

MergedData = PersonalData.merge(PoliticalData, on="ID", how="inner")

MergedData.to_csv("SmallTestMerged.csv")
