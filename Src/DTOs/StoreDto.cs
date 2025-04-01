using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Clase3103.Src.DTOs
{
    public class StoreDto
    {
        [Required (ErrorMessage = "El campo ciudad es requerido")]
        public string Name { get; set; } = string.Empty;

        [Required (ErrorMessage = "El campo ciudad es requerido")]
        public string City { get; set; } = string.Empty;
    }

}
 
    
    