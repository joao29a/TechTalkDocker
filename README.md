## How to use

Start redis with docker:

```sh
docker run --name tech-redis -p 9090:6379 redis
```

Running the server:

```sh
dotnet run --urls=http://localhost:8001 --project SignalrServerWorker/SignalrServerWorker.csproj
```

Running the client:

```sh
dotnet run --project SignalrClient/SignalrClient.csproj 8001
```

## Docs

* [Introduction to ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-3.1)
* [Tutorial: Get started with ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio)
* [Host ASP.NET Core SignalR in background services](https://docs.microsoft.com/en-us/aspnet/core/signalr/background-services?view=aspnetcore-3.1)
* [Use hubs in SignalR for ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-3.1)
* [Manage users and groups in SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/groups?view=aspnetcore-3.1)
* [Authentication and authorization in ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-3.1)
* [Set up a Redis backplane for ASP.NET Core SignalR scale-out](https://docs.microsoft.com/en-us/aspnet/core/signalr/redis-backplane?view=aspnetcore-3.1)
