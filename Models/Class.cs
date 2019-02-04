using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        [Required(ErrorMessage = "ClassName is required.")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Instructor is required.")]
        public int InstructorId { get; set; }
        [Required(ErrorMessage = "Location is required.")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        public int TimeId { get; set; }
        [Required(ErrorMessage = "TermId is required.")]
        public int TermId { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        public int ClassTypeId {get; set; }

    }
}