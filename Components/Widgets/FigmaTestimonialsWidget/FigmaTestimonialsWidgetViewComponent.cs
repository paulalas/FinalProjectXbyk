using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FigmaProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    FigmaTestimonialsWidgetViewComponent.IDENTIFIER,
    typeof(FigmaTestimonialsWidgetViewComponent),
    "Figma Testimonials",
    typeof(FigmaTestimonialsWidgetProperties),
    Description = "Testimonial carousel with prev/next navigation driven by Testimonial content items",
    IconClass = "icon-chat")]

namespace FinalProject.Widgets
{
    public class FigmaTestimonialsWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaTestimonialsWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaTestimonialsWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaTestimonialsWidgetProperties properties)
        {
            var testimonials = new List<Testimonial>();
            if (properties.Testimonials?.Any() == true)
            {
                var guids = properties.Testimonials.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<Testimonial>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                testimonials = results.ToList();
            }

            var viewModel = new FigmaTestimonialsWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                Testimonials = testimonials
            };

            return View("~/Components/Widgets/FigmaTestimonialsWidget/FigmaTestimonialsWidget.cshtml", viewModel);
        }
    }
}
