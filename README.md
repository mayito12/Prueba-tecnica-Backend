# Prueba técnica - Desarrollador Web Backend .NET

## Objetivo

Completar la capa de backend de una aplicación de presupuestos. La API debe consumir una base de datos PostgreSQL hosteada en **Neon Tech** y exponer endpoints REST para los módulos **Clientes**, **Productos**, **Servicios** y **Presupuestos**.

El frontend React ya está completo y funcional; tu trabajo es únicamente en el backend.

## Stack tecnológico

- **Backend:** .NET 9 + Entity Framework Core + Npgsql + AutoMapper
- **Frontend:** React + TypeScript + Vite (completo, no modificarlo)
- **Base de datos:** PostgreSQL (Neon Tech) — ya migrada y con datos seed cargados

## Estructura actual del proyecto

```
Prueba-tecnica-backend/
├── backend/
│   ├── Controllers/          <- Esqueletos con endpoints y XML docs
│   ├── Models/               <- Entidades completas con relaciones
│   ├── Data/
│   │   ├── AppDbContext.cs   <- DbContext con DbSets y configuraciones
│   │   └── Seed/             <- Scripts SQL (ya ejecutados)
│   ├── Migrations/           <- Migración inicial (ya aplicada)
│   ├── Program.cs            <- Configuración parcial (DbContext, CORS, Swagger)
│   └── appsettings*.json     <- Connection string configurado
├── frontend/                 <- Completo, no modificar
│   └── src/
│       ├── pages/            <- Dashboard, Clientes, Productos, Servicios, Presupuestos
│       └── api.ts            <- Cliente HTTP apuntando a localhost:5118
└── README.md
```

## Lo que debes crear

Debes implementar la **arquitectura completa** del backend partiendo de los controladores vacíos. El proyecto ya incluye:

- ✅ Modelos de datos (entidades en `Models/`)
- ✅ AppDbContext con relaciones y configuraciones
- ✅ Migración inicial aplicada a la BD
- ✅ Datos seed cargados (10 clientes, 6 productos, 5 servicios, 105 presupuestos)
- ✅ Controladores con endpoints definidos y documentación XML
- ✅ Conexión a BD configurada (Neon PostgreSQL)
- ✅ CORS configurado para `http://localhost:5173`

### 1. Carpeta `DTOs/`

Crear DTOs de entrada (Create/Update) y salida (Response) para cada módulo:

- `Clientes/` → `CreateClienteDto`, `ClienteDto`
- `Productos/` → `CreateProductoDto`, `ProductoDto`
- `Servicios/` → `CreateServicioDto`, `ServicioDto`
- `Presupuestos/` → `CreatePresupuestoDto`, `PresupuestoDto`, `UpdateEstadoDto`
- Configurar perfiles de mapeo con **AutoMapper** (`MappingProfile.cs`)

### 2. Carpeta `Repositories/`

Interfaces y sus implementaciones para el acceso a datos con EF Core:

| Interfaz | Implementación |
|----------|---------------|
| `IClienteRepository` | `ClienteRepository` |
| `IProductoRepository` | `ProductoRepository` |
| `IServicioRepository` | `ServicioRepository` |
| `IPresupuestoRepository` | `PresupuestoRepository` |

Cada repositorio debe implementar operaciones CRUD completas:
- `GetAll()` → obtener todos los registros activos
- `GetById(int id)` → obtener por ID
- `Create(T entity)` → insertar
- `Update(T entity)` → actualizar
- `Delete(int id)` → soft delete (marcar `Activo = false`)

**Importante:** Usar `Activo` para soft delete en Clientes, Productos y Servicios. Los presupuestos se eliminan físicamente.

### 3. Carpeta `Services/`

Interfaces y sus implementaciones con la lógica de negocio:

| Interfaz | Implementación |
|----------|---------------|
| `IClienteService` | `ClienteService` |
| `IProductoService` | `ProductoService` |
| `IServicioService` | `ServicioService` |
| `IPresupuestoService` | `PresupuestoService` |

Cada servicio debe:
- Usar **ILogger** para registrar cada operación
- Usar **AutoMapper** para mapear entre entidades y DTOs
- Validar datos de entrada antes de persistir
- Propagar excepciones con mensajes claros

### 4. Completar `Program.cs`

Registrar todos los servicios, repositorios y AutoMapper en el contenedor de DI:

```csharp
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IPresupuestoRepository, PresupuestoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();
```

### 5. Completar los Controladores

Cada controlador ya tiene los endpoints definidos con documentación XML (`<summary>`, `<param>`, `<returns>`). Debes reemplazar el `throw new NotImplementedException()` por la lógica real:

- Inyectar el servicio correspondiente por constructor
- Envolver cada acción en try-catch
- Loguear la operación con `ILogger`
- Retornar códigos HTTP apropiados (200, 201, 204, 400, 404, 500)
- Mapear DTOs de entrada/salida con AutoMapper

## Modelo de datos

```
Cliente: Id, Nombre, Email, Telefono, Direccion, FechaCreacion, Activo
Producto: Id, Nombre, Descripcion, Precio, Stock, FechaCreacion, Activo
Servicio: Id, Nombre, Descripcion, PrecioPorHora, FechaCreacion, Activo
Presupuesto: Id, ClienteId, FechaCreacion, Total, Estado (0=Pendiente,1=Aprobado,2=Rechazado)
PresupuestoProducto: Id, PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal
PresupuestoServicio: Id, PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal
```

## Endpoints de la API

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/clientes` | Listar clientes activos |
| GET | `/api/clientes/{id}` | Obtener cliente por ID |
| POST | `/api/clientes` | Crear cliente |
| PUT | `/api/clientes/{id}` | Actualizar cliente |
| DELETE | `/api/clientes/{id}` | Soft delete (Activo = false) |
| GET | `/api/productos` | Listar productos activos |
| GET | `/api/productos/{id}` | Obtener producto por ID |
| POST | `/api/productos` | Crear producto |
| PUT | `/api/productos/{id}` | Actualizar producto |
| DELETE | `/api/productos/{id}` | Soft delete (Activo = false) |
| GET | `/api/servicios` | Listar servicios activos |
| GET | `/api/servicios/{id}` | Obtener servicio por ID |
| POST | `/api/servicios` | Crear servicio |
| PUT | `/api/servicios/{id}` | Actualizar servicio |
| DELETE | `/api/servicios/{id}` | Soft delete (Activo = false) |
| GET | `/api/presupuestos` | Listar presupuestos |
| GET | `/api/presupuestos/{id}` | Obtener presupuesto por ID |
| POST | `/api/presupuestos` | Crear presupuesto (con detalles) |
| PATCH | `/api/presupuestos/{id}/estado` | Actualizar estado |
| DELETE | `/api/presupuestos/{id}` | Eliminar presupuesto |
| GET | `/api/presupuestos/cliente/{clienteId}` | Presupuestos por cliente |

## Criterios de evaluación

| Aspecto | Peso | Qué se evalúa |
|---------|------|---------------|
| **Arquitectura en capas** | 25% | Separación clara Controllers → Services → Repositories, inyección de dependencias |
| **DTOs + AutoMapper** | 20% | Uso correcto de DTOs de entrada/salida, perfiles de mapeo, proyecciones |
| **Manejo de errores** | 20% | Try-catch en controladores y servicios, códigos HTTP correctos, mensajes descriptivos |
| **Logging** | 15% | Uso de ILogger en todas las capas, registro de operaciones y excepciones |
| **Operaciones CRUD** | 10% | Completitud de las operaciones, soft delete, validaciones |
| **Calidad del código** | 10% | Nombres descriptivos, principios SOLID, sin código duplicado |

## Instrucciones para empezar

1. Clonar este repositorio
2. Abrir la solución en tu IDE favorito (VS, Rider, VS Code)
3. Instalar paquetes NuGet necesarios:
   ```bash
   cd backend
   dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
   ```
4. Crear las carpetas y archivos según la estructura descrita arriba
5. Implementar repositorios, servicios, DTOs y controladores
6. Verificar que el proyecto compila:
   ```bash
   dotnet build
   ```
7. Ejecutar la API:
   ```bash
   cd backend && dotnet run
   ```
8. La API estará disponible en `http://localhost:5118`
9. (Opcional) Ejecutar el frontend para probar la integración:
   ```bash
   cd frontend && npm run dev
   ```

## Notas importantes

- La base de datos ya está creada en Neon Tech con la migración inicial aplicada y datos seed cargados
- No es necesario ejecutar `dotnet ef database update`
- La conexión usa SSL Mode=VerifyFull; puede requerir instalar el certificado CA de Neon Tech
- Los endpoints DELETE deben ser soft delete (Activo = false) para Clientes, Productos y Servicios
- Los presupuestos se eliminan físicamente (no tienen Activo)
- Al crear un presupuesto, calcular el Total basado en la suma de subtotales de productos y servicios

## Entrega

Subir el código completo a un repositorio público en GitHub y compartir el enlace.
