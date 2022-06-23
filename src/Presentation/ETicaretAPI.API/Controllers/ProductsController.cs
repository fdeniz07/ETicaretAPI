using System.Net;
using ETicaretAPI.Application.Abstract.Repositories.Products;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
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


        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        #region Tracking Test

        //[HttpGet]
        //public async Task Get()
        //{

        #region Örnek ilk verinin manuel eklenmesi

        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
        //    //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 130 }
        //    //});
        //    //var count = await _productWriteRepository.SaveAsync();

        #endregion

        #region Get metodlarindaki  Tracking tanimlamasi

        //Product p = await _productReadRepository.GetByIdAsync("d6c50cc6-ef50-4e4b-a754-006aea53d82d", false);
        //p.Name = "Test2";
        //await _productWriteRepository.SaveAsync();

        #endregion

        //    //await _productWriteRepository.AddAsync(new()
        //    //{ Name = "C Product", Price = 1.500F, Stock = 10, CreatedDate = DateTime.UtcNow });
        //    //await _productWriteRepository.SaveAsync();

        //}

        #endregion

        #region Find Methode Test

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Find(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

        #endregion

        #region Interceptor Test

        //[HttpGet]
        //public async Task Get()
        //{
        //    #region Adding Customer and Orders

        //    //var customeerId = Guid.NewGuid();
        //    //await _customerWriteRepository.AddAsync(new() { Id = customeerId, Name = "Max" });

        //    //_orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Cankaya", CustomerId = customeerId });
        //    //_orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Pursaklar", CustomerId = customeerId });
        //    //await _orderWriteRepository.SaveAsync();

        //    #endregion

        //    #region UpdateDate Interceptor

        //     Order order=await _orderReadRepository.GetByIdAsync("65d211dc-5efb-48f4-8325-da15b360d126");
        //    order.Address = "Istanbul";
        //    _orderWriteRepository.SaveAsync();

        //    #endregion

        //}


        #endregion

        #region CORS Policy Test

        //CORS Poltikasi icin test amacli olusturuldu
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok("Merhaba");
        //}

        #endregion

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
           /* await Task.Delay(1500); *///Client side spinner test
            var totalCount = _productReadRepository.GetAll(false).Count(); //Veritabanimizdaki toplam kayit sayisini al
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size).Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                }).ToList(); //Sayfalama islemlerinde, sayfa basi 5 eleman görüntüleme seciliyse, 16. elamani gösterebilmek icin, 3x5 den sonraki 5 elemani getir

            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //await Task.Delay(5000);
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {

            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
