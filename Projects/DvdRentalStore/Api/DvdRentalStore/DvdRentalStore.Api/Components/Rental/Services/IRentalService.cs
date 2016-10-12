using System.Collections.Generic;
using DvdRentalStore.Api.Components.Rental.Models;

namespace DvdRentalStore.Api.Components.Rental.Services
{
    public interface IRentalService
    {
        ICollection<Models.Rental> GetRentals();
        void AddRental(RentalParameters parameters);
        void RemoveRental(int rentalId);
    }
}