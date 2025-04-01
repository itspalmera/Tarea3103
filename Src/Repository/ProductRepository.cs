using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;
using Clase3103.Src.Data;
using Clase3103.Src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clase3103.Src.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        // GET
        // Obtener listado de Productos en la base de datos
        public async Task<IEnumerable<Product>> GetProducts(string? name)
        {
            var query = _context.Products.AsQueryable();

            // Si "name" tiene algo (no es nulo o vacío), entonces filtramos los productos que contengan "name"
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        // CREATE
        // Crear un producto en la base de datos
        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
       

        // Verificar si un producto existe en la base de datos
        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(x => x.Id == id);
        }


        // Verificar si el nombre de un producto existe en la base de datos
        public async Task<bool> ProductNameExists(string name)
        {
            return await _context.Products.AnyAsync(x => x.Name == name);
        }


        // Obtener un producto por su ID
        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }

}