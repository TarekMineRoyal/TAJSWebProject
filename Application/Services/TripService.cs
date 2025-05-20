// Application/Services/TripService.cs
using Application.DTOs.Trip;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TripService : ITripService
    {
        private readonly IGenericRepository<Trip> _tripRepo;
        private readonly IMapper _mapper;

        public TripService(
            IGenericRepository<Trip> tripRepo,
            IMapper mapper)
        {
            _tripRepo = tripRepo;
            _mapper = mapper;
        }

        public async Task<TripDTO?> GetTripByIdAsync(int id)
        {
            var trip = await _tripRepo.GetByIdAsync(id);
            return trip != null ? _mapper.Map<TripDTO>(trip) : null;
        }

        public async Task<IEnumerable<TripDTO>> GetAllTripsAsync()
        {
            var trips = await _tripRepo.GetAllAsync();
            return trips?.Select(t => _mapper.Map<TripDTO>(t));
        }

        public async Task<CreateTripDTO> AddTripAsync(CreateTripDTO dto)
        {
            var trip = _mapper.Map<Trip>(dto);
            var addedTrip = await _tripRepo.AddAsync(trip);
            await _tripRepo.SaveChangesAsync();
            return _mapper.Map<CreateTripDTO>(addedTrip);
        }

        public async Task<TripDTO?> UpdateTripAsync(int id, UpdateTripDTO dto)
        {
            var existingTrip = await _tripRepo.GetByIdAsync(id);
            if (existingTrip == null) return null;

            _mapper.Map(dto, existingTrip);
<<<<<<< HEAD
            _tripRepo.Update(existingTrip);
=======
            _tripRepo.UpdateAsync(id, existingTrip);
>>>>>>> Add-Post-Service
            await _tripRepo.SaveChangesAsync();

            return _mapper.Map<TripDTO>(existingTrip);
        }

        public async Task<TripDTO> DeleteTripAsync(int id)
        {
            var deletedTrip = await _tripRepo.RemoveAsync(id);
            await _tripRepo.SaveChangesAsync();
            return _mapper.Map<TripDTO>(deletedTrip);
        }
    }
}