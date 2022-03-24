﻿using TheBillboard.API.Domain;

namespace TheBillboard.API.Abstract
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author?>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
    }
}