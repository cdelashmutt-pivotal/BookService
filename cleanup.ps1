Param (
	[string[]]$spaces
)

$currentSpace = (& cf target)[4] | foreach {($_ -split "\s+", 2)[1]} 

foreach($space in $spaces) {
	& cf target -s $space
	$apps = (& cf apps)[4..$appOutput.length] | 
			foreach { ($_ -split "\s+", 6)[0] } | 
			where { $_ -Like "bookservice*" }
	foreach($app in $apps) {
		& cf delete $app -f -r
	}
	& cf delete-service BookServiceContext -f 
}

& cf target -s $currentSpace
