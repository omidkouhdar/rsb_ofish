using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSB_Ofish_System.Models.DataBaseModels;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Utils;

namespace RSB_Ofish_System.Data
{
   
    public class RSB_Ofish_SystemContext : DbContext
    {
        public RSB_Ofish_SystemContext(DbContextOptions<RSB_Ofish_SystemContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ofish> Ofish { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Staff>  Staffs { get; set; }
      
    }
    
}
