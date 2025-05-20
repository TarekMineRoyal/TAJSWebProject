// Application/Services/TripPlanService.cs
using Application.DTOs.TripPlan;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TripPlanService : ITripPlanService
    {
        private readonly IGenericRepository<TripPlan> _tripPlanRepo;
        private readonly IMapper _mapper;

        public TripPlanService(
            IGenericRepository<TripPlan> tripPlanRepo,
            IMapper mapper)
        {
            _tripPlanRepo = tripPlanRepo;
            _mapper = mapper;
        }

        public async Task<TripPlanDTO?> GetTripPlanByIdAsync(int id)
        {
            var tripPlan = await _tripPlanRepo.GetByIdAsync(id);
            return tripPlan != null ? _mapper.Map<TripPlanDTO>(tripPlan) : null;
        }

        public async Task<IEnumerable<TripPlanDTO>> GetAllTripPlansAsync()
        {
            var tripPlans = await _tripPlanRepo.GetAllAsync();
            return tripPlans?.Select(t => _mapper.Map<TripPlanDTO>(t));
        }

        public async Task<CreateTripPlanDTO> AddTripPlanAsync(CreateTripPlanDTO dto)
        {
            var tripPlan = _mapper.Map<TripPlan>(dto);
            var addedPlan = await _tripPlanRepo.AddAsync(tripPlan);
            await _tripPlanRepo.SaveChangesAsync();
            return _mapper.Map<CreateTripPlanDTO>(addedPlan);
        }

        public async Task<TripPlanDTO?> UpdateTripPlanAsync(int id, UpdateTripPlanDTO dto)
        {
            var existingPlan = await _tripPlanRepo.GetByIdAsync(id);
            if (existingPlan == null) return null;

            _mapper.Map(dto, existingPlan);
            _tripPlanRepo.UpdateAsync(id, existingPlan);
            await _tripPlanRepo.SaveChangesAsync();

            return _mapper.Map<TripPlanDTO>(existingPlan);
        }

        public async Task<TripPlanDTO> DeleteTripPlanAsync(int id)
        {
            var deletedPlan = await _tripPlanRepo.RemoveAsync(id);
            await _tripPlanRepo.SaveChangesAsync();
            return _mapper.Map<TripPlanDTO>(deletedPlan);
        }
    }
}