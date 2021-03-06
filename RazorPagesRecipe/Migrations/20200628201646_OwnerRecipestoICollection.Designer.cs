﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RazorPagesRecipe.Data;

namespace RazorPagesRecipe.Migrations
{
    [DbContext(typeof(RazorPagesRecipeContext))]
    [Migration("20200628201646_OwnerRecipestoICollection")]
    partial class OwnerRecipestoICollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RazorPagesRecipe.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Owner", b =>
                {
                    b.Property<int>("OwnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("OwnerID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<int?>("CookingTime")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Freezable")
                        .HasColumnType("boolean");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("integer");

                    b.Property<int>("Portions")
                        .HasColumnType("integer");

                    b.Property<int?>("PreparationTime")
                        .HasColumnType("integer");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TotalTime")
                        .HasColumnType("integer");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("boolean");

                    b.HasKey("RecipeID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.RecipeUtensil", b =>
                {
                    b.Property<int>("RecipeID")
                        .HasColumnType("integer");

                    b.Property<int>("UtensilID")
                        .HasColumnType("integer");

                    b.HasKey("RecipeID", "UtensilID");

                    b.HasIndex("UtensilID");

                    b.ToTable("RecipeUtensil");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Utensil", b =>
                {
                    b.Property<int>("UtensilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("UtensilID");

                    b.ToTable("Utensil");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Recipe", b =>
                {
                    b.HasOne("RazorPagesRecipe.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryID");

                    b.HasOne("RazorPagesRecipe.Models.Owner", "Owner")
                        .WithMany("Recipes")
                        .HasForeignKey("OwnerID");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.RecipeUtensil", b =>
                {
                    b.HasOne("RazorPagesRecipe.Models.Recipe", "Recipe")
                        .WithMany("RecipeUtensils")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorPagesRecipe.Models.Utensil", "Utensil")
                        .WithMany("RecipeUtensils")
                        .HasForeignKey("UtensilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
