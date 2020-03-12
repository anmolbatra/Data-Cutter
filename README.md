# Data-Cutter
<B>About The application: </B>
<p>
Data-Cutter helps you Select columns from flat file (e.g. Comma Separated, Tab delimited) without using any SQL based system. Since it uses file pointers for data transformtation, the application is much faster than any ETL tool.
As of now it can process files as large as 64 GB (Not limited by RAM).
<p>
<I>PS: The output file uses the same delimiter as the input file.</I>

<B> Getting Started </B>
<p>
For executable use visit the folder DataCutter/bin/Release/DataCutter.exe 
<p>
1. To filter the data, click File > Open 
<I> Or alternatively press Ctrl + O. </I>
The File name will be visible in the status bar at the bottom.
<p>
2. To Cut the file column wise, use the interface to select the output column positions. i.e. Which column should be on Column(1): 4
If left blank, the tool will leave the column as blank while extracting files.
<p>
3. To Save the Selected Column in an Flat file. Click File > Save As
<p>
4. Once the application is done slicing and dicing your data, it show a pop-up with a message like 
<p>
<I>"14 rows extracted to file.txt"</I>
<p>
<I> The tool doesn't have any progress estimator built into it. If the file is large please be patient </I>

<B> Terms of Usage </B>
The code is completely free to use and modify at your own risk. Feel free to tailor the application as per your needs.

<B> In case of issues </B>
Feel free to leave a comment here or write a mail to anmol.batra@yahoo.com
