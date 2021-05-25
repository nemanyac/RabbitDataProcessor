#Run
FROM mcr.microsoft.com/windows/servercore:ltsc2019 as rdpRuntime
WORKDIR /src
COPY ./bin/Debug .
ENTRYPOINT RabbitDataProcessor.exe
#CMD [ "cmd.exe" ]