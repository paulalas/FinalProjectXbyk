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
    ServicesWidgetViewComponent.IDENTIFIER,
    typeof(ServicesWidgetViewComponent),
    "Services",
    typeof(ServicesWidgetProperties),
    Description = "Displays the latest 3 services",
    IconClass = "xp-wrench")]

namespace FinalProject.Widgets
{
    public class ServicesWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.ServicesWidget";

        private readonly IContentRetriever _contentRetriever;

        public ServicesWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(ServicesWidgetProperties properties)
        {
            var services = await _contentRetriever.RetrievePages<ServicesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                query => query
                    .TopN(3)
                    .OrderBy(OrderByColumn.Desc(nameof(ServicesDetail.ServicesDateCreated))),
                RetrievalCacheSettings.CacheDisabled
            );

            var viewModel = new ServicesWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle = properties.SectionSubtitle,
                Services = services.ToList()
            };

            return View("~/Components/Widgets/ServicesWidget/ServicesWidget.cshtml", viewModel);
        }
    }
}
