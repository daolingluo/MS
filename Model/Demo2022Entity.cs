using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Demo2022.Model
{
    public partial class Demo2022Entity : DbContext
    {
        public Demo2022Entity()
            : base("name=Demo2022Entity")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<TeamInfo> TeamInfo { get; set; }

    }
}
