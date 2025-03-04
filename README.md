# 📊 Project Management System

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-7.0-512BD4?style=flat-square&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-7.0-purple?style=flat-square&logo=.net)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=flat-square&logo=bootstrap)
![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)

A comprehensive project management solution built with ASP.NET Core MVC that helps organizations efficiently manage projects, customers, team members, and services in one centralized system.



## 🌟 Key Features

### 📋 Project Management
- **Complete Project Lifecycle** - Track projects from inception to completion
- **Automated Project Numbers** - System generates unique project identifiers
- **Project Status Tracking** - Monitor progress with customizable status workflows
- **Timeline Management** - Set and track project deadlines and milestones

### 👥 Customer Management
- **Customer Database** - Store and manage all customer information
- **Project History** - View complete project history for each customer
- **Contact Management** - Track multiple contacts per customer

### 👨‍💼 Team Management
- **Project Manager Assignment** - Assign and track project managers
- **Workload Balancing** - View project distribution across managers
- **Performance Tracking** - Monitor project completion rates and timelines

### 💰 Service & Billing
- **Service Rate Management** - Configure and update service rates
- **Billing Calculation** - Automatic calculation of project costs
- **Financial Reporting** - Generate financial summaries per project or customer

### 🎨 User Experience
- **Dark/Light Mode** - Toggle between visual themes
- **Responsive Design** - Works seamlessly on all device sizes
- **Interactive Interface** - Smooth animations and intuitive controls

## 🏗️ Technical Architecture

### Backend Implementation
The system is built on solid architectural principles:

- **Clean Architecture** - Clear separation of concerns for maintainability
- **Entity Framework Core** - Code-First approach for database management
- **Repository Pattern** - Generic repositories for consistent data access
- **Service Layer** - Encapsulates business logic away from controllers
- **Factory Pattern** - Creates standardized instances of domain objects
- **Transaction Management** - Ensures data integrity across operations
- **Asynchronous Programming** - Non-blocking operations for better performance
- **SOLID Principles** - Follows best practices in software design
- **Dependency Injection** - Loose coupling between components

### Frontend Features
The user interface focuses on usability and aesthetics:

- **Bootstrap Framework** - Mobile-first responsive design system
- **Custom CSS Variables** - Consistent theming across the application
- **JavaScript Enhancements** - Dynamic content loading and interactions
- **Interactive Components** - Cards with hover effects and visual feedback
- **Data Tables** - Sortable and filterable data presentation
- **Theme Persistence** - User preferences saved between sessions
- **Splash Screen** - Engaging application entry experience

## 📂 Project Structure

```
ProjectManagementSystem/
├── ProjectManagement.Core/           # Domain models and business logic
│   ├── Entities/                     # Domain entities (Project, Customer, etc.)
│   ├── Interfaces/                   # Repository and service interfaces
│   ├── Factories/                    # Object creation factories
│   └── Constants/                    # System-wide constants and enums
│
├── ProjectManagement.Infrastructure/ # Data access and service implementations
│   ├── Data/                         # DbContext and migrations
│   ├── Repositories/                 # Data access implementations
│   ├── Services/                     # Business logic implementations
│   └── Extensions/                   # Service registration extensions
│
└── ProjectManagement.Web/            # User interface and API
    ├── Controllers/                  # MVC controllers
    ├── ViewModels/                   # View-specific models
    ├── Views/                        # Razor views
    │   ├── Projects/                 # Project-related views
    │   ├── Customers/                # Customer-related views
    │   ├── ProjectManagers/          # Manager-related views
    │   └── Services/                 # Service-related views
    ├── wwwroot/                      # Static assets (CSS, JS, images)
    │   ├── css/                      # Stylesheets
    │   ├── js/                       # JavaScript files
    │   └── lib/                      # Third-party libraries
    └── Helpers/                      # View helpers and utilities
```

## 🚀 Getting Started

### Prerequisites
- **.NET 7.0 SDK** or later
- **Visual Studio 2022** or compatible IDE
- **SQL Server** (LocalDB, Express, or full edition)

### Installation Steps

1. **Clone the repository**
   ```
   git clone https://github.com/yourusername/ProjectManagementSystem.git
   cd ProjectManagementSystem
   ```

2. **Restore dependencies**
   ```
   dotnet restore
   ```

3. **Set up the database**
   
   Update the connection string in `appsettings.json` if needed, then run:
   ```
   dotnet ef database update --project ProjectManagement.Infrastructure --startup-project ProjectManagement.Web
   ```

4. **Run the application**
   ```
   cd ProjectManagement.Web
   dotnet run
   ```

5. **Access the application**
   
   Open your browser and navigate to `https://localhost:5001`

## 📱 Usage Guide

### Managing Projects
- Create new projects from the Projects dashboard
- Assign customers, project managers, and services
- Track progress by updating project status
- View project details including timeline and financial summaries

### Managing Customers
- Add new customers with contact information
- View all projects associated with each customer
- Update customer information as needed

### Managing Project Managers
- Add and assign project managers to projects
- Balance workload across your team
- Track performance metrics

### Service Configuration
- Define service categories and rates
- Apply services to projects
- Calculate project costs based on services

### Theme Preferences
- Toggle between dark and light modes
- Settings are remembered for future sessions

## 👨‍💻 Developer Information

This Project Management System was developed by Ilir, a first-year student at EC Education studying Web Development with .NET. It was created as part of the Data Storage course, demonstrating proficiency in modern web development techniques and best practices.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🔍 Implementation Notes

The application demonstrates several software design patterns and architectural approaches:

- **Repository Pattern** provides a clean data access layer, abstracting the underlying database operations
- **Service Layer** implements business logic that can be reused across different controllers
- **Factory Pattern** centralizes complex object creation, improving maintainability
- **Dependency Injection** allows for loose coupling and easier unit testing
- **Clean Architecture** separates concerns to improve code organization and scalability

## 🌟 Future Enhancements

Potential areas for future development:

- User authentication and role-based permissions
- Email notifications for project milestones
- Document management capabilities
- Time tracking integration
- Advanced reporting and analytics
- Mobile application

---

&copy; 2025 Ilir. All rights reserved.
