# NSERIO WEB API

_Esta es la solución requerida para el proyecto de prueba técnica para Codifico._

## Comenzando 🚀

_Es neceserio ejecutar antes que nada el script "StoreProcedures.sql"  que se encuentra en la carpeta Anexos.EL motivo es que allí se crean los procesos almacenados que se solicitaron para la aplicacion (consultas), estas a su vez son utilizadas para poblar las tablas y dar información del front._

### Tecnologías Usadas 🛠️

1. **.NET 8.0**: Framework principal para la construcción de la API.
2. **ASP.NET Core**: Para la creación de servicios web y APIs.
3. **Entity Framework Core**: ORM para el acceso a datos y mapeo de objetos.
4. **SQL Server**: Base de datos relacional utilizada para almacenar la información.
5. **Stored Procedures**: Procedimientos almacenados en SQL Server para la lógica de negocio en la base de datos.
6. **Visual Studio**: IDE utilizado para el desarrollo del proyecto.
7. **Git**: Sistema de control de versiones para el manejo del código fuente.
8. **Swagger**: Para la documentación y prueba de la API.

### Ejecución del Proyecto 🚀

1. Clona el repositorio.
2. Ejecuta el script [`StoreProcedures.sql`]
3. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`.
4. Abre la solución [`Sales_Date_Production.sln`] en Visual Studio.
5. Compila y ejecuta el proyecto.

### Endpoints Disponibles 📋

- `GET /api/SDP/GetAllUsers`: Obtiene la lista de empleados.
- `GET /api/SDP/GetProducts`: Obtiene la lista de productos.
- `GET /api/SDP/GetClientOrders/{customerId}`: Obtiene las órdenes de un cliente específico.
- `GET /api/SDP/GetShippers`: Obtiene la lista de transportistas.
- `POST /api/SDP/AddNewOrder`: Crea una nueva orden.

### Autor ✒️

- **Andrés Fernando García Perea** - [AndresFdoGarcia](https://github.com/AndresFdoGarcia)

```
