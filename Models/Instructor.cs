using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public string Fullname { get; set; }
    }
}