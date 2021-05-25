# RabbitDataProcessor
Starting from the master branch, this is a simple app which listens to messages on Rabbit and pushes them to the console output.
The goal of the workshop is to containerize the application and run it in Kubernetes.

## Prerequisites
You need Docker installed ([download link](https://www.docker.com/products/docker-desktop)).

Windows containers tend to have issues with DNS. You need to add this to Settings > Docker Engine (requires a restart of Docker desktop)
>  "dns": ["1.1.1.1"]

Visual Studio is a nice to have, but you can do withotut.

## Game plan
First we write a docker file to get going with a Windows container.
Then we improve it a little bit.


## First step
The application is written in .NET Framework, so for starters we are going to use a Windows container.
Create a simple docker file.
To build the image run the following command from the folder which contains it:
> docker build . -t rdp-simple

To run the image ask for the Rabbit URL and paste it at the end of the following command replacing the placeholder url (and the curly braces):
> docker run -it rdp-simple {url}

## Second step
Refine the docker image to use a multi-stage build.
Test that it still works.
