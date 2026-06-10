using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using CMS.ContentEngine;
using FinalProject;
using System.Collections.Generic;

namespace FinalProject.Widgets
{
    /// <summary>
    /// Carousel Banner widget properties.
    /// </summary>
    public class CarouselBannerWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Selected carousel banner items (2-4 items)
        /// </summary>
        [ContentItemSelectorComponent(
            CarouselBanner.CONTENT_TYPE_NAME,
            Label = "Carousel Banner Items",
            Order = 1,
            MinimumItems = 2,
            MaximumItems = 4)]
        public IEnumerable<ContentItemReference> CarouselItems { get; set; } = new List<ContentItemReference>();
    }
}
