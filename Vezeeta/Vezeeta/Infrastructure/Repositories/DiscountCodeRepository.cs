using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Infrastructure.Context;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly ApplicationDbContext _context;

        public DiscountCodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscountCode>> GetAllDiscountCodesAsync(int page, int pageSize, string search)
        {
            var discountCodesQuery = _context.DiscountCodes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                discountCodesQuery = discountCodesQuery.Where(dc => dc.DiscountCodeName.Contains(search));
            }

            return await discountCodesQuery.Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
        }


    }
}
