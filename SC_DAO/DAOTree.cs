using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC_DAO
{
    public class DAOTree
    {
        public string strConn(string ConL)
        {
            string strCon = string.Empty;
            strCon = ConfigurationManager.AppSettings[ConL];
            return strCon;
        }

        /// <summary>
        /// 父節點
        /// </summary>
        /// <param name="WorkId"></param>
        /// <returns></returns>
        public DataTable dtParent(string strCon, string WorkId)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try 
            {
                string Sql_cmd = "Select Distinct FunID,FunName From SC_Offer_FunList";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            { }
            finally 
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 子節點
        /// </summary>
        /// <param name="WorkId"></param>
        /// <returns></returns>
        public DataTable dtPgm(string strCon,string WorkId)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try 
            {
                string Sql_cmd = "Select FunID,FunName,PgID,PgN,PgName From SC_Offer_FunList Order By FunID,ord ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
 
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        public string GetSC_Offer_FunList_PgN(string strCon, string PgID)
        {
            string returnString = "";
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = "Select PgN from SC_Offer_FunList where PgID=@PgID";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                com.Parameters.AddWithValue("@PgID", PgID);
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                    returnString = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return returnString;
        }
    }
}
