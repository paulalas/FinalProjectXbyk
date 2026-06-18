using System.Collections.Generic;
using System.Threading.Tasks;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace FinalProject.Widgets
{
    public class ArticlesListWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "All Articles";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Articles";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Browse all of our latest news and articles.";

        [NumberInputComponent(Label = "Items Per Page", Order = 4)]
        public int PageSize { get; set; } = 5;

        [DropDownComponent(Label = "Sort Order", DataProviderType = typeof(ArticlesListSortOrderProvider), Order = 5)]
        public string SortOrder { get; set; } = "newest";
    }

    public class ArticlesListSortOrderProvider : IDropDownOptionsProvider
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
