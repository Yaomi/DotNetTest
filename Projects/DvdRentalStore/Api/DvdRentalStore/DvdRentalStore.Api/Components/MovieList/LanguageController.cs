using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.MovieList.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.MovieList
{
    [RoutePrefix("api/languages")]
    public class LanguageController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of available languages", typeof (IEnumerable<Language>))]
        public HttpResponseMessage Get()
        {
            var categories = new List<Language>
            {
                new Language
                {
                    Id = 1,
                    Name = "English"
                },
                new Language
                {
                    Id = 2,
                    Name = "Polish"
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, categories);
            return response;
        }
    }
}