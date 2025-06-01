# BaseTaskManagementBackend

Este proyecto representa la base de un backend modular y escalable para una aplicación de gestión de tareas, desarrollado en .NET con una arquitectura en capas limpia y buenas prácticas de desarrollo.

## 📦 Estructura del Proyecto

La solución está organizada en las siguientes carpetas principales:

Portfolio/
└── Backend/
├── WorkModel.API # Controladores y configuración web
├── WorkModel.Application # Lógica de aplicación (CQRS, DTOs, Servicios)
├── WorkModel.Domain # Entidades del dominio y contratos
├── WorkModel.Infrastructure # Persistencia, servicios externos
├── WorkModel.Shared # Utilidades compartidas y capa de validación
├── WorkModel.Tests # Proyecto de testing con xUnit y FluentAssertions


## ✅ Características Implementadas

- ✔️ Arquitectura en capas: Domain, Application, Infrastructure, API y Shared.
- ✔️ Autenticación con generación de JWT.
- ✔️ Uso del patrón **CQRS** con MediatR.
- ✔️ Validaciones con **FluentValidation**.
- ✔️ Pruebas automatizadas con **xUnit** y FluentAssertions.
- ✔️ Interfaces de repositorios y servicios para facilitar pruebas y extensión.

## 🛠️ Detalles de Implementación

### 🔐 Autenticación

- Entidades:
  - `User`
  - `Role`
- Interfaces:
  - `IUserRepository`, `IRoleRepository`
  - `IJwtTokenGenerator`
- Servicios:
  - `JwtTokenGenerator` para creación de tokens
- CQRS:
  - `LoginCommand` y `RegisterCommand` con sus respectivos `Handlers`
- DTOs:
  - `LoginRequest`, `RegisterRequest`, `AuthResult`

### 🧪 Testing

- Proyecto de pruebas separado
- Tests para validaciones y lógica de autenticación
- Frameworks:
  - xUnit
  - FluentAssertions
  - FluentValidation

## 📂 Validaciones

- Se ha creado una carpeta específica `Shared/Validation` donde se centralizan las reglas de validación para `LoginRequest`, `RegisterRequest`, etc.

## 🚧 Próximos Pasos

- [ ] CRUD para proyectos/tareas
- [ ] Gestión de usuarios avanzados (edición, roles)
- [ ] Middleware de manejo de errores
- [ ] Documentación con Swagger
- [ ] Integración con frontend (Angular o React)

## 🧠 Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- Visual Studio o VS Code
- Git
- (Opcional) Postman para pruebas de API

## 🚀 Cómo Ejecutar

```bash
dotnet build
dotnet run --project WorkModel.API
🤝 Contribuciones

Este proyecto es personal pero extensible. Si deseas colaborar, ¡bienvenido! Solo crea un fork y haz tu pull request.

👨‍💻 Autor

David Ugalde – GitHub