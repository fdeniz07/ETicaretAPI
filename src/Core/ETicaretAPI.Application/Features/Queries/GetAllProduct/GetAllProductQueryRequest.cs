using ETicaretAPI.Application.RequestParameters;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        //public Pagination Pagination { get; set; }

        public int Page { get; set; } = 0;

        public int Size { get; set; } = 5;
    }
}
