@Echo OFF
SET SolutionPath=SimuTraining\SimuTraining.csproj
Echo Start Time - %Time%
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSbuild.exe -p:FrameworkPathOverride=%PATH% %SolutionPath% /p:Configuration=Release /p:Platform="Any CPU"
Echo End Time - %Time%
Set /p Wait=Build Process Completed...