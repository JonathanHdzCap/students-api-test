using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    address_line = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    zip_postcode = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    state = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_address_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    email_type = table.Column<int>(type: "int", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.email);
                    table.ForeignKey(
                        name: "FK_email_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    phone_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    phone_type = table.Column<int>(type: "int", nullable: false),
                    country_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    area_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.phone_id);
                    table.ForeignKey(
                        name: "FK_phone_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_student_id",
                table: "address",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_student_id",
                table: "email",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_phone_student_id",
                table: "phone",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "phone");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
