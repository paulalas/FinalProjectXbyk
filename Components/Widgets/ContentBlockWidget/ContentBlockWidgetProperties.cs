using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class ContentBlockWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "";

        [RichTextEditorComponent(Label = "Content", Order = 2)]
        public string Content { get; set; } = "";
    }
}
