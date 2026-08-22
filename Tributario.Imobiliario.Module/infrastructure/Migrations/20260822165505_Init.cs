using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentagem = table.Column<double>(type: "float", nullable: false),
                    Majoritario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImovelRural",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelRural", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImovelRural_Imovel_Id",
                        column: x => x.Id,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImovelUrbano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelUrbano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImovelUrbano_Imovel_Id",
                        column: x => x.Id,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImovelProprietario",
                columns: table => new
                {
                    ImovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelProprietario", x => new { x.ImovelId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ImovelProprietario_Imovel_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImovelProprietario_Proprietario_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImovelProprietario_ItemsId",
                table: "ImovelProprietario",
                column: "ItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImovelProprietario");

            migrationBuilder.DropTable(
                name: "ImovelRural");

            migrationBuilder.DropTable(
                name: "ImovelUrbano");

            migrationBuilder.DropTable(
                name: "Proprietario");

            migrationBuilder.DropTable(
                name: "Imovel");
        }
    }
}
