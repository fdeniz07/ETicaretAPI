using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandRequest:IRequest<UploadProductImageCommandResponse>
    {
        public string Id { get; set; }

        public IFormFileCollection? Files { get; set; }
    }
}
