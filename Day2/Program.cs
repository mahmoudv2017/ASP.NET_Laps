using Day2.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

Ticket.AllTickets.AddRange(new List<Ticket>
            {
                new Ticket { CreatedDate = DateTime.Now, Description = "Desc1", IsClosed = true, Severity = Severity.high },
                new Ticket { CreatedDate = DateTime.Now, Description = "Desc2", IsClosed = false, Severity = Severity.low },
                new Ticket { CreatedDate = DateTime.Now, Description = "Desc3", IsClosed = true, Severity = Severity.medium },
                new Ticket { CreatedDate = DateTime.Now, Description = "Desc4", IsClosed = false, Severity = Severity.high }


            });
// Add services to the container.
builder.Services.AddControllersWithViews();

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
