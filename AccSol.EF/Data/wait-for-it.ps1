param (
    [string] $hostname,
    [int] $port,
    [int] $timeout = 15
)

$end = (Get-Date).AddSeconds($timeout)

while ((Get-Date) -le $end) {
    try {
        $socket = New-Object System.Net.Sockets.TcpClient($hostname, $port)
        $socket.Close()

        # Invoke-Sqlcmd -ServerInstance "sqlserver" -Database "master" -Username "SA" -Password "P@ssw0rd123" -InputFile "C:\scripts\CreateDatabase.sql"
        #sqlcmd -S sqlserver -U SA -P P@ssw0rd123 -d master -Q 'SELECT * FROM SYS.OBJECTS';

        Write-Output "Start of sqlcmd -S sqlserver -U SA -P P@ssw0rd123 -d master -Q 'SELECT * FROM SYS.OBJECTS';"
        #Start-Process sqlcmd -ArgumentList "-S", "sqlserver", "-U", "SA", "-P", "P@ssw0rd123", "-d", "master", "-Q", "SELECT * FROM SYS.OBJECTS" -Verb RunAs
        Start-Process sqlcmd -ArgumentList "-S", "sqlserver", "-U", "SA", "-P", "P@ssw0rd123", "-d", "master", "-Q", "SELECT * FROM SYS.OBJECTS"
        Write-Output "End of sqlcmd -S sqlserver -U SA -P P@ssw0rd123 -d master -Q 'SELECT * FROM SYS.OBJECTS';"
        return
    }
    catch {
        # Do nothing
    }

    Start-Sleep -Seconds 1
}

throw "Timeout waiting for ${hostname}:${port}"
