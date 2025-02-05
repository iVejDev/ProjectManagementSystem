using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Interfaces.Factories;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.Infrastructure.Data;
using ProjectManagementSystem.Infrastructure.Factories;
using ProjectManagementSystem.Infrastructure.Repositories;
using ProjectManagementSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Factories
builder.Services.AddScoped<IProjectFactory, ProjectFactory>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectManagerRepository, ProjectManagerRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

// Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectManagerService, ProjectManagerService>();
builder.Services.AddScoped<IServiceEntityService, ServiceEntityService>();

var app = builder.Build();

// Initialize Database and Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();