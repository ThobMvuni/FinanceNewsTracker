using FinanceNewsTracker.Models;

namespace FinanceNewsTracker.Services
{
    public interface INewsService
    {
        FinanceNews GetFinanceNews(int offset);
    }
}
