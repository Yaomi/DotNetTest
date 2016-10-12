using System;
using System.Collections.Generic;

namespace DvdRentalStore.Api.Components.MovieList.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public IEnumerable<int> CategoriesIds { get; set; }
    }
}