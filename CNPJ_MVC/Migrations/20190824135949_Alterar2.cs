using Microsoft.EntityFrameworkCore.Migrations;

namespace CNPJ_MVC.Migrations
{
    public partial class Alterar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Billing_billingid",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Extra_extraid",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Qsa_Empresa_Empresaid",
                table: "Qsa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_billingid",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_extraid",
                table: "Empresa");

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "Qsa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "extraid",
                table: "Empresa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "billingid",
                table: "Empresa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_billingid",
                table: "Empresa",
                column: "billingid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_extraid",
                table: "Empresa",
                column: "extraid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Billing_billingid",
                table: "Empresa",
                column: "billingid",
                principalTable: "Billing",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Extra_extraid",
                table: "Empresa",
                column: "extraid",
                principalTable: "Extra",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qsa_Empresa_Empresaid",
                table: "Qsa",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Billing_billingid",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Extra_extraid",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Qsa_Empresa_Empresaid",
                table: "Qsa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_billingid",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_extraid",
                table: "Empresa");

            migrationBuilder.AlterColumn<int>(
                name: "Empresaid",
                table: "Qsa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "extraid",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "billingid",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_billingid",
                table: "Empresa",
                column: "billingid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_extraid",
                table: "Empresa",
                column: "extraid");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Billing_billingid",
                table: "Empresa",
                column: "billingid",
                principalTable: "Billing",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Extra_extraid",
                table: "Empresa",
                column: "extraid",
                principalTable: "Extra",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qsa_Empresa_Empresaid",
                table: "Qsa",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
