using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;
using System.ComponentModel.DataAnnotations;

namespace Clase3103.Src.Interfaces
{
    public interface IProductRepository
    {
        // Obtener listado de Productos
        Task<IEnumerable<Product>> GetProducts(string? name);

        // Crear un producto
        Task<Product> CreateProduct(Product product);

        // Verificar si un producto existe
        Task<bool> ProductExists(int id);

        // Verificar si el nombre de un producto existe
        Task<bool> ProductNameExists(string name);

        // Obtener un producto por su ID
        Task<Product?> GetProductById(int id);
    }
}