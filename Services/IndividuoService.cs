using AutoMapper;
using Automotores.DTOs;
using Automotores.Models;
using Automotores.Repository;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Services
{
    public class IndividuoService : ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto>
    {
        private IRepository<Individuo> _individuoRepository;
        private IMapper _mapper;
        public IndividuoService(IRepository<Individuo> individuoRepository,
            IMapper mapper)
        {
            _individuoRepository = individuoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IndividuoDto>> Get()
        {
            var individuos = await _individuoRepository.Get();
            return individuos.Select(individuo => _mapper.Map<IndividuoDto>(individuo));
        }

        public async Task<IndividuoDto> GetById(int id)
        {
            var individuo = await _individuoRepository.GetById(id);
            
            if (individuo != null)
            {
                var individuoDto = _mapper.Map<IndividuoDto>(individuo);
                return individuoDto;
            }

            return null;
        }
        public async Task<IndividuoDto> Add(IndividuoInsertDto insertDto)
        {
            var individuo = _mapper.Map<Individuo>(insertDto);

            await _individuoRepository.Add(individuo);
            await _individuoRepository.Save();

            var individuoDto = _mapper.Map<IndividuoDto>(individuo);
            return individuoDto;
        }

        public async Task<IndividuoDto> Update(int id, IndividuoUpdateDto updateDto)
        {
            var individuo = await _individuoRepository.GetById(id);

            if (individuo != null)
            {
                individuo = _mapper.Map<IndividuoUpdateDto, Individuo>(updateDto, individuo);
                _individuoRepository.Update(individuo);
                await _individuoRepository.Save();

                var individuoDto = _mapper.Map<IndividuoDto>(individuo);
                return individuoDto;
            }
            return null;
        }

        public async Task<IndividuoDto> Delete(int id)
        {
            var individuo = await _individuoRepository.GetById(id);

            if(individuo != null)
            {
                var individuoDto = _mapper.Map<IndividuoDto>(individuo);

                _individuoRepository.Delete(individuo);
                await _individuoRepository.Save();

                return individuoDto;
            }
            return null;
        }
    }
}
