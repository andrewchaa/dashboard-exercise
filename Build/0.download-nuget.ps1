$nugetExist = Test-Path ..\.nuget\
if ($nugetExist -eq $FALSE) {
  mkdir ..\.nuget
  Invoke-WebRequest -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -OutFile ..\.nuget\nuget.exe
}
