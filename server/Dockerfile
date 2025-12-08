FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app/EmegeAPI

COPY . ..

RUN dotnet ef migrations add InitialCreate && dotnet ef database update

EXPOSE 5000

CMD ["dotnet", "run"]