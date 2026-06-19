using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FigmaProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CMS.ContentEngine;
using CMS.DataEngine;

[assembly: RegisterWidget(
    FigmaBlogsWidgetViewComponent.IDENTIFIER,
    typeof(FigmaBlogsWidgetViewComponent),
    "Figma Blogs",
    typeof(FigmaBlogsWidgetProperties),
    Description = "Blog cards grid with count, date ordering, and category filtering",
    IconClass = "icon-newspaper")]

namespace FinalProject.Widgets
{
    public class FigmaBlogsWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaBlogsWidget";

        private readonly IContentRetriever _contentRetriever;
        private readonly ITaxonomyRetriever _taxonomyRetriever;

        public FigmaBlogsWidgetViewComponent(IContentRetriever contentRetriever, ITaxonomyRetriever taxonomyRetriever)
        {
            _contentRetriever = contentRetriever;
            _taxonomyRetriever = taxonomyRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaBlogsWidgetProperties properties)
        {
            var count = properties.Count > 0 ? properties.Count : 3;
            var filterTagGuids = properties.Categories?.Select(t => t.Identifier).ToList();

            var orderBy = properties.Order == "oldest"
                ? OrderByColumn.Asc(nameof(Blogs.BlogDateCreated))
                : OrderByColumn.Desc(nameof(Blogs.BlogDateCreated));

            var allBlogs = await _contentRetriever.RetrievePages<Blogs>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                query => query.OrderBy(orderBy),
                RetrievalCacheSettings.CacheDisabled);

            var filtered = allBlogs.AsEnumerable();
            if (filterTagGuids?.Count > 0)
            {
                filtered = filtered.Where(b =>
                    b.BlogCategory?.Any(t => filterTagGuids.Contains(t.Identifier)) == true);
            }

            var blogList = filtered.Take(count).ToList();

            // Resolve all tag GUIDs to display titles
            var allTagGuids = blogList
                .SelectMany(b => b.BlogCategory ?? [])
                .Select(t => t.Identifier)
                .Distinct()
                .ToArray();

            var tagLookup = new Dictionary<Guid, string>();
            if (allTagGuids.Length > 0)
            {
                var tags = await _taxonomyRetriever.RetrieveTags(allTagGuids, "en");
                foreach (var tag in tags)
                    tagLookup[tag.Identifier] = tag.Title;
            }

            var cards = blogList.Select(b => new FigmaBlogCardModel
            {
                ImageUrl = b.BlogPicture?.FirstOrDefault()?.Thumbnail?.Url ?? "",
                Date     = b.BlogDateCreated.ToString("dd MMM yyyy"),
                Title    = b.BlogTitle,
                Excerpt  = StripHtml(b.BlogContent),
                TagNames = [.. (b.BlogCategory ?? [])
                               .Where(t => tagLookup.ContainsKey(t.Identifier))
                               .Select(t => tagLookup[t.Identifier])]
            }).ToList();

            var viewModel = new FigmaBlogsWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                Description  = properties.Description,
                Cards        = cards,
                ViewMoreLink = properties.ViewMoreLink
            };

            return View("~/Components/Widgets/FigmaBlogsWidget/FigmaBlogsWidget.cshtml", viewModel);
        }

        private static string StripHtml(string html)
        {
            if (string.IsNullOrEmpty(html)) return "";
            return Regex.Replace(html, "<[^>]*>", "");
        }
    }
}
