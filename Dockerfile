#Build
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS rdpBuild
WORKDIR /src
COPY . .
RUN msbuild /p:Configuration=Release

#Run
FROM mcr.microsoft.com/windows/servercore:ltsc2019 as rdpRuntime
WORKDIR /app
COPY --from=rdpBuild src/RabbitDataProcessor/bin/Release .
ENTRYPOINT RabbitDataProcessor.exe
# CMD [ "cmd.exe" ]