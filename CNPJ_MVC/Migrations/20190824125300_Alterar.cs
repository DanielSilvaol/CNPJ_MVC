using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNPJ_MVC.Migrations
{
    public partial class Alterar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesSecundarias_Empresa_Empresaid",
                table: "AtividadesSecundarias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_atualizacao",
                table: "Empresa",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "AtividadesSecundarias",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "AtividadePrincipal",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesSecundarias_Empresa_Empresaid",
                table: "AtividadesSecundarias",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadesSecundarias_Empresa_Empresaid",
                table: "AtividadesSecundarias");

            migrationBuilder.AlterColumn<string>(
                name: "ultima_atualizacao",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "AtividadesSecundarias",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "AtividadePrincipal",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadesSecundarias_Empresa_Empresaid",
                table: "AtividadesSecundarias",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
