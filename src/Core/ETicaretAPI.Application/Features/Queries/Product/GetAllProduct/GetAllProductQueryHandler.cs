using ETicaretAPI.Application.Abstracts.Repositories.Products;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            /* await Task.Delay(1500); *///Client side spinner test
            var totalCount = _productReadRepository.GetAll(false).Count(); //Veritabanimizdaki toplam kayit sayisini al
            var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size)
                .Take(request.Size).Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                }).ToList(); //Sayfalama islemlerinde, sayfa basi 5 eleman görüntüleme seciliyse, 16. elamani gösterebilmek icin, 3x5 den sonraki 5 elemani getir

            return new()
            {
                Products = products,
                TotalCount = totalCount,
            };
        }
    }
}
