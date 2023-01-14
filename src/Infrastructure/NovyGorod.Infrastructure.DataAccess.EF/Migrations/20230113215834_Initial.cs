using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "PostTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_PostTranslation_MediaData_VideoId",
                        column: x => x.VideoId,
                        principalTable: "MediaData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostTranslation_Post_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "PostBlockTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "AttachmentTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_VideoId",
                table: "PostTranslation",
                column: "VideoId");
        }

        /// <inheritdoc />
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
