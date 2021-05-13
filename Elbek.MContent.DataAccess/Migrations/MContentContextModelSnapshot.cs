﻿// <auto-generated />
using System;
using Elbek.MContent.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Elbek.MContent.DataAccess.Migrations
{
///TODO 4 для чего ты тут используешь MContentContextModelSnapshot ?
/// миграции тут нам не нужны, с базой работает проект Database, он должен создавать базу и заполнять ее данными


[DbContext(typeof(MContentContext))]
partial class MContentContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
        .HasAnnotation("Relational:MaxIdentifierLength", 128)
        .HasAnnotation("ProductVersion", "5.0.5")
        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        modelBuilder.Entity("Elbek.MContent.DataAccess.Models.Author", b =>
        {
            b.Property<Guid>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("uniqueidentifier");

            b.Property<string>("Name")
            .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Authors");
        });
#pragma warning restore 612, 618
    }
}
}
