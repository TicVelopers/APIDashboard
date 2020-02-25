using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIDashboard.Models
{
    public partial class DBAPIFUELSContext : DbContext
    {
        public DBAPIFUELSContext()
        {
        }

        public DBAPIFUELSContext(DbContextOptions<DBAPIFUELSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TdCombustibles> TdCombustibles { get; set; }
        public virtual DbSet<TdUser> TdUser { get; set; }
        public virtual DbSet<TeamXam> TeamXam { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("workstation id=DBAPIFUELS.mssql.somee.com;packet size=4096;user id=franciscohdd_SQLLogin_2;pwd=dbr4rcsm9r;data source=DBAPIFUELS.mssql.somee.com;persist security info=False;initial catalog=DBAPIFUELS");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TdCombustibles>(entity =>
            {
                entity.ToTable("TD_COMBUSTIBLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodigoDate)
                    .HasColumnName("CODIGO_DATE")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Combustible)
                    .HasColumnName("COMBUSTIBLE")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("FECHA_REGISTRO")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSemana)
                    .HasColumnName("FECHA_SEMANA")
                    .HasColumnType("date");

                entity.Property(e => e.Precio)
                    .HasColumnName("PRECIO")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SemanaLabel)
                    .HasColumnName("SEMANA_LABEL")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TdUser>(entity =>
            {
                entity.ToTable("TD_USER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApiKey)
                    .HasColumnName("API_KEY")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .HasColumnName("USER_PASS")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeamXam>(entity =>
            {
                entity.ToTable("TEAM_XAM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GithubUser)
                    .HasColumnName("GITHUB_USER")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasColumnName("TEAM")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
