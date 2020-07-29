using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIDashboard.Entities.Models
{
    public partial class DBAPIDASHBOARDContext : DbContext
    {
        public DBAPIDASHBOARDContext()
        {
        }

        public DBAPIDASHBOARDContext(DbContextOptions<DBAPIDASHBOARDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatConversation> ChatConversation { get; set; }
        public virtual DbSet<ChatFriendList> ChatFriendList { get; set; }
        public virtual DbSet<ChatUser> ChatUser { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TdCombustibles> TdCombustibles { get; set; }
        public virtual DbSet<TdUser> TdUser { get; set; }
        public virtual DbSet<UserInRole> UserInRole { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("workstation id=DBAPIDASHBOARD.mssql.somee.com;packet size=4096;user id=steven1909_SQLLogin_1;pwd=y78z2fuqq7;data source=DBAPIDASHBOARD.mssql.somee.com;persist security info=False;initial catalog=DBAPIDASHBOARD");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatConversation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHAT_CONVERSATION");

                entity.Property(e => e.DateTime)
                    .HasColumnName("DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MessageReceiver)
                    .HasColumnName("MESSAGE_RECEIVER")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MessageSender)
                    .HasColumnName("MESSAGE_SENDER")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MessageText)
                    .HasColumnName("MESSAGE_TEXT")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatFriendList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHAT_FRIEND_LIST");

                entity.Property(e => e.Estatus)
                    .HasColumnName("ESTATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NumberFriend)
                    .HasColumnName("NUMBER_FRIEND")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumberMain)
                    .HasColumnName("NUMBER_MAIN")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("CHAT_USER");

                entity.Property(e => e.Number)
                    .HasColumnName("NUMBER")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasColumnName("PICTURE")
                    .HasColumnType("image");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

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

            modelBuilder.Entity<UserInRole>(entity =>
            {
                entity.ToTable("USER_IN_ROLE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
