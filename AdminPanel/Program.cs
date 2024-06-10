using Application.Interfaces;
using Application;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;
using Infrastructure.Repo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7184/");
});

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});

builder.Services.AddGrpc();
builder.Services.AddScoped<ProductSearchClientService>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IShelfService, ShelfService>();
builder.Services.AddScoped<IShelfRepository, ShelfRepository>();

builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    //endpoints.MapGrpcService<ProductLocatorService>();
});

// Utworzenie ról i u¿ytkowników
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roleNames = { "Administrator", "U¿ytkownik" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminUser = new IdentityUser
    {
        UserName = "admin",
        Email = "admin@example.com",
        EmailConfirmed = true
    };
    var normalUser = new IdentityUser()
    {
        UserName = "user",
        Email = "user@example.com",
        EmailConfirmed = true
    };
    string adminPassword = "Admin123!";
    string userPassword = "User123!";

    var user = await userManager.FindByEmailAsync(adminUser.Email);
    var user2 = await userManager.FindByEmailAsync(normalUser.Email);

    if (user == null)
    {
        var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);
        if (createAdmin.Succeeded)
            await userManager.AddToRoleAsync(adminUser, "Administrator");
    }
    if (user2 == null)
    {
        var createUser = await userManager.CreateAsync(normalUser, userPassword);
        if (createUser.Succeeded)
            await userManager.AddToRoleAsync(normalUser, "U¿ytkownik");
    }
}

app.Run();
