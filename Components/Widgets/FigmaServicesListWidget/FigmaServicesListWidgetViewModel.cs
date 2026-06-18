using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaServicesListWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionSubtitle { get; set; }
        public List<IconWithTitleAndText> ServiceCards { get; set; } = new List<IconWithTitleAndText>();
        public string CtaTitle { get; set; }
        public string CtaText { get; set; }
        public string CtaButtonText { get; set; }
        public string CtaButtonLink { get; set; }
    }
}
