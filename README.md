## 🚧 Current Project

# 🚗 DVLD - Driving License Management System

## 📸 Screenshots

![Dashboard](Images/Dashboard.png)

# DVLD - Driving License Management System

A Windows Forms application for managing driving licenses and related operations.

## Project Architecture

The project is organized using a layered architecture to separate responsibilities and make the system easier to maintain, develop, and extend.

### 1. Presentation Layer

The Presentation Layer contains the Windows Forms user interface and handles interaction with the user.

It includes:

- `ApplicationsTypes/` - Application type related forms and functionality
- `People/` - Forms for managing people
- `Users/` - Forms for managing system users
- `Properties/` - Project properties
- `Settings/` - Application settings
- `Form1.cs` - Main form
- `Form1.Designer.cs` - Main form designer code
- `Program.cs` - Application entry point
- `usControlPanel.cs` - Control panel user control
- `usControlPanel.Designer.cs` - Control panel designer code

### 2. Business Layer

The Business Layer contains the application's business logic and rules.

It is responsible for processing application operations and communicating with the Data Access Layer.

### 3. Data Access Layer

The Data Access Layer is responsible for communicating with the database.

It contains the classes and methods used to:

- Connect to the database
- Retrieve data
- Insert data
- Update data
- Delete data

### 4. DTO Project

The DTO Project contains Data Transfer Objects (DTOs) used to transfer data between the different layers of the application.
The DTO Project is used to transfer data between the different layers.

------------------------------------------------------------------------------------------------------------------------------------
Architecture Flow
Presentation Layer
        ↓
Business Layer
        ↓
Data Access Layer
        ↓
Database

---------------------------------------------------------------------------------------------------------------------------------------
Technologies
C#
.NET
Windows Forms
SQL Server
ADO.NET

---------------------------------------------------------------------------------------------------------------------------------------------
Purpose

The main goal of this project is to build a structured Driving License Management System using a layered architecture, keeping the user interface, business logic, and database operations separated.

The project is designed to provide a clear and maintainable structure that makes it easier to develop, test, and extend the system.
