using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    public partial class CriandoRealcionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar a coluna UserId na tabela categories
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "categories",
                type: "varchar(255)",
                nullable: true);

            // Aqui você precisará escrever uma consulta ou um comando SQL que estabeleça a relação entre as tabelas
            // A consulta dependerá do banco de dados específico que você está utilizando

            // Exemplo de como isso poderia ser feito (depende do seu banco de dados):
            migrationBuilder.Sql("UPDATE categories SET UserId = (SELECT Id FROM [AdminUsers].[dbo].[AspNetUsers] WHERE ...)");

            // Adicionar uma restrição de chave estrangeira para o UserId
            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_UserId",
                table: "categories",
                column: "UserId",
                principalTable: "[NomeDoOutroBancoDeDados].[dbo].[AspNetUsers]", // Nome da tabela no outro banco de dados
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Caso queira reverter as alterações
            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_UserId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "categories");
        }
    }
}
