Param (
	[Parameter(Mandatory=$true, HelpMessage="The comma separated list of spaces to setup")]
	[string[]]$spaces
)

$currentSpace = (& cf target)[4] | foreach {($_ -split "\s+", 2)[1]} 

foreach($space in $spaces) {
	& cf target -s $space
	& cf create-service mssql-dev dev BookServiceContext 
}

& cf target -s $currentSpace
