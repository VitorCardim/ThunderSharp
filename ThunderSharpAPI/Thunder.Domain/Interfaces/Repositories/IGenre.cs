using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<Profile> GetByIdAsync(int id);
    }
}
