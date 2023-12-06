using System.Collections.Generic;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Interfaces.UseCases
{
    public interface IDashboardUseCase
    {
        Task<int> GetNumberOfDoctorsAsync();
        Task<int> GetNumberOfPatientsAsync();
        Task<(int, int, int, int)> GetRequestStatisticsAsync();
        Task<IEnumerable<(string, int)>> GetTopSpecializationsAsync();
        Task<IEnumerable<(string, int)>> GetTopDoctorsAsync();
    }
}
