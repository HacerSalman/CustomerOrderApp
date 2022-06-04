# CustomerOrderApp

## Getting Started
The solution contains 3 different projects. They are Api,Data,Core.
Api project contains Rest api endpoints.
Data contains entities,enums,context and migrations.
Core contains repositories, unitOfWork, services, DTO, models and utils.
To run these projects on your own computer, add the CUSTOMER_ORDER_DB_CONNECTION, CUSTOMER_ORDER_JWT_KEY, CUSTOMER_ORDER_VALID_ISSUER,
CUSTOMER_ORDER_VALID_AUDIENCE variables to the environmet variables and add 
the connection string of the mysql database you set on your computer as the value. 
After that write  `dotnet ef database update` command to Package Manager Console Window for generate database tables.
You can add jwt token to swagger and call endpoints.

## Architecture
This repository uses Repository Patterns and UnitOfWork. Also uses Interface Segregation and Single Responsibility SOLID principles.
Instead of gathering all responsibilities in a single interface, we used more customized interfaces, 
thus becoming compatible with the Interface Segregation Principle.Thanks to the Repository Pattern, the Single Responsibility 
principle is followed by using a separate method for each process.

## Used technologies
.Net 5, Entity Framework, AutoMapper, Pomelo, Repository Pattern, UnitOfWork, MySql, Jwt, Swagger, Fluent Api
