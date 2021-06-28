using DatasCorridas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Repositories
{
    public interface IRacingRepository : IDisposable
    {
        Task<List<Race>> Catch(int pagina, int quatidade);
        Task<Race> Catch(Guid id);
        Task<List<Race>> Catch(string country, string city );
        Task Insert(Race race);
        Task Update(Race race);
        Task Delete(Guid id);



    }
}
