using Microsoft.EntityFrameworkCore.Migrations;

namespace sheik.Migrations
{
    public partial class stage5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancellationReason",
                columns: table => new
                {
                    CancellationReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GetCancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationReason", x => x.CancellationReasonId);
                });

            migrationBuilder.CreateTable(
                name: "Drive",
                columns: table => new
                {
                    DriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FromDate = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<int>(type: "int", nullable: false),
                    PoolId = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDriveCancelled = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<int>(type: "int", nullable: false),
                    SlotTiming = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drive", x => x.DriveId);
                    table.ForeignKey(
                        name: "FK_Drive_Pool_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pool",
                        principalColumn: "PoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeAceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminResponded = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableResponse",
                columns: table => new
                {
                    AvailableResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<int>(type: "int", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    IsInterviewCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CancellationReasonId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableResponse", x => x.AvailableResponseId);
                    table.ForeignKey(
                        name: "FK_AvailableResponse_CancellationReason_CancellationReasonId",
                        column: x => x.CancellationReasonId,
                        principalTable: "CancellationReason",
                        principalColumn: "CancellationReasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableResponse_Drive_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drive",
                        principalColumn: "DriveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableResponse_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDriveResponse",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ResponseType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDriveResponse", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_EmployeeDriveResponse_Drive_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drive",
                        principalColumn: "DriveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDriveResponse_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoolMembers",
                columns: table => new
                {
                    PoolMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoolId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolMembers", x => x.PoolMemberId);
                    table.ForeignKey(
                        name: "FK_PoolMembers_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolMembers_Pool_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pool",
                        principalColumn: "PoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableResponse_CancellationReasonId",
                table: "AvailableResponse",
                column: "CancellationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableResponse_DriveId",
                table: "AvailableResponse",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableResponse_EmployeeId",
                table: "AvailableResponse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drive_PoolId",
                table: "Drive",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptId",
                table: "Employee",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_EmployeeId",
                table: "EmployeeDriveResponse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_EmployeeId",
                table: "PoolMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_PoolId",
                table: "PoolMembers",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DeptId",
                table: "Project",
                column: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableResponse");

            migrationBuilder.DropTable(
                name: "EmployeeDriveResponse");

            migrationBuilder.DropTable(
                name: "PoolMembers");

            migrationBuilder.DropTable(
                name: "CancellationReason");

            migrationBuilder.DropTable(
                name: "Drive");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
