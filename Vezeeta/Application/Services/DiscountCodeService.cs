using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.Application.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;


        public DiscountCodeService(IDiscountCodeRepository discountCodeRepository)
        {
            _discountCodeRepository = discountCodeRepository ?? throw new ArgumentNullException(nameof(discountCodeRepository));
        }


        public async Task<bool> AddDiscountCodeAsync(DiscountCode discountCode)
        {
            return await _discountCodeRepository.AddDiscountCodeAsync(discountCode);
        }


        public async Task<bool> UpdateDiscountCodeAsync(DiscountCode discountCode)
        {
            return await _discountCodeRepository.UpdateDiscountCodeAsync(discountCode);
        }


        public async Task<bool> DeleteDiscountCodeAsync(int id)
        {
            return await _discountCodeRepository.DeleteDiscountCodeAsync(id);
        }


        public async Task<bool> DeactivateDiscountCodeAsync(int id)
        {
            return await _discountCodeRepository.DeactivateDiscountCodeAsync(id);
        }

    }
}
