# do everything the easy way
# except for the security-related bits
# terraform setup... easy and hard way
# terraform template with all entities from example
# running migrations... simple and the hard way

- Postgres'ing the example
- Getting REST up and running locally
- Getting deployed to Azure unsafely
  - using new web template 
  - delete old web template
- Getting deployed to Azure safely
  - add key vault to resource group 
  - add connection string
  - add Azure Key Vault provider in code
- Https
- Setting up Authentication
- Terraforming

Learnings:
- DB Models know nothings about DatabaseContexts
- Contexts know about models (have properties like DbSet<MyModel> MyModel)
- Razor Pages do not connect to models directly
- Razor Pages hook up to aformentioned DbSet properties on Contexts

List:
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

