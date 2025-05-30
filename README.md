## Technology Stack
  * ASP.NET Core Web API
  * Entity Framework Core
  * FluentValidation
* **Database:** AWS RDS PostgreSQL


## API Endpoints (Backend)

A brief overview of the main API endpoints:

* `GET /api/destinations`: Fetches a list of all tourist destinations.
* `GET /api/destinations/{id}`: Fetches details for a specific destination by its ID.
* `POST /api/bookings`: Submits a new booking request.
    * Request Body Example: `{ "userName": "John Doe", "email": "john@example.com", "destinationId": 1, "date": "2025-12-20" }`
* `GET /api/bookings`: Fetches a list of all bookings.
* `GET /api/bookings/{id}`: Fetches details for a specific booking by its ID.
