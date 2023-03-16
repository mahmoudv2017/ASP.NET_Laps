using Microsoft.EntityFrameworkCore;
using Your_Project_Name.Models.Domain;
using TicketsLayer.DAL.Models;
using System.Text.Json;

namespace TicketsLayer.DAL.Context;

public class TicketContext:DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Dev_Tickets> Dev_Tickets => Set<Dev_Tickets>();

    public TicketContext(DbContextOptions<TicketContext> tickersOptions):base(tickersOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {






        base.OnModelCreating(modelBuilder);

        Ticket[] data = new Ticket[]{
            new Ticket {  Description="Desc1",IsClosed=true,Severity=Severity.High , Dept_id=1 },
              new Ticket {  Description="Desc2",IsClosed=false,Severity=Severity.High , Dept_id=1 }
        };
        modelBuilder.Entity<Ticket>().HasKey(x => x.Id);
        modelBuilder.Entity<Ticket>().HasOne(e => e.Department)
            .WithMany(e => e.Tickets)
            .HasForeignKey(e => e.Dept_id)
            .OnDelete(DeleteBehavior.NoAction); //why

        //modelBuilder.Entity<Ticket>().HasData( //seeding with foeign keys
        //    new Ticket { Description = "Desc1", IsClosed = true, Severity = Severity.High, Dept_id = 1 },
        //      new Ticket { Description = "Desc2", IsClosed = false, Severity = Severity.High, Dept_id = 1 }
        //);


    modelBuilder.Entity<Developer>().HasOne(de => de.Department)
            .WithMany(dep => dep.Developers)
            .HasForeignKey(de => de.Dept_ID);

        modelBuilder.Entity<Dev_Tickets>(config =>
        {
            config.HasKey(de => new { de.Ticket_id, de.Dev_id });

            config.HasOne(de => de.Ticket)
            .WithMany(e => e.Developers)
            .HasForeignKey(e => e.Ticket_id);

            config.HasOne(de => de.Developer)
            .WithMany(e => e.Tickets)
            .HasForeignKey(e => e.Dev_id);
        });





    }
}

