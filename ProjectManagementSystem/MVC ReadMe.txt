

The MVC web application project handling the user interface and application flow.

## Project Structure

### /Controllers
MVC Controllers:
- `HomeController.cs`: Main navigation and about page
- `ProjectsController.cs`: Project CRUD operations
- `CustomersController.cs`: Customer management
- `ProjectManagersController.cs`: Project manager functions
- `ServicesController.cs`: Service management

### /Views
Razor views organized by controller:
- `/Home`: Main views and about page
- `/Projects`: Project management views
- `/Customers`: Customer management views
- `/ProjectManagers`: Project manager views
- `/Services`: Service management views
- `/Shared`: Layout and partial views

### /ViewModels
View-specific models:
- `CreateProjectViewModel.cs`: Project creation
- `EditProjectViewModel.cs`: Project editing
- `ProjectViewModel.cs`: Project display
- Similar models for other entities

### /wwwroot
Static files:
- `/css`: Style sheets including site.css
- `/js`: JavaScript files
- `/lib`: Third-party libraries

## Frontend Features
- Dark/Light mode theme switching
- Interactive UI elements
- Responsive design
- Bootstrap integration
- Custom animations
- Splash screen
- Modern styling with CSS variables

## Key Features
- MVC architecture
- Responsive UI
- Theme support
- CRUD operations
- Form validation
- Error handling