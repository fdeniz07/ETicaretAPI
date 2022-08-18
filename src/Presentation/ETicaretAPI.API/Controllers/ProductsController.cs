using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{

    //This Controller is currently being used for testing purposes

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            #region Test Code Before CQRS Pattern
            ///* await Task.Delay(1500); *///Client side spinner test
            //var totalCount = _productReadRepository.GetAll(false).Count(); //Veritabanimizdaki toplam kayit sayisini al
            //var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size)
            //    .Take(pagination.Size).Select(p => new
            //    {
            //        p.Id,
            //        p.Name,
            //        p.Stock,
            //        p.Price,
            //        p.CreatedDate,
            //        p.UpdatedDate
            //    }).ToList(); //Sayfalama islemlerinde, sayfa basi 5 eleman görüntüleme seciliyse, 16. elamani gösterebilmek icin, 3x5 den sonraki 5 elemani getir

            //return Ok(new
            //{
            //    totalCount,
            //    products
            //});
            #endregion

            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }

        #region Test Code Before CQRS Pattern
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload(string id)
        //{

        #region TestProcess
        //wwwroot/resource/product-images
        //string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

        //if (!Directory.Exists(uploadPath))
        //    Directory.CreateDirectory(uploadPath);

        //Random r = new();
        //foreach (IFormFile file in Request.Form.Files)
        //{
        //    string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

        //    using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
        //    await file.CopyToAsync(fileStream);
        //    await fileStream.FlushAsync();
        //}
        #endregion

        #region Table Per Hierarchy

        #region ImageFile Upload
        //var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
        //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
        //{
        //    FileName = d.fileName,
        //    Path = d.path
        //}).ToList());
        //await _productImageFileWriteRepository.SaveAsync();
        #endregion

        #region InvoiceFile Upload
        //var datas = await _fileService.UploadAsync("resource/invoices", Request.Form.Files);
        //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
        //{
        //    FileName = d.fileName,
        //    Path = d.path,
        //    Price = new Random().Next()
        //}).ToList()); ;
        //await _invoiceFileWriteRepository.SaveAsync();
        #endregion

        #region File Upload
        //var datas = await FileService.UploadAsync("resource/files", Request.Form.Files);
        //await _fileWriteRepository.AddRangeAsync(datas.Select(d => new ETicaretAPI.Domain.Entities.File()
        //{
        //    FileName = d.fileName,
        //    Path = d.path
        //}).ToList()); ;
        //await _fileWriteRepository.SaveAsync();
        #endregion

        #region Queries
        //var d1 = _fileReadRepository.GetAll();
        //var d2 = _productImageFileReadRepository.GetAll();
        //var d3 = _invoiceFileReadRepository.GetAll();
        #endregion

        #endregion

        #region Upload Local and Cloud

        //Asagidaki kod local storage icin uygun iken cloud icin path gecersizdir.
        //var datas = await _storageService.UploadAsync("resource/files", Request.Form.Files);

        //Cloud icin gecerli path yazimi asagidaki gibidir
        //var datas = await _storageService.UploadAsync("files", Request.Form.Files);

        //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
        //{
        //    FileName = d.fileName,
        //    Path = d.pathOrContainerName,
        //    Storage=_storageService.StorageName
        //}).ToList());
        //await _productImageFileWriteRepository.SaveAsync();

        #endregion

        //List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);

        //Product product = await _productReadRepository.GetByIdAsync(id);

        //foreach (var r in result)
        //{
        //    product.ProductImageFiles.Add(new()
        //    {
        //        FileName = r.fileName,
        //        Path = r.pathOrContainerName,
        //        Storage = _storageService.StorageName,
        //        Size = 0,
        //        Products = new List<Product>() { product}

        //    });
        //}

        //    await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
        //    {
        //        FileName = r.fileName,
        //        Path = r.pathOrContainerName,
        //        Storage = _storageService.StorageName,
        //        Size = 0,
        //        Products = new List<Product>() { product }
        //    }).ToList());

        //    await _productImageFileWriteRepository.SaveAsync();

        //    return Ok();
        //}
        #endregion

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            #region Old Codes before CQRS Pattern
            #region TestProcess
            //wwwroot/resource/product-images
            //string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

            //if (!Directory.Exists(uploadPath))
            //    Directory.CreateDirectory(uploadPath);

            //Random r = new();
            //foreach (IFormFile file in Request.Form.Files)
            //{
            //    string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

            //    using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            //    await file.CopyToAsync(fileStream);
            //    await fileStream.FlushAsync();
            //}
            #endregion

            #region Table Per Hierarchy

            #region ImageFile Upload
            //var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path
            //}).ToList());
            //await _productImageFileWriteRepository.SaveAsync();
            #endregion

            #region InvoiceFile Upload
            //var datas = await _fileService.UploadAsync("resource/invoices", Request.Form.Files);
            //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    Price = new Random().Next()
            //}).ToList()); ;
            //await _invoiceFileWriteRepository.SaveAsync();
            #endregion

            #region File Upload
            //var datas = await FileService.UploadAsync("resource/files", Request.Form.Files);
            //await _fileWriteRepository.AddRangeAsync(datas.Select(d => new ETicaretAPI.Domain.Entities.File()
            //{
            //    FileName = d.fileName,
            //    Path = d.path
            //}).ToList()); ;
            //await _fileWriteRepository.SaveAsync();
            #endregion

            #region Queries
            //var d1 = _fileReadRepository.GetAll();
            //var d2 = _productImageFileReadRepository.GetAll();
            //var d3 = _invoiceFileReadRepository.GetAll();
            #endregion

            #endregion

            #region Upload Local and Cloud

            //Asagidaki kod local storage icin uygun iken cloud icin path gecersizdir.
            //var datas = await _storageService.UploadAsync("resource/files", Request.Form.Files);

            //Cloud icin gecerli path yazimi asagidaki gibidir
            //var datas = await _storageService.UploadAsync("files", Request.Form.Files);

            //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.pathOrContainerName,
            //    Storage=_storageService.StorageName
            //}).ToList());
            //await _productImageFileWriteRepository.SaveAsync();

            #endregion

            //List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);

            //Product product = await _productReadRepository.GetByIdAsync(id);

            //foreach (var r in result)
            //{
            //    product.ProductImageFiles.Add(new()
            //    {
            //        FileName = r.fileName,
            //        Path = r.pathOrContainerName,
            //        Storage = _storageService.StorageName,
            //        Size = 0,
            //        Products = new List<Product>() { product}

            //    });
            //}

            //await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
            //{
            //    FileName = r.fileName,
            //    Path = r.pathOrContainerName,
            //    Storage = _storageService.StorageName,
            //    Size = 0,
            //    Products = new List<Product>() { product }
            //}).ToList());

            //await _productImageFileWriteRepository.SaveAsync();

            //return Ok();
            #endregion

            uploadProductImageCommandRequest.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageQueryRequest getProductImageQueryRequest)
        {
           List<GetProductImageQueryResponse> response=await _mediator.Send(getProductImageQueryRequest);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest,[FromQuery] string ImageId)
        {
            removeProductImageCommandRequest.ImageId = ImageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
            return Ok();
        }
    }
}
