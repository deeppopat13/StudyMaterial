using StudyMaterial.Areas.Course.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using StudyMaterial.Areas.Branch.Models;
using StudyMaterial.Areas.Semester.Models;
using StudyMaterial.Areas.Subject.Models;
namespace StudyMaterial.DAL
{
    public class DALBase
    {
        public DataTable dbo_pr_Course_SelectAll(string conn, int? UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("pr_Course_SelectAll");
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
        #region dbo.PR_Course_SelectByPK
        public DataTable dbo_PR_Course_SelectByPK(string conn, int? CourseID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Course_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CourseID", SqlDbType.Int, CourseID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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
        #region dbo.PR_Course_Insert
        public void dbo_PR_Course_Insert(string conn, CourseModel modelCourse, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Course_Insert");
                sqlDB.AddInParameter(dbCMD, "CourseName", SqlDbType.NVarChar, modelCourse.CourseName);
                sqlDB.AddInParameter(dbCMD, "CourseCode", SqlDbType.Int, modelCourse.CourseCode);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                sqlDB.ExecuteNonQuery(dbCMD);



            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region dbo.PR_Course_UpdateByPK
        public void dbo_PR_Course_UpdateByPK(string conn,CourseModel modelCourse, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Course_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, modelCourse.CourseID);
                sqlDb.AddInParameter(dbCmd, "CourseName", SqlDbType.NVarChar, modelCourse.CourseName);
                sqlDb.AddInParameter(dbCmd, "CourseCode", SqlDbType.Int, modelCourse.CourseCode);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_LOC_Course_DeleteByPK
        public void dbo_PR_Course_DeleteByPK(string conn,int CourseID,int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Course_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, CourseID);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region dbo.PR_Branch_SelectAll
        public DataTable dbo_PR_Branch_SelectAll(string conn, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Branch_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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
        #region dbo.PR_Branch_DeleteByPK
        public void dbo_PR_Branch_DeleteByPK(string conn, int BranchID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Branch_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, BranchID);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Branch_SelectByPK
        public DataTable dbo_PR_Branch_SelectByPK(string conn, int? BranchID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Branch_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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
        #region dbo.PR_Branch_Insert
        public void dbo_PR_Branch_Insert(string conn, BranchModel modelBranch, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Branch_Insert");
                sqlDB.AddInParameter(dbCMD, "CourseID", SqlDbType.Int, modelBranch.CourseID);
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.NVarChar, modelBranch.BranchName);
                sqlDB.AddInParameter(dbCMD, "BranchCode", SqlDbType.Int, modelBranch.BranchCode);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                sqlDB.ExecuteNonQuery(dbCMD);



            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region dbo.PR_Branch_UpdateByPK
        public void dbo_PR_Branch_UpdateByPK(string conn, BranchModel modelBranch, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Branch_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, modelBranch.CourseID);
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, modelBranch.BranchID);
                sqlDb.AddInParameter(dbCmd, "BranchName", SqlDbType.NVarChar, modelBranch.BranchName);
                sqlDb.AddInParameter(dbCmd, "BranchCode", SqlDbType.Int, modelBranch.BranchCode);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Semester_SelectAll
        public DataTable dbo_PR_Semester_SelectAll(string conn, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Semester_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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
        #region dbo.PR_Semester_DeleteByPK
        public void dbo_PR_Semester_DeleteByPK(String conn, int SemesterID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Semester_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.AddInParameter(dbCmd, "SemesterID", SqlDbType.Int, SemesterID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Semester_SelectByPK
        public DataTable dbo_PR_Semester_SelectByPK(string conn, int? SemesterID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Semester_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "SemesterID", SqlDbType.Int, SemesterID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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
        #region dbo.PR_Semester_Insert
        public void dbo_PR_Semester_Insert(string conn, SemesterModel modelSemester, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Semester_Insert");
                sqlDB.AddInParameter(dbCMD, "CourseID", SqlDbType.Int, modelSemester.CourseID);
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, modelSemester.BranchID);
                sqlDB.AddInParameter(dbCMD, "Semester", SqlDbType.Int, modelSemester.Semester);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                sqlDB.ExecuteNonQuery(dbCMD);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region dbo.PR_Semester_UpdateByPK
        public void dbo_PR_Semester_UpdateByPK(string conn, SemesterModel modelSemester, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, modelSemester.CourseID);
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, modelSemester.BranchID);
                sqlDb.AddInParameter(dbCmd, "SemesterID", SqlDbType.Int, modelSemester.SemesterID);
                sqlDb.AddInParameter(dbCmd, "Semester", SqlDbType.Int, modelSemester.Semester);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }

        }
        #endregion
        #region dbo.PR_Subject_SelectAll
        public DataTable dbo_PR_Subject_SelectAll(string conn, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Subject_SelectAll");
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
        #region dbo.PR_Subject_SelectByPK
        public DataTable dbo_PR_Subject_SelectByPK(string conn, int? SubjectID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Subject_SelectByPK");
                sqlDb.AddInParameter(dbCmd, "SubjectID", SqlDbType.Int, SubjectID);
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
        #region dbo.PR_Subject_Insert
        public void dbo_PR_Subject_Insert(string conn, SubjectModel modelSubject, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Subject_Insert");
                
                sqlDb.AddInParameter(dbCmd, "SemesterID", SqlDbType.Int, modelSubject.SemesterID);
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, modelSubject.BranchID);
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, modelSubject.CourseID);
                sqlDb.AddInParameter(dbCmd, "SubjectName", SqlDbType.NVarChar, modelSubject.SubjectName);
                sqlDb.AddInParameter(dbCmd, "SubjectImage", SqlDbType.NVarChar, modelSubject.SubjectImage);
                sqlDb.AddInParameter(dbCmd, "SubjectCode", SqlDbType.Int, modelSubject.SubjectCode);
               sqlDb.AddInParameter(dbCmd, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Subject_UpdateByPK
        public void dbo_PR_Subject_UpdateByPK(string conn, SubjectModel modelSubject, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_CON_Contact_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "ContactID", SqlDbType.Int, modelSubject.SubjectID);
                
                sqlDb.AddInParameter(dbCmd, "SemesterID", SqlDbType.Int, modelSubject.SemesterID);
                sqlDb.AddInParameter(dbCmd, "BranchID", SqlDbType.Int, modelSubject.BranchID);
                sqlDb.AddInParameter(dbCmd, "CourseID", SqlDbType.Int, modelSubject.CourseID);
                sqlDb.AddInParameter(dbCmd, "SubjectName", SqlDbType.NVarChar, modelSubject.SubjectName);
                sqlDb.AddInParameter(dbCmd, "SubjectImage", SqlDbType.NVarChar, modelSubject.SubjectImage);
               
                sqlDb.AddInParameter(dbCmd, "SubjectCode", SqlDbType.Int, modelSubject.SubjectCode);
                
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Subject_DeleteByPK
        public void dbo_PR_Subject_DeleteByPK(string conn, int SubjectID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Subject_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "SubjectID", SqlDbType.Int, SubjectID);
                sqlDb.AddInParameter(dbCmd, "UserID", SqlDbType.Int, UserID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Semester_SelectDropDownByBranchID
        public DataTable dbo_PR_Semester_SelectDropDownByBranchID(string conn, int BranchID, int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Semester_SelectDropDownByBranchID");
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
    }
}
