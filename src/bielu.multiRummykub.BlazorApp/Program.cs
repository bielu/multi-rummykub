using bielu.multiRummykub.Blazor.DragAndDrop;
using bielu.multiRummykub.Server.DbContexts;
using bielu.multiRummykub.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddIdentity<IdentityUser, IdentityRole>() .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(
        options => options.UseInMemoryDatabase("rummyCube"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
}
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddBlazorDragDrop();
// Add the Vite Manifest Service.
var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();
var options = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "public/dist"));
var compositeProvider = new CompositeFileProvider(
    app.Environment.WebRootFileProvider,
    options);
app.Environment.WebRootFileProvider = compositeProvider;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = compositeProvider,
    RequestPath = "/dist"
});
app.UseRouting();
builder.WebHost.UseStaticWebAssets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();