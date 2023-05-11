using Microsoft.AspNetCore.Mvc;
using System.Data;
using StudyMaterial.DAL;
using StudyMaterial.BAL;
using StudyMaterial.Areas.Course.Models;
using System.Data.SqlClient;
using StudyMaterial.Models;
namespace StudyMaterial.Areas.Course.Controllers
{
    [CheckAccess]
    [Area("Course")]
    [Route("Course/[controller]/[action]")]
    public class CourseController : Controller
    {
        private IConfiguration Configuration;

        public CourseController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = this.Configuration.GetConnectionString("myConnectionString");
            
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_pr_Course_SelectAll(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));

            return View("CourseList", dt);
        }
        [HttpPost]
        public IActionResult Save(CourseModel modelCourse)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();

                if (modelCourse.CourseID == null)
                {
                    dalLOC.dbo_PR_Course_Insert(connectionstr, modelCourse, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }
                else
                {
                    dalLOC.dbo_PR_Course_UpdateByPK(connectionstr, modelCourse, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                }
            }




            return RedirectToAction("Index");
        }
        public IActionResult Filter(int? CourseCode, string? CourseName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_Course_SelectByCourseNameCode(connectionstr, CourseCode, CourseName, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("CourseList", dt);
        }
        public IActionResult Delete(int CourseID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_Course_DeleteByPK(connectionstr, CourseID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? CourseID)
        {
            if (CourseID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                DataTable dt = dalLOC.dbo_PR_Course_SelectByPK(connectionstr, CourseID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                CourseModel modelCourse = new CourseModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelCourse.CourseID = Convert.ToInt32(dr["CourseID"]);
                    modelCourse.CourseName = Convert.ToString(dr["CourseName"]);
                    modelCourse.CourseCode = Convert.ToInt32(dr["CourseCode"]);
                    modelCourse.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelCourse.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("CourseAddEdit", modelCourse);

            }
            return View("CourseAddEdit");
        }

    }
    }
   

