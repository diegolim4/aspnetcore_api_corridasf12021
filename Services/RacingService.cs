using DatasCorridas.Entities;
using DatasCorridas.InputModel;
using DatasCorridas.Repositories;
using DatasCorridas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Services
{
    public class RacingService : IRacingService
    {
        private readonly IRacingRepository _racingRepository;

        public RacingService(IRacingRepository racingRepository)
        {
            _racingRepository = racingRepository;
        }

        public async Task<List<RacingViewModel>> Catch(int pagina, int quantidade)
        {
            var race = await _racingRepository.Catch(pagina, quantidade);

            return race.Select(race => new RacingViewModel
            {
                Id = race.Id,
                Country = race.Country,
                City = race.City,
                Date = race.Date,
                Hour = race.Hour

            }).ToList();
        }
        public async Task<RacingViewModel> Catch(Guid id)
        {
            var race = await _racingRepository.Catch(id);

            if (race == null)
                return null;

            return new RacingViewModel
            {
                Id = race.Id,
                Country = race.Country,
                City = race.City,
                Date = race.Date,
                Hour = race.Hour
            };

        }
        public async Task<RacingViewModel> Inserir(RacingInputModel race)
        {
            var entidadeRace = await _racingRepository.Catch(race.Country, race.City);

            if (entidadeRace.Count > 0)
                throw new RaceRegisteredException();

            var jogoInsert = new Race
            {
                Id = Guid.NewGuid(),
                Country = race.Country,
                City = race.City,
                Date = race.Date,
                Hour = race.Hour,
            };

            await _racingRepository.Insert(raceInsert);

            return new RacingViewModel
            {
                Id = raceInsert.Id,
                Country = race.Country,
                City = race.City,
                Date = race.Date,
                Hour = race.Hour
            };
        }
        public async Task Atualizar(Guid id, RacingInputModel race)
        {
            var entidadeRace = await _racingRepository.Catch(id);

            if (entidadeRace == null)
                throw new RaceRegisteredException();

            entidadeRace.Country = race.Country;
            entidadeRace.City = race.City;
            entidadeRace.Date = race.Date;
            entidadeRace.Hour = race.Hour;

            await _racingRepository.Update(entidadeRace);
        }
        public async Task Atualizar(Guid id, int date)
        {
            var entidadeRace = await _racingRepository.Catch(id);

            if (entidadeRace == null)
                throw new RaceRegisteredException();

            entidadeRace.Date = date;

            await _raceRepository.Atualizar(entidadeRace);
        }
        public async Task Remover(Guid id)
        {
            var jogo = await _racingRepository.Catch(id);

            if (jogo == null)
                throw new RaceRegisteredException();

            await _raceRepository.Remover(id);
        }

        public void Dispose()
        {
            _racingRepository?.Dispose();
        }
    }
}
}    
