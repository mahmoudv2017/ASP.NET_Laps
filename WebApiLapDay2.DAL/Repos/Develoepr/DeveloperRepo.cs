using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLapDay2.DAL.Context;
using WebApiLapDay2.DAL.Models;

namespace WebApiLapDay2.DAL.Repos.Develoepr
{
    public class DeveloperRepo : GlobalRepo<Developer>, IDeveloperRepo
    {
        public DeveloperRepo(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}
