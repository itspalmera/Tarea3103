using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;
using System.ComponentModel.DataAnnotations;

namespace Clase3103.Src.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;


        public List <Product> Products { get; set; } = new List<Product>();
    }
}