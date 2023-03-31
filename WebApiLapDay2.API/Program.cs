using Microsoft.EntityFrameworkCore;
using WebApiLapDay2.BL.Managers.Ticket;
using WebApiLapDay2.DAL;
using WebApiLapDay2.DAL.Context;
using WebApiLapDay2.DAL.Repos.Deparmtent;
using WebApiLapDay2.DAL.Repos.Develoepr;
using WebApiLapDay2.DAL.Repos.Ticket;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IticketRepo, TicketsRepo>();
builder.Services.AddScoped<IDepartmentRepo, DeparmtnetRepo>();
builder.Services.AddScoped<IDeveloperRepo , DeveloperRepo>();

builder.Services.AddScoped<ITicketManager, TicketManager>();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("ticketURL");
    options.UseSqlServer(ConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
