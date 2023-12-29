using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class Alter_TranslationTables_CreationOfCompositePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTranslation_Attachment_EntityId",
                table: "AttachmentTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_PostBlockTranslation_PostBlock_EntityId",
                table: "PostBlockTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTranslation_Post_EntityId",
                table: "PostTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTranslation",
                table: "PostTranslation");

            migrationBuilder.DropIndex(
                name: "IX_PostTranslation_EntityId_LanguageId",
                table: "PostTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostBlockTranslation",
                table: "PostBlockTranslation");

            migrationBuilder.DropIndex(
                name: "IX_PostBlockTranslation_EntityId_LanguageId",
                table: "PostBlockTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentTranslation",
                table: "AttachmentTranslation");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentTranslation_EntityId_LanguageId",
                table: "AttachmentTranslation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostTranslation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostBlockTranslation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AttachmentTranslation");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "PostTranslation",
                newName: "ModelId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "PostBlockTranslation",
                newName: "ModelId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AttachmentTranslation",
                newName: "ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTranslation",
                table: "PostTranslation",
                columns: new[] { "ModelId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostBlockTranslation",
                table: "PostBlockTranslation",
                columns: new[] { "ModelId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentTranslation",
                table: "AttachmentTranslation",
                columns: new[] { "ModelId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTranslation_Attachment_ModelId",
                table: "AttachmentTranslation",
                column: "ModelId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostBlockTranslation_PostBlock_ModelId",
                table: "PostBlockTranslation",
                column: "ModelId",
                principalTable: "PostBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTranslation_Post_ModelId",
                table: "PostTranslation",
                column: "ModelId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTranslation_Attachment_ModelId",
                table: "AttachmentTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_PostBlockTranslation_PostBlock_ModelId",
                table: "PostBlockTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTranslation_Post_ModelId",
                table: "PostTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTranslation",
                table: "PostTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostBlockTranslation",
                table: "PostBlockTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentTranslation",
                table: "AttachmentTranslation");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "PostTranslation",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "PostBlockTranslation",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "AttachmentTranslation",
                newName: "EntityId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostTranslation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostBlockTranslation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AttachmentTranslation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTranslation",
                table: "PostTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostBlockTranslation",
                table: "PostBlockTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentTranslation",
                table: "AttachmentTranslation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_EntityId_LanguageId",
                table: "PostTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostBlockTranslation_EntityId_LanguageId",
                table: "PostBlockTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTranslation_EntityId_LanguageId",
                table: "AttachmentTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTranslation_Attachment_EntityId",
                table: "AttachmentTranslation",
                column: "EntityId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostBlockTranslation_PostBlock_EntityId",
                table: "PostBlockTranslation",
                column: "EntityId",
                principalTable: "PostBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTranslation_Post_EntityId",
                table: "PostTranslation",
                column: "EntityId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
