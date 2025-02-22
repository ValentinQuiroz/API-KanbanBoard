# API Kanban Board

API REST para gestionar un tablero Kanban, desarrollada con .NET Core 8.0 y Entity Framework Core.

## Descripción
Esta API proporciona endpoints para gestionar un tablero Kanban, permitiendo la creación, lectura, actualización y eliminación (CRUD) de columnas y tareas. Está diseñada para trabajar en conjunto con una aplicación frontend, con configuración CORS específica para desarrollo local.

## Características
- CRUD completo para tareas
- Gestión de columnas del tablero Kanban
- Validación de datos
- Soporte para CORS
- Integración con SQL Server

## Tecnologías Utilizadas
- .NET 8.0
- Entity Framework Core 9.0
- SQL Server
- Swagger (reemplazable)
- Microsoft.AspNetCore.Cors

## Requisitos Previos
- Visual Studio 2022 o posterior
- SQL Server Express
- .NET 8.0 SDK
- SQL Server Management Studio (recomendado)

## Instalación y configuración

1. Clonar el repositorio
```bash
   git clone https://github.com/ValentinQuiroz/API-KanbanBoard
   ```
2. Ejecutar el script SQL(`API_KanbanBoard/SQL/kanbanDBscript.sql`) para crear la base de datos

3. Configurar la cadena de conexión en `appsettings.json`
```bash
"ConnectionStrings": {
"Conexion": "Server=.\\SQLEXPRESS;Database=KanbanDB;Trusted_Connection=true;TrustServerCertificate=true"
}
```
4. Ejecutar la aplicación
