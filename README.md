
# RedditUWP

This app uses the API of **Reddit** to show the top 50 of posts, allowing the user to dismiss, read and refresh the posts.

## Getting Started

Download this proyect using the command:
**git clone https://github.com/gabybonaventura/RedditUWP.git**

### Prerequisites

Before run this application, you must have the latest version of Windows 10 (version 1909 at this time) and have the following software installed

* Visual Studio 2019 Community ([https://visualstudio.microsoft.com/es/vs/community/](https://visualstudio.microsoft.com/es/vs/community/))
* Universal Windows Platform development ([https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up))
*  **SQLite for Universal Windows Platform** ([https://marketplace.visualstudio.com/items?itemName=SQLiteDevelopmentTeam.SQLiteforUniversalWindowsPlatform](https://marketplace.visualstudio.com/items?itemName=SQLiteDevelopmentTeam.SQLiteforUniversalWindowsPlatform))


## Built With

### Architecture

* Model-View-ViewModel Pattern
* N-Layer Architecture
* Dependency Injection

### Tools
* Autofac
* AutoMapper
* Behaviors.Uwp
* Newtonsoft.Json
* RestSharp
* SQLite

### Programs
* Visual Studio 2019 Community
* Postman

## Decisions taken
This project should be done in a couple of hours. Because of that, i took several decisions to make it.

I prioritized the architecture and maintainability of the app. Because of that, I implemented MVVM pattern, N-Layer architecture and  dependency injection.  In addition, it is easier to test the app and to find issues faster.

I implemeted SQLite because it's faster than SQL Server, easier to develop, save the information locally and doesn't depend on internet connection. Anyway, I can implement the inferface IRepository with SQL Server logic and the app will work fine.

With more time, I could improve the UI and develop some feactures such as pagination support and save pictures in the picture gallery.
## Author

* **Bonaventura Gabriel**  - [Linkedin](https://www.linkedin.com/in/gabriel-bonaventura) -  [GitHub](https://github.com/gabybonaventura)
