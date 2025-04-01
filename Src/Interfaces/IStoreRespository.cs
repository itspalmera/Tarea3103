using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;

namespace Clase3103.Src.Interfaces
{
    public interface IStoreRespository
    {
        // Obtener listado de Tiendas
        Task<IEnumerable<Store>> GetStores(string? name);

        // Crear una tienda
        Task<Store> CreateStore(Store store);

        // Obtener una tienda por name
        Task<Store?> GetStoreByName(string name);

        // Obtener tieindas con sus productos
        Task<IEnumerable<Store>> GetStoresWithProducts();

        
    }
}