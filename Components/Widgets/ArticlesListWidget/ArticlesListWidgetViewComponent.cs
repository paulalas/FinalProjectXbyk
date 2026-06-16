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
    ArticlesListWidgetViewComponent.IDENTIFIER,
    typeof(ArticlesListWidgetViewComponent),
    "Articles List",
    typeof(ArticlesListWidgetProperties),
    Description = "Filterable, paginated list of all articles",
    IconClass = "xp-list-bullets")]

namespace FinalProject.Widgets
{
    public class ArticlesListWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.ArticlesListWidget";

        private readonly IContentRetriever _contentRetriever;

        public ArticlesListWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(ArticlesListWidgetProperties properties)
        {
            var allArticles = await _contentRetriever.RetrievePages<ArticlesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                q => q.OrderBy(OrderByColumn.Desc(nameof(ArticlesDetail.ArticleDateCreated))),
                RetrievalCacheSettings.CacheDisabled
            );

            var articleList = allArticles.ToList();

            var categories = articleList
                .Select(a => a.ArticleCategory)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            var viewModel = new ArticlesListWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle = properties.SectionSubtitle,
                Articles = articleList,
                Categories = categories
            };

            return View("~/Components/Widgets/ArticlesListWidget/ArticlesListWidget.cshtml", viewModel);
        }
    }
}
