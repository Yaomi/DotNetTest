using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.MovieList.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.MovieList
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of available categories", typeof (IEnumerable<Category>))]
        public HttpResponseMessage Get()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Comedy"
                },
                new Category
                {
                    Id = 2,
                    Name = "Action"
                },
                new Category
                {
                    Id = 3,
                    Name = "Horror"
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, categories);
            return response;
        }
    }
}