# Netrex E-Commerce Portal

Netrex is a modern, enterprise-level E-Commerce management system built using the **.NET Core** ecosystem. The application is designed keeping scalability, maintainability, and loose coupling in mind, strictly adhering to **Clean Architecture** principles and the **Repository Design Pattern**.

---

## 🏗️ Architecture & Design Principles

The project is structured around **Clean Architecture** , where dependencies flow inwards. The core business logic is completely isolated from external frameworks, databases, and UI components.

* **Domain Layer (Core):** The center of the onion. Contains enterprise business rules, entities, enums, and exceptions. It has zero dependencies on other projects.
* **Application Layer:** Contains application-specific business rules, Use Cases (Services/Queries/Commands), DTOs, and interface definitions (like `IRepository`).
* **Infrastructure Layer:** Handles external concerns like database persistence (EF Core, Migrations, Repositories implementation), identity management, caching, or third-party APIs.
* **Web / API Layer:** The entry point of the application. Handles HTTP requests, controllers, middleware, and Swagger UI configuration.

### 🔄 Dependency Flow Diagram
```text
  [ Web / API ] ──> [ Application ] ──> [ Domain ]
                          │
  [ Infrastructure ] ─────┘ (Implements Application Interfaces)
  Netrex_ECommerce/
│
├── src/
│   ├── Netrex.Domain/          # Core Entities, Enums, Value Objects
│   ├── Netrex.Application/     # Interfaces, Services, Use Cases, DTOs, Mapping
│   ├── Netrex.Infrastructure/  # DbContext, Repositories, Migrations, External APIs
│   └── Netrex.WebAPI/          # Controllers, Middlewares, Program.cs, AppSettings
│
└── tests/                      # Unit, Integration, and Architecture Tests

git clone [https://github.com/Asim-AKM/Netrex_ECommerce.git](https://github.com/Asim-AKM/Netrex_ECommerce.git)
    cd Netrex_ECommerce
    ```

2.  **Configure the Database:**
    Update the connection string in `src/Netrex.WebAPI/appsettings.json`:
```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=NetrexDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

3.  **Apply Database Migrations:**
    Open your terminal in the root folder and run:
```bash
    dotnet ef database update --project src/Netrex.Infrastructure --startup-project src/Netrex.WebAPI
    ```

4.  **Run the API application:**
```bash
    dotnet run --project src/Netrex.WebAPI
    ```
    Open `https://localhost:xxxx/swagger` in your browser to view the API documentation.

---

## 🔒 Security & Data Integrity

* **Claims-Based Context:** To prevent data tampering, internal IDs such as `UserId` are omitted from incoming request payloads. The API reads these directly from the secure decrypted JWT claims token context at the execution level.
* **Input Isolation:** Request objects (DTOs) are kept clean and strictly separated from Core Domain entities to ensure zero unintended database mutations.
