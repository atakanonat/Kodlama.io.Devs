using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<Technology?> GetAsyncWithInclude(Expression<Func<Technology, bool>> predicate,
            Expression<Func<Technology, object>>? include = null)
        {
            return await Context.Set<Technology>().Include(include).FirstOrDefaultAsync(predicate);
        }
    }
}