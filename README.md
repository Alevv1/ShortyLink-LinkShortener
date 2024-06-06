
# ShortyLink 
es una aplicación web de acortador de URL desarrollada con tecnología ASP.NET Core MVC. Permite a los usuarios crear enlaces cortos a partir de URLs largas, lo que facilita compartir enlaces de manera más concisa y eficiente.

## Tecnologías Utilizadas
ShortyLink está construido utilizando las siguientes tecnologías:

- ASP.NET Core MVC: Utilizado para desarrollar la lógica del servidor y proporcionar una arquitectura MVC robusta para la aplicación web.
- Entity Framework Core: Utilizado como ORM (Mapeo Objeto-Relacional) para interactuar con la base de datos SQL Server.
- HTML/CSS/Bootstrap: Utilizados para la maquetación y diseño de la interfaz de usuario, proporcionando una experiencia de usuario atractiva y receptiva.
- C#: Utilizado como lenguaje de programación principal para la lógica del servidor y la manipulación de datos.

## Funcionalidades Principales
- Acortamiento de URL: Los usuarios pueden ingresar una URL larga y obtener un enlace corto correspondiente.
- Redirección: Los enlaces cortos generados redirigen automáticamente a las URLs originales.
- Historial de Enlaces: Los usuarios pueden ver una lista de todos los enlaces acortados previamente.

## Instalación y Uso
Para utilizar ShortyLink localmente:

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio o cualquier otro editor de código.
3. Configura la cadena de conexión de la base de datos en appsettings.json.
4. Ejecuta las migraciones de Entity Framework para crear la base de datos.
5. Ejecuta la aplicación y accede a ella desde tu navegador web.
