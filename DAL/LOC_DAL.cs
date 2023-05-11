
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
namespace StudyMaterial.DAL
{
    public class LOC_DAL : DALBase
    {
        #region dbo.PR_LOC_Course_SelectByCourseNameCode
        public DataTable dbo_PR_Course_SelectByCourseNameCode(string conn, int? CourseCode, string? CourseName, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Course_SelectByCourseNameCode");
                sqlDb.AddInParameter(dbCmd, "CourseCode", SqlDbType.Int, CourseCode);
                sqlDb.AddInParameter(dbCmd, "CourseName", SqlDbType.NVarChar, CourseName);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region dbo.PR_Branch_SelectByBranchNameCode
        public DataTable dbo_PR_Branch_SelectByBranchNameCode(string conn, string? CourseName, string? BranchName, string? BranchCode, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Branch_SelectByBranchNameCode");
                sqlDb.AddInParameter(dbCmd, "CourseName", SqlDbType.NVarChar, CourseName);
                sqlDb.AddInParameter(dbCmd, "BranchName", SqlDbType.NVarChar, BranchName);
                sqlDb.AddInParameter(dbCmd, "BranchCode", SqlDbType.NVarChar, BranchCode);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Course_SelectForDropDown
        public DataTable dbo_PR_Course_SelectForDropDown(string conn, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Course_SelectForDropDown");
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Semester_SelectBySemesterSemester
        public DataTable dbo_PR_Semester_SelectBySemesterSemester(string conn, string? CourseName, string? BranchName, int? Semester, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Semester_SelectBySemesterSemester");
                sqlDb.AddInParameter(dbCmd, "CourseName", SqlDbType.NVarChar, CourseName);
                sqlDb.AddInParameter(dbCmd, "BranchName", SqlDbType.NVarChar, BranchName);
                sqlDb.AddInParameter(dbCmd, "Semester", SqlDbType.Int, Semester);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Semester_SelectForDropDown
        public DataTable dbo_PR_Semester_SelectForDropDown(string conn, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Semester_SelectForDropDown");
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Semester_SelectDropDownByStateID
        public DataTable dbo_PR_Semester_SelectDropDownBySemesterID(string conn, int BranchID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Semester_SelectDropDownByStateID");
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, BranchID);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Branch_SelectDropDownByCourseID
        public DataTable dbo_PR_Branch_SelectDropDownByCourseID(string conn, int? CourseID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Branch_SelectDropDownByCourseID");
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, CourseID);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Subject_SelectBySubjectNameCode
        public DataTable dbo_PR_Subject_SelectBySubjectNameCode(string conn, string? CourseName, string? BranchName, int Semester,  string? SubjectName, int SubjectCode, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Subject_SelectBySubjectNameCode");
                sqlDb.AddInParameter(dbCmd, "CourseName", SqlDbType.NVarChar, CourseName);
                sqlDb.AddInParameter(dbCmd, "BranchName", SqlDbType.NVarChar, BranchName);
                sqlDb.AddInParameter(dbCmd, "Semester", SqlDbType.Int, Semester);
                sqlDb.AddInParameter(dbCmd, "SubjectName", SqlDbType.NVarChar, SubjectName);
                sqlDb.AddInParameter(dbCmd, "SubjectCode", SqlDbType.Int, SubjectCode);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
