# OziKargo
- University 2nd year C# course project.
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


## 📸 Screenshots
# Main Screen
<img width="847" height="546" alt="Ekran görüntüsü 2025-08-06 195905" src="https://github.com/user-attachments/assets/8f66e0a1-874f-41a7-a245-8e2e2af7ef42" />
<img width="843" height="544" alt="Ekran görüntüsü 2025-08-06 195933" src="https://github.com/user-attachments/assets/e4605b80-7a2c-4a4c-ae2c-ebf4e50be75e" />

# Customer Tracking Screen
<img width="1574" height="485" alt="Ekran görüntüsü 2025-08-06 195957" src="https://github.com/user-attachments/assets/e75605f0-db55-4afe-b540-7bd274a1c06e" />

# Cargo Person Login and Panel Screen
<img width="510" height="440" alt="Ekran görüntüsü 2025-08-06 200030" src="https://github.com/user-attachments/assets/b0e2724f-e942-44ef-9a70-c1c76aa7f2b1" />
<img width="1375" height="1009" alt="Ekran görüntüsü 2025-08-06 200052" src="https://github.com/user-attachments/assets/02d95b13-04f8-4ca3-8828-f176ddae7e49" />
<img width="1680" height="967" alt="Ekran görüntüsü 2025-08-06 200115" src="https://github.com/user-attachments/assets/97b5d18d-9c5d-478a-b476-4861577dd5a4" />

# Admin Login and Panel Screen
<img width="509" height="445" alt="Ekran görüntüsü 2025-08-06 200146" src="https://github.com/user-attachments/assets/60d8e191-55b0-474f-a630-45b5e139241c" />
<img width="1320" height="778" alt="Ekran görüntüsü 2025-08-06 200207" src="https://github.com/user-attachments/assets/23c91c10-d46c-44d8-8dda-e5091a4d52ec" />

