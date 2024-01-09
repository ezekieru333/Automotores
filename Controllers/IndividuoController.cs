using Automotores.DTOs;
using Automotores.Services;
using Automotores.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividuoController : ControllerBase
    {

        private IValidator<IndividuoInsertDto> _individuoInsertValidator;
        private IValidator<IndividuoUpdateDto> _individuoUpdateValidator;
        private ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto> _individuoService;

        public IndividuoController(IValidator<IndividuoInsertDto> individuoInsertValidator,
            IValidator<IndividuoUpdateDto> individuoUpdateValidator,
            [FromKeyedServices("individuoService")] ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto> individuoService)
        {
            _individuoInsertValidator = individuoInsertValidator;
            _individuoUpdateValidator = individuoUpdateValidator;
            _individuoService = individuoService;
        }

        [HttpGet]
        public async Task<IEnumerable<IndividuoDto>> Get()
            => await _individuoService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<IndividuoDto>> GetById(int id)
        {
            var individuoDto = await _individuoService.GetById(id);
            return individuoDto == null ? NotFound() : Ok(individuoDto);
        }

        [HttpPost]
        public async Task<ActionResult<IndividuoDto>> Add(IndividuoInsertDto individuoInsertDto)
        {
            var validationResult = await _individuoInsertValidator.ValidateAsync(individuoInsertDto);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var individuoDto = await _individuoService.Add(individuoInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = individuoDto.Id }, individuoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IndividuoDto>> Update(int id, IndividuoUpdateDto individuoUpdateDto)
        {
            var validationResult = await _individuoUpdateValidator.ValidateAsync(individuoUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var individuoDto = await _individuoService.Update(id, individuoUpdateDto);
            return individuoDto == null ? NotFound() : Ok(individuoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IndividuoDto>> Delete(int id)
        {
            var individuoDto = await _individuoService.Delete(id);

            return individuoDto == null ? NotFound() : Ok(individuoDto);
        }

    }
}
