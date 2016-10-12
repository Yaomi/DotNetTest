using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.Rental.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.Rental
{
    [SwaggerResponseRemoveDefaults]
    [RoutePrefix("api/staffs")]
    public class StaffController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of staffs", typeof(IEnumerable<User>))]
        public HttpResponseMessage Get()
        {
            var staffs = new List<User>
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Tiberius",
                    LastName = "Gracchus"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Gaius",
                    LastName = "Marius"
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, staffs);
            return response;
        }
    }
}