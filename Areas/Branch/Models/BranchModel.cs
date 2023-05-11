
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace StudyMaterial.Areas.Branch.Models
{
    public class BranchModel
    {
        public int? BranchID { get; set; }

        public int CourseID { get; set; }
        [Required]
        [DisplayName("Branch Name")]
        [StringLength(20, MinimumLength = 3)]

        public string? BranchName { get; set; }

        public string BranchCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


    }
    public class BranchDropDownModel
    {
        public int BranchID { get; set; }

        public string? BranchName { get; set; }

    
}
}
