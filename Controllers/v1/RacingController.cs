using DatasCorridas.InputModel;
using DatasCorridas.Services;
using DatasCorridas.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RacingController : ControllerBase
    {
        private readonly IRacingService _racingService;
        
        public RacingController(IRacingService racingService)
        {
            _racingService = racingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RacingViewModel>>> Catch([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1,50)] int quatidade=5)
        {
            var result = await _racingService.Catch(pagina, quatidade);

            if(result.Count()==0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{idRace:guid}")]
        public async Task<ActionResult<RacingViewModel>> Catch([FromRoute] Guid idRace)        
        {
            var result = await _racingService.Catch(idRace);

            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RacingViewModel>> InsertRace([FromBody] RacingInputModel raceInputModel)
        {
            try
            {
                var result = await _racingService.Insert(raceInputModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("Já exite uma corrida cadastradas com essa informações");
            }            
        }

        [HttpPut("{idRace:guid}")]
        public async Task<ActionResult> UpdateRace([FromRoute] Guid idRace, [FromBody] RacingInputModel racingInputModel)
        {
            try
            {
                await _racingService.Update(idRace, racingInputModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Corrida não encontrada");
            }
        }

        [HttpPatch("{idRace:guid}/data/{data:double}")]
        public async Task<ActionResult> UpdateRace([FromRoute] Guid idRace, [FromRoute] int data)
        {
            try
            {
                await _racingService.Update(idRace, data);

                return Ok();
            }
            catch (Exception exe)
            {
                return NotFound("Não exite essa corrida");
            }
        }

        [HttpDelete("{idRace:guid}")]
        public async Task<ActionResult> DeleteRace([FromRoute] Guid idRace)
        {
            try
            {
                await _racingService.Delete(idRace);

                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não essa corrida");
            }     
        }
    }
}
