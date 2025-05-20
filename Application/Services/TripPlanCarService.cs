// Application/Services/TripPlanCarService.cs
using Application.DTOs.TripPlanCar;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TripPlanCarService : ITripPlanCarService
    {
        private readonly IGenericRepository<TripPlanCar> _repo;
        private readonly IMapper _mapper;

        public TripPlanCarService(
            IGenericRepository<TripPlanCar> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TripPlanCarDTO?> GetTripPlanCarByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity != null ? _mapper.Map<TripPlanCarDTO>(entity) : null;
        }

        public async Task<IEnumerable<TripPlanCarDTO>> GetAllTripPlanCarsAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities?.Select(e => _mapper.Map<TripPlanCarDTO>(e));
        }

        public async Task<CreateTripPlanCarDTO> AddTripPlanCarAsync(CreateTripPlanCarDTO dto)
        {
            var entity = _mapper.Map<TripPlanCar>(dto);
            var added = await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return _mapper.Map<CreateTripPlanCarDTO>(added);
        }

        public async Task<TripPlanCarDTO?> UpdateTripPlanCarAsync(int id, UpdateTripPlanCarDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _repo.UpdateAsync(id, existing);
            await _repo.SaveChangesAsync();

            return _mapper.Map<TripPlanCarDTO>(existing);
        }

        public async Task<TripPlanCarDTO> DeleteTripPlanCarAsync(int id)
        {
            var deleted = await _repo.RemoveAsync(id);
            await _repo.SaveChangesAsync();
            return _mapper.Map<TripPlanCarDTO>(deleted);
        }
    }
}