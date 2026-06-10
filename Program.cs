using FinalProject;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Enable desired Kentico Xperience features
builder.Services.AddKentico(features =>
{
        features.UsePageBuilder(new PageBuilderOptions
    {
        ContentTypeNames = new[]
        {
            Home.CONTENT_TYPE_NAME,
            AboutUs.CONTENT_TYPE_NAME,
            ContactUs.CONTENT_TYPE_NAME,
            ArticlesList.CONTENT_TYPE_NAME,
            ArticlesDetail.CONTENT_TYPE_NAME,
            ServicesList.CONTENT_TYPE_NAME,
            ServicesDetail.CONTENT_TYPE_NAME,
        }
    });
    features.UseWebPageRouting();
    // features.UseActivityTracking();
    // features.UseEmailStatisticsLogging();
    // features.UseEmailMarketing();
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.InitKentico();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseAuthentication();


app.UseKentico();

app.UseAuthorization();

app.Kentico().MapRoutes();

app.Run();
