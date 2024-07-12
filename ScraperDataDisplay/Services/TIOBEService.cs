using Microsoft.EntityFrameworkCore;
using ScraperDataDisplay.Data;
using ScraperDataDisplay.Entities;

namespace ScraperDataDisplay.Services
{
    public class TIOBEService : ITIOBEService
    {
        private readonly ScrapeCaptureDbContext scrapeCaptureDbContext;

        public TIOBEService(ScrapeCaptureDbContext scrapeCaptureDbContext)
        {
            this.scrapeCaptureDbContext = scrapeCaptureDbContext;
        }
        public async Task<List<TIOBERankedLanguage>> GetTIOBERankedLanguages()
        {
            return await (from lang in this.scrapeCaptureDbContext.TIOBERankedLanguages
                          select new TIOBERankedLanguage
                          {
                              Id = lang.Id,
                              RankOrder = lang.RankOrder,
                              LanguageName = lang.LanguageName,
                              ImagePath = lang.ImagePath
                          }).ToListAsync();
        }
    }
}
