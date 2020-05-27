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
    [Migration("20200526090411_RemoveIngredientMeasurementManyToMany")]
    partial class RemoveIngredientMeasurementManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RazorPagesRecipe.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("IngredientID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MeasurementID");

                    b.HasIndex("IngredientID");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<int?>("CookingTime")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .HasColumnType("text");

                    b.Property<int?>("PreparationTime")
                        .HasColumnType("integer");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("TotalTime")
                        .HasColumnType("integer");

                    b.HasKey("RecipeID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeID")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientID")
                        .HasColumnType("integer");

                    b.HasKey("RecipeID", "IngredientID");

                    b.HasIndex("IngredientID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Measurement", b =>
                {
                    b.HasOne("RazorPagesRecipe.Models.Ingredient", "Ingredient")
                        .WithMany("Measurements")
                        .HasForeignKey("IngredientID");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.Recipe", b =>
                {
                    b.HasOne("RazorPagesRecipe.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("RazorPagesRecipe.Models.RecipeIngredient", b =>
                {
                    b.HasOne("RazorPagesRecipe.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorPagesRecipe.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
