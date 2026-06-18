using System.Collections.Generic;
using System.Threading.Tasks;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace FinalProject.Widgets
{
    public class ServicesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Our Services";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Services";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Explore what we have to offer.";

        [NumberInputComponent(Label = "Number of Services", Order = 4)]
        public int Count { get; set; } = 3;

        [DropDownComponent(Label = "Sort Order", DataProviderType = typeof(ServicesSortOrderProvider), Order = 5)]
        public string SortOrder { get; set; } = "newest";
    }

    public class ServicesSortOrderProvider : IDropDownOptionsProvider
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
