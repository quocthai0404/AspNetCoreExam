# AspdotNetCoreMVCExam
ABC Company Support System
This project is a support system for ABC Company. It is built using ASP.NET Core MVC, Entity Framework Core, and AJAX. The system has three user roles:

**Admin:**
Can log in to the system with admin privileges. <br>
Can view a list of employees. <br>
Can create new employee accounts. <br>
Can view and assign support requests. <br>
Can search for requests by time range and priority. <br>
**Support Staff:**
Can log in to the system with support staff privileges. <br>
Can view assigned support requests. <br>
Can search for requests by time range and priority. <br>
Can update their account information. <br>
**Employee:**
Can log in to the system with employee privileges. <br>
Can submit support requests. <br>
Can view their submitted support requests. <br>
Can search for their submitted requests by time range and priority. <br>
Can update their account information. <br>
**Database** <br>
The database for the system is shown in the following diagram:

![Database diagram](https://camo.githubusercontent.com/bfeb65d0f971c17e6e3db4433fe1a067a1a17ef0e3464922de2908fd6e1e22e6/68747470733a2f2f64726976652e676f6f676c652e636f6d2f75633f6578706f72743d646f776e6c6f61642669643d31537434554b527a4b785262527067314e4844773335704b473664717979436d5f)

**Features**
**The system has the following features:**

**Authentication and authorization:** Users must authenticate with a username and password before they can access the system. Users are authorized to perform certain actions based on their role. <br>
**Employee management:** Admins can create new employee accounts and view a list of all employees. <br>
**Support request management:** Employees can submit support requests, and support staff can view and assign requests. <br>
**Search:** Users can search for requests by time range and priority. <br>
**Account management:** Users can update their account information. <br> 
**#Technologies**
The system is built using the following technologies:

**ASP.NET Core MVC:** A web application framework for building ASP.NET Core web applications. <br>
**Entity Framework Core:** An object-relational mapper (ORM) for .NET. <br>
**AJAX:** A set of web development techniques that use asynchronous HTTP requests to make web pages more responsive. <br>
**LINQ:** A query language for working with data in .NET. <br>

#Getting Started
To get started with the system, you will need to have the following installed: <br>

Visual Studio 2019: A development environment for .NET. <br>
.NET Core SDK: A software development kit for .NET Core. <br>
SQL Server: A relational database management system. <br>
Once you have these installed, you can clone the repository and build the solution. Then, you can run the application in Visual Studio. <br>

Documentation
For more detailed documentation, please refer to the following:

ASP.NET Core MVC documentation: https://learn.microsoft.com/en-us/aspnet/mvc/
Entity Framework Core documentation: https://learn.microsoft.com/en-us/ef/
AJAX documentation: https://developer.mozilla.org/en-US/docs/Glossary/AJAX
LINQ documentation: https://learn.microsoft.com/en-us/dotnet/csharp/linq/
