## Dependencies

    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="1.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version= "1.1.1"/>

    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />

## Load Db connection string from appsettings.json
    {
        "connectionStrings": {
            "libraryDBConnectionString": "Server=localhost;Database=LibraryDB;User Id=sa;Password=Sql@1433"
        }
    }

    Startup.cs / ConfigureServices()
    var connectionString = Configuration["connectionStrings:libraryDBConnectionString"];
    services.AddDbContext<LibraryContext>(o => o.UseSqlServer(connectionString));

## Create Database
    $ dotnet ef dbcontext list
    $ dotnet ef dbcontext info
    
    $ dotnet ef migrations add init
    $ dotnet ef database update