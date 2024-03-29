﻿using F = ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstracts.Repositories
{
    public interface IFileWriteRepository : IGenericWriteRepository<F::File>
    {
    }
}
