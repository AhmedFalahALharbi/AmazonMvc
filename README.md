# AmazonMVC Order Management

## Overview
This project is an ASP.NET MVC web application for managing customer orders. It displays order details, including order status, items, total price, and delivery timeline.

## Features
- View detailed order information.
- Display order items dynamically.
- Show order status with badges.
- Interactive delivery timeline.
- Bootstrap-based responsive design.

## Technologies Used
- ASP.NET Core MVC
- Razor Views
- C#
- Bootstrap 5
- Entity Framework Core (EF Core)
- SQL Server

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repository.git
   ```
2. Navigate to the project directory:
   ```sh
   cd AmazonMVC
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Update database:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run
   ```

## Project Structure
```
AmazonMVC/
│-- Controllers/
│   ├── OrderController.cs
│-- Models/
│   ├── Order.cs
│   ├── OrderItem.cs
│-- Views/
│   ├── Order/
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│-- wwwroot/
│-- appsettings.json
│-- Startup.cs
```

## Usage
1. Navigate to the `Orders` page.
2. Click on an order to view its details.
3. Check the order timeline to see its progress.

## API Endpoints
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/Order/Index` | Displays all orders |
| GET | `/Order/Details/{id}` | Displays details of a specific order |

## License
This project is licensed under the MIT License.

## Author
[Your Name]

