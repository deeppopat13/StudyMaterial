using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
namespace StudyMaterial.DAL
{
    public class SEC_DALBase
    {
        #region Method: dbo_PR_Mst_User_SelectByPK
        public DataTable dbo_PR_User_Master_SelectByPK(string ConnStr, int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Mst_User_SelectByPK");
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

        #region Method: dbo_PR_Mst_User_SelectByUserNamePassword
        public DataTable dbo_PR_User_Master_SelectByUserNamePassword(string ConnStr, string UserName, string UserPassword)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Mst_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "UserPassword", SqlDbType.VarChar, UserPassword);

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

        #region Method: dbo_PR_User_Master_Insert
        public decimal? dbo_PR_User_Master_Insert(string ConnStr, string UserName, string UserPassword, string UserEmail, DateTime? CreationDate, DateTime? ModificationDate)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Mst_User_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "UserPassword", SqlDbType.VarChar, UserPassword);
                /* sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.VarChar, FirstName);
                 sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.VarChar, LastName);*/
                sqlDB.AddInParameter(dbCMD, "UserEmail", SqlDbType.VarChar, UserEmail);
                /*sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);*/
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, CreationDate);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, ModificationDate);

                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                    return null;

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
