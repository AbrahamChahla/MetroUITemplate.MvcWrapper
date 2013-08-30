MetroUIMvc

You should read up on the configuration of the Metro UI Template
from http://metro-webdesign.info to fully understand how to configure
for their javascript.  I'm only going to provide enough to get you going.

Also note, I go for code readability foremost over optimaization.  So don't
get excited if you see better ways.  If you do... great... implement it!

Probably the easiest way to understand the code is to start in this order:
	1. MetroTile.cs
	2. MetroRow.cs
	3. MetroColumn.cs
	4. MetroScreen.cs
	5. HomeController.cs
	6. Index.cshtml
	7. _Layout.cshtml

Quick Start
	1. Need to create a MetroScreen object
	2. Add a column to the MetroScreen
	3. Add a row to the column
	4. Add tiles to a row
	5. Add additional rows and tiles as needed
	6. Add new columns as needed
	
Read the code!

