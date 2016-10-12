using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdRentalStore.Api.Components.MovieList.Models;
using Swashbuckle.Swagger.Annotations;

namespace DvdRentalStore.Api.Components.MovieList
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns a list of available movies", typeof (IEnumerable<Movie>))]
        public HttpResponseMessage Get()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "One for the Money",
                    Description =
                        "A divorced, unemployed woman becomes a bounty hunter to make ends meet, with her first big case revolving around a former high school boyfriend.",
                    LanguageId = 1,
                    ReleaseYear = 2012,
                    CategoriesIds = new List<int> {1, 2}
                },
                new Movie
                {
                    Id = 2,
                    Title = "Hall Pass",
                    Description =
                        "Two married guys get a 'hall pass' from their wives that entitles them to sleep with as many women as they want for just one week.",
                    LanguageId = 2,
                    ReleaseYear = 2014,
                    CategoriesIds = new List<int> {2, 3}
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, movies);
            return response;
        }
    }
}