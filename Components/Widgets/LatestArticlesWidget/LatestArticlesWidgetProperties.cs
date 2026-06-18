using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace FinalProject.Widgets
{
    public class LatestArticlesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Latest Articles";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Articles";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Stay up to date with our latest news and articles.";

        [NumberInputComponent(Label = "Number of Articles", Order = 4)]
        public int Count { get; set; } = 3;

        [DropDownComponent(Label = "Sort Order", DataProviderType = typeof(ArticleSortOrderProvider), Order = 5)]
        public string SortOrder { get; set; } = "newest";

        [TagSelectorComponent("ArticleTaxonomy", Label = "Filter by Category (leave empty to show all)", Order = 6)]
        public IEnumerable<TagReference> CategoryFilter { get; set; }
    }

    public class ArticleSortOrderProvider : IDropDownOptionsProvider
    {
        public Task<IEnumerable<DropDownOptionItem>> GetOptionItems() =>
            Task.FromResult<IEnumerable<DropDownOptionItem>>(new[]
            {
                new DropDownOptionItem { Value = "newest", Text = "Newest First" },
                new DropDownOptionItem { Value = "oldest", Text = "Oldest First" },
                new DropDownOptionItem { Value = "az",     Text = "A to Z (Title)" },
                new DropDownOptionItem { Value = "za",     Text = "Z to A (Title)" }
            });
    }
}
