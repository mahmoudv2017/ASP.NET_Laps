using Microsoft.EntityFrameworkCore;
using Your_Project_Name.Models.Domain;
using TicketsLayer.DAL.Models;
using System.Text.Json;

namespace TicketsLayer.DAL.Context;

public class TicketContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Department> Departments => Set<Department>();



    public TicketContext(DbContextOptions<TicketContext> tickersOptions) : base(tickersOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {






        base.OnModelCreating(modelBuilder);

        //Ticket[] data = new Ticket[]{
        //    new Ticket {  Description="Desc1",IsClosed=true,Severity=Severity.High , Dept_id=1 },
        //      new Ticket {  Description="Desc2",IsClosed=false,Severity=Severity.High , Dept_id=1 }
        //};
        modelBuilder.Entity<Ticket>().HasKey(x => x.Id);
        modelBuilder.Entity<Ticket>().HasOne(e => e.Department)
            .WithMany(e => e.Tickets)
            .HasForeignKey(e => e.Dept_id)
            .OnDelete(DeleteBehavior.NoAction); //why

        //modelBuilder.Entity<Ticket>().HasData( //seeding with foeign keys
        //    new Ticket { Description = "Desc1", IsClosed = true, Severity = Severity.High, Dept_id = 1 },
        //      new Ticket { Description = "Desc2", IsClosed = false, Severity = Severity.High, Dept_id = 1 }
        //);


        //modelBuilder.Entity<Developer>().HasOne(de => de.dev_department)
        //        .WithMany(dep => dep.Developers)
        //        .HasForeignKey(de => de.Dept_ID);





          List<Department> _departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Beauty \u0026 Health"},{"Id":3,"Name":"Electronics"}]""") ?? new();

        modelBuilder.Entity<Department>().HasData(_departments);

        //List<Developer> _developers = new List<Developer>() { new Developer { Id = 1, FirstName = "Freddie", LastName = "Johnson", Dept_ID = 1 } };
        //var devolopers = new List<Developer>() { new Developer { Id = 1, FirstName = "Freddie", LastName = "Johnson", Dept_ID = 1 }};
        modelBuilder.Entity<Developer>().HasData(new Developer { Id = 1, FirstName = "Freddie", LastName = "Johnson", DepartmentID = 1 });



        var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Dept_id":2, "IsClosed":true, "Id":20,"Title":"in","Description":"Harum hic impedit dolore voluptate placeat.","Severity":1},{"Id":1,"Title":"id","Description":"Rerum totam est quo possimus sunt sunt ad.","Severity":0,"Dept_id":1},{"Id":2,"Title":"dicta","Description":"Id cumque explicabo beatae.","Severity":1,"Dept_id":3},{"Id":3,"Title":"eius","Description":"Consectetur beatae dolorem voluptates occaecati.","Severity":0,"Dept_id":2},{"Id":4,"Title":"assumenda","Description":"Nulla est doloribus ut non aspernatur vero dolores.","Severity":2,"Dept_id":1},{"Id":5,"Title":"ex","Description":"Et praesentium est ipsum eligendi rerum itaque voluptate quia.","Severity":1,"Dept_id":2},{"Id":6,"Title":"velit","Description":"Optio non debitis ut molestiae dolorem ad.","Severity":2,"Dept_id":3}]""") ?? new();
        modelBuilder.Entity<Ticket>().HasData(tickets);



    }
}

