del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack OqtaneLabs.ContactForm.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y
