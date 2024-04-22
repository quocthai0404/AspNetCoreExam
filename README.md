# AspdotNetCoreMVCExam
ABC Company Support System
This project is a support system for ABC Company. It is built using ASP.NET Core MVC, Entity Framework Core, and AJAX. The system has three user roles:

Admin:
Can log in to the system with admin privileges.
Can view a list of employees.
Can create new employee accounts.
Can view and assign support requests.
Can search for requests by time range and priority.
Support Staff:
Can log in to the system with support staff privileges.
Can view assigned support requests.
Can search for requests by time range and priority.
Can update their account information.
Employee:
Can log in to the system with employee privileges.
Can submit support requests.
Can view their submitted support requests.
Can search for their submitted requests by time range and priority.
Can update their account information.
Database
The database for the system is shown in the following diagram:

[Database diagram]

Features
The system has the following features:

Authentication and authorization: Users must authenticate with a username and password before they can access the system. Users are authorized to perform certain actions based on their role.
Employee management: Admins can create new employee accounts and view a list of all employees.
Support request management: Employees can submit support requests, and support staff can view and assign requests.
Search: Users can search for requests by time range and priority.
Account management: Users can update their account information.
Technologies
The system is built using the following technologies:

ASP.NET Core MVC: A web application framework for building ASP.NET Core web applications.
Entity Framework Core: An object-relational mapper (ORM) for .NET.
AJAX: A set of web development techniques that use asynchronous HTTP requests to make web pages more responsive.
LINQ: A query language for working with data in .NET.
Getting Started
To get started with the system, you will need to have the following installed:

Visual Studio 2019: A development environment for .NET.
.NET Core SDK: A software development kit for .NET Core.
SQL Server: A relational database management system.
Once you have these installed, you can clone the repository and build the solution. Then, you can run the application in Visual Studio.

Documentation
For more detailed documentation, please refer to the following:

ASP.NET Core MVC documentation: https://learn.microsoft.com/en-us/aspnet/mvc/
Entity Framework Core documentation: https://learn.microsoft.com/en-us/ef/
AJAX documentation: https://developer.mozilla.org/en-US/docs/Glossary/AJAX
LINQ documentation: https://learn.microsoft.com/en-us/dotnet/csharp/linq/
