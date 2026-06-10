using System.Collections.Generic;
using FinalProject;

namespace FinalProject.Widgets
{
    /// <summary>
    /// View model for carousel banner widget.
    /// </summary>
    public class CarouselBannerWidgetViewModel
    {
        public List<CarouselBanner> CarouselItems { get; set; } = new List<CarouselBanner>();
    }
}
