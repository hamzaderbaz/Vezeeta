using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.UseCases;

namespace Vezeeta.Application.UseCases
{
    public class DashboardUseCase : IDashboardUseCase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public DashboardUseCase(IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        }

        public async Task<int> GetNumberOfDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();
            return doctors?.Count ?? 0;
        }

        public async Task<int> GetNumberOfPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return patients?.Count ?? 0;
        }

    }
}