# goalsystems

## Inventory manager

1. Run the api server

`cd .\GoalSystems.API\` 

`dotnet run`  

It will be listening on: https://localhost:7116

2. In another terminal, run the main application

`cd .\GoalSystems.Application\`  
`dotnet run`  

It will be listening on: https://localhost:7236 . After click in the link, the browser redirects to https://localhost:44492 , where the SPA development server will be running.

3. The UI is depeloped in React. However, the api can also be accesible using Swagger. The user can list, add and delete items to the inventory.

4. For notification when an item expires, a warning badge will be shown in the list page. For notification when an item have been removed, an alert will be shown in the list page.

5. Run the tests

`cd .\GoalSystems.UnitTests\`  
`dotnet test`

6. Third-party nuget package used: Moq and FluentAsserts, for testing.