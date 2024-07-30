using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcApp.Models
{
    [Table("MovieTable")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Title Cannot be empty")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } =string.Empty;
        public string Director { get; set; } = string.Empty ;
        public int Duration { get; set; }
        public string Actors { get; set; } = string.Empty;
        public double Rating { get; set; } = 10;
    }
}
