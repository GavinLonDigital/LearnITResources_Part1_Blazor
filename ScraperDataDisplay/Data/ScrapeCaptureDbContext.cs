
using Microsoft.EntityFrameworkCore;
using ScraperDataDisplay.Entities;

namespace ScraperDataDisplay.Data
{
    public class ScrapeCaptureDbContext : DbContext
    {
        public ScrapeCaptureDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TIOBERankedLanguage> TIOBERankedLanguages { get; set; }
        public DbSet<AmazonBook> AmazonBooks { get; set; }
    }
}
