using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Models;

namespace BeanSceneApp.Data
{
    public class BeanSceneAppContext : DbContext
    {
        public BeanSceneAppContext (DbContextOptions<BeanSceneAppContext> options)
            : base(options)
        {
        }

        public DbSet<BeanSceneApp.Models.User> User { get; set; } = default!;
    }
}
