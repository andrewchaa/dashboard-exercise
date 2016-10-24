invoke-sqlcmd -inputfile ".\2.1.create-strategies.sql" -serverinstance "." -database "Dashboard3"
invoke-sqlcmd -inputfile ".\2.2.create-capitals.sql" -serverinstance "." -database "Dashboard3"
invoke-sqlcmd -inputfile ".\2.3.create-pnls.sql" -serverinstance "." -database "Dashboard3"
