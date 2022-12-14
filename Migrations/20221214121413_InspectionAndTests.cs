using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class InspectionAndTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Breakdown",
                columns: table => new
                {
                    BreakdownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakdownName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BreakdownDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakdownNumber = table.Column<int>(type: "int", maxLength: 99, nullable: false),
                    ReparationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineStop = table.Column<int>(type: "int", maxLength: 99, nullable: false),
                    MachineReplacement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdown", x => x.BreakdownId);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ConfigName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.CarModelId);
                });

            migrationBuilder.CreateTable(
                name: "CarParts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PointOfPurchase = table.Column<double>(type: "float", nullable: false),
                    SafetyStock = table.Column<double>(type: "float", nullable: false),
                    LevelService = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParts", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerFoundDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    ExtraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescExtra = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.ExtraID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderDefinition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "MachineAquisition",
                columns: table => new
                {
                    MachineAquisitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineAquisitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    QuantityOfParts = table.Column<int>(type: "int", nullable: false),
                    ProducedParts = table.Column<double>(type: "float", nullable: false),
                    MaintenancePrice = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAquisition", x => x.MachineAquisitionID);
                });

            migrationBuilder.CreateTable(
                name: "MachineBrand",
                columns: table => new
                {
                    MachineBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineBrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineBrand", x => x.MachineBrandId);
                });

            migrationBuilder.CreateTable(
                name: "MachineState",
                columns: table => new
                {
                    MachineStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateMachine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineState", x => x.MachineStateId);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.ProductionId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftType",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftType", x => x.ShiftTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SupplierContact = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SupplierZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LaunchYear = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelParts",
                columns: table => new
                {
                    ModelPartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CarPartsProductId = table.Column<int>(type: "int", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarModelsCarModelId = table.Column<int>(type: "int", nullable: true),
                    QtdPecas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelParts", x => x.ModelPartsId);
                    table.ForeignKey(
                        name: "FK_ModelParts_CarModels_CarModelsCarModelId",
                        column: x => x.CarModelsCarModelId,
                        principalTable: "CarModels",
                        principalColumn: "CarModelId");
                    table.ForeignKey(
                        name: "FK_ModelParts_CarParts_CarPartsProductId",
                        column: x => x.CarPartsProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerContact",
                columns: table => new
                {
                    CustomerContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContact", x => x.CustomerContactId);
                    table.ForeignKey(
                        name: "FK_CustomerContact_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderState = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineModel",
                columns: table => new
                {
                    MachineModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MachineBrandId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineModel", x => x.MachineModelId);
                    table.ForeignKey(
                        name: "FK_MachineModel_MachineBrand_MachineBrandId",
                        column: x => x.MachineBrandId,
                        principalTable: "MachineBrand",
                        principalColumn: "MachineBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionManager",
                columns: table => new
                {
                    SectionManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionManager", x => x.SectionManagerId);
                    table.ForeignKey(
                        name: "FK_SectionManager_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionManager_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "PriorityId");
                    table.ForeignKey(
                        name: "FK_SectionManager_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftType_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftType",
                        principalColumn: "ShiftTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineBudget",
                columns: table => new
                {
                    MachineBudgetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataSolicitada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    AquisitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineBudget", x => x.MachineBudgetID);
                    table.ForeignKey(
                        name: "FK_MachineBudget_MachineAquisition_AquisitionId",
                        column: x => x.AquisitionId,
                        principalTable: "MachineAquisition",
                        principalColumn: "MachineAquisitionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineBudget_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    OnDuty = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "FK_Collaborator_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborator_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "CarConfig",
                columns: table => new
                {
                    CarConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumExtras = table.Column<int>(type: "int", nullable: false),
                    AddedPrice = table.Column<double>(type: "float", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarConfig", x => x.CarConfigId);
                    table.ForeignKey(
                        name: "FK_CarConfig_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineModelId = table.Column<int>(type: "int", nullable: false),
                    MachineStateId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machine_MachineModel_MachineModelId",
                        column: x => x.MachineModelId,
                        principalTable: "MachineModel",
                        principalColumn: "MachineModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_MachineState_MachineStateId",
                        column: x => x.MachineStateId,
                        principalTable: "MachineState",
                        principalColumn: "MachineStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionAndTest",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAndTest", x => x.InspectionId);
                    table.ForeignKey(
                        name: "FK_InspectionAndTest_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineMaintenance",
                columns: table => new
                {
                    MachineMaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Effective_End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expected_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineMaintenance", x => x.MachineMaintenanceId);
                    table.ForeignKey(
                        name: "FK_MachineMaintenance_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineMaintenance_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineMaintenance_TaskType_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskType",
                        principalColumn: "TaskTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemiFinished",
                columns: table => new
                {
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Manufacter = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SemiFinishedState = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InspectionAndTestInspectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemiFinished", x => x.SemiFinishedId);
                    table.ForeignKey(
                        name: "FK_SemiFinished_InspectionAndTest_InspectionAndTestInspectionId",
                        column: x => x.InspectionAndTestInspectionId,
                        principalTable: "InspectionAndTest",
                        principalColumn: "InspectionId");
                });

            migrationBuilder.CreateTable(
                name: "MaterialUsado",
                columns: table => new
                {
                    MaterialUsadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsado", x => x.MaterialUsadoId);
                    table.ForeignKey(
                        name: "FK_MaterialUsado_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialUsado_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemiFinishedCar",
                columns: table => new
                {
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemiFinishedCar", x => new { x.SemiFinishedId, x.CarId });
                    table.ForeignKey(
                        name: "FK_SemiFinishedCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandId",
                table: "Car",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarConfig_CarId",
                table: "CarConfig",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_GenderId",
                table: "Collaborator",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_TaskId",
                table: "Collaborator",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_CustomerId",
                table: "CustomerContact",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_CollaboratorId",
                table: "InspectionAndTest",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineModelId",
                table: "Machine",
                column: "MachineModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineStateId",
                table: "Machine",
                column: "MachineStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_SectionId",
                table: "Machine",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineBudget_AquisitionId",
                table: "MachineBudget",
                column: "AquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineBudget_SupplierId",
                table: "MachineBudget",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_MachineId",
                table: "MachineMaintenance",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_PriorityId",
                table: "MachineMaintenance",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_TaskTypeId",
                table: "MachineMaintenance",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineModel_MachineBrandId",
                table: "MachineModel",
                column: "MachineBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_MaterialId",
                table: "MaterialUsado",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_SemiFinishedId",
                table: "MaterialUsado",
                column: "SemiFinishedId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarModelsCarModelId",
                table: "ModelParts",
                column: "CarModelsCarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarPartsProductId",
                table: "ModelParts",
                column: "CarPartsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_GenderId",
                table: "SectionManager",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_PriorityId",
                table: "SectionManager",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_SectionId",
                table: "SectionManager",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SemiFinished_InspectionAndTestInspectionId",
                table: "SemiFinished",
                column: "InspectionAndTestInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SemiFinishedCar_CarId",
                table: "SemiFinishedCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftTypeId",
                table: "Shift",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_MaterialId",
                table: "Stock",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakdown");

            migrationBuilder.DropTable(
                name: "CarConfig");

            migrationBuilder.DropTable(
                name: "CustomerContact");

            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "MachineBudget");

            migrationBuilder.DropTable(
                name: "MachineMaintenance");

            migrationBuilder.DropTable(
                name: "MaterialUsado");

            migrationBuilder.DropTable(
                name: "ModelParts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "SectionManager");

            migrationBuilder.DropTable(
                name: "SemiFinishedCar");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "MachineAquisition");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarParts");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "SemiFinished");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MachineModel");

            migrationBuilder.DropTable(
                name: "MachineState");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "InspectionAndTest");

            migrationBuilder.DropTable(
                name: "MachineBrand");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
