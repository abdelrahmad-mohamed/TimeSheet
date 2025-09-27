using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalBrands.TimeSheet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(name: "Employee Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(name: "Employee Name", type: "varchar(50)", maxLength: 50, nullable: false),
                    EmployeeEmail = table.Column<string>(name: "Employee Email", type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    oid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(name: "Project Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(name: "Project Name", type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(name: "Project Description", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(name: "Task Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(name: "Task Title", type: "varchar(30)", nullable: false),
                    TaskDescription = table.Column<string>(name: "Task Description", type: "varchar(max)", nullable: false),
                    NumberOfHours = table.Column<int>(name: "Number Of Hours", type: "int", nullable: false),
                    TaskStatus = table.Column<string>(name: "Task Status", type: "nvarchar(max)", nullable: false, defaultValue: "NotStarted"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Employee Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Project Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Employee Id", "Address", "oid", "DateOfBirth", "Employee Email", "Employee Name", "PhoneNumber", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo, Egypt", null, new DateOnly(1995, 5, 12), "Ahmedli@example.com", "Ahmed Ali", "01012345678", "Software Developer", 15000m },
                    { 2, "Alexandria, Egypt", null, new DateOnly(1998, 8, 20), "sara.mohamed@example.com", "Sara Mohamed", "01198765432", "QA Engineer", 12000m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Project Id", "Project Description", "Project Name" },
                values: new object[,]
                {
                    { 1, "Internal project to track working hours", "Time Tracking System" },
                    { 2, "Web platform for online shopping", "E-Commerce Platform" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task Id", "Task Description", "EmployeeId", "Number Of Hours", "ProjectId", "Task Status", "Task Title" },
                values: new object[,]
                {
                    { 1, "Create ERD and schema", 1, 5, 1, "InProgress", "Design DB" },
                    { 2, "Build initial API endpoints", 1, 6, 1, "InProgress", "API Setup" },
                    { 3, "Implement product catalog", 1, 7, 2, "Completed", "Product Module" },
                    { 4, "Implement shopping cart", 1, 4, 2, "NotStarted", "Cart Module" },
                    { 5, "Write unit tests", 2, 5, 1, "InProgress", "Testing API" },
                    { 6, "Check frontend components", 2, 3, 1, "Completed", "UI Review" },
                    { 7, "Test payment gateway", 2, 6, 2, "InProgress", "Payment Module" },
                    { 8, "Document found issues", 2, 4, 2, "InProgress", "Bug Report" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
