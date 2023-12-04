﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaOrderCenterAPI.DataAccess;

#nullable disable

namespace PizzaOrderCenterAPI.Migrations
{
    [DbContext(typeof(PizzaOrderCenterDbContext))]
    partial class PizzaOrderCenterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PizzaPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("PizzeriaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            PizzaName = "Capricciosa",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 1
                        },
                        new
                        {
                            PizzaId = 2,
                            PizzaName = "Mexicana",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 1
                        },
                        new
                        {
                            PizzaId = 3,
                            PizzaName = "Margherita",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 1
                        },
                        new
                        {
                            PizzaId = 4,
                            PizzaName = "Vegetarian",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 2
                        },
                        new
                        {
                            PizzaId = 5,
                            PizzaName = "Capricciosa",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 2
                        },
                        new
                        {
                            PizzaId = 6,
                            PizzaName = "Super Supreme",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 3
                        },
                        new
                        {
                            PizzaId = 7,
                            PizzaName = "The Lot",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 3
                        },
                        new
                        {
                            PizzaId = 8,
                            PizzaName = "Meat Lover",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 4
                        },
                        new
                        {
                            PizzaId = 9,
                            PizzaName = "Cheese Pizza",
                            PizzaPrice = 20.0m,
                            PizzeriaId = 4
                        });
                });

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.PizzaOrder", b =>
                {
                    b.Property<int>("PizzaOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaOrderId");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.PizzaOrderItem", b =>
                {
                    b.Property<int>("PizzaOrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("LineTotal")
                        .HasColumnType("TEXT");

                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzaOrderItemId");

                    b.ToTable("PizzaOrderItems");
                });

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.PizzaOrderItemTopping", b =>
                {
                    b.Property<int>("PizzaOrderItemToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaOrderItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaToppingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ToppingLineItemTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaOrderItemToppingId");

                    b.ToTable("PizzaOrderItemToppings");
                });

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.PizzaTopping", b =>
                {
                    b.Property<int>("PizzaToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PizzaToppingName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaToppingId");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            PizzaToppingId = 1,
                            PizzaToppingName = "Cheese"
                        },
                        new
                        {
                            PizzaToppingId = 2,
                            PizzaToppingName = "Capsicum"
                        },
                        new
                        {
                            PizzaToppingId = 3,
                            PizzaToppingName = "Salami"
                        },
                        new
                        {
                            PizzaToppingId = 4,
                            PizzaToppingName = "Olives"
                        });
                });

            modelBuilder.Entity("PizzaOrderCenterAPI.Models.Pizzeria", b =>
                {
                    b.Property<int>("PizzeriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("PizzeriaName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("PizzeriaId");

                    b.ToTable("Pizzerias");

                    b.HasData(
                        new
                        {
                            PizzeriaId = 1,
                            Location = "Preston",
                            PizzeriaName = "Preston Pizzeria"
                        },
                        new
                        {
                            PizzeriaId = 2,
                            Location = "South Bank",
                            PizzeriaName = "South Bank Pizzeria"
                        },
                        new
                        {
                            PizzeriaId = 3,
                            Location = "Mulgrave",
                            PizzeriaName = "Mulgrave Pizzeria"
                        },
                        new
                        {
                            PizzeriaId = 4,
                            Location = "Mulgrave",
                            PizzeriaName = "Mulgrave East Pizzeria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}