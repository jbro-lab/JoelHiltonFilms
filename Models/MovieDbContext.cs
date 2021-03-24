﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JoelHiltonFilms.Models
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
