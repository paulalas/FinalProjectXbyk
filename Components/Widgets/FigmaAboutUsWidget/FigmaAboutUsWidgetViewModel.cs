using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaAboutUsWidgetViewModel
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
        public List<AboutUsTextData> ServiceItems { get; set; } = new List<AboutUsTextData>();
        public string NoteText { get; set; }
        public string NoteLinkText { get; set; }
        public string NoteLinkHref { get; set; }
        public string HouseImageUrl { get; set; }
    }
}
