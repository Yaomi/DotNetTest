using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.Rental.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.Rental
{
    [RoutePrefix("api/inventories")]
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of inventory", typeof (IEnumerable<Inventory>))]
        public HttpResponseMessage Get()
        {
            var inventories = new List<Inventory>
            {
                new Inventory
                {
                    Id = 1,
                    MovieId = 1
                },
                new Inventory
                {
                    Id = 2,
                    MovieId = 1
                },
                new Inventory
                {
                    Id = 2,
                    MovieId = 2
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, inventories);
            return response;
        }
    }
}