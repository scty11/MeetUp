# MeetUp

A API to enable the booking of seats for a meetup.

The solution is ready to run on download as i have included SQLite as a database and i have added swagger to enable easy testing of the api. The intergration tests should also be able to run on download, make sure to use VS 2107.

This is designed to give an overview of techniques used to build an api for example a microservice.

Tools I have used

1. Fluentvalidations to validate the create booking dto.
2. Automapper to easily map the domain and dto objects.
3. Entity framework code first to enable easy creation and testing of the project.
4. Using .net core 2.0.
5. Xunit to create unit and intergration tests using .net core's TestServer.
7. Swagger to provide an easy interface to test the API.
8. Serilog to provide global logging.

Things to do.

1. combine the paging action into a single action.
2. validate the database objects and add fluent api configs.
3. ceate a generic base repository when more actions are added.
4. possible create a unit of work for complex logic.
5. Add a TestStartUp for intergration tests instead of using current StartUp
