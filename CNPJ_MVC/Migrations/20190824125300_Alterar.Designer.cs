﻿// <auto-generated />
using System;
using CNPJ_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CNPJ_MVC.Migrations
{
    [DbContext(typeof(CnpjContext))]
    [Migration("20190824125300_Alterar")]
    partial class Alterar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CNPJ_MVC.Models.AtividadePrincipal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Empresaid");

                    b.Property<string>("code");

                    b.Property<string>("text");

                    b.HasKey("id");

                    b.HasIndex("Empresaid");

                    b.ToTable("AtividadePrincipal");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.AtividadesSecundarias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Empresaid");

                    b.Property<string>("code");

                    b.Property<string>("text");

                    b.HasKey("id");

                    b.HasIndex("Empresaid");

                    b.ToTable("AtividadesSecundarias");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Billing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("database");

                    b.Property<bool>("free");

                    b.HasKey("id");

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Empresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("abertura");

                    b.Property<string>("bairro");

                    b.Property<int?>("billingid");

                    b.Property<string>("capital_social");

                    b.Property<string>("cep");

                    b.Property<string>("cnpj");

                    b.Property<string>("complemento");

                    b.Property<string>("data_situacao");

                    b.Property<string>("data_situacao_especial");

                    b.Property<string>("efr");

                    b.Property<string>("email");

                    b.Property<int?>("extraid");

                    b.Property<string>("fantasia");

                    b.Property<string>("logradouro");

                    b.Property<string>("motivo_situacao");

                    b.Property<string>("municipio");

                    b.Property<string>("natureza_juridica");

                    b.Property<string>("nome");

                    b.Property<string>("numero");

                    b.Property<string>("porte");

                    b.Property<string>("situacao");

                    b.Property<string>("status");

                    b.Property<string>("telefone");

                    b.Property<string>("tipo");

                    b.Property<string>("uf");

                    b.Property<DateTime>("ultima_atualizacao");

                    b.HasKey("id");

                    b.HasIndex("billingid");

                    b.HasIndex("extraid");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Extra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("id");

                    b.ToTable("Extra");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Qsa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Empresaid");

                    b.Property<string>("nome");

                    b.Property<string>("nome_rep_legal");

                    b.Property<string>("pais_origem");

                    b.Property<string>("qual");

                    b.Property<string>("qual_rep_legal");

                    b.HasKey("id");

                    b.HasIndex("Empresaid");

                    b.ToTable("Qsa");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.AtividadePrincipal", b =>
                {
                    b.HasOne("CNPJ_MVC.Models.Empresa")
                        .WithMany("atividade_principal")
                        .HasForeignKey("Empresaid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CNPJ_MVC.Models.AtividadesSecundarias", b =>
                {
                    b.HasOne("CNPJ_MVC.Models.Empresa")
                        .WithMany("atividades_secundarias")
                        .HasForeignKey("Empresaid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Empresa", b =>
                {
                    b.HasOne("CNPJ_MVC.Models.Billing", "billing")
                        .WithMany()
                        .HasForeignKey("billingid");

                    b.HasOne("CNPJ_MVC.Models.Extra", "extra")
                        .WithMany()
                        .HasForeignKey("extraid");
                });

            modelBuilder.Entity("CNPJ_MVC.Models.Qsa", b =>
                {
                    b.HasOne("CNPJ_MVC.Models.Empresa")
                        .WithMany("qsa")
                        .HasForeignKey("Empresaid");
                });
#pragma warning restore 612, 618
        }
    }
}
