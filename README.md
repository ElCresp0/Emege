# Emege - create, share, engage

## Goal

This is a full stack application made for me to learn and show the usage of the following fullstack frameworks

- C# (backend)
- vue.js (frontend)

## Run on host

```bash
# server
cd server/EmegeAPI
dotnet run

# client
cd client
npm install
npm run dev
```

## Run in containers

```bash
docker compose up
```

## BKMs

1.  

Problem:

- `Error: Cannot find module @rollup/rollup-linux-x64-gnu. npm has a bug related to optional dependencies`
- `sh: 1: vite: not found`
- `Error: EmegeClient   | You installed esbuild for another platform than the one you're currently using.`

Solution:

- Ensure `npm install` is executed on the container and on-host generated `node_modules` don't sneak into it
- Put `node_modules` in the `.dockerignore` and define two volumes in `docker-compose.yml` as follows (order matters):

```yaml
volumes:
- ./client:/app
- /app/node_modules
```

- some StackOverflow users suggested certain modifications of the `client\package.json` \
  but in this case it didn't resolve the issue

2.  

Problem:

Client `vue.js` website is not accessible under host's `localhost`

Solution:

- Ensure ports are set up correctly
- In the `Dockerfile` use the `--host` flag as follows

```bash
npm run dev -- --host
```

3.  

Problem:

Server `C#` application is not accessible under host's `localhost`

Solution:

- Ensure ports are set up correctly
- Change "localhost" to "*" in `server\EmegeAPI\EmegeAPI.http` and `server\EmegeAPI\Properties\launchSettings.json` \
  so that the application exposes it's endpoints not only to container's `localhost` but also to external addresses, including the host OS
- Set the following flags in `docker-compose.yml`

```yaml
environment:
    - ASPNETCORE_ENVIRONMENT=Local
    - ASPNETCORE_URLS=http://*:5007
    - DOTNET_URLS=http://*:5007
```
