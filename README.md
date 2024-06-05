# Alumni Record Management System

This project is an Alumni Record Management System built with ASP.NET Core MVC and Entity Framework Core. The application allows users to manage student records, including adding, editing, and deleting student details. Additionally, it features a secure login system with session management to control access.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap 5

## Database Schema
The project uses SQL Server for database management. Below is the schema for the database tables used in this project.

### Users Table
This table stores user login details.
```sql
CREATE TABLE [dbo].[Users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Role]     VARCHAR (50) NOT NULL
);
```

### Student Table
This table stores student information.
```sql
CREATE TABLE [dbo].[Student] (
    [Sid]   INT          IDENTITY (1, 1) NOT NULL,
    [Sname] VARCHAR (50) NULL,
    [Sage]  VARCHAR (50) NULL
);
```

## Project Structure
- `Controllers/`: Contains the MVC controllers that handle user requests and responses.
- `Models/`: Contains the entity models and the DbContext.
- `Views/`: Contains the Razor views for rendering UI.
- `wwwroot/`: Contains static files like CSS, JavaScript, and images.

## Usage
### Login
1. **Navigate to the login page**: `/login/contaactus`
2. **Enter your credentials**: username and password
3. **Successful login**: Redirects to the student list page
4. **Failed login**: Displays an error message

### Student Management
1. **Add Student**
   - Navigate to the student list page.
   - Fill in the student name and age.
   - Click "Submit".
   - The student is added to the list.

2. **Edit Student**
   - Click "Edit" next to a student entry.
   - Modify the student details and submit.
   - The student details are updated.

3. **Delete Student**
   - Click "Delete" next to a student entry.
   - Confirm the deletion.
   - The student is removed from the list.

### Session Management
- **Login**: Sets a session variable to indicate the user is logged in.
- **Logout**: Clears the session variable.
- **Session Check**: Before performing student management operations, the session variable is checked to ensure the user is logged in.

