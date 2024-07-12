using ScraperDataDisplay.Models;

namespace ScraperDataDisplay.Services
{
    public interface IAmazonService
    {
        Task<List<AmazonBooksByLanguage>> GetAmazonBooksGroupedByLanguage();
    }
}
