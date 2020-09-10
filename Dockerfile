FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnet-builder
WORKDIR /signalr
COPY src/ .
RUN dotnet publish SignalrServerWorker/SignalrServerWorker.csproj -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS dotnet-runtime
WORKDIR /signalr
ENV ASPNETCORE_URLS http://*:8000
EXPOSE 8000
COPY --from=dotnet-builder /signalr/publish .
ENTRYPOINT ["dotnet", "SignalrServerWorker.dll"]