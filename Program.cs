using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using MudBlazor;
using ZNSTLibrary.Authentication;
using ZNSTLibrary.Data;
using ZNSTLibrary.Data.Services.Users;
using ZNSTLibrary.Services.EmailService;
using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Services.Books;
using ZNSTLibrary.Services.Categories;
using ZNSTLibrary.Services.Publishers;
using ZNSTLibrary.Services.Authors;
using ZNSTLibrary.Services.Rentals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
/* builder.Services.AddDbContext<ZNSTLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZNSTLibraryContext") ?? throw new InvalidOperationException("Connection string 'ZNSTLibraryContext' not found.")));*/

builder.Services.AddDbContext<ZNSTLibraryContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string not found.");
    }

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthenticationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<MudThemeProvider>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ZNSTLibraryContext>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<ISnackbar, SnackbarService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookRental, BookRental>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IEmailService, EmailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
