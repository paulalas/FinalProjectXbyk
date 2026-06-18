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
    ServicesListWidgetViewComponent.IDENTIFIER,
    typeof(ServicesListWidgetViewComponent),
    "Services List",
    typeof(ServicesListWidgetProperties),
    Description = "Filterable, paginated list of all services",
    IconClass = "icon-clipboard-list")]

namespace FinalProject.Widgets
{
    public class ServicesListWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.ServicesListWidget";

        private readonly IContentRetriever _contentRetriever;

        public ServicesListWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(ServicesListWidgetProperties properties)
        {
            var orderBy = properties.SortOrder switch
            {
                "oldest" => OrderByColumn.Asc(nameof(ServicesDetail.ServicesDateCreated)),
                "az"     => OrderByColumn.Asc(nameof(ServicesDetail.ServicesTitle)),
                "za"     => OrderByColumn.Desc(nameof(ServicesDetail.ServicesTitle)),
                _        => OrderByColumn.Desc(nameof(ServicesDetail.ServicesDateCreated))
            };

            var allServices = await _contentRetriever.RetrievePages<ServicesDetail>(
                new RetrievePagesParameters { LinkedItemsMaxLevel = 1 },
                q => q.OrderBy(orderBy),
                RetrievalCacheSettings.CacheDisabled
            );

            var serviceList = allServices.ToList();

            var categories = serviceList
                .Select(s => s.ServicesCategory)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            var viewModel = new ServicesListWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionTitleHighlight = properties.SectionTitleHighlight,
                SectionSubtitle = properties.SectionSubtitle,
                Services = serviceList,
                Categories = categories,
                PageSize = properties.PageSize > 0 ? properties.PageSize : 5
            };

            return View("~/Components/Widgets/ServicesListWidget/ServicesListWidget.cshtml", viewModel);
        }
    }
}
