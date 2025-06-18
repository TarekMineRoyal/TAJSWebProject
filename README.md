# TAJS Tour Agency API

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-12.0-green)
![Entity%20Framework%20Core](https://img.shields.io/badge/EF%20Core-8.0-blue)
![Architecture](https://img.shields.io/badge/Architecture-Clean-red)
![License](https://img.shields.io/badge/License-MIT-yellow.svg)

TAJS Tour Agency is a feature-rich backend API that powers a modern web application for car rentals and trip bookings. It provides a complete solution for managing vehicles, planning tour packages, handling user authentication, and processing payments.

**Frontend Repository:** [**AbSamrah/FrontEnd**](https://github.com/AbSamrah/FrontEnd)

## About The Project

This project is the backend for a comprehensive tour and vehicle rental platform. It's built using a clean, service-oriented architecture to separate concerns and ensure maintainability. The API exposes a set of well-defined endpoints to support a decoupled frontend application.

The core functionalities include:
* **Vehicle Rental:** A complete system for managing a fleet of cars, allowing users to browse, check availability for specific dates, and book vehicles.
* **Trip Planning & Booking:** A module for creating and managing multi-day tour packages. Users can book these trips, and cars can be optionally included as part of a private tour.
* **Payment Processing:** Secure payment integration with both **Stripe** and **PayPal** to handle transactions for bookings.

## Key Features

-   **RESTful API:** A well-structured set of endpoints for all application features.
-   **User Authentication:** Secure user registration and login system using JWT (JSON Web Tokens).
-   **Role-Based Access Control:**
    -   **Customer:** Can browse, book cars and trips, and make payments.
    -   **Employee:** Can manage cars, trip plans, and blog posts.
    -   **Admin:** Has full access, including employee and admin management.
-   **Advanced Car Search:** Filter available cars by date range, model, seating capacity, price, and category.
-   **Payment Gateway:** Supports payments through PayPal.
-   **Database Seeding:** Comes with pre-configured data for roles, users, cars, and trips to get the environment running quickly.
-   **Static File Handling:** Includes an endpoint for uploading and serving static assets like car images.

## Technology Stack

* **Backend:** ASP.NET Core 8
* **Database:** Microsoft SQL Server with Entity Framework Core 8
* **Authentication:** ASP.NET Core Identity with JWT Bearer Tokens
* **Payment Gateways:** PayPal
* **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API layers)

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

* .NET 8.0 SDK
* Microsoft SQL Server
* A code editor like Visual Studio or VS Code

### Installation

1.  **Clone the Frontend & Backend Repositories**
    ```sh
    # Clone the backend (this repo)
    git clone [https://github.com/tarekmineroyal/tajswebproject.git](https://github.com/tarekmineroyal/tajswebproject.git)

    # Clone the frontend
    git clone [https://github.com/AbSamrah/FrontEnd.git](https://github.com/AbSamrah/FrontEnd.git)
    ```

2.  **Configure Backend Secrets**
    This project requires connection strings and API keys. It's recommended to use the .NET Secret Manager.
    
    Navigate to the `API` project directory and set up your secrets:
    ```sh
    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:Identity" "Your_Identity_DB_Connection_String"
    dotnet user-secrets set "ConnectionStrings:MainDatabase" "Your_Main_App_DB_Connection_String"
    dotnet user-secrets set "Stripe:SecretKey" "Your_Stripe_Secret_Key"
    dotnet user-secrets set "PayPal:ClientId" "Your_PayPal_ClientID"
    dotnet user-secrets set "PayPal:ClientSecret" "Your_PayPal_Client_Secret"
    ```
    Alternatively, you can add these values to your `appsettings.Development.json` file.

3.  **Setup the Databases**
    This project uses two separate database contexts: one for the application data (`TourAgencyDbContext`) and one for identity (`CustomIdentityDbContext`). You need to apply migrations for both.
    
    Open a terminal in the `Infrastructure` project directory and run the following commands:
    ```sh
    # Apply migrations for the main application database
    dotnet ef database update --context TourAgencyDbContext
    # Or
    update-database --context TourAgencyDbContext

    # Apply migrations for the identity database
    dotnet ef database update --context CustomIdentityDbContext
    # Or
    update-database --context CustomIdentityDbContext
    ```
    The application will automatically seed the databases with initial data for roles, users, and sample content on the first run in a development environment.

4.  **Run the Backend API**
    Navigate back to the `API` project directory and run the application:
    ```sh
    dotnet run
    ```
    The API will be available at `http://localhost:5117` by default.

5.  **Setup and Run the Frontend**
    Follow the instructions in the [frontend repository's README](https://github.com/AbSamrah/FrontEnd) to get the user interface running.
