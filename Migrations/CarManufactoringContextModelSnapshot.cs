﻿// <auto-generated />
using System;
using CarManufactoring.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarManufactoring.Migrations
{
    [DbContext(typeof(CarManufactoringContext))]
    partial class CarManufactoringContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarManufactoring.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LaunchYear")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarManufactoring.Models.CarConfig", b =>
                {
                    b.Property<int>("CarConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarConfigId"), 1L, 1);

                    b.Property<double>("AddedPrice")
                        .HasColumnType("float");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumExtras")
                        .HasColumnType("int");

                    b.HasKey("CarConfigId");

                    b.HasIndex("CarId");

                    b.ToTable("CarConfig");
                });

            modelBuilder.Entity("CarManufactoring.Models.CarParts", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("LevelService")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("PointOfPurchase")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("SafetyStock")
                        .HasColumnType("int");

                    b.Property<string>("StockState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("CarParts");
                });

            modelBuilder.Entity("CarManufactoring.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("ClientContact")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("ClientDataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClientSex")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CarManufactoring.Models.Collaborator", b =>
                {
                    b.Property<int>("CollaboratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollaboratorId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("OnDuty")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CollaboratorId");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("CarManufactoring.Models.CollaboratorShift", b =>
                {
                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId", "CollaboratorId");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("CollaboratorShift");
                });

            modelBuilder.Entity("CarManufactoring.Models.CollaboratorTask", b =>
                {
                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int");

                    b.HasKey("ShiftId", "TaskId", "CollaboratorId");

                    b.HasIndex("CollaboratorId");

                    b.HasIndex("TaskId");

                    b.HasIndex("ShiftId", "CollaboratorId");

                    b.ToTable("CollaboratorTask");
                });

            modelBuilder.Entity("CarManufactoring.Models.Estimate", b =>
                {
                    b.Property<int>("EstimateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstimateID"), 1L, 1);

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<DateTime>("dataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataSolicitada")
                        .HasColumnType("datetime2");

                    b.HasKey("EstimateID");

                    b.ToTable("Estimate");
                });

            modelBuilder.Entity("CarManufactoring.Models.Extra", b =>
                {
                    b.Property<int>("ExtraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtraID"), 1L, 1);

                    b.Property<string>("DescExtra")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ExtraID");

                    b.ToTable("Extra");
                });

            modelBuilder.Entity("CarManufactoring.Models.Machines", b =>
                {
                    b.Property<int>("MachinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachinesId"), 1L, 1);

                    b.Property<DateTime>("AquisitionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("MachineBrand")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("MachineModel")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("MachineStateId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("MachinesId");

                    b.HasIndex("MachineStateId");

                    b.HasIndex("SectionId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("CarManufactoring.Models.MachineState", b =>
                {
                    b.Property<int>("MachineStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachineStateId"), 1L, 1);

                    b.Property<string>("StateMachine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MachineStateId");

                    b.ToTable("MachineState");
                });

            modelBuilder.Entity("CarManufactoring.Models.MaintenanceTask", b =>
                {
                    b.Property<int>("MaintenanceTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceTaskId"), 1L, 1);

                    b.Property<string>("TaskDef")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("MaintenanceTaskId");

                    b.ToTable("MaintenanceTask");
                });

            modelBuilder.Entity("CarManufactoring.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaterialId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("CarManufactoring.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderState")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("StateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CarManufactoring.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SectionId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("CarManufactoring.Models.SectionManager", b =>
                {
                    b.Property<int>("SectionManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionManagerId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("SectionManagerId");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionManager");
                });

            modelBuilder.Entity("CarManufactoring.Models.SemiFinished", b =>
                {
                    b.Property<int>("SemiFinishedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemiFinishedId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Manufacter")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SemiFinishedState")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SemiFinishedId");

                    b.ToTable("SemiFinished");
                });

            modelBuilder.Entity("CarManufactoring.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShiftHours")
                        .HasColumnType("int");

                    b.Property<string>("ShiftStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("CarManufactoring.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("LimitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TaskId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("CarManufactoring.Models.WorkMachineMaintenance", b =>
                {
                    b.Property<int>("WorkMachineMaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkMachineMaintenanceId"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int>("MachinesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MaintenanceStateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaintenanceTaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PreviewStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SectionManagerId")
                        .HasColumnType("int");

                    b.Property<string>("WorkPriority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkStatesId")
                        .HasColumnType("int");

                    b.HasKey("WorkMachineMaintenanceId");

                    b.HasIndex("MachinesId");

                    b.HasIndex("MaintenanceTaskId");

                    b.HasIndex("SectionManagerId");

                    b.HasIndex("WorkStatesId");

                    b.ToTable("WorkMachineMaintenance");
                });

            modelBuilder.Entity("CarManufactoring.Models.WorkStates", b =>
                {
                    b.Property<int>("WorkStatesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkStatesId"), 1L, 1);

                    b.Property<string>("StateWork")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WorkStatesId");

                    b.ToTable("WorkStates");
                });

            modelBuilder.Entity("CarManufactoring.Models.CarConfig", b =>
                {
                    b.HasOne("CarManufactoring.Models.Car", "Car")
                        .WithMany("CarConfigs")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarManufactoring.Models.CollaboratorShift", b =>
                {
                    b.HasOne("CarManufactoring.Models.Collaborator", "Collaborator")
                        .WithMany("Shifts")
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.Shift", "Shift")
                        .WithMany("Collaborators")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("CarManufactoring.Models.CollaboratorTask", b =>
                {
                    b.HasOne("CarManufactoring.Models.Collaborator", "Collaborator")
                        .WithMany("Tasks")
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.Task", "Task")
                        .WithMany("Collaborators")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.CollaboratorShift", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ShiftId", "CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");

                    b.Navigation("Shift");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("CarManufactoring.Models.Machines", b =>
                {
                    b.HasOne("CarManufactoring.Models.MachineState", "MachineState")
                        .WithMany("Machines")
                        .HasForeignKey("MachineStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.Section", "Section")
                        .WithMany("Machines")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineState");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CarManufactoring.Models.SectionManager", b =>
                {
                    b.HasOne("CarManufactoring.Models.Section", "Section")
                        .WithMany("Manager")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CarManufactoring.Models.WorkMachineMaintenance", b =>
                {
                    b.HasOne("CarManufactoring.Models.Machines", "Machines")
                        .WithMany("WorkMachineMaintenances")
                        .HasForeignKey("MachinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.MaintenanceTask", "MaintenanceTask")
                        .WithMany("WorkMachineMaintenances")
                        .HasForeignKey("MaintenanceTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.SectionManager", "SectionManager")
                        .WithMany("WorkMachineMaintenances")
                        .HasForeignKey("SectionManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarManufactoring.Models.WorkStates", "WorkStates")
                        .WithMany("WorkMachineMaintenances")
                        .HasForeignKey("WorkStatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machines");

                    b.Navigation("MaintenanceTask");

                    b.Navigation("SectionManager");

                    b.Navigation("WorkStates");
                });

            modelBuilder.Entity("CarManufactoring.Models.Car", b =>
                {
                    b.Navigation("CarConfigs");
                });

            modelBuilder.Entity("CarManufactoring.Models.Collaborator", b =>
                {
                    b.Navigation("Shifts");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("CarManufactoring.Models.CollaboratorShift", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("CarManufactoring.Models.Machines", b =>
                {
                    b.Navigation("WorkMachineMaintenances");
                });

            modelBuilder.Entity("CarManufactoring.Models.MachineState", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("CarManufactoring.Models.MaintenanceTask", b =>
                {
                    b.Navigation("WorkMachineMaintenances");
                });

            modelBuilder.Entity("CarManufactoring.Models.Section", b =>
                {
                    b.Navigation("Machines");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("CarManufactoring.Models.SectionManager", b =>
                {
                    b.Navigation("WorkMachineMaintenances");
                });

            modelBuilder.Entity("CarManufactoring.Models.Shift", b =>
                {
                    b.Navigation("Collaborators");
                });

            modelBuilder.Entity("CarManufactoring.Models.Task", b =>
                {
                    b.Navigation("Collaborators");
                });

            modelBuilder.Entity("CarManufactoring.Models.WorkStates", b =>
                {
                    b.Navigation("WorkMachineMaintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
