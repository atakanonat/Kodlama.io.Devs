using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Repositories
{
    public interface ITechnologyRepository : IAsyncRepository<Technology>, IRepository<Technology>
    {
        Task<Technology> GetAsyncWithInclude(Expression<Func<Technology, bool>> predicate, Func<IQueryable<Technology>, IIncludableQueryable<Technology, object>>? include = null);
    }
}