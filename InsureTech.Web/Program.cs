using InsureTech.Application.Interfaces;
using InsureTech.Infrastructure.Data;
using InsureTech.Infrastructure.Repositories;
using InsureTech.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Add this for Swagger

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your services here
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Set the login page path
        options.AccessDeniedPath = "/Account/AccessDenied"; // Optionally set access denied path
    });

// Register Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Your API Title",
        Version = "v1",
        Description = "Description of your API",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://example.com"),
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Enables authentication middleware
app.UseAuthorization(); // Enables authorization middleware

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();
// Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger"; // URL: /swagger/index.html
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Changed to Home/Index to avoid infinite redirect loop

app.Run();
