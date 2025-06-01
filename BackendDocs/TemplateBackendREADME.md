markdown
# 🏗️ Backend Template: Clean Architecture + DDD

_Plantilla modular para proyectos backend con capas claras y patrones escalables._

## **📌 Decisiones de Arquitectura**

### **1. Estructura del Proyecto**
```plaintext
src/
├── Domain/          # Lógica de negocio pura
├── Infrastructure/  # Implementaciones externas
├── Application/     # Casos de uso y servicios
├── API/             # Capa de presentación
└── Tests/           # Pruebas automatizadas
2. Tecnologías Principales

Capa	Tecnologías/Patrones
Domain	Entidades, Value Objects, Domain Events
Infrastructure	EF Core, Dapper, Redis, RabbitMQ
Application	CQRS (MediatR), FluentValidation
API	REST/GraphQL, JWT, Swagger
3. Patrones Clave

Clean Architecture: Separación clara de capas (Domain sin dependencias externas).
Repository + Unit of Work: Para abstraer la persistencia.
CQRS: Separación de comandos (write) y queries (read) donde aplica.
Domain Events: Para manejar eventos de negocio (ej: OrderCreatedEvent).
4. Reglas de Implementación

✅ Domain:

Contiene solo lógica de negocio.
No depende de ninguna otra capa.
Interfaces definidas aquí (ej: IOrderRepository).
✅ Infrastructure:

Implementa interfaces de Domain.
Configura bases de datos, mensajería, etc.
✅ Application:

Orquesta flujos de negocio.
Usa DTOs para transferencia de datos.
✅ API:

Solo maneja HTTP, autenticación y serialización.
Sin lógica de negocio.
🚀 Cómo Usar Este Template

1. Configuración Inicial

bash
# Clonar el repositorio
git clone https://github.com/tu-repo/backend-template.git

# Instalar dependencias
dotnet restore
2. Generar Nueva Entidad

Ejemplo para agregar una entidad Product:

bash
dotnet run generate-entity Product --properties "Id:Guid,Name:string,Price:decimal"
Esto creará:

Domain/Entities/Product.cs
Application/DTOs/ProductDto.cs
Infrastructure/Repositories/ProductRepository.cs
3. Módulos Opcionales

Para activar módulos como CQRS o Redis, edita appsettings.json:

json
{
  "Features": {
    "CQRS": true,
    "RedisCaching": false
  }
}
🧩 Módulos Incluidos

Módulo	Descripción	Activación
CQRS	Patrón Command/Query con MediatR	Features.CQRS=true
Redis	Caching distribuido	Features.Redis=true
GraphQL	Alternativa a REST	Features.GraphQL=true
Hangfire	Procesamiento en segundo plano	Features.Hangfire=true
🔧 Configuración por Entorno

json
// appsettings.Development.json
{
  "Database": {
    "Provider": "SqlServer",
    "ConnectionString": "Server=localhost;Database=DevDB;Trusted_Connection=True;"
  },
  "JWT": {
    "SecretKey": "dev-secret-key"
  }
}
🧪 Testing

bash
# Ejecutar pruebas unitarias
dotnet test src/Tests/Unit

# Ejecutar pruebas de integración
dotnet test src/Tests/Integration
📚 Documentación Adicional

Clean Architecture Guidelines
CQRS Pattern
EF Core Best Practices
🛠 Soporte

¿Problemas o sugerencias? Abre un issue.


### **Características Clave del README**:
1. **Modular**: Explica cómo activar/desactivar funcionalidades.
2. **Auto-documentado**: Incluye comandos útiles y ejemplos.
3. **Decisiones justificadas**: Explica el "porqué" de cada patrón.
4. **Amigable para DevOps**: Configuración por entorno y testing.

