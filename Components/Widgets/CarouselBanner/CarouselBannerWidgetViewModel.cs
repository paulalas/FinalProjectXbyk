using System.Collections.Generic;
using FinalProject;

namespace FinalProject.Widgets
{
    public class CarouselBannerWidgetViewModel
    {
        public List<CarouselBannerItemViewModel> CarouselItems { get; set; } = new List<CarouselBannerItemViewModel>();
    }

    public class CarouselBannerItemViewModel
    {
        public CarouselBanner Item { get; set; }
        public string ButtonUrl { get; set; }
    }
}
