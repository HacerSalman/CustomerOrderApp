﻿// <auto-generated />
using CustomerOrderApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerOrderApp.Data.Migrations
{
    [DbContext(typeof(CustomerOrderDbContext))]
    partial class CustomerOrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.Customer", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<string>("Email")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("email");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<string>("Password")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("password");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerAddress", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("address");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<ulong>("CustomerId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("customer_id");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("customer_address");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerOrder", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<ulong>("CustomerAddressId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("customer_address_id");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<ulong>("Quantity")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("CustomerAddressId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("customer_order");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerOrderProduct", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<ulong>("CustomerOrderId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("customer_order_id");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<ulong>("ProductId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("product_id");

                    b.Property<ulong>("Quantity")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("CustomerOrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("customer_order_product");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerPermission", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<ulong>("CustomerId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("customer_id");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("permission");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.HasIndex("Permission", "CustomerId")
                        .IsUnique();

                    b.ToTable("customer_permission");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.Product", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Barcode")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("barcode");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("description");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext")
                        .HasColumnName("modifier");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext")
                        .HasColumnName("owner");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<ulong>("Quantity")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<long>("UpdateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("Update_time");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("Description");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 1ul,
                            Barcode = "Barcode",
                            CreateTime = 1654358265000L,
                            Description = "New Product",
                            Modifier = "EF",
                            Owner = "EF",
                            Price = 10.0,
                            Quantity = 5ul,
                            Status = "ACTIVE",
                            UpdateTime = 1654358265000L
                        });
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Enums.EntityStatus", b =>
                {
                    b.Property<string>("V")
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("v");

                    b.HasKey("V");

                    b.ToTable("entity_status");

                    b.HasData(
                        new
                        {
                            V = "ACTIVE"
                        },
                        new
                        {
                            V = "PASSIVE"
                        },
                        new
                        {
                            V = "DELETED"
                        });
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Enums.Permission", b =>
                {
                    b.Property<string>("V")
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("v");

                    b.HasKey("V");

                    b.ToTable("permission");

                    b.HasData(
                        new
                        {
                            V = "CUSTOMER_MANAGE"
                        },
                        new
                        {
                            V = "CUSTOMER_ORDER_MANAGE"
                        },
                        new
                        {
                            V = "PRODUCT_MANAGE"
                        },
                        new
                        {
                            V = "SYSTEM_MANAGE"
                        });
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.Customer", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerAddress", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerOrder", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Entities.CustomerAddress", "CustomerAddress")
                        .WithMany()
                        .HasForeignKey("CustomerAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerAddress");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerOrderProduct", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Entities.CustomerOrder", "CustomerOrder")
                        .WithMany("CustomerOrderProducts")
                        .HasForeignKey("CustomerOrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerOrder");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerPermission", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Enums.Permission", null)
                        .WithMany()
                        .HasForeignKey("Permission")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.Product", b =>
                {
                    b.HasOne("CustomerOrderApp.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerOrderApp.Data.Entities.CustomerOrder", b =>
                {
                    b.Navigation("CustomerOrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
