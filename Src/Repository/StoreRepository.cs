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
    public class StoreRepository : IStoreRespository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext context)
        {
            _context = context;
        }

        // GET
        // Obtener listado de Tiendas en la base de datos
        public async Task<IEnumerable<Store>> GetStores(string? name)
        {
            var query = _context.Stores.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        // CREATE
        // Crear una tienda en la base de datos
        public async Task<Store> CreateStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }


        // Obtener una tienda por name
        public async Task<Store?> GetStoreByName(string name)
        {
            return await _context.Stores.FirstOrDefaultAsync(s => s.Name == name);
        }


        // Obtener tiendas con sus productos
        public async Task<IEnumerable<Store>> GetStoresWithProducts()
        {
            return await _context.Stores
                .Include(s => s.Products)
                .ToListAsync();
        }

        


    }
}