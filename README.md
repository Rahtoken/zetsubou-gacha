# Zetsubou Gacha

_To learn full stack development by developing a gacha clone._

## The Tech

- .NET Core 3.0 for the backend API.
- React for the frontend client.
- MongoDB as the database.
- Docker for deployment.

## Rolling the Gacha

Docker is highly recommended to run/test the project.

### Run the Backend Tests

1. Go to the `.\Test\Backend.Tests\` directory.
2. Ensure that an instance of MongoDB is running.
3. `dotnet build -c Release`
4. `dotnet vstest .\bin\Release\netcoreapp3.0\Backend.Tests.dll`

### Run the Backend API

1. Go to the `.\Backend\` directory.
2. Ensure that an instance of MongoDB is running.
3. `dotnet run`

### Run the React Frontend

1. Go to the `.\client\` directory.
2. `npm i`
3. `npm start`

### Populating the Database

To speed up things, dummy data has been provided in `TestData.json`.

1. Go to `.\Scripts\` directory.
2. Ensure that an instance of MongoDB is running.
3. `pip install pymongo`
4. `python Populate.py`
5. `python Populate.Test.py`

### Ensure that an Instance of MongoDB is Running

The easiest way is using Docker.

1. `docker pull mongo`
2. `docker volume create zbdata`
3. `docker run --name zbmongo -p 27017:27017 -v zbdata:/data/db mongo`
