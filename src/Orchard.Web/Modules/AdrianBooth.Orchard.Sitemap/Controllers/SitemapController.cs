using System.Text;
using System.Web.Mvc;
using AdrianBooth.Orchard.Sitemap.Services;

namespace AdrianBooth.Orchard.Sitemap.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ISitemapService _sitemapService;

        public SitemapController(ISitemapService sitemapService)
        {
            _sitemapService = sitemapService;
        }
        public ContentResult Index()
        {
            var sitemapContent = _sitemapService.GetSitemap();

            return new ContentResult
            {
                Content = sitemapContent,
                ContentEncoding = Encoding.UTF8,
                ContentType = "application/xml"
            };
        }
    }
}