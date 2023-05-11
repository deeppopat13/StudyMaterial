using StudyMaterial.Areas.Subject.Models;
using StudyMaterial.Areas.Semester.Models;
using StudyMaterial.Areas.Course.Models;
using StudyMaterial.Areas.Branch.Models;
using Microsoft.AspNetCore.Mvc;
using StudyMaterial.BAL;
using StudyMaterial.DAL;
using System.Data;
using System.Data.SqlClient;

namespace StudyMaterial.Areas.Subject.Controllers
{
    [CheckAccess]
    [Area("Subject")]
    [Route("Subject/[controller]/[action]")]
    public class SubjectController : Controller
    {
        private IConfiguration Configuration;
        public SubjectController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Subject_SelectAll(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("SubjectList", dt);
        }
        public IActionResult Filter(string? SubjectName, string? CourseName, string? BranchName, int Semester, int SubjectCode)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Subject_SelectBySubjectNameCode(connectionstr, CourseName, BranchName, Semester,SubjectName, SubjectCode, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("ContactList", dt);
        }

        public IActionResult Delete(int SubjectID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_Subject_DeleteByPK(connectionstr, SubjectID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? SubjectID)
        {
            string connectionstr2 = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn2 = new SqlConnection(connectionstr2);
            conn2.Open();
            SqlCommand objCmd2 = conn2.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "PR_Course_SelectForDropDown";
            DataTable dt2 = new DataTable();
            SqlDataReader objSDR2 = objCmd2.ExecuteReader();
            dt2.Load(objSDR2);

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

            List<SemesterDropDownModel> list2 = new List<SemesterDropDownModel>();

            ViewBag.SemesterList = list2;

            

            if (SubjectID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                DataTable dt = dalLOC.dbo_PR_Subject_SelectByPK(connectionstr, SubjectID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                SubjectModel modelSubject = new SubjectModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelSubject.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    modelSubject.CourseID = Convert.ToInt32(dr["CourseID"]);
                    modelSubject.SemesterID = Convert.ToInt32(dr["SemesterID"]);
                    modelSubject.BranchID = Convert.ToInt32(dr["BranchID"]);
                    modelSubject.SubjectName = Convert.ToString(dr["SubjectName"]);
                    modelSubject.SubjectCode = Convert.ToInt32(dr["Subjectcode"]);
                    modelSubject.SubjectImage = Convert.ToString(dr["SubjectImage"]);
                    modelSubject.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    TempData["SubjectImage"] = dr["SubjectImage"].ToString();
                }
                string connectionstr7 = Configuration.GetConnectionString("myConnectionString");
                
                DataTable dt7 = dalLOC.dbo_PR_Branch_SelectDropDownByCourseID(connectionstr7, modelSubject.CourseID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                List<BranchDropDownModel> lista = new List<BranchDropDownModel>();
                foreach (DataRow dr in dt7.Rows)
                {
                    BranchDropDownModel vlst = new BranchDropDownModel();

                    vlst.BranchID = Convert.ToInt32(dr["BranchID"]);
                    vlst.BranchName = Convert.ToString(dr["BranchName"]);
                    lista.Add(vlst);
                }
                ViewBag.StateList = lista;
                string connectionstr3 = Configuration.GetConnectionString("myConnectionString");

                DataTable dt3 = dalLOC.dbo_PR_Semester_SelectDropDownByBranchID(connectionstr3, modelSubject.BranchID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                List<SemesterDropDownModel> listc = new List<SemesterDropDownModel>();
                foreach (DataRow dr in dt3.Rows)
                {
                    SemesterDropDownModel vlst2 = new SemesterDropDownModel();

                    vlst2.SemesterID = Convert.ToInt32(dr["SemesterID"]);
                    vlst2.Semester = Convert.ToInt32(dr["Semester"]);
                    listc.Add(vlst2);
                }
                ViewBag.SemesterList = listc;
                return View("SubjectAddEdit", modelSubject);
            }
            return View("SubjectAddEdit");
        }
        [HttpPost]
        public IActionResult Save(SubjectModel modelSubject)
        {
            if (modelSubject.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, modelSubject.File.FileName);
                modelSubject.SubjectImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelSubject.File.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelSubject.File.CopyTo(stream);
                }
            }
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            if (modelSubject.SubjectID == null)
            {
                dalLOC.dbo_PR_Subject_Insert(connectionstr, modelSubject, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            }
            else
            {
                dalLOC.dbo_PR_Subject_UpdateByPK(connectionstr, modelSubject, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DropDownByCourse(int? CourseID)
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
        public IActionResult DropDownByBranch(int BranchID)
        {
            string connectionstr3 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt3 = dalLOC.dbo_PR_Semester_SelectDropDownByBranchID(connectionstr3, BranchID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            List<SemesterDropDownModel> list2 = new List<SemesterDropDownModel>();
            foreach (DataRow dr in dt3.Rows)
            {
                SemesterDropDownModel vlst2 = new SemesterDropDownModel();

                vlst2.SemesterID = Convert.ToInt32(dr["SemesterID"]);
                vlst2.Semester = Convert.ToInt32(dr["Semester"]);
                list2.Add(vlst2);
            }
            var vModel = list2;
            return Json(vModel);
        }

    }
}
