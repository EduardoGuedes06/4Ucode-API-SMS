using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Ucode_sms.Domain.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeCliente = table.Column<string>(type: "varchar(75)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CountEnvios = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "twillo_Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Mensagem = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountSid = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthToken = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServiceSid = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ToPhoneNumber = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FromPhoneNumber = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusSend = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twillo_Log", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_contato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    numero = table.Column<string>(type: "varchar(13)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_contato_tb_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_conteudo_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Texto = table.Column<string>(type: "varchar(450)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_conteudo_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_conteudo_cliente_tb_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_envios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TextoEnvio = table.Column<string>(type: "varchar(260)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enviado = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_envios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_envios_tb_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_envios_tb_contato_NumeroId",
                        column: x => x.NumeroId,
                        principalTable: "tb_contato",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_contato_ClienteId",
                table: "tb_contato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_conteudo_cliente_ClienteId",
                table: "tb_conteudo_cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_envios_ClienteId",
                table: "tb_envios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_envios_NumeroId",
                table: "tb_envios",
                column: "NumeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_conteudo_cliente");

            migrationBuilder.DropTable(
                name: "tb_envios");

            migrationBuilder.DropTable(
                name: "twillo_Log");

            migrationBuilder.DropTable(
                name: "tb_contato");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
