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

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Product 1",
                            Price = 100,
                            StoreId = 1
                        },
                        new Product
                        {
                            Name = "Product 2",
                            Price = 200,
                            StoreId = 2
                        },
                        new Product
                        {
                            Name = "Product 3",
                            Price = 300,
                            StoreId = 3
                        }
                    );

                    context.SaveChanges();
                }
                
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(
                        new Store
                        {
                            Id = 1,
                            Name = "Store 1",
                            City = "City 1",
                        },
                        new Store
                        {
                            Id = 2,
                            Name = "Store 2",
                            City = "City 2",
                        },
                        new Store
                        {
                            Id = 3,
                            Name = "Store 3",
                            City = "City 3",
                        }
                    );

                    context.SaveChanges();
                }
            }
         }
    }
}