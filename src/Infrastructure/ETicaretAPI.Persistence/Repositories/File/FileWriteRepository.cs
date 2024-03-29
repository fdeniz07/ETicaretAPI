﻿using ETicaretAPI.Application.Abstracts.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class FileWriteRepository : GenericWriteRepository<ETicaretAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
