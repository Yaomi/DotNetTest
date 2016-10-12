using System.Collections.Generic;
using System.Linq;
using DvdRentalStore.Api.Components.Rental.Models;

namespace DvdRentalStore.Api.Components.Rental.Services
{
    public class RentalService : IRentalService
    {
        private ICollection<Models.Rental> _rentals = new List<Models.Rental>();

        public ICollection<Models.Rental> GetRentals()
        {
            return _rentals;
        }

        public void AddRental(RentalParameters parameters)
        {
            var rental = new Models.Rental
            {
                Id = GetNewId(_rentals),
                CustomerId = parameters.CustomerId,
                InventoryId = parameters.InventoryId,
                RentalDate = parameters.RentalDate,
                ReturnDate = parameters.ReturnDate,
                StaffId = parameters.StaffId
            };

            _rentals.Add(rental);
        }

        public void RemoveRental(int rentalId)
        {
            _rentals = _rentals.Where(note => note.Id != rentalId).ToList();
        }

        private static int GetNewId(ICollection<Models.Rental> rentals)
        {
            return rentals.Any() ? rentals.Select(r => r.Id).Max() + 1 : 1;
        }
    }
}