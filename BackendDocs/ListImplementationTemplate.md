✅ Clases a implementar:


📁 Domain/Authentication/
User
Role

📁 Domain/Interfaces/Repository
IUserRepository
IRoleRepository


📁 Application/Auth/
AuthResult.cs
Commands/RegisterCommand.cs
Commands/RegisterCommandHandler.cs
Commands/LoginCommand.cs
Commands/LoginCommandHandler.cs

📁 Application/DTO/
RegisterRequest
LoginRequest

📁 Domain/Interfaces/Services/
IJwtTokenGenerator.cs

📁 Infrastructure/Authentication/
JwtTokenGenerator.cs
JwtSettings.cs

📁 Infrastructre/Repositories/
UserRepository
RoleRepository

📁 API/Controllers/
AuthController.cs

📁 API/Middeleware/
TokenValidationMiddleware

