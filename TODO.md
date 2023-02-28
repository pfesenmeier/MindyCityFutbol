# do everything the easy way
# except for the security-related bits
# terraform setup... easy and hard way
# terraform template with all entities from example
# running migrations... simple and the hard way

- Postgres'ing the example
- Getting REST up and running locally
- Getting deployed to Azure unsafely
- Getting deployed to Azure safely
- Https
- Terraforming

List:
Added Postgres to dependencies
  - Add Microsoft.EntityFrameworkCore.Design package for migration createion (I think)
  - Add Npgsql.EntityFrameworkCore.PostgreSQL pckg
  - scaffold context using `dotnet ef dbcontext scaffold`
  - adjust scaffolded DB context: 
    - move connection string from context to configuration (appsettings)
    - move "useNpgsql" call from context to Program.cs 
      - here is the builder instance, who has access to aspnet configuration (connection string in appsettings) by default
