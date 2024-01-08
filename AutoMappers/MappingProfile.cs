using AutoMapper;
using Automotores.DTOs;
using Automotores.Models;

namespace Automotores.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehiculoInsertDto, Vehiculo>();
            CreateMap<VehiculoUpdateDto, Vehiculo>();
            CreateMap<Vehiculo, VehiculoDto>();

            CreateMap<IndividuoInsertDto, Individuo>();
            CreateMap<IndividuoUpdateDto, Individuo>();
            CreateMap<Individuo, IndividuoDto>();
        }
    }
}
