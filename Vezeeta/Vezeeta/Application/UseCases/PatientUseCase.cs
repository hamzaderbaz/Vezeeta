using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.UseCases;

namespace Vezeeta.Application.UseCases
{
    public class PatientUseCase : IPatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientUseCase(IPatientRepository patientRepository)
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
