# Agri-Energy Connect - Prototype Web Application

# ORGINAL REPO 
Had a Issue with .net was using the ide rider on my mac and tried it on my virtual machine and it did not work transfer all the code to this repo thats why the commits are so low 
https://github.com/Joshua-shields/AgriEnergyConnect_st10255631_MVC.git old repo 

![Screenshot 2025-05-12 at 13 44 11](https://github.com/user-attachments/assets/76d52350-9383-4f5c-b4f1-6827fbb64bbd)


## Table of Contents

1. [Project Overview](#project-overview)
2. [Prerequisites](#prerequisites)
3. [Setup Instructions](#setup-instructions)
4. [Database Setup](#database-setup)
5. [Building and Running the Prototype](#building-and-running-the-prototype)
6. [User Roles and Credentials](#user-roles-and-credentials)
7. [System Functionalities](#system-functionalities)
8. [Tech Stack](#tech-stack)
9. [Notes and Troubleshooting](#notes-and-troubleshooting)
10. [References](#references)
11. [Annexure of AI Use](#annexure-of-ai-use)

## Project Overview

Portfolio of Evidence for the PROG7311 (Programming 3A) 
The prototype demonstrates core functionalities for a platform designed to bridge the gap between the agricultural sector and green energy technology providers. It includes features for two main user roles: Farmers and Employees.



## Prerequisites
NET 8 SDK if not installed https://dotnet.microsoft.com/en-us/download/dotnet/8.0
Visual Studio 2022
SQLite, file-based

## Setup Instructions
* Clone repo or unzip project
* Open the solution folder
* When code is run DB with be seeded(populated with data)

## Database setup
* On first run, the database file called agrienergy_connect.db will be created in the project directory.

![Screenshot 2025-05-12 at 16 15 23](https://github.com/user-attachments/assets/51d0e893-dbb9-4f79-926a-b481ca42dd7b)

* Data has already been entered to the dd employees and farmers as well as products using this method
  
![Screenshot 2025-05-13 at 18 29 09](https://github.com/user-attachments/assets/a5207591-923f-4014-9420-9f7529481224)

![Screenshot 2025-05-13 at 18 30 05](https://github.com/user-attachments/assets/ee8f8200-9f0a-4109-b8f7-b340cbbc6a7d)

The location of the connection string is located in appsetting.json the file look like this 
![Screenshot 2025-05-12 at 16 18 42](https://github.com/user-attachments/assets/16cf45fb-948e-45a8-9ff8-3faf5ae9f26b)



## Building and Running the Prototype
* click the run button or you can use the terminal a type into the terminal dotnet build dotnet run --project AgriEnergyConnect_st10255631_MVC * would need to replace with actual path 


## User Roles and Credentials

The system supports two distinct user roles. Sample user accounts should have been created by the database setup script.

*   **Farmer:**
    *   Can add products to their profile.
    *   Can view their own product listings.
  
*   **Employee:**
    *   Can add new farmer profiles to the system.
    *   Can view all products from any specific farmer.
    *   Can filter product searches (e.g., by date range, product type).

Sample account go as follows:

### Employee Account
- **Username:** Clive
- **Password:** cliveemp123
- **Role:** Employee

### Farmer Account 1
- **Username:** Matt
- **Password:** southafrica
- **Role:** Farmer

### Farmer Account 2
- **Username:** LukeC
- **Password:** suidAfrika
- **Role:** Farmer

## System Functionalities

## Tech stack 
Technology Stack
Backend: ASP.NET Core MVC .NET 8
Database: SQLite using Entity Framework Core
Frontend: Razor Views and Bootstrap 
Authentication: ASP.NET Core Cookie Authentication

## References
** GeeksforGeeks (2022). MVC Framework Introduction. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/mvc-framework-introduction/. [Accessed 2 April 2025]
** Microsoft. (2025). Entity Framework documentation. Microsoft Learn. Available at: https://learn.microsoft.com/en-us/ef/ [Accessed: 14 April 2025]
** www.youtube.com. (2023). CSS Tutorial – Full Course for Beginners. [online] Available at: https://www.youtube.com/watch?v=OXGznpKZ_sA. [Accessed 8 April 2025] 
** www.youtube.com. (2022). Learn HTML – Full Tutorial for Beginners (2022). [online] Available at: ç. [Accessed 11 April 2025]
** GeeksforGeeks. (2024). Web Development. [online] Available at: https://www.geeksforgeeks.org/web-development/. [Accessed 12 April 2025]

## Annexure of AI use
I Joshua Shields ST10255631 use AI in my assignment:
AI used: Claude 
Used to help with seeding the db
Date used: 12 April 

Screenshot of chat conversations 
![Screenshot overview ](https://github.com/user-attachments/assets/dc208e1e-a9d3-4eb8-91a0-fe299b5da37c)

![Screenshot chat 1](https://github.com/user-attachments/assets/02982956-567f-4dac-82c6-fcf669d8bd1c)
![Screenshot chat 1 contuined](https://github.com/user-attachments/assets/438b6e91-5171-4e07-b041-6d588274b6d6)

Used to help with role based access 
AI used: Gemini
Date used 20 April 
![Gemini chat role based](https://github.com/user-attachments/assets/a382afd1-b6f8-41c3-a70c-ec9d79b39740)


Used AI as i had a issue with the Database 
AI used: Claude 
Date used 7 May 2025
![DB issue](https://github.com/user-attachments/assets/084caacd-d3d7-439f-ad0e-7f81e3f50bf1)

Used AI on how to go about UX testing 
AI used: T3 chat (o3 mini model)

![UX test 1](https://github.com/user-attachments/assets/dfdf99a1-3598-4890-8061-fa1f9b42ab7d)
![UX TEST 2](https://github.com/user-attachments/assets/0e1ce2a5-56b2-48fc-b2de-fab83f0c762f)


