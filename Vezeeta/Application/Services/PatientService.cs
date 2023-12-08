using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(int page, int pageSize, string search)
        {
            return await _patientRepository.GetAllPatientsAsync(page, pageSize, search);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }


    }
}
