using DatasCorridas.InputModel;
using DatasCorridas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Services
{
    public interface IRacingService : IDisposable
    {
        Task<List<RacingViewModel>> Catch(int pagina, int quantidade);
        Task<RacingViewModel> Catch(Guid id);
        Task<RacingViewModel> Insert(RacingInputModel race);
        Task Update(Guid id, RacingInputModel race);
        Task Update(Guid id, int date);
        Task Delete(Guid id);
    }
}
