# EventManager_Dimitar_Tachev
To get the application running you should download all four folders that are uploaded in this repository:
1.EventManager.Client
2.EventManager.Data
3.EventManager.Models
4.EventManager.Services

After downloading the folders you should add them to a solution of your own and then set the EventManager.Client as the StartUp project. You can find the database connection string inside the OnConfiguring method in the EventManagerContext class, which is located in the EventManager.Data project. By default the database is called EventManager and is created in the (LocalDb)\MSSQLLocalDB server, but you can change those settings according to your own preferences. To run the application hit CTRL + F5 upon which the console will open and you will be greeted by a start message. It explains what commands the application executes and how. To exit the application just close the console.
