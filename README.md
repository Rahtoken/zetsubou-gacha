# A project to help us learn React and ASP.NET #

[![Build Status](https://dev.azure.com/16241A05C2/ZetsubouGacha/_apis/build/status/Rahtoken.zetsubou-gacha%20(1)?branchName=master)](https://dev.azure.com/16241A05C2/ZetsubouGacha/_build/latest?definitionId=3&branchName=master)

### Objective ###
----------
Emulate the Gacha system of the Fate series of games. Learn interesting stuff on the way.

### Setup ###
1. Requirements: .NET Core 2.2 and NodeJS.
2. Execute the following commands:
    1. `git clone https://github.com/Rahtoken/zetsubou-gacha.git`
    2. `cd zetsubou-gacha`
    3. Set the following `dotnet user-secrets` in ZetsubouGachaDatabaseSettings: ServantsCollectionName, DatabaseName, ConnectionString.
### How To Run ###
1. Go to the root directory.
2. `dotnet run` runs the backend server and starts the frontend build.
3. To test frontend changes exclusively:
   1. Go to `ClientApp` directory.
   2. `npm start` starts the React deployment process.

### Backend ###
----------
The backend for this project is ASP.NET Core.

### Frontend ###
----------
The frontend for this project is React.
