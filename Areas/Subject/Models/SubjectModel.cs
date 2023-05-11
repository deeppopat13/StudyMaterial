using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace StudyMaterial.Areas.Subject.Models
{
    public class SubjectModel
    {
        public int? CourseID { get; set; }
        public int? SubjectID { get; set; }

        public int SemesterID { get; set; }

        public int BranchID { get; set; }
        [Required]
        [DisplayName("Subject Name")]
        [StringLength(20, MinimumLength = 3)]

        public string? SubjectName { get; set; }

        public int SubjectCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }

        public string SubjectImage { get; set; }



    }
}
