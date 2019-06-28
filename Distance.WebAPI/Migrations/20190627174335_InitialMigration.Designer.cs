﻿// <auto-generated />
using System;
using Distance.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Distance.WebAPI.Migrations
{
    [DbContext(typeof(DistanceContext))]
    [Migration("20190627174335_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Distance.Domain.Entities.CalculoHistoricoLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distancia");

                    b.Property<int>("DistanciaDestinoId");

                    b.Property<int>("DistanciaOrigemId");

                    b.Property<int>("LatitudeDestino");

                    b.Property<int>("LatitudeOrigem");

                    b.Property<DateTime>("LogData");

                    b.Property<int>("LongitudeDestino");

                    b.Property<int>("LongitudeOrigem");

                    b.HasKey("Id");

                    b.ToTable("CalculoHistoricoLog");
                });

            modelBuilder.Entity("Distance.Domain.Entities.Distancia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Latitude");

                    b.Property<int>("Longitude");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Distancia");
                });
#pragma warning restore 612, 618
        }
    }
}
