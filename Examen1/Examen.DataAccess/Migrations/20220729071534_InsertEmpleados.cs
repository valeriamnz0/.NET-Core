using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.DataAccess.Migrations
{
    public partial class InsertEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Empleados (Cedula,Nombre,Apellidos,Genero,CorreoElectronico) VALUES (116950428,'Bryan','Vargas','Hombre','Bryantest@mail.com')");
            migrationBuilder.Sql("INSERT INTO Empleados (Cedula,Nombre,Apellidos,Genero,CorreoElectronico) VALUES (116950428,'Bryan2','Vargas','Hombre','Bryantest2@mail.com')");
            migrationBuilder.Sql("INSERT INTO Empleados (Cedula,Nombre,Apellidos,Genero,CorreoElectronico) VALUES (116950428,'Bryan3','Vargas','Hombre','Bryantest3@mail.com')");
            migrationBuilder.Sql("INSERT INTO Empleados (Cedula,Nombre,Apellidos,Genero,CorreoElectronico) VALUES (116950428,'Bryan4','Vargas','Hombre','Bryantest4@mail.com')");
            migrationBuilder.Sql("INSERT INTO Empleados (Cedula,Nombre,Apellidos,Genero,CorreoElectronico) VALUES (116950428,'Bryan5','Vargas','Hombre','Bryantest5@mail.com')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
