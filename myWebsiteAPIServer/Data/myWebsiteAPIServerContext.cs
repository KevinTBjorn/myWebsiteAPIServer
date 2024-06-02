using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myWebsiteAPIServer.Models;

namespace myWebsiteAPIServer.Data
{
    public class myWebsiteAPIServerContext : DbContext
    {
        public myWebsiteAPIServerContext (DbContextOptions<myWebsiteAPIServerContext> options)
            : base(options)
        {
        }

        public DbSet<myWebsiteAPIServer.Models.BaseData> BaseData { get; set; } = default!;
    }
}
