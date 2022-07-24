using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MediaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsLocal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaData", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostBlock_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTranslation_MediaData_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "MediaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTranslation_Post_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_PostBlock_BlockId",
                        column: x => x.BlockId,
                        principalTable: "PostBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostBlockTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBlockTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostBlockTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostBlockTranslation_PostBlock_EntityId",
                        column: x => x.EntityId,
                        principalTable: "PostBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttachmentTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentTranslation_Attachment_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentTranslation_MediaData_MediaId",
                        column: x => x.MediaId,
                        principalTable: "MediaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_BlockId",
                table: "Attachment",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTranslation_EntityId_LanguageId",
                table: "AttachmentTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTranslation_LanguageId",
                table: "AttachmentTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTranslation_MediaId",
                table: "AttachmentTranslation",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_Code",
                table: "Language",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaData_Url",
                table: "MediaData",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostBlock_PostId",
                table: "PostBlock",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBlockTranslation_EntityId_LanguageId",
                table: "PostBlockTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostBlockTranslation_LanguageId",
                table: "PostBlockTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_EntityId_LanguageId",
                table: "PostTranslation",
                columns: new[] { "EntityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_LanguageId",
                table: "PostTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_PreviewId",
                table: "PostTranslation",
                column: "PreviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentTranslation");

            migrationBuilder.DropTable(
                name: "PostBlockTranslation");

            migrationBuilder.DropTable(
                name: "PostTranslation");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "MediaData");

            migrationBuilder.DropTable(
                name: "PostBlock");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
