using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Clase3103.Src.Models;
using Clase3103.Src.Interfaces;
using Clase3103.Src.DTOs;
using Clase3103.Src.Repository;

namespace Clase3103.Src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Variable de IProductRepository
        private readonly IProductRepository _productRepository;
        // Variable de IStoreRespository
        private readonly IStoreRespository _storeRespository;

        // Inicializar variables de repository en un Constructor ProductController
        public ProductController(IProductRepository productRepository, IStoreRespository StoreRepository)
        {
            _productRepository = productRepository;
            _storeRespository = StoreRepository; 
        }


        //! Endpoints de la API

        // Obtener todos los productos
        // GET api/product/list

        [HttpGet]
        [Route("list")]

        public async Task<IActionResult> GetProducts([FromQuery] string? name) // Se pueden poner atributos condicionales con ?
        {
            
            // Obtener todos los usuarios desde el Repositorio
            var products = await _productRepository.GetProducts(name);

            if (products == null)
            {
                return NotFound("No se encontraron productos.");
            }

            // Mapear products a DTOs enriquecidos con GenderName
            
            var productsDtos = products.Select(product => new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
               });
            

            return Ok(productsDtos);
        }

        // Crear un nuevo producto
        // POST api/product/add

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (productDto.Price <= 0)
            {
                return BadRequest("El precio no puede ser menor o igual a 0");
            }

            if (await _productRepository.ProductNameExists(productDto.Name))
            {
                return BadRequest("El nombre del producto ya existe");
            }

            var store = await _storeRespository.GetStoreByName(productDto.NameStore);
            if (store == null)
            {
                return NotFound("La tienda especificada no existe");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                StoreId = store.Id
            };

            await _productRepository.CreateProduct(product);

            return Ok("Producto creado correctamente");
        }


        // Obtener un producto por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound("Producto no encontrado");
            }

            var productDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            };

            return Ok(productDto);
        }


    }

}