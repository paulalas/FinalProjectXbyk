using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FinalProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataEngine;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    ArticlesListWidgetViewComponent.IDENTIFIER,
    typeof(ArticlesListWidgetViewComponent),
    "Articles List",
    typeof(ArticlesListWidgetProperties),
    Description = "Filterable, paginated list of all articles",
    IconClass = "icon-list-bullets")]

namespace FinalProject.Widgets
{
    public class ArticlesListWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.ArticlesListWidget";

        private readonly IContentRetriever _contentRetriever;
        private readonly ITaxonomyRetriever _taxonomyRetriever;

        public ArticlesListWidgetViewComponent(IContentRetriever contentRetriever, ITaxonomyRetriever taxonomyRetriever)
        {
            _contentRetriever = contentRetriever;
            _taxonomyRetriever = taxonomyRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(ArticlesListWidgetProperties properties)
        {
            var allArticles = await _contentRetriever.RetrievePages<ArticlesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                q => q.OrderBy(OrderByColumn.Desc(nameof(ArticlesDetail.ArticleDateCreated))),
                RetrievalCacheSettings.CacheDisabled
            );

            var articleList = allArticles.ToList();

            // Collect all unique tag GUIDs across all articles
            var allTagGuids = articleList
                .SelectMany(a => a.ArticleTaxonomy ?? Enumerable.Empty<TagReference>())
                .Select(t => t.Identifier)
                .Distinct()
                .ToArray();

            // Resolve GUIDs → tag titles via Kentico taxonomy service
            var tagLookup = new Dictionary<Guid, string>();
            if (allTagGuids.Length > 0)
            {
                var tags = await _taxonomyRetriever.RetrieveTags(allTagGuids, "en");
                foreach (var tag in tags)
                {
                    tagLookup[tag.Identifier] = tag.Title;
                }
            }

            // Unique sorted tag titles for filter buttons
            var categories = tagLookup.Values
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            var viewModel = new ArticlesListWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle = properties.SectionSubtitle,
                Articles = articleList,
                Categories = categories,
                TagTitles = tagLookup
            };

            return View("~/Components/Widgets/ArticlesListWidget/ArticlesListWidget.cshtml", viewModel);
        }
    }
}
