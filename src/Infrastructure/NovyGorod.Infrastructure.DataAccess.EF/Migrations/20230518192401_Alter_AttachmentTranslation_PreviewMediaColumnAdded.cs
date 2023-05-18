using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class AlterAttachmentTranslationPreviewMediaColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTranslation_MediaData_MediaId",
                table: "AttachmentTranslation");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "AttachmentTranslation",
                newName: "SourceMediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentTranslation_MediaId",
                table: "AttachmentTranslation",
                newName: "IX_AttachmentTranslation_SourceMediaId");

            migrationBuilder.AddColumn<int>(
                name: "PreviewMediaId",
                table: "AttachmentTranslation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTranslation_PreviewMediaId",
                table: "AttachmentTranslation",
                column: "PreviewMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTranslation_MediaData_PreviewMediaId",
                table: "AttachmentTranslation",
                column: "PreviewMediaId",
                principalTable: "MediaData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTranslation_MediaData_SourceMediaId",
                table: "AttachmentTranslation",
                column: "SourceMediaId",
                principalTable: "MediaData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTranslation_MediaData_PreviewMediaId",
                table: "AttachmentTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTranslation_MediaData_SourceMediaId",
                table: "AttachmentTranslation");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentTranslation_PreviewMediaId",
                table: "AttachmentTranslation");

            migrationBuilder.DropColumn(
                name: "PreviewMediaId",
                table: "AttachmentTranslation");

            migrationBuilder.RenameColumn(
                name: "SourceMediaId",
                table: "AttachmentTranslation",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentTranslation_SourceMediaId",
                table: "AttachmentTranslation",
                newName: "IX_AttachmentTranslation_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTranslation_MediaData_MediaId",
                table: "AttachmentTranslation",
                column: "MediaId",
                principalTable: "MediaData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
