using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeAdam.Contracts
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public string Category { get; set; }
        public string Company { get; set; }
    }
}
