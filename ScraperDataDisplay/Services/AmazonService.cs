using Microsoft.EntityFrameworkCore;
using ScraperDataDisplay.Data;
using ScraperDataDisplay.Models;

namespace ScraperDataDisplay.Services
{
    public class AmazonService : IAmazonService
    {
        private readonly ScrapeCaptureDbContext scrapeCaptureDbContext;

        public AmazonService(ScrapeCaptureDbContext scrapeCaptureDbContext)
        {
            this.scrapeCaptureDbContext = scrapeCaptureDbContext;
        }

        public async Task<List<AmazonBooksByLanguage>> GetAmazonBooksGroupedByLanguage()
        {
            return await (from t in this.scrapeCaptureDbContext.TIOBERankedLanguages
                          join b in this.scrapeCaptureDbContext.AmazonBooks
                          on t.Id equals b.LanguageId into grouping
                          orderby t.RankOrder
                          select new AmazonBooksByLanguage
                          {
                              Id = t.Id,
                              LanguageName = t.LanguageName,
                              RankOrder = t.RankOrder,
                              ImagePath = t.ImagePath,
                              AmazonBooks = grouping.ToList()
                          }).ToListAsync();
        }
    }
}
