using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaCTABannerWidgetViewModel
    {
        public string Title { get; set; }
        public List<IconWithTitleAndText> FeatureItems { get; set; } = new List<IconWithTitleAndText>();
        public string CtaText { get; set; }
        public string CtaLink { get; set; }
        public string ImageUrl { get; set; }
    }
}
