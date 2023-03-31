using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiLapDay2.DAL.Models;

namespace WebApiLapDay2.DAL.Context
{
    public class MyDbContext:DbContext
    {
        public DbSet<Ticket> Ticket => Set<Ticket>();
        public DbSet<Developer> Developer => Set<Developer>();
        public DbSet<Departments> Departments => Set<Departments>();
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":20,"Title":"in","Description":"Harum hic impedit dolore voluptate placeat.","Severity":1 },{"Id":1,"Title":"id","Description":"Rerum totam est quo possimus sunt sunt ad.","Severity":0},{"Id":2,"Title":"dicta","Description":"Id cumque explicabo beatae.","Severity":1},{"Id":3,"Title":"eius","Description":"Consectetur beatae dolorem voluptates occaecati.","Severity":0},{"Id":4,"Title":"assumenda","Description":"Nulla est doloribus ut non aspernatur vero dolores.","Severity":2},{"Id":5,"Title":"ex","Description":"Et praesentium est ipsum eligendi rerum itaque voluptate quia.","Severity":1,"DepartmentId":2},{"Id":6,"Title":"velit","Description":"Optio non debitis ut molestiae dolorem ad.","Severity":2}]""") ?? new();
            modelBuilder.Entity<Ticket>().HasData(tickets);

            var departments = JsonSerializer.Deserialize<List<Departments>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Beauty \u0026 Health"},{"Id":3,"Name":"Electronics"}]""") ?? new();
            modelBuilder.Entity<Departments>().HasData(departments);

            var devolopers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Diabetes","DepartmentsID":2},{"Id":2,"Name":"Hypertension","DepartmentsID":2},{"Id":3,"Name":"Asthma","DepartmentsID":2},{"Id":4,"Name":"Depression","DepartmentsID":1},{"Id":5,"Name":"Arthritis","DepartmentsID":1},{"Id":6,"Name":"Allergy","DepartmentsID":3},{"Id":7,"Name":"Flu","DepartmentsID":3}]""") ?? new();
            modelBuilder.Entity<Developer>().HasData(devolopers);
            base.OnModelCreating(modelBuilder);
        }
    }
}
