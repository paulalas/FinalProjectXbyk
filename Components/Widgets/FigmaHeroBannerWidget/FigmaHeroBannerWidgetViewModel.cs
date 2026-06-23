using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaHeroBannerWidgetViewModel
    {
        public List<IconWithTitleAndText> TaglineItems { get; set; } = new List<IconWithTitleAndText>();
        public string Title { get; set; }
        public List<IconWithTitleAndText> FeatureItems { get; set; } = new List<IconWithTitleAndText>();
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public string LeftPhotoUrl { get; set; }
        public string RightPhotoUrl { get; set; }
        public List<IconWithTitleAndText> HighlightItems { get; set; } = new List<IconWithTitleAndText>();
    }
}
