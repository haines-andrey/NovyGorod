using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostBlock_Index",
                table: "PostBlock",
                column: "Index",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Index",
                table: "Post",
                column: "Index",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Index",
                table: "Attachment",
                column: "Index",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostBlock_Index",
                table: "PostBlock");

            migrationBuilder.DropIndex(
                name: "IX_Post_Index",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_Index",
                table: "Attachment");
        }
    }
}
