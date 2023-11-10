# Game Stor Api

## Starting SQL Server

```powershell
$sa_password ="[SA password here]"
$ docker run -d -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 
-v sqlvolume:var/opt/mssql  -d --rm --name my-mssql mcr.microsoft.com/mssql/server:2022-latest
```


