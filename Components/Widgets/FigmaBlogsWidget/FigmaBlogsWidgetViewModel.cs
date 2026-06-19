using System.Collections.Generic;

namespace FinalProject.Widgets
{
    public class FigmaBlogsWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string Description { get; set; }
        public List<FigmaBlogCardModel> Cards { get; set; } = new List<FigmaBlogCardModel>();
        public string ViewMoreLink { get; set; }
    }

    public class FigmaBlogCardModel
    {
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public List<string> TagNames { get; set; } = new List<string>();
    }
}
