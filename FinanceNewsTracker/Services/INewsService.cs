using FinanceNewsTracker.Models;
using System.Threading.Tasks;

namespace FinanceNewsTracker.Services
{
    public interface INewsService
    {
        Task<FinanceNews> GetFinanceNewsAsync(int offset);
    }
}
