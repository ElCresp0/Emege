#!/bin/bash

export ConnectionStrings__default="Host=postgres;Database=EmegeDB;Username=postgres;Password=$(cat /run/secrets/db_password)"

# in prod setting following ef commands should be executed once during deployment, not on each application startup
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run