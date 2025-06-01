---
theme: default
---

# Demo 1: State Management

- .NET 8 Web App with two endpoints:
  - POST `/profile` endpoint to store a social media profile
  - GET `/profile/{id}` endpoint to get a social media profile by ID
- Profile data is stored a local state store
- Run .NET 8 App (`dapr run -f .` in VSCode terminal)
- Call the endpoints (REST Client in VSCode)
