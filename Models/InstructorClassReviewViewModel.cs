using System.Collections.Generic;

namespace StudentApp.Models
{
    public class InstructorClassReviewViewModel
    {
        public InstructorClassReviewViewModel(Instructor i , decimal d, List<ClassDetails> c)
        {
            InstructorModel = i;
            AverageReview = d;
            ClassesList = c;
        }

        public Instructor InstructorModel { get; set; }
        public decimal AverageReview;
        public List<ClassDetails> ClassesList { get; set; }
    }
}