using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaFeaturesWidgetViewModel
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
        public List<IconWithTitleAndText> FeatureItems { get; set; } = new List<IconWithTitleAndText>();
    }
}
