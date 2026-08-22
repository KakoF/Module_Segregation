using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameItemsToProprietarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImovelProprietario_Imovel_ImovelId",
                table: "ImovelProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelProprietario_Proprietario_ItemsId",
                table: "ImovelProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelRural_Imovel_Id",
                table: "ImovelRural");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelUrbano_Imovel_Id",
                table: "ImovelUrbano");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imovel",
                table: "Imovel");

            migrationBuilder.RenameTable(
                name: "Imovel",
                newName: "Imoveis");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ImovelProprietario",
                newName: "ProprietariosId");

            migrationBuilder.RenameIndex(
                name: "IX_ImovelProprietario_ItemsId",
                table: "ImovelProprietario",
                newName: "IX_ImovelProprietario_ProprietariosId");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "ImovelUrbano",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Hectares",
                table: "ImovelRural",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Imoveis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imoveis",
                table: "Imoveis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelProprietario_Imoveis_ImovelId",
                table: "ImovelProprietario",
                column: "ImovelId",
                principalTable: "Imoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelProprietario_Proprietario_ProprietariosId",
                table: "ImovelProprietario",
                column: "ProprietariosId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelRural_Imoveis_Id",
                table: "ImovelRural",
                column: "Id",
                principalTable: "Imoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelUrbano_Imoveis_Id",
                table: "ImovelUrbano",
                column: "Id",
                principalTable: "Imoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImovelProprietario_Imoveis_ImovelId",
                table: "ImovelProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelProprietario_Proprietario_ProprietariosId",
                table: "ImovelProprietario");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelRural_Imoveis_Id",
                table: "ImovelRural");

            migrationBuilder.DropForeignKey(
                name: "FK_ImovelUrbano_Imoveis_Id",
                table: "ImovelUrbano");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imoveis",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "ImovelUrbano");

            migrationBuilder.DropColumn(
                name: "Hectares",
                table: "ImovelRural");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Imoveis");

            migrationBuilder.RenameTable(
                name: "Imoveis",
                newName: "Imovel");

            migrationBuilder.RenameColumn(
                name: "ProprietariosId",
                table: "ImovelProprietario",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_ImovelProprietario_ProprietariosId",
                table: "ImovelProprietario",
                newName: "IX_ImovelProprietario_ItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imovel",
                table: "Imovel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelProprietario_Imovel_ImovelId",
                table: "ImovelProprietario",
                column: "ImovelId",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelProprietario_Proprietario_ItemsId",
                table: "ImovelProprietario",
                column: "ItemsId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelRural_Imovel_Id",
                table: "ImovelRural",
                column: "Id",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImovelUrbano_Imovel_Id",
                table: "ImovelUrbano",
                column: "Id",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
