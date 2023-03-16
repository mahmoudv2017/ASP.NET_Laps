using Microsoft.EntityFrameworkCore;
using TicketLayer.BL.Managers.Tickets;
using TicketsLayer.DAL.Context;
using TicketsLayer.DAL.Repos.TicketRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectionString = builder.Configuration.GetConnectionString("ticketsUrl");

builder.Services.AddDbContext<TicketContext>(options => options.UseSqlServer(ConnectionString));


builder.Services.AddScoped<ITicketRepo, TickerRepo>();
builder.Services.AddScoped<ITickersManager, TicketsManager>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
