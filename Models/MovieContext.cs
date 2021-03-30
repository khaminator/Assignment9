using System;
using Microsoft.EntityFrameworkCore;
namespace Assignment9_2.Models
{
    public class MovieListContext : DbContext
    {
        //Constructor
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options)
       {

       }

        //import table in asp.net of type Movies. Call it Movie and get and set
        public DbSet<Movies> Movie { get; set; }

    }
}
