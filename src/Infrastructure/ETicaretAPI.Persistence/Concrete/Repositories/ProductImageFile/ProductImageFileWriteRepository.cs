﻿using ETicaretAPI.Application.Abstracts.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories
{
    public class ProductImageFileWriteRepository : GenericWriteRepository<ETicaretAPI.Domain.Entities.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
