using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    public partial class AddVideoInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "PostTranslation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTranslation_VideoId",
                table: "PostTranslation",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTranslation_MediaData_VideoId",
                table: "PostTranslation",
                column: "VideoId",
                principalTable: "MediaData",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTranslation_MediaData_VideoId",
                table: "PostTranslation");

            migrationBuilder.DropIndex(
                name: "IX_PostTranslation_VideoId",
                table: "PostTranslation");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "PostTranslation");
        }
    }
}
