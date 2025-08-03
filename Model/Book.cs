using System.ComponentModel.DataAnnotations;

namespace LearningController2.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

    }
}
