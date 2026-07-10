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
│   └── ApiTemplate/          <-- API a completar
│       ├── Controllers/      (esqueletos creados)
│       ├── Services/         (esqueletos creados)
│       ├── Repositories/     (esqueletos creados)
│       ├── Models/           (ya incluidos)
│       ├── DTOs/             (ya incluidos)
│       ├── Data/             (ya incluido)
│       └── Program.cs        (ya configurado)
├── frontend/                 <-- Frontend React (completo, no modificar)
│   └── src/
│       ├── pages/            (Dashboard, Productos, Servicios, Presupuestos, Clientes)
│       └── api.ts            (cliente HTTP para consumir la API)
└── README.md
```

## Lo que debes implementar en el backend

Debes **completar la implementación** de la API .NET. El esqueleto del proyecto ya está creado con la estructura de capas. Tu tarea es escribir la lógica faltante siguiendo buenas prácticas. **Presta especial atención a los siguientes puntos**:

### 1. Capa de Repositorios (Data Access)
- Implementar completamente cada repositorio (`ClienteRepository`, `ProductoRepository`, `ServicioRepository`, `PresupuestoRepository`)
- Operaciones CRUD completas para cada módulo
- Consultas optimizadas con `Include` para relaciones

### 2. Capa de Servicios (Business Logic)
- Implementar completamente cada servicio (`ClienteService`, `ProductoService`, `ServicioService`, `PresupuestoService`)
- Validaciones de negocio
- Mapeo entre entidades y DTOs
- Manejo de errores y excepciones
- Logging de operaciones importantes

### 3. Capa de Controladores (API endpoints)
- Endpoints REST completos para cada módulo (los esqueletos ya están creados)
- Documentación de endpoints
- Manejo de códigos HTTP apropiados (200, 201, 204, 400, 404, 500)

### 4. Base de datos
- Crear la base de datos en **Neon Tech** (PostgreSQL)
- Configurar la conexión en `appsettings.json`
- Crear y ejecutar las migraciones de Entity Framework Core
- Las tablas deben reflejar fielmente los modelos incluidos

### 5. Buenas prácticas que evaluaremos
- **Arquitectura en capas:** Separación clara entre Controllers / Services / Repositories
- **Código limpio y legible:** Nombres descriptivos, principios SOLID
- **Comentarios relevantes:** Explica decisiones importantes donde sea necesario
- **Manejo de errores:** Try-catch, validaciones, mensajes de error claros
- **Logging:** Uso de ILogger para registrar operaciones importantes
- **Inyección de dependencias:** Correcto registro y uso de dependencias
- **DTOs correctamente implementados:** Mapeo adecuado entre entidades y DTOs

## Modelo de datos

- **Cliente:** Id, Nombre, Email, Teléfono, Dirección, FechaCreacion
- **Producto:** Id, Nombre, Descripción, Precio, Stock, FechaCreacion
- **Servicio:** Id, Nombre, Descripción, PrecioPorHora, FechaCreacion
- **Presupuesto:** Id, ClienteId, FechaCreacion, Total, Estado (Pendiente/Aprobado/Rechazado)
- **PresupuestoDetalle:** Id, PresupuestoId, TipoItem (Producto/Servicio), ItemId, Cantidad, PrecioUnitario, Subtotal

## Instrucciones para empezar

1. Clonar este repositorio
2. Crear una base de datos PostgreSQL en [Neon Tech](https://neon.tech)
3. Configurar la conexión en `backend/ApiTemplate/appsettings.json`
4. Ejecutar migraciones de EF Core
5. Ejecutar el backend: `cd backend/ApiTemplate && dotnet run`
6. Ejecutar el frontend: `cd frontend && npm run dev`
7. Abrir `http://localhost:5173` en el navegador

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
| POST | /api/presupuestos | Crear presupuesto |
| PATCH | /api/presupuestos/{id}/estado | Actualizar estado del presupuesto |
| DELETE | /api/presupuestos/{id} | Eliminar presupuesto |
| GET | /api/presupuestos/cliente/{clienteId} | Presupuestos por cliente |

## Criterios de evaluación

- Correcta implementación de la arquitectura en capas
- Calidad y legibilidad del código
- Manejo de errores y casos borde
- Uso de logging
- Comentarios explicativos
- Funcionamiento correcto de todos los CRUD
- Integración correcta con la base de datos
- Capacidad de consumir la API desde el frontend

## Entrega

Subir el código completo a un repositorio público en GitHub y compartir el enlace.
