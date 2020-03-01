# Contacts Management
Contacts management REST API

## Setup & Use

### 1. requirements

+ **.NET Core >= v3.0**
+ **.NET Core CLI >= v3.0**
+ **Visual Studio >= v2019**
+ **SQL Server (SDT, Express): Optional**

### 2. Clone the project

#### SSH:
```
$ git clone git@github.com:PKriwin/Contacts_Management.git
```

#### https:
```
$ git clone https://github.com/PKriwin/Contacts_Management.git
```

### 3. Edit app settings for database

#### SQL Server
To use with sql server, in **appsettings.json** disable in memory database and add your connection string like so:
```
"InMemoryDatabase": true,
"ConnectionStrings": {
  "ContactManagement": "YOUR CONNECTION STRING"
}
```
Run initial Migration by entering the following commands in terminal from the project directory:

```
$ dotnet restore
$ dotnet ef database update
```
#### In memory 
To use with an in memory database (reset at each launch), enable it in **appsettings.json** like so:
```
"InMemoryDatabase": true
```
### 4. Build & Run

The api runs by default on http://localhost:5000

#### Visual Studio

Hit the run button

#### .NET Core CLI
Run the following commands in terminal from the project directory:

```
$ dotnet restore
$ dotnet run --project Contact_Management.csproj
```


### Documentation
Go to **/swagger/index.html** to have the interactive API documentation

## License
MIT
