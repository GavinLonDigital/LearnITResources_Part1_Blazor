using ScraperDataDisplay.Entities;

namespace ScraperDataDisplay.Services
{
    public interface ITIOBEService
    {
        Task<List<TIOBERankedLanguage>> GetTIOBERankedLanguages();
    }
}
