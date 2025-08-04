using System.ComponentModel.DataAnnotations;

namespace Books.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }

    }
}
