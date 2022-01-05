#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcRope.Models;

namespace MvcRope.Data
{
    public class MvcRopeContext : DbContext
    {
        public MvcRopeContext (DbContextOptions<MvcRopeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcRope.Models.Rope> Rope { get; set; }
    }
}
