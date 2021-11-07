using InterviewSimpleWebApi.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSimpleWebApi.Data
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
        { }
    }
}
