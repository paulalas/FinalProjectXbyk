using System.Collections.Generic;
using FinalProject;

namespace FinalProject.Widgets
{
    public class ServicesWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionTitleHighlight { get; set; }
        public string SectionSubtitle { get; set; }
        public List<ServicesDetail> Services { get; set; } = new List<ServicesDetail>();
    }
}
