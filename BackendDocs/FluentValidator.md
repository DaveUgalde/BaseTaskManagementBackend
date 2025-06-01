FluentValidation, MediatR y CQRS

Arquitectura general del flujo
1. Cliente envia un RegisterCommand con los datos del nuevo usuario.
2. El comando se enruta por MediatR al RegisterCommandHandler.
3. Antes de llegar al Handler, entra un ValidationBehaviour(middleware de MediatR).
4. Est ValidationBehaviour invoca todos los AbstractValidator<T> registrados
para el tipo de comando (en estecaso RegisterCommandValidator).
5. Si hay errores de validacion:
  * Se lanza una excepcion (como ValidationException).
  * El flujo se detiene, nollega al Handler.
6. Si no hay errores, continua y se ejecuta el Handler.

