# ProjectManagementSystem.Infrastructure

This project handles data access and business logic implementation.

## Project Structure

### /Data
Database context and configurations:
- `ApplicationDbContext.cs`: EF Core database context
- `DbInitializer.cs`: Database seeding and initialization

### /Repositories
Repository implementations:
- `BaseRepository.cs`: Generic repository implementation
- `CustomerRepository.cs`: Customer data access
- `ProjectRepository.cs`: Project data access with special operations
- `ProjectManagerRepository.cs`: Project manager data access
- `ServiceRepository.cs`: Service data access

### /Services
Business logic implementations:
- `BaseService.cs`: Generic service implementation
- `CustomerService.cs`: Customer business logic
- `ProjectService.cs`: Project business logic with transactions
- `ProjectManagerService.cs`: Project manager operations
- `ServiceEntityService.cs`: Service-related operations

### /Factories
Factory pattern implementations:
- `ProjectFactory.cs`: Creates project instances

## Key Features
- Entity Framework Core implementation
- Code-First approach
- Transaction management
- Generic repository pattern
- Async/await implementation
- Database migrations
- Data seeding