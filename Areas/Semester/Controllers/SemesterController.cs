using StudyMaterial.Areas.Semester.Models;
using StudyMaterial.Areas.Course.Models;
using StudyMaterial.Areas.Branch.Models;
using StudyMaterial.BAL;
using StudyMaterial.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace StudyMaterial.Areas.Semester.Controllers
{
    [CheckAccess]
    [Area("Semester")]
    [Route("Semester/[controller]/[action]")]
    public class SemesterController : Controller
    {
        private IConfiguration Configuration;
        public SemesterController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Semester_SelectAll(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("SemesterList", dt);
        }
        public IActionResult Filter(int Semester,string? CourseName, string? BranchName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Semester_SelectBySemesterSemester(connectionstr, CourseName, BranchName, Semester, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("SemesterList", dt); 
        }

        public IActionResult Delete(int SemesterID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_Semester_DeleteByPK(connectionstr, SemesterID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? SemesterID)
        {
            string connectionstr2 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt2 = dalLOC.dbo_PR_Course_SelectForDropDown(connectionstr2, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            List<CourseDropDownModel> list1 = new List<CourseDropDownModel>();
            foreach (DataRow dr in dt2.Rows)
            {
                CourseDropDownModel vlst1 = new CourseDropDownModel();

                vlst1.CourseID = Convert.ToInt32(dr["CourseID"]);
                vlst1.CourseName = Convert.ToString(dr["CourseName"]);
                list1.Add(vlst1);
            }
            ViewBag.CourseList = list1;



            List<BranchDropDownModel> list = new List<BranchDropDownModel>();

            ViewBag.BranchList = list;



            if (SemesterID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");

                DataTable dt = dalLOC.dbo_PR_Semester_SelectByPK(connectionstr, SemesterID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                SemesterModel modelSemester = new SemesterModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelSemester.SemesterID = Convert.ToInt32(dr["SemesterID"]);
                    modelSemester.BranchID = Convert.ToInt32(dr["BranchID"]);
                    modelSemester.CourseID = Convert.ToInt32(dr["CourseID"]);
                    modelSemester.Semester = Convert.ToInt32(dr["Semester"]);
                    modelSemester.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelSemester.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("SemesterAddEdit", modelSemester);
            }
            return View("SemesterAddEdit");
        }
        [HttpPost]
        public IActionResult Save(SemesterModel modelSemester)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                if (modelSemester.SemesterID == null)
                {
                    dalLOC.dbo_PR_Semester_Insert(connectionstr, modelSemester, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }
                else
                {
                    dalLOC.dbo_PR_Semester_UpdateByPK(connectionstr, modelSemester, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }

            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult DropDownByCourse(int CourseID)
        {
            string connectionstr7 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt7 = dalLOC.dbo_PR_Branch_SelectDropDownByCourseID(connectionstr7, CourseID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            List<BranchDropDownModel> list = new List<BranchDropDownModel>();
            foreach (DataRow dr in dt7.Rows)
            {
                BranchDropDownModel vlst = new BranchDropDownModel();

                vlst.BranchID = Convert.ToInt32(dr["BranchID"]);
                vlst.BranchName = Convert.ToString(dr["BranchName"]);
                list.Add(vlst);
            }
            var vModel = list;
            return Json(vModel);
        }

    }
}
