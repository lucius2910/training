using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi1.Migrations
{
    /// <inheritdoc />
    public partial class update_ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_hocsinhs_LopId",
                table: "hocsinhs",
                column: "LopId");

            migrationBuilder.CreateIndex(
                name: "IX_giaoviens_LopId",
                table: "giaoviens",
                column: "LopId");

            migrationBuilder.AddForeignKey(
                name: "FK_giaoviens_lops_LopId",
                table: "giaoviens",
                column: "LopId",
                principalTable: "lops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hocsinhs_lops_LopId",
                table: "hocsinhs",
                column: "LopId",
                principalTable: "lops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_giaoviens_lops_LopId",
                table: "giaoviens");

            migrationBuilder.DropForeignKey(
                name: "FK_hocsinhs_lops_LopId",
                table: "hocsinhs");

            migrationBuilder.DropIndex(
                name: "IX_hocsinhs_LopId",
                table: "hocsinhs");

            migrationBuilder.DropIndex(
                name: "IX_giaoviens_LopId",
                table: "giaoviens");
        }
    }
}
