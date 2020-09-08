# lean_tech_backend_test
Backend Test SQuaRE

## Instructions to run the solution projects
1. The project is builded with netcore 3.1
2. The dabase for relational objects is sql-server 2019
3. The database for non relational objects is mongodb with a local connection
4. Download the solution and let it install the dependecies

### Hello-Word
1. Run the project and access to the enpoiints http://localhost/holamundo/txt and http://localhost/helloworld/json

### nosqlstructure
1. The structure for the database is in the file nosqlstructure.js

### qlstructure
1. The structure for the database is in the file sqlstructure.png
2. The ERD schemma for create the database structure is in the file sqlstructure.sql

### sql-CRUD
1. Create the database structure by running the script sqlstructure.sql
2. The current dabatase name is Test, but you can change it if you want, remeber to change the connection string in the project settings file
3. Run the accitons (GET,POST,PUT,DELETE) for the different models
4. The project has swagger so the structure to the above endpoins is documented there

### NoSQL-CRUD
1. Run nosql
2. The current dabatase name is Test, but you can change it if you want, remeber to change the connection string in the project settings file
3. Run the accitons (GET,POST,PUT,DELETE) for the different models
4. The project has swagger so the structure to the above endpoins is documented there

### US Energy Information Administration - API_EIA
1. The project has swagger so the structure to the GET endpoin is documented there

### Demo
1. Create the database structure by running the script demo_sqlstructure.sql, you need to enable full text search in the database if is not enable
2. The current dabatase name is Demo, but you can change it if you want, remeber to change the connection string in the project settings file
3. Run the accitons (GET,GET/{id},POST,PUT,DELETE) for the different models https://localhost:44385/shipment and https://localhost:44385/carrier
4. The project has swagger so the structure to the above endpoins is documented there

### Authentication (inside Demo project)
1. Actually there are two inlie users, admin and test and the password for both is 123456
2. Get the token by posting to the endpoint https://localhost:44385/login with the following json object
{
    "username": "admin",
    "password": "123456"
}
3. Take the token from the response and add it to the resquest for shipment endpoints https://localhost:44385/shipment 

### Import from excel (inside Demo project)
1. acces the route https://localhost:44385/importoexcel and you will see a simple UI for select the excel file and upolad the databa to shipments table in Demo database
2. Currently is just exporting xls, xlsx excel file extensions, csv is bugged.

### Export to gooogle drive (inside Demo project) [Bugged]
1. acces the route https://localhost:44385/uploadtodrive and you will see a simple UI for select the excel file and upolad to a folder in google drive
2. Currently the files is not being uploaded but there is no error throwing
3. you may want to change the file client_secrets.json to set your own credentials.

END.
