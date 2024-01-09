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
    public class VehiculoController : ControllerBase
    {
        private IValidator<VehiculoInsertDto> _vehiculoInsertValdiator;
        private IValidator<VehiculoUpdateDto> _vehiculoUpdateValidator;
        private ICommonService<VehiculoDto, VehiculoInsertDto, VehiculoUpdateDto> _vehiculoService;

        public VehiculoController(IValidator<VehiculoInsertDto> vehiculoInsertValdiator,
            IValidator<VehiculoUpdateDto> vehiculoUpdateValidator,
            ICommonService<VehiculoDto, VehiculoInsertDto, VehiculoUpdateDto> vehiculoService)
        {
            _vehiculoInsertValdiator = vehiculoInsertValdiator;
            _vehiculoUpdateValidator = vehiculoUpdateValidator;
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<IEnumerable<VehiculoDto>> Get()
            => await _vehiculoService.Get();

        [HttpGet("{id}")]
        public async Task<VehiculoDto> GetById(int id)
            => await _vehiculoService.GetById(id);

        [HttpPost]
        async Task<ActionResult<VehiculoDto>> Add(VehiculoInsertDto vehiculoInsertDto)
        {
            var validationResult = await _vehiculoInsertValdiator.ValidateAsync(vehiculoInsertDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var vehiculoDto = await _vehiculoService.Add(vehiculoInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = vehiculoDto.Id }, vehiculoDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehiculoDto>> Update(int id,  VehiculoUpdateDto vehiculoUpdateDto)
        {
            var validationResult = await _vehiculoUpdateValidator.ValidateAsync(vehiculoUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var vehiculoDto = await _vehiculoService.Update(id, vehiculoUpdateDto);

            return vehiculoDto == null ? NotFound() : Ok(vehiculoDto);
        }

        [HttpDelete]
        public async Task<ActionResult<VehiculoDto>> Delete(int id)
        {
            var vehiculoDto = await _vehiculoService.Delete(id);
            return vehiculoDto == null ? NotFound() : Ok(vehiculoDto);
        }
    }
}
