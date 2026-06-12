using System.Collections.Generic;
using FinalProject;

namespace FinalProject.Widgets
{
    public class LatestArticlesWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionTitleHighlight { get; set; }
        public string SectionSubtitle { get; set; }
        public List<ArticlesDetail> Articles { get; set; } = new List<ArticlesDetail>();
    }
}
