using System.Threading.Tasks;
using System.Collections.Generic;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace FinalProject.Widgets
{
    public class FigmaBlogsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Explore Insights in Our Blog";

        [TextAreaComponent(Label = "Description", Order = 2)]
        public string Description { get; set; } = "Find lots of insights and information on our blog. Explore, learn, and get inspired today.";

        [NumberInputComponent(Label = "Number of Blogs", Order = 3)]
        public int Count { get; set; } = 3;

        [DropDownComponent(Label = "Order", DataProviderType = typeof(BlogSortOrderProvider), Order = 4)]
        public string Order { get; set; } = "newest";

        [TagSelectorComponent("FigmaProjectTaxonomies", Label = "Filter by Category (leave empty to show all)", Order = 5)]
        public IEnumerable<TagReference> Categories { get; set; }

        [TextInputComponent(Label = "View More Link", Order = 6)]
        public string ViewMoreLink { get; set; } = "#";
    }

    public class BlogSortOrderProvider : IDropDownOptionsProvider
    {
        public Task<IEnumerable<DropDownOptionItem>> GetOptionItems() =>
            Task.FromResult<IEnumerable<DropDownOptionItem>>(new[]
            {
                new DropDownOptionItem { Value = "newest", Text = "Newest First" },
                new DropDownOptionItem { Value = "oldest", Text = "Oldest First" }
            });
    }
}
