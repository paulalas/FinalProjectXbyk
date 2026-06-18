using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaContentBlockWidgetViewModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<IconWithTitleAndText> Steps { get; set; } = new List<IconWithTitleAndText>();
    }
}
