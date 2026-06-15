using Kentico.PageBuilder.Web.Mvc;
using FinalProject.Widgets;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    ContentBlockWidgetViewComponent.IDENTIFIER,
    typeof(ContentBlockWidgetViewComponent),
    "Content Block",
    typeof(ContentBlockWidgetProperties),
    Description = "Editable title and rich text content block",
    IconClass = "xp-edit")]

namespace FinalProject.Widgets
{
    public class ContentBlockWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.ContentBlockWidget";

        public Task<ViewViewComponentResult> InvokeAsync(ContentBlockWidgetProperties properties)
        {
            return Task.FromResult(View(
                "~/Components/Widgets/ContentBlockWidget/ContentBlockWidget.cshtml",
                properties
            ));
        }
    }
}
