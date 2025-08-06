# OziKargo
This project was developed as a final exam assignment for my university course using C# and SQL Server. The application is built with Entity Framework and LINQ for database operations.

🔧 Features:
Users can enter their tracking number and full name to view real-time information about their cargo.

A login screen is provided for personnel; entering a valid username and password allows access to the internal system.

After login, personnel can navigate to the cargo registration page, where they can enter new shipments using multiple values from comboboxes (as required by the instructor).

There is a separate Admin panel that requires a different admin username and password.

Admins can:

View customer data

Add new customers

Edit existing records

Delete customer records

The project interface is created with Windows Forms, and all database interactions are handled using Entity Framework (EF) and LINQ queries.

## Database Setup

To run this project:

1. Open SQL Server Management Studio (SSMS).
2. Run the `DatabaseScripts/Cargo_DB_Script.sql` script to create the database and tables.
3. Update the connection string in `app.config` if needed.
4. Build and run the C# project.
