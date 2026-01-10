FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app/EmegeAPI

COPY ["EmegeAPI/EmegeAPI.csproj", "./"]
RUN dotnet restore "./EmegeAPI.csproj"

COPY . ..

RUN dotnet tool install --global dotnet-ef --version 8.0.8
ENV PATH="$PATH:/root/.dotnet/tools"

# dotnet ef commands are in `run.sh` to be executed when the database server is up

EXPOSE 5000

CMD ["./run.sh"]