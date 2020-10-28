# MarsImage
Test Project for Stealth Monitoring Company

# Description
This is a test programming project for Stealth Monitoring Company.

The project is basically an app that will get images from NASA API, will download it and save in the local folder with a given dates.

Since the project has to be done in a short period of time, I use the approach of BDD framework. I started it simple and little by little added some features like multi threading and some separation of concerns. I'm also thinking of adding unit testing and performance testing but I think I won't make it due to time constraints.

The project will definetely need some additional work to make it an "enterprise/business" level software and I coded it readable and extendable so that new features can be added easily.


# Installation
Since this project is just for testing purposes only, the expectation would be the user will just get the code and run it manually in Visual Studio. 

The project can run using docker. If you want to test it, you may downloading and install docker for windows here - https://docs.docker.com/docker-for-windows/


# Usage
After the user manually run the project in Visual Studio, the images will be saved under the foler "wwwroot\downloadedImages"
