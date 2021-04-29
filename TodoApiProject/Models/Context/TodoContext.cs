using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiProject.Models.Entities;

namespace TodoApiProject.Models.Context
{
    public class TodoContext : DbContext

    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost\SQLEXPRESS;Database=TodoAPI;Trusted_Connection=True;");
        }
        public DbSet<Work> Works { get; set; }
    }

}

