using System.Collections.Generic;
using CMS.ContentEngine;
using FigmaProject;
using FinalProject;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaAboutUsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "Professional for your home services";

        [TextAreaComponent(Label = "Content Text", Order = 2)]
        public string ContentText { get; set; } = "You need help for home care? We are home care professionals focused in the US region. We provide several services that support home services.";

        [ContentItemSelectorComponent(AboutUsTextData.CONTENT_TYPE_NAME, Label = "Service List Items", MaximumItems = 8, Order = 3)]
        public IEnumerable<ContentItemReference> ServiceItems { get; set; }

        [TextAreaComponent(Label = "Note Text", Order = 4)]
        public string NoteText { get; set; } = "We already 24 hours fast services to help you. You can contact us at";

        [TextInputComponent(Label = "Note Link Text", Order = 5)]
        public string NoteLinkText { get; set; } = "(888) 617-5894";

        [TextInputComponent(Label = "Note Link Href", Order = 6)]
        public string NoteLinkHref { get; set; } = "tel:+18886175894";

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "House Image", MaximumItems = 1, Order = 7)]
        public IEnumerable<ContentItemReference> HouseImage { get; set; }
    }
}
