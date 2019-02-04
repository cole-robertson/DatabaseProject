using System.Collections.Generic;

namespace StudentApp.Models
{
    public class ClassReviewViewModel
    {
        public ClassReviewViewModel(ClassDetails cmodel, List<Review> reviews)
        {
            ClassModel = cmodel;
            ReviewsModel = reviews;
        }
        public ClassDetails ClassModel { get; set; }
        public List<Review> ReviewsModel { get; set; }
    }
}