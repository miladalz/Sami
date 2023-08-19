using Domain.Common;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IList<T>> FindAll(PaginationRequest pr, Expression<Func<T, bool>>? filter = null);
        Task<T?> FindById(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Remove(T entity);
    }
}
