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
                    ProjectDescription = table.Column<string>(name: "Project Description", type: "nvarchar(max)", nullable: false),
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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompleteTask = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()"),
                    TaskStatus = table.Column<string>(name: "Task Status", type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    TaskCategory = table.Column<string>(name: "Task Category", type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Employee Id", "Address", "oid", "Employee Email", "Employee Name", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo, Egypt", null, "Ahmedli@example.com", "Ahmed Ali", "01012345678", 15000m },
                    { 2, "Alexandria, Egypt", null, "sara.mohamed@example.com", "Sara Mohamed", "01198765432", 12000m }
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
                columns: new[] { "Task Id", "Task Category", "Task Description", "EmployeeId", "EndDate", "ProjectId", "StartDate", "Task Status", "Task Title" },
                values: new object[,]
                {
                    { 1, "Research", "Create ERD and schema", 1, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", "Design DB" },
                    { 2, "FeatureDevelopment", "Build initial API endpoints", 1, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", "API Setup" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task Id", "Task Category", "CompleteTask", "Task Description", "EmployeeId", "EndDate", "ProjectId", "StartDate", "Task Status", "Task Title" },
                values: new object[] { 3, "FeatureDevelopment", new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), "Implement product catalog", 1, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Product Module" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task Id", "Task Category", "Task Description", "EmployeeId", "EndDate", "ProjectId", "StartDate", "Task Status", "Task Title" },
                values: new object[,]
                {
                    { 4, "FeatureDevelopment", "Implement shopping cart", 1, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Cart Module" },
                    { 5, "Testing", "Write unit tests", 2, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", "Testing API" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task Id", "Task Category", "CompleteTask", "Task Description", "EmployeeId", "EndDate", "ProjectId", "StartDate", "Task Status", "Task Title" },
                values: new object[] { 6, "Improvement", new DateTime(2025, 9, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), "Check frontend components", 2, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "UI Review" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task Id", "Task Category", "Task Description", "EmployeeId", "EndDate", "ProjectId", "StartDate", "Task Status", "Task Title" },
                values: new object[,]
                {
                    { 7, "Testing", "Test payment gateway", 2, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", "Payment Module" },
                    { 8, "Documentation", "Document found issues", 2, new DateTime(2025, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", "Bug Report" }
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
