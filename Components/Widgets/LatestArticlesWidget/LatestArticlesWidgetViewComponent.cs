using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FinalProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataEngine;

[assembly: RegisterWidget(
    LatestArticlesWidgetViewComponent.IDENTIFIER,
    typeof(LatestArticlesWidgetViewComponent),
    "Latest Articles",
    typeof(LatestArticlesWidgetProperties),
    Description = "Displays articles with configurable count, order, and category filter",
    IconClass = "icon-newspaper")]

namespace FinalProject.Widgets
{
    public class LatestArticlesWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.LatestArticlesWidget";

        private readonly IContentRetriever _contentRetriever;

        public LatestArticlesWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(LatestArticlesWidgetProperties properties)
        {
            var count = properties.Count > 0 ? properties.Count : 3;

            // Build the order clause from the selected sort order
            var orderBy = properties.SortOrder switch
            {
                "oldest" => OrderByColumn.Asc(nameof(ArticlesDetail.ArticleDateCreated)),
                "az"     => OrderByColumn.Asc(nameof(ArticlesDetail.ArticleTitle)),
                "za"     => OrderByColumn.Desc(nameof(ArticlesDetail.ArticleTitle)),
                _        => OrderByColumn.Desc(nameof(ArticlesDetail.ArticleDateCreated))
            };

            // Fetch articles with ordering — no TopN yet so category filter can run first
            var allArticles = await _contentRetriever.RetrievePages<ArticlesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                query => query.OrderBy(orderBy),
                RetrievalCacheSettings.CacheDisabled
            );

            var articleList = allArticles.ToList();

            // Filter by selected category tags if any are chosen
            var filterTags = properties.CategoryFilter?.ToList();
            if (filterTags != null && filterTags.Count > 0)
            {
                var filterGuids = filterTags.Select(t => t.Identifier).ToHashSet();
                articleList = articleList
                    .Where(a => a.ArticleTaxonomy?.Any(t => filterGuids.Contains(t.Identifier)) == true)
                    .ToList();
            }

            var viewModel = new LatestArticlesWidgetViewModel
            {
                SectionTitle          = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle       = properties.SectionSubtitle,
                Articles              = articleList.Take(count).ToList()
            };

            return View("~/Components/Widgets/LatestArticlesWidget/LatestArticlesWidget.cshtml", viewModel);
        }
    }
}
