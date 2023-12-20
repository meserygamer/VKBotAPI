using Microsoft.EntityFrameworkCore;

namespace CallBackVKAPI.Models.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() => Database.EnsureCreated();

        public DbSet<BotUser> BotUsers => Set<BotUser>();

        public DbSet<Schedule> Schedules => Set<Schedule>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AppDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BotUser>(entity => 
            {
                entity.HasKey(e => e.Id).HasName("BotUser_pk");

                entity.ToTable("BotUsers");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BotUserID");

                entity.Property(e => e.VkId)
                    .HasColumnName("BotUserVkId");

                entity.Property(e => e.IsSubscriber)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("IsSubscriber");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("IsAdmin");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Schedule_pk");

                entity.ToTable("Schedules");

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .HasColumnName("SchedulesID");

                entity.Property(e => e.AuthorID)
                      .HasColumnName("AuthorID");

                entity.Property(e => e.ScheduleDate)
                      .HasColumnType("DATE")
                      .HasColumnName("SchedulesDate");

                entity.Property(e => e.ScheduleURL)
                      .HasColumnName("ScheduleURL");

                entity.Property(e => e.SheduleByteForm)
                      .HasColumnName("SheduleByteForm");

                entity.HasOne(s => s.User)
                      .WithMany(u => u.Schedules)
                      .HasForeignKey(s => s.AuthorID)
                      .IsRequired();
            });
        }
    }
}
