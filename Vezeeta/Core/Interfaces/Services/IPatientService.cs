using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync(int page, int pageSize, string search);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<int> AddPatientAsync(Patient patient);
        Task<bool> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int id);

    }
}
