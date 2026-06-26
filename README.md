# 📦 ControlStock ERP

Sistema de gestión de inventario desarrollado en **ASP.NET Core 8 MVC + Identity + Entity Framework Core**.

---

## 🚀 Características

- 🔐 Autenticación con ASP.NET Identity
- 👥 Sistema de roles (Admin / User)
- 📦 Gestión de productos (CRUD completo)
- 🗂 Gestión de categorías (CRUD completo)
- 📊 Dashboard tipo ERP con métricas:
  - Total de productos
  - Stock bajo
  - Valor del inventario
  - Total de categorías
- 🛠 Panel administrativo (ERP)
- 🎨 Interfaz basada en Bootstrap 5

---

## 🧠 Arquitectura

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- Identity (autenticación y roles)
- Razor Views

---

## 👤 Roles del sistema

### 🔴 Admin
- Acceso completo al ERP
- Gestión de productos y categorías
- Panel de administración

### 🟢 User
- Acceso a consulta del sistema
- Visualización de datos del inventario

---

## 🗂 Módulos

### 📦 Productos
- Crear, editar, eliminar productos
- Gestión de stock
- Asociación a categorías

### 🗂 Categorías
- CRUD completo
- Conteo de productos por categoría
- Visualización en tabla tipo ERP

### 🛠 Admin Panel
- Dashboard con estadísticas
- Acceso rápido a módulos

---

## 🧪 Tecnologías usadas

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server
- Bootstrap 5
- Identity
- Razor Pages + MVC

---

## ⚙️ Instalación

```bash
git clone https://github.com/tuusuario/controlstock-erp.git
cd controlstock-erp

1 Configurar appsettings.json
2 Ejecutar migraciones:
```dotnet ef database update```

3 Ejecutar proyecto:
```dotnet run```
```
---

## 📸 Capturas

- Video:▶️[.NET,Identity,Razor Pages + MVC](https://youtu.be/86ETKryHBPw)

## 📌 Estado del proyecto

✔ En desarrollo
✔ Funcional
✔ Base ERP lista para escalar

## 👨‍💻 Autor

- Autor: [Israel M.P.]
- Email: israel_melli@hotmail.com
- GitHub: israelmellado

## 📄 Licencia

Uso educativo / desarrollo personal