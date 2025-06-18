namespace Application.DTOs.TripBooking
{
    public class CreateTripBookingRequestDTO
    {
        public int TripId { get; set; }
        public string BookingType { get; set; }
        public int Seats { get; set; }
        public int? CarId { get; set; }
        public bool WithDriver { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
    }
}