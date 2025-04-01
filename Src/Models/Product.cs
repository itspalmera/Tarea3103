using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Clase3103.Src.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }

        public int StoreId { get; set; }
        public Store Store {get; set;} = null!; // Relación con la tienda
    }
}