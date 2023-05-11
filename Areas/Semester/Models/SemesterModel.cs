using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace StudyMaterial.Areas.Semester.Models
{
    public class SemesterModel
    {
       
            public int? SemesterID { get; set; }

            public int? CourseID { get; set; }

            public int BranchID { get; set; }
            [Required]
            [DisplayName("Semester")]
            

            public int Semester { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime ModificationDate { get; set; }


        }
        public class SemesterDropDownModel
        {
            public int SemesterID { get; set; }

            public int Semester { get; set; }

        }
    }

