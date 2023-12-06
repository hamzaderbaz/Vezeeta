using System;

namespace Vezeeta.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
        public string DiscountCode { get; set; }
        public decimal FinalPrice { get; set; }
        public BookingStatus Status { get; set; }

       
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }

    public enum BookingStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    
}
