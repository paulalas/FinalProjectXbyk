using System;
using System.Collections.Generic;
using FinalProject;

namespace FinalProject.Widgets
{
    public class ArticlesListWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionTitleHighlight { get; set; }
        public string SectionSubtitle { get; set; }
        public List<ArticlesDetail> Articles { get; set; } = new List<ArticlesDetail>();
        public List<string> Categories { get; set; } = new List<string>();
        public Dictionary<Guid, string> TagTitles { get; set; } = new Dictionary<Guid, string>();
    }
}
