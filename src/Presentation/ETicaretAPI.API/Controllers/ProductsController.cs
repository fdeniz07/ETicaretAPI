
using ETicaretAPI.Application.Abstract.Repositories.Customers;
using ETicaretAPI.Application.Abstract.Repositories.Orders;
using ETicaretAPI.Application.Abstract.Repositories.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        private readonly IOrderWriteRepository _orderWriteRepository; //Test amacli, daha sonra kaldirilacak
        private readonly ICustomerWriteRepository _customerWriteRepository; //Test amacli, daha sonra kaldirilacak


        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        //[HttpGet]
        //public async Task Get()
        //{
        //    #region Örnek ilk verinin manuel eklenmesi

        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 130 }
        //    //});
        //    //var count = await _productWriteRepository.SaveAsync();

        //    #endregion

        //    #region Get metodlarindaki  Tracking tanimlamasi

        //    //Product p = await _productReadRepository.GetByIdAsync("d6c50cc6-ef50-4e4b-a754-006aea53d82d", false);
        //    //p.Name = "Test2";
        //    //await _productWriteRepository.SaveAsync();

        //    #endregion

        //    //await _productWriteRepository.AddAsync(new()
        //    //{ Name = "C Product", Price = 1.500F, Stock = 10, CreatedDate = DateTime.UtcNow });
        //    //await _productWriteRepository.SaveAsync();

        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task Get()
        {
            var customeerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customeerId, Name = "Max" });

            _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Cankaya", CustomerId = customeerId });
            _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Pursaklar", CustomerId = customeerId });
            await _orderWriteRepository.SaveAsync();
        }
    }
}
