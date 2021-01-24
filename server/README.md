# Backend  
This project was developed with 
1. .Net core 3.0
2. Sql Server data base 
3. JSON Web Token (or JWT)
4. Swagger

# Instructions 
1. The data model was built using entity framework code fisrt. Therefore, the project contains the migration files that must be executed for the creation of the database. In the appsettings.json file you can find the connection string to the database
2. For the authentication of the users, it was decided to create an authentication model using JSON Web Token (or JWT) in .net core, for which, a user table was created that contains the information of the users who are enabled to login in the API
3. When you run the application, you will get the swagger UI as shown below:
http://{ip}:{port}/swagger/index.html
![alt text](https://i.ibb.co/z2LfC77/autenticacion.png)
```Note: In order to consume the services of Agencies, the token that is generated in the authentication endpoint (/ api / v1 / Authentication / Login) must be sent. For that, you must click on the Authorize button and add this token under the Value box..```
