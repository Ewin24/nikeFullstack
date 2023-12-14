using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    apellido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPersona);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Precio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Categoria_idCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idProducto);
                    table.ForeignKey(
                        name: "fk_Producto_Categoria1builder",
                        column: x => x.Categoria_idCategoria,
                        principalTable: "categoria",
                        principalColumn: "idCategoria");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    idusuario = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Persona_idPersona = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    celular = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idusuario);
                    table.ForeignKey(
                        name: "fk_usuario_Persona",
                        column: x => x.Persona_idPersona,
                        principalTable: "persona",
                        principalColumn: "idPersona");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    idInventario = table.Column<int>(type: "int", nullable: false),
                    existencias = table.Column<int>(type: "int", nullable: true),
                    fechaActualizacion = table.Column<DateOnly>(type: "date", nullable: true),
                    Producto_idProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idInventario);
                    table.ForeignKey(
                        name: "fk_Inventario_Producto1",
                        column: x => x.Producto_idProducto,
                        principalTable: "producto",
                        principalColumn: "idProducto");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "carrito",
                columns: table => new
                {
                    idCarrito = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: true),
                    usuario_idusuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCarrito);
                    table.ForeignKey(
                        name: "fk_Carrito_usuario1",
                        column: x => x.usuario_idusuario,
                        principalTable: "usuario",
                        principalColumn: "idusuario");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    idOrden = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateOnly>(type: "date", nullable: true),
                    Total = table.Column<double>(type: "double", nullable: true),
                    usuario_idusuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idOrden);
                    table.ForeignKey(
                        name: "fk_Orden_usuario1",
                        column: x => x.usuario_idusuario,
                        principalTable: "usuario",
                        principalColumn: "idusuario");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "detallecarrito",
                columns: table => new
                {
                    idDetalleCarrito = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Carrito_idCarrito = table.Column<int>(type: "int", nullable: false),
                    Producto_idProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idDetalleCarrito);
                    table.ForeignKey(
                        name: "fk_DetalleCarrito_Carrito1",
                        column: x => x.Carrito_idCarrito,
                        principalTable: "carrito",
                        principalColumn: "idCarrito");
                    table.ForeignKey(
                        name: "fk_DetalleCarrito_Producto1",
                        column: x => x.Producto_idProducto,
                        principalTable: "producto",
                        principalColumn: "idProducto");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "detalleorden",
                columns: table => new
                {
                    idDetalleOrden = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    PrecioUnitario = table.Column<double>(type: "double", nullable: true),
                    Orden_idOrden = table.Column<int>(type: "int", nullable: false),
                    Producto_idProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idDetalleOrden);
                    table.ForeignKey(
                        name: "fk_DetalleOrden_Orden1",
                        column: x => x.Orden_idOrden,
                        principalTable: "orden",
                        principalColumn: "idOrden");
                    table.ForeignKey(
                        name: "fk_DetalleOrden_Producto1",
                        column: x => x.Producto_idProducto,
                        principalTable: "producto",
                        principalColumn: "idProducto");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_Carrito_usuario1_idx",
                table: "carrito",
                column: "usuario_idusuario");

            migrationBuilder.CreateIndex(
                name: "fk_DetalleCarrito_Carrito1_idx",
                table: "detallecarrito",
                column: "Carrito_idCarrito");

            migrationBuilder.CreateIndex(
                name: "fk_DetalleCarrito_Producto1_idx",
                table: "detallecarrito",
                column: "Producto_idProducto");

            migrationBuilder.CreateIndex(
                name: "fk_DetalleOrden_Orden1_idx",
                table: "detalleorden",
                column: "Orden_idOrden");

            migrationBuilder.CreateIndex(
                name: "fk_DetalleOrden_Producto1_idx",
                table: "detalleorden",
                column: "Producto_idProducto");

            migrationBuilder.CreateIndex(
                name: "fk_Inventario_Producto1_idx",
                table: "inventario",
                column: "Producto_idProducto");

            migrationBuilder.CreateIndex(
                name: "fk_Orden_usuario1_idx",
                table: "orden",
                column: "usuario_idusuario");

            migrationBuilder.CreateIndex(
                name: "fk_Producto_Categoria1_idx",
                table: "producto",
                column: "Categoria_idCategoria");

            migrationBuilder.CreateIndex(
                name: "fk_usuario_Persona_idx",
                table: "usuario",
                column: "Persona_idPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallecarrito");

            migrationBuilder.DropTable(
                name: "detalleorden");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "carrito");

            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
