using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoxingChampionshipWebApplication.Models
{
    public class BattleContext : DbContext
    {
        public DbSet<Battle> Battles { get; set; }
    }
}