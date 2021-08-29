# SISTEMA WEB
# CONTROL DE INVENTARIOS

El siguiente proyecto muestra el desarrollo de un Sistema Web que permite la administración de usuarios, productos, categorías, proveedores, clientes, notas de venta, reportes e infomación personal.

El sistema se administra en base a perfiles, dependiendo del rol se mostrará los módulos hábiles para cada usuario.

Video demostrativo: https://www.youtube.com/watch?v=O8Utbfiy8_M&t=7s

Realizado por: Diana Bonilla
## 1. Herramientas de Desarrollo
Visual Studio 2019

El Sistema Web se desarrolla bajo el lenguaje C# el cual está incluido en la plataforma de Visual Studio 2019.

SQL Server 2018

El Sistema Web se conecta a un servidor para extraer los datos.

## 2. Estructura y Arquitectura
* Arquitectura
La arquitectura del Sistema Web se muestra en la siguiente imagen
* Estructura
Se utiliza el patrón arquitectónico MVC, que permite tener la administración del sistema de una
manera más eficiente y poder corregir errores o adaptar más capas, en la siguiente imagen muestra los directorios utilizados en el modelo, vista o controlador.

## 3. Funcionalidades Principales
Durante el desarrollo del Sistema Web se pudo obtener varios requerimientos y funcionalidades, algunas de las más importantes son las siguientes:

## Iniciar Sesión
El usuario puede iniciar sesión usando el nombre de usuario y contraseña, el sistema valida las credenciales ingresadas y permite el ingreso al sistema dependiendo el rol seleccionado. Adicional a eso existe un enlace para poder recuperar la contraseña.
![iniciar Sesión](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Inicio%20de%20sesi%C3%B3n.png?raw=true)

## PERFIL ADMINISTRADOR
El usuario con perfil administrador tendrá acceso a los siguientes modulos:
* Registrar Usuarios
El usuario con perfil administrador puede registrar, modificar, desactivar, exportar y visualizar los usuarios registrados
![registrar usuarios](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Usuarios.png?raw=true)
* Registrar Productos
El usuario con perfil administrador puede registrar, modificar, desactivar, exportar y visualizar los productos registrados
![registrar productos](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Productos.png?raw=true)
* Registrar Categorías
El usuario con perfil administrador puede registrar, modificar, desactivar, exportar y visualizar los productos registrados
![registrar productos](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Productos.png?raw=true)
* Registrar Proveedores
El usuario con perfil administrador puede registrar, modificar, desactivar, exportar y visualizar los proveedores registrados
![registrar proveedores](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Proveedor.png?raw=true)
* Registrar Clientes
El usuario con perfil administrador puede registrar, modificar, desactivar, exportar y visualizar los clientes registrados
![registrar clientes](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Clientes.png?raw=true)
* Registro de Reportes
El usuario administrador puede visualizar el reporte de las ventas registradas en la aplicación móvil
![reporte ventas](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Reporte%20de%20Ventas.png?raw=true)
* Actualizar Información Personal
El usuario administrador puede actualizar cierta información personal
![perfil administrador](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Perfil%20AdministradorI.jpg?raw=true)

## PERFIL EMPLEADO
El usuario con perfil empleado tendrá acceso a los siguientes modulos:
* Registrar Clientes
El usuario con perfil empleado puede registrar, modificar, desactivar, exportar y visualizar los clientes registrados
![registrar clientes](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Clientes.png?raw=true)
* Registrar Productos
El usuario con perfil empleado puede registrar, modificar, desactivar, exportar y visualizar los productos registrados
![registrar productos](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Productos.png?raw=true)
* Registrar Proveedores
El usuario con perfil empleado puede registrar, modificar, desactivar, exportar y visualizar los proveedores registrados
![registrar proveedores](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Proveedor.png?raw=true)
* Actualizar Información Personal
El usuario con perfil empleado puede actualizar cierta información personal
![perfil empleado](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Perfil%20Empleado.png?raw=true)
## PERFIL CAJERO
El usuario con perfil cajero tendrá acceso a los siguientes modulos:
* Registro Nota de Venta
El usuario con perfil cajero puede generar un nota de venta en base al pedido.
![nota de venta](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Notas%20de%20Venta.png?raw=true)
* Visualizar Reporte de Ventas
El usuario con perfil cajero puede generar un reporte de ventas en base a un filtro de búsqueda y obtener el total de ventas realizadas en ese periodo de tiempo
![reporte de ventas con filtro](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Reporte%20de%20Ventas%20con%20filtros.png?raw=true)
* Registrar Productos
El usuario con perfil cajero puede registrar, modificar, desactivar, exportar y visualizar los productos registrados
![registrar productos](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Registro%20de%20Productos.png?raw=true)
* Actualizar Información Personal
El usuario con perfil cajero puede actualizar cierta información personal
![perfil cajero](https://github.com/DIANA2512/AdministracionWeb/blob/main/Capturas/Perfil%20Cajero.jpg?raw=true)
## 4. Anexos
En el siguiente link se encuentra toda la información como Manual Técnico y video explicativo
[Documentacion](https://github.com/DIANA2512/Documentacion_Tesis.git)

