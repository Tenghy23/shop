# Domain-Driven Design for Microservice Architecture .Net6

First attempt on creating an Ecommerce store with a DDD driven architecture design. Documentation in Progress.

- [Apply CQRS & DDD in MA](#1)
- [Implement reads/queries in a CQRS microservice](#2)
- [Sample DDD Layer Design in MA](#3)
- [Domain Implementation](#4)
- [Infrastructure Implementation](#5)

<h1 id="1">Apply CQRS & DDD in MA</h1>

[Applying simplified CQRS and DDD patterns in a microservice | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns)

- CQRS is an architectural pattern that separates the models for reading and writing data. [Command Query Separation (CQS)](https://martinfowler.com/bliki/CommandQuerySeparation.html)

The basic idea is that you can divide a system's operations into two sharply separated categories:

-   Queries. These queries return a result and do not change the state of the system, and they are free of side effects.
    
-   Commands. These commands change the state of a system.

![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/apply-simplified-microservice-cqrs-ddd-patterns/simplified-cqrs-ddd-microservice.png)

<h1 id="2">Implement reads/queries in a CQRS microservice</h1>

[Implementing reads/queries in a CQRS microservice | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/cqrs-microservice-reads)

![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/cqrs-microservice-reads/simple-approach-cqrs-queries.png)

<h1 id="3">Sample DDD Layer Design in MA</h1>

![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/ddd-oriented-microservice/domain-driven-design-microservice.png)
![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/ddd-oriented-microservice/ddd-service-layer-dependencies.png)

[Designing a DDD-oriented microservice | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

### Application Layer

- Defines the jobs the software is supposed to do and directs the expressive domain objects to work out problems
- Layer is kept thin, does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down

### Domain Layer
- Responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure.

### Infrastructure Layer
- The infrastructure layer is how the data that is initially held in domain entities (in memory) is persisted in databases or another persistent store. An example is using Entity Framework Core code to implement the Repository pattern classes that use a DBContext to persist data in a relational database.


<h1 id="4">Domain Implementation</h1>

[Implementing a microservice domain model with .NET | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model)

- DDD talks about problems as domains. It describes independent problem areas as Bounded Contexts (each Bounded Context correlates to a microservice) 

- DDD approaches should be applied only if you are implementing complex microservices with significant business rules. Simpler responsibilities, like a CRUD service, can be managed with simpler approaches


	
![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/net-core-microservice-domain-model/ordering-microservice-container.png)

### Structure aggregates in a custom .NET Standard library

- An aggregate refers to a cluster of domain objects grouped together to match transactional consistency

- Transactional consistency means that an aggregate is guaranteed to be consistent and up to date at the end of a business action

![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/net-core-microservice-domain-model/vs-solution-explorer-order-aggregate.png)

<h1 id="5">Infrastructure Implementation</h1>

- Data persistence components provide access to the data hosted within the boundaries of a microservice
- Repositories are classes or components that encapsulate the logic required to access data sources
- For each aggregate or aggregate root, you should create one repository class. In a microservice based on Domain-Driven Design (DDD) patterns, the only channel you should use to update the database should be the repositories. This is because they have a one-to-one relationship with the aggregate root, which controls the aggregate's invariants and transactional consistency
- Repository allows you to populate data in memory that comes from the database in the form of the domain entities. Once the entities are in memory, they can be changed and then persisted back to the database through transactions.

![](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/infrastructure-persistence-layer-design/repository-aggregate-database-table-relationships.png)

