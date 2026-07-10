# Prueba técnica - Desarrollador Web Backend .NET

## Objetivo

Completar una API REST en .NET que será consumida por un frontend React (ya incluido en este repositorio). La API debe conectarse a una base de datos PostgreSQL en **Neon Tech** y manejar los módulos de **Presupuestos**, **Productos**, **Servicios** y **Clientes**.

## Stack tecnológico

- **Backend:** .NET 9 + Entity Framework Core + Npgsql
- **Frontend:** React + TypeScript + Vite (ya completo)
- **Base de datos:** PostgreSQL (Neon Tech)

## Estructura del proyecto

```
Prueba-tecnica-backend/
├── backend/
│   └── ApiTemplate/
│       ├── Controllers/      (esqueletos vacíos con TODOs)
│       ├── Services/          (solo interfaces)
│       ├── Repositories/      (solo interfaces)
│       ├── Models/            (entidades completas)
│       ├── DTOs/              (completos)
│       ├── Data/              (AppDbContext completo)
│       └── Program.cs         (configuración básica, DI por completar)
├── frontend/                  (completo, no modificar)
│   └── src/
│       ├── pages/             (Dashboard, Productos, Servicios, Presupuestos, Clientes)
│       └── api.ts             (cliente HTTP para consumir la API)
└── README.md
```

## Lo que debes implementar

Debes implementar **toda la lógica del backend** partiendo del esqueleto proporcionado. El proyecto ya incluye:

- ✅ Modelos de datos (entidades)
- ✅ DTOs de entrada/salida
- ✅ AppDbContext con las relaciones entre entidades
- ✅ Interfaces de Repositorios y Servicios
- ✅ Controladores con los endpoints definidos (vacíos)
- ✅ Configuración de EF Core + PostgreSQL
- ✅ Cliente HTTP en el frontend

### Capa de Repositorios

Crear las implementaciones concretas de cada interfaz en `Repositories/`:

- `ClienteRepository` → `IClienteRepository`
- `ProductoRepository` → `IProductoRepository`
- `ServicioRepository` → `IServicioRepository`
- `PresupuestoRepository` → `IPresupuestoRepository`

Cada repositorio debe implementar operaciones CRUD completas usando Entity Framework Core.

### Capa de Servicios

Crear las implementaciones concretas de cada interfaz en `Services/`:

- `ClienteService` → `IClienteService`
- `ProductoService` → `IProductoService`
- `ServicioService` → `IServicioService`
- `PresupuestoService` → `IPresupuestoService`

Deben contener la lógica de negocio, validaciones, mapeo entre entidades y DTOs, y logging.

### Capa de Controladores

Completar los controladores en `Controllers/` inyectando los servicios y exponiendo los endpoints REST.

### Configuración

Registrar todos los repositorios y servicios en el contenedor de DI en `Program.cs`.

## Modelo de datos

- **Cliente:** Id, Nombre, Email, Teléfono, Dirección, FechaCreacion
- **Producto:** Id, Nombre, Descripción, Precio, Stock, FechaCreacion
- **Servicio:** Id, Nombre, Descripción, PrecioPorHora, FechaCreacion
- **Presupuesto:** Id, ClienteId, FechaCreacion, Total, Estado (Pendiente/Aprobado/Rechazado)
- **PresupuestoDetalle:** Id, PresupuestoId, TipoItem (Producto/Servicio), ItemId, Cantidad, PrecioUnitario, Subtotal

## Endpoints que debe exponer la API

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/clientes | Listar clientes |
| GET | /api/clientes/{id} | Obtener cliente por ID |
| POST | /api/clientes | Crear cliente |
| PUT | /api/clientes/{id} | Actualizar cliente |
| DELETE | /api/clientes/{id} | Eliminar cliente |
| GET | /api/productos | Listar productos |
| GET | /api/productos/{id} | Obtener producto por ID |
| POST | /api/productos | Crear producto |
| PUT | /api/productos/{id} | Actualizar producto |
| DELETE | /api/productos/{id} | Eliminar producto |
| GET | /api/servicios | Listar servicios |
| GET | /api/servicios/{id} | Obtener servicio por ID |
| POST | /api/servicios | Crear servicio |
| PUT | /api/servicios/{id} | Actualizar servicio |
| DELETE | /api/servicios/{id} | Eliminar servicio |
| GET | /api/presupuestos | Listar presupuestos |
| GET | /api/presupuestos/{id} | Obtener presupuesto por ID |
| POST | /api/presupuestos | Crear presupuesto (con detalles) |
| PATCH | /api/presupuestos/{id}/estado | Actualizar estado |
| DELETE | /api/presupuestos/{id} | Eliminar presupuesto |
| GET | /api/presupuestos/cliente/{clienteId} | Presupuestos por cliente |

## Criterios de evaluación

- **Arquitectura en capas:** Separación clara Controllers → Services → Repositories
- **Código limpio:** Nombres descriptivos, principios SOLID, sin código duplicado
- **Comentarios relevantes:** Donde sea necesario explicar decisiones
- **Manejo de errores:** Try-catch, validaciones, códigos HTTP apropiados
- **Logging:** Uso de ILogger para registrar operaciones importantes
- **Operaciones CRUD completas** para cada módulo
- **Integración correcta con PostgreSQL** en Neon Tech
- **La API debe poder ser consumida** desde el frontend React

## Instrucciones para empezar

1. Clonar este repositorio
2. Crear una base de datos PostgreSQL en [Neon Tech](https://neon.tech)
3. Configurar la conexión en `backend/ApiTemplate/appsettings.json`
4. Implementar la lógica del backend (repositorios, servicios, controladores)
5. Ejecutar migraciones de EF Core
6. Ejecutar el backend: `cd backend/ApiTemplate && dotnet run`
7. Ejecutar el frontend: `cd frontend && npm run dev`
8. Abrir `http://localhost:5173` en el navegador

## Entrega

Subir el código completo a un repositorio público en GitHub y compartir el enlace.
