# Task List API

This is a .NET 8 Web API project that provides a RESTful service for managing task lists. The API allows users to create, update, delete, and share task lists with other users.

## Table of Contents

- [Features](#features)
- [Endpoints](#endpoints)
- [Setup Instructions](#setup-instructions)
- [Using the API](#using-the-api)
  - [Using Swagger](#using-swagger)
  - [Using Postman](#using-postman)

## Features

- **Task List Management**: Create, retrieve, update, and delete task lists.
- **Sharing Task Lists**: Share task lists with other users.
- **Pagination**: Retrieve a paginated list of task lists.
- **Sorting**: Task lists are sorted by creation date.

## Endpoints

### Task Lists

- **Create a Task List**
  - `POST /api/tasklists`
  - **Body**: 
    ```json
    {
        "name": "Task List Name"
    }
    ```
  - **Response**: The created task list with its ID and `createdAt` timestamp.

- **Get a Task List by ID**
  - `GET /api/tasklists/{id}`
  - **Parameters**: 
    - `id`: The ID of the task list to retrieve.
    - `userId`: The ID of the user making the request (passed as a query parameter).
  - **Response**: The requested task list.

- **Get All Task Lists**
  - `GET /api/tasklists`
  - **Parameters**:
    - `userId`: The ID of the user making the request (passed as a query parameter).
    - `page`: The page number (optional).
    - `pageSize`: The number of items per page (optional).
  - **Response**: A paginated and sorted list of task lists.

- **Update a Task List**
  - `PUT /api/tasklists/{id}`
  - **Parameters**: 
    - `id`: The ID of the task list to update.
    - `userId`: The ID of the user making the request (passed as a query parameter).
  - **Body**: 
    ```json
    {
        "name": "Updated Task List Name"
    }
    ```
  - **Response**: The updated task list.

- **Delete a Task List**
  - `DELETE /api/tasklists/{id}`
  - **Parameters**: 
    - `id`: The ID of the task list to delete.
    - `userId`: The ID of the user making the request (passed as a query parameter).
  - **Response**: A success message.

### Sharing Task Lists

- **Add a User to a Task List**
  - `POST /api/tasklists/{id}/share`
  - **Parameters**: 
    - `id`: The ID of the task list to share.
  - **Body**: 
    ```json
    {
        "userId": "User ID to Share With"
    }
    ```
  - **Response**: The updated task list with the new shared user.

- **Remove a User from a Task List**
  - `DELETE /api/tasklists/{id}/share`
  - **Parameters**: 
    - `id`: The ID of the task list.
  - **Body**: 
    ```json
    {
        "userId": "User ID to Remove"
    }
    ```
  - **Response**: The updated task list without the removed user.

## Setup Instructions

1. **Clone the repository:**
2. **Build and run the containers:**
   ```bash
   docker-compose up --build
2. **Access the API:**
   
   The API will be available at http://localhost:8080.

## Using the API
### Using Swagger
1. Access Swagger by navigating to http://localhost:8080/swagger in your browser.
2. Interact with the API using the Swagger UI. You can execute requests directly from the interface.
### Using Postman
1. Open Postman and create a new request.
2. Set the request URL to http://localhost:8080/api/tasklist

