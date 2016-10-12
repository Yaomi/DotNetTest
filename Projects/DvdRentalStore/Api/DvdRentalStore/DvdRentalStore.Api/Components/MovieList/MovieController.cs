using System.Collections.Generic;
using System.Web.Http;

namespace DvdRentalStore.Api.Components.MovieList
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }
    }
}