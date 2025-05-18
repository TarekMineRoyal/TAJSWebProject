// Application/DTOs/TripPlanCar/CreateTripPlanCarDTO.cs
namespace Application.DTOs.TripPlanCar
{
    public class CreateTripPlanCarDTO
    {
        public int Id { get; set; } // Required for CreatedAtAction
        public decimal Price { get; set; }
        public int TripPlanId { get; set; }
        public int CarId { get; set; }
    }
}