# asp-net-core-api-base
This is a base solution for web api using .net core

This solution follows N-layers structure with 3 layers:
  - API Web Presenter layer
  - Business Logic Layer - BLL
  - Data Access Layer - DAL
  
Read more at : https://www.c-sharpcorner.com/article/onion-architecture-in-asp-net-core-mvc/

Benefits of this solution:
  - provide an easy to setup and run base solution
  - easy to expand and maintain
  - use swagger for API specifications
  - use configuration extensions to auto register singleton for dependency injection, so no need to register each time you create new service and iservice

Steps to run:
  - clone repository
  - change connection string at appsetting.json in project API (API layer)
  - this solution use sql server and default db management. If you use mysql or other db, change OnConfiguring in 
DAL/Contexts/DatabaseContext.cs. Read more at: https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions
  - at package manager console, switch target project to DAL (DAL layer)
  - type : 
    + add-migration Initial 
    + update-database
  - after that, check your db if it created new db successfully

Steps to add new model API:
  - at DAL layer: add new model to Models folder
  - at BLL layer: add new I[Model]Service and [Model]Service to Services folder
  - at API layer: add new controller to Controllers foler
  - that's all. see an example of get and post movie at : https://github.com/stevelee2497/asp-net-core-api-base/commit/2a13334787987d5af61ef03b110c6c18e7647b8a
