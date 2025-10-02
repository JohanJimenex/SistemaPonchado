# 🕒 Sistema de Ponchado de Empleados

Un sistema simple para registrar entradas y salidas de empleados usando Windows Forms y .NET 9.

## 📋 ¿Qué hace este proyecto?

Este sistema permite:
- ✅ **Administradores**: Gestionar empleados (CRUD completo), ver todos los ponchados
- ✅ **Empleados**: Registrar entrada/salida, ver su historial personal
- ✅ **Base de datos local**: SQLite para almacenar información

## 🛠️ Tecnologías Usadas

- **C# .NET 9** - Lenguaje de programación
- **Windows Forms** - Interfaz gráfica
- **Entity Framework Core** - Para manejar la base de datos
- **SQLite** - Base de datos local
- **BCrypt** - Para encriptar contraseñas

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos
- Visual Studio Code o Visual Studio
- .NET 9 SDK instalado

### Pasos para ejecutar
1. **Clonar o descargar** el proyecto
2. **Abrir terminal** en la carpeta del proyecto
3. **Ejecutar**:
   ```bash
   dotnet build
   dotnet run --project SistemaPonchado
   ```

## 👤 Credenciales por defecto

### Administrador
- **Usuario:** `admin`
- **Contraseña:** `admin123`

### Empleados
Las credenciales se generan automáticamente al crear empleados:
- **Usuario:** Primera letra del nombre + apellido (ej: "Juan Pérez" → `jperez`)
- **Contraseña:** Últimos 4 dígitos de la cédula
  
Al crear un empleado, se muestra un cuadro con las credenciales y un botón **Copiar** para llevar usuario/contraseña al portapapeles.

## 📁 Estructura del Proyecto

```
SistemaPonchado/
├── Models/          # Clases que representan datos (Usuario, Empleado, Ponchado)
├── Services/        # Lógica de negocio (AuthService, EmpleadoService, etc.)
├── Forms/           # Ventanas de la aplicación
├── Data/            # Configuración de base de datos
└── Program.cs       # Punto de entrada de la aplicación
```

## 🔑 Conceptos Clave para Aprender

### 1. **Modelos (Models)**
Son clases que representan entidades de la vida real:
- `Usuario` = Datos de login
- `Empleado` = Información personal del empleado
- `Ponchado` = Registro de entrada/salida

### 2. **Servicios (Services)**
Contienen la lógica de negocio:
- `AuthService` = Maneja login y autenticación
- `EmpleadoService` = Crear, editar, buscar empleados
- `PonchadoService` = Registrar entradas/salidas

### 3. **Formularios (Forms)**
Las ventanas que ve el usuario:
- `LoginForm` = Pantalla de inicio de sesión
- `AdminMainForm` = Menú principal del administrador
- `EmpleadoMainForm` = Menú del empleado
 - `GestionEmpleadosForm` = CRUD de empleados (listar, buscar, agregar, editar, desactivar, reset clave)
 - `EditarEmpleadoForm` = Edición de datos de un empleado
 - `CredencialesUsuarioForm` = Cuadro para mostrar/copiar credenciales generadas

### 4. **Entity Framework**
ORM (Object-Relational Mapping) que convierte:
- Clases C# ↔ Tablas de base de datos
- Objetos ↔ Registros
- Propiedades ↔ Columnas

## 🎯 Flujo de la Aplicación

1. **Login** → Verificar credenciales
2. **Si es Admin** → Ver menú administrador
3. **Si es Empleado** → Ver menú empleado
4. **Ponchar** → Registrar entrada o salida según el estado
5. **Ver datos** → Mostrar registros con paginación
6. **Cerrar sesión** → Al cerrar el formulario principal, retorna a la pantalla de Login

## 🔧 Funcionalidades Principales

### Para Administradores
- Gestión de Empleados (CRUD):
  - Listar y buscar empleados
  - Agregar empleados (genera credenciales automáticamente y muestra cuadro con botón Copiar)
  - Editar datos (nombre, cédula, departamento, cargo, activo)
  - Desactivar empleados (soft-delete)
  - Restablecer contraseña a los últimos 4 de la cédula y forzar cambio en el próximo inicio de sesión
- Ver todos los registros de ponchado
- Sistema de paginación para grandes cantidades de datos

### Para Empleados
- Registrar entrada al trabajo
- Registrar salida del trabajo
- Ver su historial personal de ponchados
- Sistema automático que calcula horas trabajadas
- **Una entrada y una salida por día** - No se permiten múltiples registros

## 📚 Conceptos de Programación que Puedes Aprender

- **Programación Orientada a Objetos** (clases, herencia, encapsulación)
- **Patrón MVC** (separación de responsabilidades)
- **Async/Await** (programación asíncrona)
- **Entity Framework** (ORM y base de datos)
- **Windows Forms** (interfaces gráficas)
- **Validación de datos** (verificar entradas del usuario)
- **Manejo de excepciones** (try-catch)
- **Encriptación** (BCrypt para passwords)

## 🧑‍💼 Gestión de Empleados (CRUD)

- Acceso: En `AdminMainForm`, botón `Gestión de Empleados`.
- Listado: Grilla con búsqueda por nombre, cédula o departamento.
- Agregar: Abre formulario con validaciones. Al guardar, se genera usuario/clave y aparece un cuadro con botón **Copiar**.
- Editar: Modifica datos del empleado y estado activo.
- Restablecer contraseña: Botón `Reset` que coloca la clave como los últimos 4 de la cédula y marca el usuario para cambiarla en el próximo login.
- Desactivar: Marca empleado (y su usuario) como inactivo sin borrar datos.

Archivos relacionados:
- `Forms/GestionEmpleadosForm.cs` (lista y acciones)
- `Forms/EditarEmpleadoForm.cs` (edición)
- `Forms/CredencialesUsuarioForm.cs` (copiar credenciales)
- `Services/AuthService.cs` (método de restablecimiento de contraseña)

## 🤝 Contribuir

Este proyecto es ideal para:
- Practicar C# y .NET
- Aprender Windows Forms
- Entender bases de datos con Entity Framework
- Practicar patrones de diseño

¡Siéntete libre de hacer modificaciones y mejoras!
