using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Clase3103.Src.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "El campo de precio es necesario")]
        public string Name { get; set; } = string.Empty;
        
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Price must be a positive number above 0.")]
        public int Price { get; set; }
    }
    
}