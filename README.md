# POC for a attempt on creating a SaaS platform that uses kubernetes/AKS
This repository contains a POC where I attempt to learn how to create a SaaS platform for the company that I am working in. The code is open source as I am using my spare time to make it and not actual company hours. Until the POC is done, it will be separated into different branches depending on the content's phase. Each phase will be a branch of the previous stage.

## Before use
You can use my code freely as long as you credit me correctly where you use it. If you wish to take the source privately, please message me. I will allow it; however, I am curious how you will use the source code... I am not expecting payment or anything, just the simple respect of getting informed.

## Contributions
You are welcome to create pull requests to change the code base into something better. However, they will most likely not be looked at until I am done with the beginning code phases.

## Folder structure
src:: The folder will contain all frontend and backend code
deployment:: Will contain all deployment files that belong to kubernetes and similar products
build:: Will contain all content that has something to do with CI/CD
scripts:: will contain all scripts that the user or the build system can run.

## How to debug/run the application
Coming soon

## Phases
### phase 1 (Current active development branch)
Order service with creating and read functionality (no Database)
docker compose for quick and local testing
Kubernetes deployment scripts
API test (Postman)
Performance test (No tool decided yet)

## Tools setup for the repository 
### Sonarqube cloud
There is a SonarQube cloud subscription targeting the public GitHub repository constantly to scan every change made to correct any mistakes or critical errors introduced during development. It also helps ensure any common security risks are found early.

## Technology used
- DotNet 6/C# for any backend technology
- Frontend yet to be decided 
- Docker as the container service selected
- Kubernetes for orchestration

## Projects
### TeamTwo.WebShop.OrderService
This project contains the order part of this POC. It is coded as a complete web API with the create read functionality.