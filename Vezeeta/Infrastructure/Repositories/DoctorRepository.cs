using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Infrastructure.Context;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(int page, int pageSize, string search)
        {
            
            var doctorsQuery = _context.Doctors.AsQueryable();
            
            
            if (!string.IsNullOrEmpty(search))
            {
                doctorsQuery = doctorsQuery.Where(d => d.FirstName.Contains(search) || d.LastName.Contains(search));
            }

            return await doctorsQuery.Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
        }


    }
}
