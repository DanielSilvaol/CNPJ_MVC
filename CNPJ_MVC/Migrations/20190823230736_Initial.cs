using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNPJ_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    free = table.Column<bool>(nullable: false),
                    database = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_situacao = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    situacao = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    numero = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    municipio = table.Column<string>(nullable: true),
                    porte = table.Column<string>(nullable: true),
                    abertura = table.Column<string>(nullable: true),
                    natureza_juridica = table.Column<string>(nullable: true),
                    cnpj = table.Column<string>(nullable: true),
                    ultima_atualizacao = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    fantasia = table.Column<string>(nullable: true),
                    efr = table.Column<string>(nullable: true),
                    motivo_situacao = table.Column<string>(nullable: true),
                    data_situacao_especial = table.Column<string>(nullable: true),
                    capital_social = table.Column<string>(nullable: true),
                    extraid = table.Column<int>(nullable: true),
                    billingid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empresa_Billing_billingid",
                        column: x => x.billingid,
                        principalTable: "Billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresa_Extra_extraid",
                        column: x => x.extraid,
                        principalTable: "Extra",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadePrincipal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    Empresaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadePrincipal", x => x.id);
                    table.ForeignKey(
                        name: "FK_AtividadePrincipal_Empresa_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadesSecundarias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    Empresaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesSecundarias", x => x.id);
                    table.ForeignKey(
                        name: "FK_AtividadesSecundarias_Empresa_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qsa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    qual = table.Column<string>(nullable: true),
                    pais_origem = table.Column<string>(nullable: true),
                    nome_rep_legal = table.Column<string>(nullable: true),
                    qual_rep_legal = table.Column<string>(nullable: true),
                    Empresaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qsa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Qsa_Empresa_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadePrincipal_Empresaid",
                table: "AtividadePrincipal",
                column: "Empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesSecundarias_Empresaid",
                table: "AtividadesSecundarias",
                column: "Empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_billingid",
                table: "Empresa",
                column: "billingid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_extraid",
                table: "Empresa",
                column: "extraid");

            migrationBuilder.CreateIndex(
                name: "IX_Qsa_Empresaid",
                table: "Qsa",
                column: "Empresaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadePrincipal");

            migrationBuilder.DropTable(
                name: "AtividadesSecundarias");

            migrationBuilder.DropTable(
                name: "Qsa");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "Extra");
        }
    }
}
