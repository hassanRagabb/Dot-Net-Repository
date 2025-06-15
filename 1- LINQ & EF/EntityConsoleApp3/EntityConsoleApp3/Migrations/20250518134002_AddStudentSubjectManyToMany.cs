using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityConsoleApp3.Migrations
{
    public partial class AddStudentSubjectManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentsStudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentsStudentID, x.SubjectsSubjectID });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_StudentsStudentID",
                        column: x => x.StudentsStudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects_SubjectsSubjectID",
                        column: x => x.SubjectsSubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectsSubjectID",
                table: "StudentSubject",
                column: "SubjectsSubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");
        }
    }
}
