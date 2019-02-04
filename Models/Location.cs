using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Building is required.")]
        public string Building { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public int RoomNumber { get; set; }
    }
}