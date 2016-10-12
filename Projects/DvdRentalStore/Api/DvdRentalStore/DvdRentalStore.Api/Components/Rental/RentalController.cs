using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.Rental.Models;
using DvdRentalStore.Api.Components.Rental.Services;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.Rental
{
    [RoutePrefix("api/rentals")]
    public class RentalController : ApiController
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of rentals", typeof(IEnumerable<Models.Rental>))]
        public HttpResponseMessage Get()
        {
            var rentals = _rentalService.GetRentals();
            var response = Request.CreateResponse(HttpStatusCode.OK, rentals);
            return response;
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Add rental.")]
        public HttpResponseMessage Post(RentalParameters rentalParameters)
        {
            _rentalService.AddRental(rentalParameters);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Remove rental.")]
        public HttpResponseMessage Delete(int rentalId)
        {
            _rentalService.RemoveRental(rentalId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}