Next things on agenda:
  - Setting up Authentication
  - Setting up Authorization (superuser, admins, players, coaches)
  - Terraforming

Learnings:
- DB Models know nothings about DatabaseContexts
- Contexts know about models (have properties like DbSet<MyModel> MyModel)
- Razor Pages do not connect to models directly
- Razor Pages hook up to aformentioned DbSet properties on Contexts

List of things done:
1. Added Postgres to dependencies
  - Add Microsoft.EntityFrameworkCore.Design package for migration createion (I think)
  - Add Npgsql.EntityFrameworkCore.PostgreSQL pckg
  - scaffold context using `dotnet ef dbcontext scaffold`
  - adjust scaffolded DB context: 
    - move connection string from context to configuration (appsettings)
    - move "useNpgsql" call from context to Program.cs 
      - here is the builder instance, who has access to aspnet configuration (connection string in appsettings) by default
2. Scaffolded CRUD actions
  - installed aspnet-codegenerator from `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 6`
  - created CRUD pages with ` dotnet aspnet-codegenerator razorpage -m Team -dc MindyCityFutbolContext -udl -outDir Pages`
3. Deploy to Azure
  - Select "Web App + Database" from the Azure marketplace
  - Setup automatic github deployments with Github Actions
4. Fix Deployment Errors
  - Add global.json with sdk.version = "6". ef tool defaults to latest, but latest sdk incompatible with bundle tool.
  - Add line to generated github action to create a migration bundle
5. Automate finding connection string on Azure
  - add enviroment variable configuration provider who reads from `POSTGRESQLCONNSTR_` variables to find connection strings (this is the Azure App Services convention)
  - change auto-generated connection string to use the Ssl Mode Npsql wants: `VerifyFull` or `VerifyCA`, not the non-standard `Require`
  - in Azure Portal, change name of connection string to `ConnectionStrings__MindyCityFutbolContext` (overides appsettings ConnectionStrings.MindyCityFutbolContext)
  - call migrate script from within SSH session with this value
  - did not have to setup key vault
6. Https works out of the box on Azure... that is nice
