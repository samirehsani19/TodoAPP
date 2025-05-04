## Todo APP ##

## 🧰 Technologies Used

### 💻 Frontend
- React (Hooks, Functional Components)
- Axios
- CSS / TailwindCSS (optional styling)

### 🛠️ Backend
- .NET 9 (ASP.NET Core Web API)
- C#
- AutoMapper
- xUnit & Moq (for unit testing)
- Logger (Microsoft.Extensions.Logging)
- CI/CD for automatic build and tests running 

This application is built using REST API and React. <br/>
You can do the following operations:
* Add a Todo
* Delete a Todo

### How to test it on your computer ###
* Clone this repository

  ### Run Web API ###
* Inside Web API folder > click on **ToDoApp.sln** file to open it in **Visual Studio**
* Run ToDoApp.WebAPI in **Visual Studio** by clickin on [Play] button.
  The API will run and will listen to ports:
  * http://localhost:5001;
  * https://localhost:5002

### Run React App ###
* Open **Client** folder in **Visual Studio Code**
* Run **npm install** to install all dependencies defined in package.json
* Then Run **npm start** to start react development server


  When you run the client app, it will try to communicate with the API to get list of todos. It is important to run the API before running the client app.

You should see a similar page
![image](https://github.com/user-attachments/assets/3a03446d-e585-4de1-954c-1ec4b50e72ba)
