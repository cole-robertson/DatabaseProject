using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Class is required.")]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ScreenName { get; set; }
        public string Description { get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a rating from 1 to 5")]
        public int Rating { get; set; }

        public string StarRating()
        {
            string _RatingString = "★★★★★☆☆☆☆☆";
            string stars = _RatingString.Substring(5 - Rating, 5);
            return stars;
        }
    }
}