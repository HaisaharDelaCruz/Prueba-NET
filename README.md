# Prueba técnica .NET

Dentro del proyecto estará todos los documentos necesarios para la ejecución del proyecto.

## Herramientas

- Entity
- .NET
- Angular
- SQL Server Express

## Actividad 1

Para hacer las migraciones nos tendremos que dirigir hacia la Consola del Administrador de Paquetes, y escoger en el proyecto predeterminado la solución de Datos.

Al seleccionarla ejecutaremos los siguientes comandos.

```bash
add-migration FaseDesarrollo
update-database
```

Al hacer el update, podremos ejecutar de manera tradicional la aplicación.
Para iniciar Angular irémos a la carpeta AngularTienda y ejecutaremos el siguiente comando.

```
ng serve
```
Al ejecutar la aplicación se abrirá en la siguiente ruta:
http://localhost:64372

los datos de acceso son:
Usuario:
Luis
Constraseña:
123


## Articulo

```http
  GET /api/Articulo/obtenerArticulos
  GET /api/Articulo/{id}
  DELETE /api/Articulo/{id}
  POST /api/Articulo/crearArticulo
  PUT /api/Articulo/editarArticulo/{id}
  POST /api/Articulo/asignarArticulo
  GET /api/Articulo/mostrarTiendaArticulo

```

## Auth
```http
  POST /api/auth/login
  POST /api/auth/register
```

## Carrito

```http
  POST /api/Carrito/comprar
  GET /api/Carrito/obtenerComprasCliente/{clienteId}
```

## Cliente
```http
  POST /api/clientes/obtenerClientes
  GET /{id}
  POST /api/clientes/crearCliente
  PUT /api/clientes/crearCliente
  DELETE /api/clientes/eliminarCliente/{id}
```
## Tiendas
```http
  GET /api/Tiendas/obtenerTiendas
  GET /api/Tiendas/obtenerTienda/{id}
  POST /api/Tiendas/obtenerTienda/{id}
  PUT /api/Tiendas/editarTienda/{id}
  DELETE /api/Tiendas/eliminarTienda/{id}
```
