using AutoMapper;
using Automotores.DTOs;
using Automotores.Models;
using Automotores.Repository;

namespace Automotores.Services
{
    public class VehiculoService : ICommonService<VehiculoDto, VehiculoInsertDto, VehiculoUpdateDto>
    {
        private IRepository<Vehiculo> _vehiculoRepository;
        private IMapper _mapper;

        public VehiculoService(IRepository<Vehiculo> vehiculoRepository,
            IMapper mapper)
        {
            _vehiculoRepository = vehiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehiculoDto>> Get()
        {
            var vehiculos = await _vehiculoRepository.Get();
            return vehiculos.Select(vehiculo => _mapper.Map<VehiculoDto>(vehiculo));
        }

        public async  Task<VehiculoDto> GetById(int id)
        {
            var vehiculo = await _vehiculoRepository.GetById(id);

            if(vehiculo != null)
            {
                var vehiculoDto = _mapper.Map<VehiculoDto>(vehiculo);

                return vehiculoDto;
            }

            return null;
        }

        public async Task<VehiculoDto> Add(VehiculoInsertDto insertDto)
        {
            var vehiculo = _mapper.Map<Vehiculo>(insertDto);

            await _vehiculoRepository.Add(vehiculo);
            await _vehiculoRepository.Save();

            var vehiculoDto = _mapper.Map<VehiculoDto>(vehiculo);
            return vehiculoDto;
        }

        public async Task<VehiculoDto> Update(int id, VehiculoUpdateDto updateDto)
        {
            var vehiculo = await _vehiculoRepository.GetById(id);

            if(vehiculo != null)
            {
                vehiculo = _mapper.Map<VehiculoUpdateDto, Vehiculo>(updateDto, vehiculo);
                _vehiculoRepository.Update(vehiculo);
                await _vehiculoRepository.Save();

                var vehiculoDto = _mapper.Map<VehiculoDto>(vehiculo);
                return vehiculoDto;
            }
            return null;
        }

        public async Task<VehiculoDto> Delete(int id)
        {
            var vehiculo = await _vehiculoRepository.GetById(id);

            if (vehiculo != null)
            {
                var vehiculoDto = _mapper.Map<VehiculoDto>(vehiculo);

                _vehiculoRepository.Delete(vehiculo);
                await _vehiculoRepository.Save();

                return vehiculoDto;
            }
            return null;
        }
    }
}
