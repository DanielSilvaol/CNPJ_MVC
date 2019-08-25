using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CNPJ_MVC.Models
{
    public class CnpjContext : DbContext
    {
        public CnpjContext (DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("Empresa").HasKey(x => x.id);
            modelBuilder.Entity<AtividadesSecundarias>().ToTable("AtividadesSecundarias").HasKey(x => x.id);
            modelBuilder.Entity<AtividadePrincipal>().ToTable("AtividadePrincipal").HasKey(x => x.id);
            modelBuilder.Entity<Qsa>().ToTable("Qsa").HasKey(x => x.id);
            modelBuilder.Entity<Extra>().ToTable("Extra").HasKey(x => x.id);
            modelBuilder.Entity<Billing>().ToTable("Billing").HasKey(x => x.id);

            modelBuilder.Entity<Empresa>().HasOne(em => em.extra)
                                          .WithOne(ex => ex.Empresa)
                                          .HasForeignKey<Empresa>(em=>em.extraid);

            modelBuilder.Entity<Empresa>().HasOne(em => em.billing)
                                          .WithOne(ex => ex.Empresa)
                                          .HasForeignKey<Empresa>(em => em.billingid);

            modelBuilder.Entity<AtividadesSecundarias>().HasOne(ats => ats.Empresa)
                                                        .WithMany(em => em.atividades_secundarias)
                                                        .HasForeignKey(ats => ats.Empresaid);

            modelBuilder.Entity<AtividadePrincipal>().HasOne(atp => atp.Empresa)
                                                        .WithMany(em => em.atividade_principal)
                                                        .HasForeignKey(atp => atp.Empresaid);

            modelBuilder.Entity<Qsa>().HasOne(qs => qs.Empresa)
                                        .WithMany(em => em.qsa)
                                        .HasForeignKey(qs => qs.Empresaid);

            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<CNPJ_MVC.Models.Empresa> Empresa { get; set; }
        public virtual DbSet<CNPJ_MVC.Models.AtividadesSecundarias> AtividadesSecundarias{ get; set; }
        public virtual DbSet<CNPJ_MVC.Models.AtividadePrincipal> AtividadePrincipal { get; set; }
        public virtual DbSet<CNPJ_MVC.Models.Qsa> Qsa { get; set; }
        public virtual DbSet<Extra> Extra { get; set; }
        public virtual DbSet<Billing> Billing { get; set; }
    }
}
