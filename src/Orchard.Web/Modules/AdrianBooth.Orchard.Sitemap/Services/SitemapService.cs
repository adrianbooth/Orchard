using System;
using System.Linq;
using System.Text;
using Orchard.Autoroute.Models;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.Services;

namespace AdrianBooth.Orchard.Sitemap.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly IContentManager _contentManager;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public SitemapService(IContentManager contentManager, ICacheManager cacheManager, IClock clock)
        {
            _contentManager = contentManager;
            _cacheManager = cacheManager;
            _clock = clock;
        }
        public string GetSitemap()
        {
            return _cacheManager.Get("simple-sitemap", true, ctx =>
            {
                ctx.Monitor(_clock.When(TimeSpan.FromMinutes(60 * 24)));
                return SitemapString();
            });
        }

        private string SitemapString()
        {
            var itemLocations = _contentManager.Query<AutoroutePart, AutoroutePartRecord>()
                  .Where(part => part.DisplayAlias != null).List().Select(e => e.DisplayAlias);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            stringBuilder.AppendLine("<urlset xmlns=\"http://www.google.com/schemas/sitemap/0.90\">");
            foreach (var url in itemLocations)
            {
                stringBuilder.AppendLine($"<url><loc>{url}</loc></url>");
            }
            stringBuilder.AppendLine("</urlset>");

            return stringBuilder.ToString();
        }
    }
}