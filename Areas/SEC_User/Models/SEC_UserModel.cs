using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudyMaterial.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        /*public string? FirstName { get; set; }
        public string? LastName { get; set; }*/
        public string? UserEmail { get; set; }
        /* public string? PhotoPath { get; set; }*/
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
