using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class all_migrations : Migration
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
                    BreakdownNumber = table.Column<int>(type: "int", nullable: false),
                    ReparationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineStop = table.Column<int>(type: "int", nullable: false),
                    MachineReplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairInTheCompany = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Function",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionId);
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
                name: "InspectionTestState",
                columns: table => new
                {
                    InspectionTestStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTestState", x => x.InspectionTestStateId);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationCar",
                columns: table => new
                {
                    LocalizationCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationCar", x => x.LocalizationCarId);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationCode",
                columns: table => new
                {
                    LocalizationCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Column = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Line = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationCode", x => x.LocalizationCodeId);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    OrderStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.OrderStateId);
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
                name: "SemiFinished",
                columns: table => new
                {
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Manufacter = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SemiFinishedState = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemiFinished", x => x.SemiFinishedId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftType",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftTypeSearchShiftTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftType", x => x.ShiftTypeId);
                    table.ForeignKey(
                        name: "FK_ShiftType_ShiftType_ShiftTypeSearchShiftTypeId",
                        column: x => x.ShiftTypeSearchShiftTypeId,
                        principalTable: "ShiftType",
                        principalColumn: "ShiftTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SupplierContact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SupplierZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "SupplierParts",
                columns: table => new
                {
                    SupplierPartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierParts", x => x.SupplierPartsId);
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
                name: "WarehouseStock",
                columns: table => new
                {
                    WarehouseStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseStock", x => x.WarehouseStockId);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    WorkingHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.WorkingHoursId);
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
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    TimeProduction = table.Column<int>(type: "int", nullable: false)
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
                name: "MachineModel",
                columns: table => new
                {
                    MachineModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MachineBrandId = table.Column<int>(type: "int", nullable: false)
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
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStateId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "OrderState",
                        principalColumn: "OrderStateId",
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
                name: "MaterialUsed",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    MaterialUsedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsed", x => new { x.MaterialId, x.SemiFinishedId });
                    table.ForeignKey(
                        name: "FK_MaterialUsed_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Restrict);
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
                    Valor = table.Column<double>(type: "float", nullable: true),
                    prazoGarantia = table.Column<int>(type: "int", nullable: false),
                    custoManutencao = table.Column<double>(type: "float", nullable: false),
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
                name: "PriceSupplierPartsCarParts",
                columns: table => new
                {
                    PriceSupplierPartsCarPartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierPartsId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Promocao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSupplierPartsCarParts", x => x.PriceSupplierPartsCarPartsId);
                    table.ForeignKey(
                        name: "FK_PriceSupplierPartsCarParts_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceSupplierPartsCarParts_SupplierParts_SupplierPartsId",
                        column: x => x.SupplierPartsId,
                        principalTable: "SupplierParts",
                        principalColumn: "SupplierPartsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierPartsCarParts",
                columns: table => new
                {
                    SupplierPartsId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PrazoEntrega = table.Column<int>(type: "int", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPartsCarParts", x => new { x.SupplierPartsId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupplierPartsCarParts_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierPartsCarParts_SupplierParts_SupplierPartsId",
                        column: x => x.SupplierPartsId,
                        principalTable: "SupplierParts",
                        principalColumn: "SupplierPartsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
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
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WarehouseStockId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_WarehouseStock_WarehouseStockId",
                        column: x => x.WarehouseStockId,
                        principalTable: "WarehouseStock",
                        principalColumn: "WarehouseStockId",
                        onDelete: ReferentialAction.Cascade);
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
                    FinalPrice = table.Column<double>(type: "float", nullable: false),
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
                name: "SemiFinishedCar",
                columns: table => new
                {
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedCarsId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineModelId = table.Column<int>(type: "int", nullable: false),
                    MachineStateId = table.Column<int>(type: "int", nullable: false),
                    LocalizationCodeId = table.Column<int>(type: "int", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machine_LocalizationCode_LocalizationCodeId",
                        column: x => x.LocalizationCodeId,
                        principalTable: "LocalizationCode",
                        principalColumn: "LocalizationCodeId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorShifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorShiftId = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorShifts", x => new { x.CollaboratorId, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_CollaboratorShifts_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollaboratorShifts_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftSchedule",
                columns: table => new
                {
                    ShiftSchedulesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSchedule", x => x.ShiftSchedulesId);
                    table.ForeignKey(
                        name: "FK_ShiftSchedule_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollaboratorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_Collaborator_CollaboratorID",
                        column: x => x.CollaboratorID,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkerPunctuality",
                columns: table => new
                {
                    WorkerPunctualityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MissedHoursLastWeek = table.Column<int>(type: "int", nullable: false),
                    LateShiftsLastWeek = table.Column<int>(type: "int", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPunctuality", x => x.WorkerPunctualityId);
                    table.ForeignKey(
                        name: "FK_WorkerPunctuality_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId");
                });

            migrationBuilder.CreateTable(
                name: "ConfigList",
                columns: table => new
                {
                    ConfigListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    ExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigList", x => x.ConfigListId);
                    table.ForeignKey(
                        name: "FK_ConfigList_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigList_Extra_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extra",
                        principalColumn: "ExtraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelParts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    QtdPecas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelParts", x => new { x.ProductId, x.CarConfigId });
                    table.ForeignKey(
                        name: "FK_ModelParts_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelParts_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.ProductionId);
                    table.ForeignKey(
                        name: "FK_Production_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesLine",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLine", x => new { x.OrderId, x.CarConfigId });
                    table.ForeignKey(
                        name: "FK_SalesLine_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesLine_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeOfProduction",
                columns: table => new
                {
                    TimeOfProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOfProduction", x => x.TimeOfProductionId);
                    table.ForeignKey(
                        name: "FK_TimeOfProduction_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
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
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "InspectionAndTest",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionsId = table.Column<int>(type: "int", nullable: false),
                    QuantityTested = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_InspectionAndTest_InspectionTestState_StateId",
                        column: x => x.StateId,
                        principalTable: "InspectionTestState",
                        principalColumn: "InspectionTestStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionAndTest_Production_ProductionsId",
                        column: x => x.ProductionsId,
                        principalTable: "Production",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockFinalProduct",
                columns: table => new
                {
                    StockFinalProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalizationCarId = table.Column<int>(type: "int", nullable: false),
                    ChassiNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockFinalProduct", x => x.StockFinalProductId);
                    table.ForeignKey(
                        name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId",
                        column: x => x.LocalizationCarId,
                        principalTable: "LocalizationCar",
                        principalColumn: "LocalizationCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockFinalProduct_Production_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Production",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceCollaborators",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    MachineMaintenanceId = table.Column<int>(type: "int", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCollaborators", x => new { x.CollaboratorId, x.MachineMaintenanceId });
                    table.ForeignKey(
                        name: "FK_MaintenanceCollaborators_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceCollaborators_MachineMaintenance_MachineMaintenanceId",
                        column: x => x.MachineMaintenanceId,
                        principalTable: "MachineMaintenance",
                        principalColumn: "MachineMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTestsProduction",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    InspectionTestsProductionId = table.Column<int>(type: "int", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTestsProduction", x => new { x.InspectionId, x.ProductionId });
                    table.ForeignKey(
                        name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "InspectionAndTest",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionTestsProduction_Production_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Production",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
              name: "CarPartsProductId",
              table: "Warehouse",
              type: "int",
              nullable: true);

            migrationBuilder.CreateTable(
                name: "WarehouseProduct",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProduct", x => new { x.WarehouseId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WarehouseProduct_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseProduct_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProduct_ProductId",
                table: "WarehouseProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_CarParts_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId");
        


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
                name: "IX_CollaboratorShifts_ShiftId",
                table: "CollaboratorShifts",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigList_CarConfigId",
                table: "ConfigList",
                column: "CarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigList_ExtraId",
                table: "ConfigList",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_CustomerId",
                table: "CustomerContact",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_CollaboratorId",
                table: "InspectionAndTest",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_ProductionsId",
                table: "InspectionAndTest",
                column: "ProductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_StateId",
                table: "InspectionAndTest",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTestsProduction_ProductionId",
                table: "InspectionTestsProduction",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_LocalizationCodeId",
                table: "Machine",
                column: "LocalizationCodeId");

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
                name: "IX_MaintenanceCollaborators_MachineMaintenanceId",
                table: "MaintenanceCollaborators",
                column: "MachineMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsed_SemiFinishedId",
                table: "MaterialUsed",
                column: "SemiFinishedId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarConfigId",
                table: "ModelParts",
                column: "CarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateId",
                table: "Order",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceSupplierPartsCarParts_ProductId",
                table: "PriceSupplierPartsCarParts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceSupplierPartsCarParts_SupplierPartsId",
                table: "PriceSupplierPartsCarParts",
                column: "SupplierPartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_CarConfigId",
                table: "Production",
                column: "CarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLine_CarConfigId",
                table: "SalesLine",
                column: "CarConfigId");

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
                name: "IX_SemiFinishedCar_CarId",
                table: "SemiFinishedCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftTypeId",
                table: "Shift",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftSchedule_CollaboratorId",
                table: "ShiftSchedule",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftType_ShiftTypeSearchShiftTypeId",
                table: "ShiftType",
                column: "ShiftTypeSearchShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_MaterialId",
                table: "Stock",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_WarehouseStockId",
                table: "Stock",
                column: "WarehouseStockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_LocalizationCarId",
                table: "StockFinalProduct",
                column: "LocalizationCarId");

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_ProductionId",
                table: "StockFinalProduct",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPartsCarParts_ProductId",
                table: "SupplierPartsCarParts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction",
                column: "CarConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CollaboratorID",
                table: "Warehouse",
                column: "CollaboratorID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPunctuality_CollaboratorId",
                table: "WorkerPunctuality",
                column: "CollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakdown");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CollaboratorShifts");

            migrationBuilder.DropTable(
                name: "ConfigList");

            migrationBuilder.DropTable(
                name: "CustomerContact");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "InspectionTestsProduction");

            migrationBuilder.DropTable(
                name: "MachineBudget");

            migrationBuilder.DropTable(
                name: "MaintenanceCollaborators");

            migrationBuilder.DropTable(
                name: "MaterialUsed");

            migrationBuilder.DropTable(
                name: "ModelParts");

            migrationBuilder.DropTable(
                name: "PriceSupplierPartsCarParts");

            migrationBuilder.DropTable(
                name: "SalesLine");

            migrationBuilder.DropTable(
                name: "SectionManager");

            migrationBuilder.DropTable(
                name: "SemiFinishedCar");

            migrationBuilder.DropTable(
                name: "ShiftSchedule");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "StockFinalProduct");

            migrationBuilder.DropTable(
                name: "SupplierPartsCarParts");

            migrationBuilder.DropTable(
                name: "TimeOfProduction");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WorkerPunctuality");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "InspectionAndTest");

            migrationBuilder.DropTable(
                name: "MachineAquisition");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "MachineMaintenance");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SemiFinished");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "WarehouseStock");

            migrationBuilder.DropTable(
                name: "LocalizationCar");

            migrationBuilder.DropTable(
                name: "CarParts");

            migrationBuilder.DropTable(
                name: "SupplierParts");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "InspectionTestState");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "CarConfig");

            migrationBuilder.DropTable(
                name: "LocalizationCode");

            migrationBuilder.DropTable(
                name: "MachineModel");

            migrationBuilder.DropTable(
                name: "MachineState");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "MachineBrand");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
