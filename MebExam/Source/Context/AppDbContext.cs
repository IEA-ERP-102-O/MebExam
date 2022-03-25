using MebExam.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MebExam.Source.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Database=MebExamDb;User Id=sa;Password=1234")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
