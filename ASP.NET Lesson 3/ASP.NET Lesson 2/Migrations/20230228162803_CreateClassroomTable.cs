using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Lesson_2.Migrations
{
    public partial class CreateClassroomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClassroomId",
                table: "Clients",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Classrooms_ClassroomId",
                table: "Clients",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Classrooms_ClassroomId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClassroomId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Clients");
        }
    }
}
