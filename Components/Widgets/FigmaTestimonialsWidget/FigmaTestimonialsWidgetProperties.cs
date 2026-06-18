using System.Collections.Generic;
using CMS.ContentEngine;
using FigmaProject;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaTestimonialsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Here our original reviews from trusted platform";

        [ContentItemSelectorComponent(Testimonial.CONTENT_TYPE_NAME, Label = "Testimonials", MaximumItems = 10, Order = 2)]
        public IEnumerable<ContentItemReference> Testimonials { get; set; }
    }
}
