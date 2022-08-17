using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }
    }
}
