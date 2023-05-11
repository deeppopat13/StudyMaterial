
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace StudyMaterial.Areas.Course.Models
{
    public class CourseModel
    {
        public int? CourseID { get; set; }

        [Required]
        [DisplayName("Country Name")]
        [StringLength(20, MinimumLength = 3)]

        public String CourseName { get; set; }


        public int CourseCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
    public class CourseDropDownModel
    {
        public int CourseID { get; set; }

        public String CourseName { get; set; }

    }
}



