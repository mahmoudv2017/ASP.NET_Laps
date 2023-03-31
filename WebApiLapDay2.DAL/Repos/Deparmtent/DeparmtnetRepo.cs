using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiLapDay2.DAL.Repos.Deparmtent;

using WebApiLapDay2.DAL.Context;
using WebApiLapDay2.DAL.Models;

public class DeparmtnetRepo : GlobalRepo<Departments>, IDepartmentRepo
{
    public DeparmtnetRepo(MyDbContext myDbContext) : base(myDbContext)
    {
    }
}
