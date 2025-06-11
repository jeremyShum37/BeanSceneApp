using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BeanSceneApp.Data
{
    public class BeanSceneAppContext : IdentityDbContext<IdentityUser>
    {
        public BeanSceneAppContext (DbContextOptions<BeanSceneAppContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<Sitting> Sittings { get; set; } = default!;
        public DbSet<Table> Table { get; set; } = default!;
        public DbSet<Area> Area { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Identity Fix
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<Table>().HasKey(t => new { t.TableId, t.ReservationId });

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("User_Type")
                .HasValue<User>("User_Base")
                .HasValue<Member>("User_Memb");
        }
    }
}
