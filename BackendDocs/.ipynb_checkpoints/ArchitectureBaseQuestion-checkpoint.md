🔹 1. Configuración Básica

* Nombre del proyecto:

Ejemplo: InventoryManagementSystem

* Tipo de API:

- REST

- GraphQL

- gRPC

- Microservicios

- Híbrido (REST + GraphQL)

* Arquitectura:

- Clean Architecture (recomendado)

- Capas tradicionales (N-Layer)

- Hexagonal (Ports & Adapters)

- Vertical Slice



🔹 2. Dominio (Domain Layer)

* Entidades principales:

- Lista nombres (ej: User, Product, Order, Procedure, Stage).

* Patrones avanzados en Domain:

* EntityBase (clase abstracta con Id, CreatedAt)

- Value Objects (ej: EmailAddress, Money)

- Aggregate Roots (ej: Procedure como raíz)

- Domain Events (ej: ProcedureCreatedEvent)

* Interfaces de dominio:

- IRepository<T> (genérico)

- Repositorios personalizados (ej: IProcedureRepository)

- Domain Services (ej: IProcedureValidator)



🔹 3. Infraestructura (Infrastructure Layer)

* Base de datos:

- SQL Server + EF Core

- PostgreSQL + EF Core

- MongoDB

- Dapper (para SQL puro)

- Redis (caching)

* Patrones de persistencia:

- Repository + Unit of Work

- CQRS con MediatR

- Specification Pattern

* Servicios externos:

- Email (SendGrid, SMTP)

- Cloud Storage (AWS S3, Azure Blob)

- Mensajería (RabbitMQ, Kafka)

- HTTP Clients (Refit)

