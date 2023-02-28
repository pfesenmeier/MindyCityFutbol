using Microsoft.EntityFrameworkCore;
using MindyCityFutbol.Data;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSession(options => {
//     options.IdleTimeout = TimeSpan.FromSeconds(10);
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
// });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MindyCityFutbolContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MindyCityFutbolContext") ?? throw new InvalidOperationException("Connection String 'MindyCityFutbolContext' not found")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
