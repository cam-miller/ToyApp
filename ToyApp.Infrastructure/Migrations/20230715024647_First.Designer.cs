﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToyApp.Infrastructure.Persistence;

#nullable disable

namespace ToyApp.Infrastructure.Migrations
{
    [DbContext(typeof(ToyAppContext))]
    [Migration("20230715024647_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ToyApp.Infrastructure.RepositoryModels.TodoItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Uuid");

                    b.ToTable("todo_item", (string)null);
                });

            modelBuilder.Entity("ToyApp.Infrastructure.RepositoryModels.TodoItemModel", b =>
                {
                    b.OwnsOne("ToyApp.Core.TodoItem", "Todo", b1 =>
                        {
                            b1.Property<int>("TodoItemModelId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("DueDate")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("TodoItemModelId");

                            b1.ToTable("todo_item");

                            b1.WithOwner()
                                .HasForeignKey("TodoItemModelId");
                        });

                    b.Navigation("Todo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}