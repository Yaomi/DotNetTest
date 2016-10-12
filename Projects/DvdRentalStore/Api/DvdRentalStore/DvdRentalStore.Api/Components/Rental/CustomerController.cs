using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.Rental.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.Rental
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list customers", typeof (IEnumerable<User>))]
        public HttpResponseMessage Get()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Marcus",
                    LastName = "Cicero"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Julius",
                    LastName = "Caesar"
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, users);
            return response;
        }
    }
}