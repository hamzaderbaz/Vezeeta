using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Infrastructure.Context;

namespace Vezeeta.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(int page, int pageSize, string search)
        {
            var patientsQuery = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                patientsQuery = patientsQuery.Where(p => p.FullName.Contains(search));
            }

            return await patientsQuery.Skip((page - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();
        }


    }
}
