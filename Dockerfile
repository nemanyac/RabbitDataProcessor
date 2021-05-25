#Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS rdpBuild
WORKDIR /src
COPY . .
RUN dotnet restore RabbitDataProcessor
RUN dotnet build RabbitDataProcessor
RUN dotnet publish RabbitDataProcessor  --configuration Release --self-contained=false --runtime linux-x64 --output output

#Run
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS rdpRuntime
WORKDIR /app
COPY --from=rdpBuild /src/output/ .
ENTRYPOINT ["dotnet", "RabbitDataProcessor.dll"]