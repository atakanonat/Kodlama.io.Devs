using Core.Persistence.Repositories;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Services.Repositories
{
    public interface ITechnologyRepository : IAsyncRepository<Technology>, IRepository<Technology>
    {
        Task<Technology?> GetAsyncWithInclude(Expression<Func<Technology, bool>> predicate, Expression<Func<Technology, object>>? include = null);
    }
}