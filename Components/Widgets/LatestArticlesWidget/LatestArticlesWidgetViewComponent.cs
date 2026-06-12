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
    Description = "Displays the latest 3 articles",
    IconClass = "xp-newspaper")]

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
            var articles = await _contentRetriever.RetrievePages<ArticlesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                query => query
                    .TopN(3)
                    .OrderBy(OrderByColumn.Desc(nameof(ArticlesDetail.ArticleDateCreated))),
                RetrievalCacheSettings.CacheDisabled
            );

            var viewModel = new LatestArticlesWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle = properties.SectionSubtitle,
                Articles = articles.ToList()
            };

            return View("~/Components/Widgets/LatestArticlesWidget/LatestArticlesWidget.cshtml", viewModel);
        }
    }
}
