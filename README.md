# RabbitDataProcessor
Starting from the master branch, this is a simple app which listens to messages on Rabbit and pushes them to the console output.
The goal of the workshop is to containerize the application and run it in Kubernetes.

## Prerequisites
You need Docker installed ([download link](https://www.docker.com/products/docker-desktop)).

Windows containers tend to have issues with DNS. You need to add this to Settings > Docker Engine (requires a restart of Docker desktop)
>  "dns": ["1.1.1.1"]

Visual Studio is a nice to have as is dotnet cli, but you can do withotut.

## Game plan
First we write a docker file to get going with a Windows container. 

Then we improve it a little bit.

Then we refactor our project to be able to run in Linux and change our Dockerfile to be based on a small linux image.

Then we introduce docker compose. We will also stop using a command line parameter and start using config files/env variables.

Then we add Rabbit to docker compose.

Then we use some proper logging library and add Seq to docker compose.


## First step
The application is written in .NET Framework, so for starters we are going to use a Windows container.
Create a simple docker file.
To build the image run the following command from the folder which contains it:
> docker build . -t rdp-simple

To run the image ask for the Rabbit URL and paste it at the end of the following command replacing the placeholder url (and the curly braces):
> docker run -it rdp-simple {url}

## Second step
Refine the docker image to not have to build manually.

Test that it still works. You may want to use a different tag.

You can check out the stage_1_dockerfile branch for the final result:
> git checkout stage_1_dockerfile

## Third step
If you have VS/dotnet cli - convert the project (root folder of the solution) to .NET 5.
First, install [tryconvert](https://github.com/dotnet/try-convert):
> dotnet tool install -g try-convert

Then, convert:
> try-convert

This should work, but now we have to modify our Dockerfile.
For this step we will actually have to move it outside of the project folder so that the build can access other projects as well.

Switch Docker Desktop to a Linux container and create the Linux DockerFile.
To build:
> docker build . -t rdp-simple-linux

To run the image:
> docker run -it rdp-simple-linux {url}

You can check out the stage_2_linux branch for the final result:
> git checkout stage_2_linux

## Fourth step
Time to add docker compose. Some modifications will be needed as we no longer have an interactive shell and we want to not source-controll secrets.

