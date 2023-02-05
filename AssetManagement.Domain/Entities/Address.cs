using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Address
    {
        public string? PostCode { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public int StreetNumber { get; set; }
    }
}
