using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeAdam.Data
{
    public class NorthwindDbContextFactory
    {
        public NorthwindContext GetContext()
        {
            var options = new DbContextOptionsBuilder()
                              .UseSqlServer("Server=.;Database=Northwind;User Id=sa;Password=1q2w3e4R!")
                              .Options;
            return new NorthwindContext(options);
        }
    }
}
