using System.Collections.Generic;
using FigmaProject;

namespace FinalProject.Widgets
{
    public class FigmaTestimonialsWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public List<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
    }
}
