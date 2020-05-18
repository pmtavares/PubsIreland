#### MySQL Database


### Commands Dotnet

>> Add Migration using EF: dotnet ef migrations add InitialCommitSetupProject -p Persistence/ -s API/


>> Update Database: dotnet ef database update -p Persistence/ -s API/

>> Remove Migration: dotnet ef migrations remove --project Persistence -s API

Watch Run: dotnet watch run (works only inside the startup project)


### Back end installation



. MYSQL: Pomelo.EntityFrameworkCore.MySql 2.2.0

. Microsoft.EntityFrameworkCore 2.2.6: Persistence
. Microsoft.EntityFrameworkCore.Design: Persistence
. AutoMapper.Extensions.Microsoft.DependencyInjection: Application

