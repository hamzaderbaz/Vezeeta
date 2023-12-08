using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Repositories;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;


        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }


        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(int page, int pageSize, string search)
        {
            return await _doctorRepository.GetAllDoctorsAsync(page, pageSize, search);
        }


        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }


        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            return await _doctorRepository.AddDoctorAsync(doctor);
        }


        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            return await _doctorRepository.UpdateDoctorAsync(doctor);
        }


        public async Task<bool> DeleteDoctorAsync(int id)
        {
            return await _doctorRepository.DeleteDoctorAsync(id);
        }


    }
}
