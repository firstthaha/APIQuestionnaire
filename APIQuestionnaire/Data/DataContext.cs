using APIQuestionnaire.Model;
using Microsoft.EntityFrameworkCore;

namespace APIQuestionnaire.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DataQuestion> QuestionTable { get; set; }
        public DbSet<Title> TitleTable { get; set; }
        public DbSet<Occupation> OccupationTable { get; set; }
        public DbSet<Topic> TopicTable { get; set; }
        public DbSet<Country> CountryTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataQuestion>().ToTable("DataQuestion").HasKey(b => b.Id);

            modelBuilder.Entity<Title>().ToTable("Title").HasKey(b => b.TitleCode);

            modelBuilder.Entity<Occupation>().ToTable("Occupation").HasKey(b => b.OccCode);

            modelBuilder.Entity<Topic>().ToTable("Topic").HasKey(b => b.TopicCode);

            modelBuilder.Entity<Country>().ToTable("Country").HasKey(b => b.CountryCode);
        }
    }
}
