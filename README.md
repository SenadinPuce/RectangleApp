# RectangleApp

## Overview

RectangleApp is a web application that allows users to draw and manipulate rectangles. The project consists of a React frontend and an ASP.NET Core Web API backend.

## Prerequisites

- Docker
- Node.js (version 14.x or higher)
- npm (version 6.x or higher)


## Getting Started

### 1. Clone the Repository
Clone the repository to your local machine using Git:
```
https://github.com/SenadinPuce/RectangleApp.git
```

### 2. Start the Project with Docker
Use Docker to start the project by navigating to the root directory and typing:
```
docker-compose up --build
```

The API will be available at `http://localhost:7076`.

### 3. Start the Web App
Navigate to the rectangle-drawer directory, install the dependencies, and start the React app:

First step: 
```
cd rectangle-drawer
```
Second step:
```
npm install
```
Third step:
```
npm start
```

The web app will be available at `https://localhost:3000`. 

## API Documentation

The API endpoints are documented using Swagger. Once the docker container is running, you can access the documentation at:

`http://localhost:7076/swagger/index.html`


## Contact
For any questions or issues, please contact senadin.puce@gmail.com.

>[!NOTE]
>This `README.md` file provides a guide to setting up and running the RectangleApp project. It includes sections for prerequisites, getting started, API documentation, and contact information.
