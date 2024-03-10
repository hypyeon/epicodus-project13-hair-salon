# Eau Clair's Salon 💇🏽
by Hayeong Pyeon

![preview](./HairSalon/wwwroot/img/preview.png)

## Table of Contents
1. [Technologies Used](#technologies-used)
2. [Description](#description)
3. [Setup Instructions](#setup-instructions)
4. [Known Bugs](#known-bugs)
5. [License](#license)

## Technologies Used
- C#
- ASP.NET
- MySQL (Community Server, Workbench)
- Entity Framework Core
- HTML Helper Methods, Lambda Expressions, String Interpolation
- ViewBag
- One-to-many Relationship 
- MVC

## Description
- This application is an independent project as a review of **Database Basics** chapter of **C#** course provided by Epicodus.
- As the salon owner (user), you can do the following:
1) To see a list of all stylists. 
2) To select a stylist, see their details, and see a list of all clients that belong to that stylist. 
3) Add new stylists to the system when hired. 
4) Add new clients to a specific stylist (failure to assign each client to a stylist will not have them added to the list). 

## Setup Instructions
### Installation Requirements
1. Make sure you have [MySQL Community Server and Workbench installed](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql). 
2. Clone this repo. 
3. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory named **HairSalon**. 
4. Within **HairSalon**, add the dependencies that are necessary for Entity Framework Core by runniing the following commands: 
```
dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0
```
4. Within the same directory, create a new file named `appsettings.json`. In the `json` file, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. 
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=hayeong_pyeon;uid=[YOUR-USER-NAME];pwd=[YOUR-PASSWORD];"
  }
}
```
5. In the production directory, run `dotnet watch run` in the command line to start the project in development mode with a watcher.

### Importing Database
1. In the *Navigator* > *Administration* window, select **Data Import/Restore**.
2. In *Import Options* select **Import from Self-Contained File**.
3. Navigate to the file that has been just created.
4. Under *Default Schema to be Imported To*, select the **New** button.
  - Enter `hayeong_pyeon`.
  - Click **Ok**.
5. Navigate to the tab called *Import Progress* and click **Start Import** at the bottom right corner of the window.
After you are finished with the above steps, reopen the *Navigator* > *Schemas* tab. Right click and select **Refresh All** to view the created database.

## Known Bugs
No bug found as of March 10, 2024

## License
[MIT](/LICENSE.txt) | Copyright © 2024 Hayeong Pyeon