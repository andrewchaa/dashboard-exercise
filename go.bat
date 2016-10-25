pushd build
Powershell -ExecutionPolicy RemoteSigned -File .\0.download-nuget.ps1
Powershell -ExecutionPolicy RemoteSigned -File .\1.create-database.ps1
Powershell -ExecutionPolicy RemoteSigned -File .\2.0.create-tables.ps1

popd

.nuget\NuGet.exe restore

REM Building the solution
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" .\Dashboard.sln /t:rebuild

pushd .\Dashboard.App.ImportStrategy\bin\Debug\
Dashboard.App.ImportStrategy.exe ..\..\..\Build\properties.csv
popd

pushd .\Dashboard.App.ImportCapital\bin\Debug\
Dashboard.App.ImportCapital.exe ..\..\..\Build\capital.csv
popd

pushd .\Dashboard.App.ImportPnl\bin\Debug\
Dashboard.App.ImportPnl.exe ..\..\..\Build\pnl.csv
popd

pushd .\dashboard
npm i
popd
