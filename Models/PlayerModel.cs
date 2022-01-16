using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebFootballApp.Models
{
    public partial class PlayerModel : DbContext
    {
        public PlayerModel()
            : base("name=PlayerModel")
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
