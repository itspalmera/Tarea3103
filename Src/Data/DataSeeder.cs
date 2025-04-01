using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Clase3103.Src.Data
{
    public class DataSeeder
    {
         public static void Initialize(IServiceProvider serviceProvider){

            using (var scope = serviceProvider.CreateScope())
            {
                
                var services = scope.ServiceProvider; // Provider de bogus
                var context = services.GetRequiredService<DataContext>(); // Contexto de la base de datos

                // Datos

                if (context.Stores.Any() || context.Products.Any())
                    return;

                // Crear tiendas
                var store1 = new Store 
                { 
                    Name = "Store 1", 
                    City = "City A" 
                };

                var store2 = new Store 
                { 
                    Name = "Store 2", 
                    City = "City B" 
                };

                // Crear productos
                var product1 = new Product 
                { 
                    Name = "Product 1", 
                    Price = 100, 
                    Store = store1,
                    StoreId = store1.Id
                };

                var product2 = new Product 
                { 
                    Name = "Product 2", 
                    Price = 200, 
                    Store = store1,
                    StoreId = store1.Id
                };

                var product3 = new Product 
                { 
                    Name = "Product 3", 
                    Price = 300, 
                    Store = store2,
                    StoreId = store2.Id
                };

                // Agregar datos al contexto
                context.Stores.AddRange(store1, store2);
                context.Products.AddRange(product1, product2, product3);

                // Guardar cambios
                context.SaveChanges();
            }
         }
    }
}