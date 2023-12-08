using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Interfaces.Repositories
{
    public interface IDiscountCodeRepository
    {
        Task<IEnumerable<DiscountCode>> GetAllDiscountCodesAsync(int page, int pageSize, string search);
        Task<DiscountCode> GetDiscountCodeByIdAsync(int id);
        Task<int> AddDiscountCodeAsync(DiscountCode discountCode);
        Task<bool> UpdateDiscountCodeAsync(DiscountCode discountCode);
        Task<bool> DeleteDiscountCodeAsync(int id);

    }
}
