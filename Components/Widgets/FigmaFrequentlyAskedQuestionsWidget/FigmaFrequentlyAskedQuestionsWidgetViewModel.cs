using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaFrequentlyAskedQuestionsWidgetViewModel
    {
        public string Title { get; set; }
        public string HelpText { get; set; }
        public string HelpLinkText { get; set; }
        public string HelpLinkUrl { get; set; }
        public List<FrequentQuestions> Items { get; set; } = new List<FrequentQuestions>();
    }
}
