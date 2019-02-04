using System.Collections.Generic;

namespace StudentApp.Models
{
    public class EnrollViewModel
    {
        public List<ClassDetails> ClassList { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TermName { get; set; }
        public string TermYear{ get; set; }
        public string Days{ get; set; }
        public string Type{ get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }

    }
}