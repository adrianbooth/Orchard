using Orchard;

namespace AdrianBooth.Orchard.Sitemap.Services
{
    public interface ISitemapService : IDependency {
        string GetSitemap();
    }
}