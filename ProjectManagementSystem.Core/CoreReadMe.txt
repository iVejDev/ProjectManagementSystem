# ProjectManagementSystem.Core

This project serves as the core domain layer of the application, containing all business logic and domain models.

## Project Structure

### Entities
Domain models representing the business objects:
- `BaseEntity.cs`: Abstract base class for all entities
- `Customer.cs`: Customer entity with related projects
- `Project.cs`: Main project entity with relationships
- `ProjectManager.cs`: Project manager entity
- `Service.cs`: Service offerings entity

### Enums
Enumeration types:
- `ProjectStatus.cs`: Defines project states (NotStarted, InProgress, Completed)

### Interfaces
Interface definitions for the application:

#### /Repositories
Repository interfaces for data access:
- `IBaseRepository.cs`: Generic repository interface
- `ICustomerRepository.cs`: Customer-specific operations
- `IProjectRepository.cs`: Project-specific operations
- `IProjectManagerRepository.cs`: Project manager operations
- `IServiceRepository.cs`: Service-related operations

#### /Services
Service interfaces for business logic:
- `IBaseService.cs`: Generic service interface
- `ICustomerService.cs`: Customer business operations
- `IProjectService.cs`: Project business operations
- `IProjectManagerService.cs`: Project manager operations
- `IServiceEntityService.cs`: Service-related operations

#### /Factories
Factory interfaces for object creation:
- `IProjectFactory.cs`: Project creation factory

### DTOs
Data Transfer Objects for external communication (if any)

## Key Features
- Clean separation of concerns
- Domain-driven design principles
- SOLID principle implementation
- Interface-based design
- Rich domain model