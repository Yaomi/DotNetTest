using System;

namespace DvdRentalStore.Api.Components.Rental.Models
{
    public class RentalParameters
    {
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}