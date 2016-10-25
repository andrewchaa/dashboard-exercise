# dashboard-exercise

* Andrew Chaa
* Dashboard in react.js, api gateway and apis are in ASP.NET Web Api2
* Libraries used: 
  * Api: ASP.NET Web Api 2, Ninject, Dapper, NLog, and Moq
  * Client-side: react.js, react-router, and react-chartlist
  * Build: powershell script
* The architecture: Microservices over HTTP for this exercise. Ideally messaging rather than api call would be more scalable, supporting CQRS.

# To run the application

* in powershell or cmd.exe, run go.bat
* It will 
  * Create "Dashboard" database
  * Create all the tables required. 
  * Build the solution
  * Import the data from csv files
  * npm install all the dependencies
  
* Run the two projects, so that the websites start running.
* Visit the home page of Board project.
