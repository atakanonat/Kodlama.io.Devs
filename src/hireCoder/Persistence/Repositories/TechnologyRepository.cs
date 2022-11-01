using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<Technology> GetAsyncWithInclude(Expression<Func<Technology, bool>> predicate,
            Func<IQueryable<Technology>, IIncludableQueryable<Technology, object>>? include = null)
        {
            IQueryable<Technology> queryable = Query();
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }
    }
}