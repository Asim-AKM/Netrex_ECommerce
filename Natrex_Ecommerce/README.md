# Netrex E-Commerce Platform

A complete, enterprise-level e-commerce platform built with modern .NET technologies, enabling customers to browse products, manage accounts, place orders, and sellers to manage their stores.

---

## 🚀 Tech Stack

- **Backend Framework:** ASP.NET Core 9 Web API
- **Frontend Framework:** Blazor WebAssembly (Separate Solution)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Architecture:** Clean Architecture
- **Authentication:** JWT (JSON Web Tokens)
- **Validation:** FluentValidation
- **Image Storage:** Cloudinary
- **API Documentation:** Swagger/OpenAPI
- **IDE:** Visual Studio 2022

---

## 📁 Project Structure
```
NetrexEcommerce/
├── APIGateway_Service/          # API Controllers & Endpoints
├── Application_Service/              # Business Logic Layer (Managers/Services)
├── Infrastructure_Service/           # Data Access & External Services
├── Domain_Service/                   # Entities, Interfaces & Enums
└── docs/                             # Documentation
    └── CloudinarySetup.md           # Cloudinary integration guide
```

---

## 🏗️ Architecture

**Clean Architecture Pattern:**
```
Controller → Manager (Service) → Repository → Database
     ↓            ↓                    ↓
  Receives    Business Logic      Data Access
  Requests    & Validation        & Queries
```

**Flow:**
1. **Controller** - Receives HTTP requests
2. **DTO (Data Transfer Object)** - Request/Response models
3. **Manual Mapper** - Maps DTO ↔ Entity
4. **Manager/Service** - Business logic & validation
5. **Repository** - Database operations
6. **Entity Framework Core** - ORM

---

## 📦 Modules

### 1. User Management Module
- User registration & authentication
- Role-based access control
- Customer profiles & addresses
- Password management with encryption

### 2. Seller Module
- Seller account management
- Shop details & categories
- Store information

### 3. Product Management Module
- Product catalog
- Product categories
- Product images (Cloudinary integration)
- Inventory management

### 4. Payment & Payout Module
- Invoice generation
- Payment processing
- Transaction tracking
- Seller payout management

### 5. Cart & Order Module
- Shopping cart functionality
- Order placement & tracking
- Order item management

---

## 🛠️ Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express/Developer/Enterprise)
- [Cloudinary Account](https://cloudinary.com/) (for image storage)

---

## ⚙️ Installation & Setup

### 1. Clone the Repository
```bash
git clone <repository-url>
cd NetrexEcommerce
```

### 2. Database Setup

**Update Connection String:**

Open `appsettings.json` in the **WebApi** project and update:
```json
{
  "ConnectionStrings": {
    "NetrexConnectionString": "Server=YOUR_SERVER;Database=NetrexEcommerce;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Run Migrations:**
```bash
cd APIGateway_Service
dotnet ef database update
```

This will create the database and all required tables.

### 3. Cloudinary Configuration

**Get Cloudinary Credentials:**
1. Sign up at [Cloudinary](https://cloudinary.com/)
2. Go to Dashboard
3. Copy: Cloud Name, API Key, API Secret

**Update appsettings.json:**
```json
{
  "Cloudinary": {
    "CloudName": "your-cloud-name",
    "ApiKey": "your-api-key",
    "ApiSecret": "your-api-secret"
  }
}
```

See [CloudinarySetup.md](docs/CloudinarySetup.md) for detailed usage guide.

### 4. JWT Configuration

**Update appsettings.json:**
```json
{
  "JwtSettings": {
    "SecretKey": "your-secret-key-at-least-32-characters-long",
    "Issuer": "NetrexEcommerce",
    "Audience": "NetrexEcommerceUsers",
    "ExpiryInMinutes": 60
  }
}
```

⚠️ **Important:** Use a strong, unique secret key for production!

### 5. Restore Dependencies
```bash
dotnet restore
```

### 6. Build the Solution
```bash
dotnet build
```

### 7. Run the Application
```bash
cd APIGateway_Service
dotnet run
```

The API will start at: `https://localhost:7239` 

---

## 📚 API Documentation

Once the application is running, access Swagger UI at:
```
https://localhost:7239/swagger
```

Swagger provides:
- Interactive API documentation
- Endpoint testing
- Request/Response models
- Authentication testing

---

## 🔐 Authentication

### JWT Authentication Flow:

1. **Register/Login** → Receive JWT token
2. **Add token to requests** → `Authorization: Bearer <your-token>`
3. **Access protected endpoints** → Token validates user

**Example:**
```http
POST /api/Authentication/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "expiresAt": "2024-01-26T12:00:00Z"
  },
  "isSuccess": true,
  "message": "Login successful"
}
```

---

## 🧪 Testing

### Test Cloudinary Integration

**Endpoint:** `POST /api/CloudinaryTest/upload-test`

Upload a test image to verify Cloudinary setup.

### FluentValidation

All DTOs are validated using FluentValidation before processing:
- Automatic validation on API requests
- Clear validation error messages
- Custom validation rules per module

---

## 📂 Database Schema

### Key Entities:

- **User** - User accounts and authentication
- **UserRole** - Role-based access control
- **UserCredential** - Password hashing and security
- **Customer** - Customer profiles and addresses
- **Seller** - Seller accounts and stores
- **Product** - Product catalog
- **ProductImage** - Product images (Cloudinary URLs)
- **Cart & CartItem** - Shopping cart
- **Order & OrderItem** - Orders and line items
- **Invoice** - Billing records
- **PaymentDetail** - Payment transactions
- **SellerPayout** - Seller earnings

---

## 🌐 Cloudinary Integration

Images are stored on Cloudinary cloud storage instead of local server.

**Benefits:**
- ✅ Unlimited storage
- ✅ Automatic image optimization
- ✅ CDN delivery (fast loading)
- ✅ Image transformations

**Usage:**
See detailed guide: [CloudinarySetup.md](docs/CloudinarySetup.md)

---

## 🔧 Development Workflow

### Adding a New Feature:

1. **Create Entity** (Domain Layer)
2. **Create Repository Interface** (Domain Layer)
3. **Implement Repository** (Infrastructure Layer)
4. **Create DTO** (Application Layer)
5. **Create Manager/Service** (Application Layer)
6. **Add FluentValidation** (Application Layer)
7. **Create Controller** (WebApi Layer)
8. **Register Services** (DI Configuration)
9. **Test with Swagger**

---

## 📋 Folder Organization

### Application Layer
```
Application_Service/
├── Common/
│   ├── APIResponses/        # Standard API response models
│   ├── Cloudinary/          # Cloudinary interfaces
│   └── Email/               # Email service
├── DTO_s/                   # Data Transfer Objects
├── Interfaces/              # Service/Manager interfaces
├── Services/                # Business logic implementation
└── DI/                      # Dependency Injection configuration
```

### Infrastructure Layer
```
Infrastructure_Service/
├── Data/                    # DbContext
├── Persistance/
│   ├── Repositories/        # Repository implementations
│   ├── CloudinaryImplementation/  # Cloudinary manager
│   └── UnitOfWork/         # Unit of Work pattern
└── DI/                      # Infrastructure DI configuration
```

### Domain Layer
```
Domain_Service/
├── Entities/                # Database entities
├── RepoInterfaces/          # Repository interfaces
└── Enums/                   # Enumerations
```

---

## 🚦 API Response Format

All API endpoints return standardized responses:

### Success Response:
```json
{
  "data": { ... },
  "isSuccess": true,
  "message": "Operation successful",
  "status": "Ok"
}
```

### Error Response:
```json
{
  "data": null,
  "isSuccess": false,
  "message": "Error description",
  "status": "BadRequest"
}
```

---

## 🔒 Security Features

- ✅ JWT Authentication
- ✅ Password Hashing (Encryption)
- ✅ Role-based Authorization
- ✅ FluentValidation (Input sanitization)
- ✅ HTTPS enforcement
- ✅ CORS configuration

---

## 📖 Documentation

- [Cloudinary Setup Guide](docs/CloudinarySetup.md) - How to use Cloudinary for image management

---

## 🤝 Contributing

1. Create a feature branch
2. Make your changes
3. Test thoroughly
4. Submit a Pull Request

### Code Standards:
- Follow Clean Architecture principles
- Use meaningful variable/method names
- Add XML comments for public methods
- Write unit tests for business logic
- Validate all inputs with FluentValidation

---

## 📝 License

[Add your license here]

---

## 📞 Support

For questions or issues:
- Check documentation in `/docs` folder
- Review Swagger API documentation
- Contact development team

---

## 🎯 Future Enhancements

- [ ] Deploy to Azure/AWS
- [ ] Add unit tests
- [ ] Add integration tests
- [ ] Implement caching (Redis)
- [ ] Add logging (Serilog)
- [ ] Add API rate limiting
- [ ] Implement real-time notifications (SignalR)
- [ ] Add payment gateway integration
- [ ] Implement advanced search & filtering

---

**Built with ❤️ using .NET 9 and Clean Architecture**