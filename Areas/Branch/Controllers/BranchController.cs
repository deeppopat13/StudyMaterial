using StudyMaterial.Areas.Course.Models;
using StudyMaterial.Areas.Branch.Models;
using StudyMaterial.BAL;
using StudyMaterial.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace StudyMaterial.Areas.Branch.Controllers
{
    [CheckAccess]
    [Area("Branch")]
    [Route("Branch/[controller]/[action]")]
    public class BranchController : Controller
    {
        private IConfiguration Configuration;

        public BranchController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Branch_SelectAll(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("BranchList",dt);
        }
        public IActionResult Filter(string? BranchCode, string? BranchName, string? CourseName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Branch_SelectByBranchNameCode(connectionstr, CourseName, BranchName, BranchCode, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("BranchList", dt);
        }
        public IActionResult Delete(int BranchID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_Branch_DeleteByPK(connectionstr, BranchID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? BranchID)
        {
            string connectionstr1 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt1 = dalLOC.dbo_PR_Course_SelectForDropDown(connectionstr1, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            List<CourseDropDownModel> list = new List<CourseDropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                CourseDropDownModel vlst = new CourseDropDownModel();

                vlst.CourseID = Convert.ToInt32(dr["CourseID"]);
                vlst.CourseName = Convert.ToString(dr["CourseName"]);
                list.Add(vlst);
            }
            ViewBag.CourseList = list;
            if (BranchID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");

                DataTable dt = dalLOC.dbo_PR_Branch_SelectByPK(connectionstr, BranchID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));

                BranchModel modelBranch = new BranchModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelBranch.BranchID = Convert.ToInt32(dr["BranchID"]);
                    modelBranch.CourseID = Convert.ToInt32(dr["CourseID"]);
                    modelBranch.BranchName = Convert.ToString(dr["BranchName"]);
                    modelBranch.BranchCode = Convert.ToString(dr["BranchCode"]);
                    modelBranch.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelBranch.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("BranchAddEdit", modelBranch);

            }
            return View("BranchAddEdit");
        }
        [HttpPost]
        public IActionResult Save(BranchModel modelBranch)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                if (modelBranch.BranchID == null)
                {
                    dalLOC.dbo_PR_Branch_Insert(connectionstr, modelBranch, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }
                else
                {
                    dalLOC.dbo_PR_Branch_UpdateByPK(connectionstr, modelBranch, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }

            }

            return RedirectToAction("Index");
        }
    }
}
