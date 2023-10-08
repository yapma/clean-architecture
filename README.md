# Clean Architecture Template with ASP.NET v6
This solution presents a robust implementation of the [Clean Architecture] Principles using ASP.NET Core, following the principles of domain-driven design. By adhering to these principles, the codebase is structured in a way that promotes modularization, maintainability, and extensibility.

If you find this project useful, please give it a star. Thanks! ⭐

## Getting Started
- Download this Repository (and modify as needed)

To get started based on this repository, you need to get a copy locally. You have three options: **fork**, **clone**, or **download**.

1- If you intend to experiment with the project or use it as a foundation for an application, it is recommended to **download** the repository, unblock the zip file, and extract it into a new folder.

2- **Fork** this repository only if your intention is to submit a pull request or if you desire to maintain a personal copy of the repository in your GitHub account.

3- If you are a contributor with commit access, it is advisable to **clone** this repository.

## Technologies and Important Libraries
- [ASP.Net 6]
- [EF Core 6]
- [Mapster]
- [Result]
- [xUnit], [Moq]
## Overview
The Core section serves as the focal point of the Clean Architecture design, with all other project dependencies directed towards it. As a result, it relies on minimal external dependencies. The Core is responsible for encapsulating the Domain Model.
### Domain
The Domain layer encompasses a collection of essential business domain objects, including entities, contracts, data transfer objects (DTOs), and enums. It is crucial for the Domain layer to be independent and decoupled from other layers.
### Application
The Application layer is responsible for housing the business logic of the system. It depends solely on the Domain layer for its functionality. In this solution, logic implementation is carried out through services. Alternatively, you can consider utilizing the Command Query Responsibility Segregation (CQRS) pattern within this layer.
### Infrastructure
The Infrastructure layer encompasses classes that handle the interaction with external resources, such as file systems, web services, SMTP, and more.
### Presentation
The Presentation section is responsible for providing various services, such as REST APIs, GraphQL, and more. It can also include web UI projects.

## Support
If you are having problems, please let me know by raising a new issue.

## License
This project is licensed with the MIT license.

   [Clean Architecture]: <https://blog.cleancoder.com/uncle-bob/2011/11/22/Clean-Architecture.html>
   [ASP.Net 6]: <https://github.com/dotnet/aspnetcore>
   [EF Core 6]: <https://github.com/dotnet/efcore>
   [Mapster]: <https://github.com/MapsterMapper/Mapster>
   [Result]: <https://github.com/ardalis/Result>
   [xUnit]: <https://github.com/xunit/xunit>
   [Moq]: <https://github.com/devlooped/moq>