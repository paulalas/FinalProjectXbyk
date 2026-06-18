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
    FigmaServicesListWidgetViewComponent.IDENTIFIER,
    typeof(FigmaServicesListWidgetViewComponent),
    "Figma Services List",
    typeof(FigmaServicesListWidgetProperties),
    Description = "Services grid with icon cards and a CTA card, driven by IconWithTitleAndText content items",
    IconClass = "icon-grid")]

namespace FinalProject.Widgets
{
    public class FigmaServicesListWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaServicesListWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaServicesListWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaServicesListWidgetProperties properties)
        {
            var serviceCards = new List<IconWithTitleAndText>();
            if (properties.ServiceCards?.Any() == true)
            {
                var guids = properties.ServiceCards.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<IconWithTitleAndText>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                serviceCards = results.ToList();
            }

            var viewModel = new FigmaServicesListWidgetViewModel
            {
                SectionTitle    = properties.SectionTitle,
                SectionSubtitle = properties.SectionSubtitle,
                ServiceCards    = serviceCards,
                CtaTitle        = properties.CtaTitle,
                CtaText         = properties.CtaText,
                CtaButtonText   = properties.CtaButtonText,
                CtaButtonLink   = properties.CtaButtonLink
            };

            return View("~/Components/Widgets/FigmaServicesListWidget/FigmaServicesListWidget.cshtml", viewModel);
        }
    }
}
