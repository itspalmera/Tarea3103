using Microsoft.AspNetCore.Mvc;
using Clase3103.Src.Interfaces;
using Clase3103.Src.Models;
using Clase3103.Src.DTOs;

namespace Clase3103.Src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRespository _storeRepository;

        public StoreController(IStoreRespository storeRepository)
        {
            _storeRepository = storeRepository;
        }



        [HttpGet("GetWhiteProducts")]
        public async Task<ActionResult<IEnumerable<Store>>> GetStoresWithProducts()
        {
            var stores = await _storeRepository.GetStoresWithProducts();
            return Ok(stores);
        }


        [HttpPost("add")]
        public async Task<IActionResult> CreateStore([FromBody] StoreDto storeDto)
        {
            if (string.IsNullOrWhiteSpace(storeDto.Name) || string.IsNullOrWhiteSpace(storeDto.City))
            {
                return BadRequest("Debe completar todos los campos");
            }

            var store = new Store
            {
                Name = storeDto.Name,
                City = storeDto.City
            };

            var created = await _storeRepository.CreateStore(store);
            return Ok(created);
        }


    }
}
