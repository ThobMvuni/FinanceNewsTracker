using FinanceNewsTracker.Models;
using FinanceNewsTracker.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceNewsTracker.Pages
{
    public class IndexModel : PageModel
    {
        public FinanceNews? news { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly INewsService _newsService;

        public IndexModel(ILogger<IndexModel> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        public async Task OnGet()
        {
            try
            {
                news = await _newsService.GetFinanceNewsAsync(0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading news");
                news = null;
            }
        }

        public async Task OnGetLoadMoreNews(int offset)
        {
            try
            {
                news = await _newsService.GetFinanceNewsAsync(offset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading more news");
                news = null;
            }
        }
    }
}
