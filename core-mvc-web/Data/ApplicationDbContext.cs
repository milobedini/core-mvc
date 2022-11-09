using System;
using Microsoft.EntityFrameworkCore;
using core_mvc_web.Models;

namespace core_mvc_web.Data
{
    //Extension of DbContext from EFC
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Create Category table using the category model.
        //This is code first development compared to database first.

        public DbSet<Category> Categories { get; set; }
    }
}

