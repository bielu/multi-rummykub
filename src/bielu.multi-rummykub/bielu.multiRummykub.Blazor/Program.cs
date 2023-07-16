using bielu.multiRummykub.Server.DbContexts;
using bielu.multiRummykub.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();