@Echo OFF
SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\
SET SolutionPath=d:\projects\SimuTraining\SimuTraining.sln
Echo Start Time - %Time%
MSbuild %SolutionPath% /p:Configuration=Release /p:Platform="Any CPU"
Echo End Time - %Time%
Set /p Wait=Build Process Completed...