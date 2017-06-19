using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace SC_DAO
{
    public class XMSSCData
    {
        DB_IO IO = new DB_IO();

        public string strConn(string ConL)
        {
            string strCon = string.Empty;
            strCon = ConfigurationManager.AppSettings[ConL];
            return strCon;
        }

        #region xms_sc_data
        //查詢xms_sc_data
        public DataTable XMS_SC_Data(string strCon, string goo_no)
        {
            string con_str = strConn(strCon);
            DataTable XMS_SC_Data = new DataTable();

            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select 
                                    site_no,a.goo_no,LTRIM(RTRIM(b.goo_na))+LTRIM(RTRIM(b.sub_na)) as N_merd_name,
                                    contract_date_s,contract_date_e,
                                    sc_date_s,sc_date_e,stop_date,SnFlag=CASE WHEN Sn is not null THEN 'Y' ELSE 'N' END,ID
                                   From dbo.XMS_SC_Data a inner join mkfgoomi b on a.goo_no=b.goo_no
                                   Where 1=1 and contract_date_s>=dateadd(year, -1, getdate()) ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (goo_no.Length > 0)
                {
                    Sql_cmd += "And a.goo_no like @goo_no+'%' ";
                    SqlParameter p_Cate_Code = new SqlParameter("@goo_no", SqlDbType.VarChar);
                    p_Cate_Code.Value = goo_no;
                    com.Parameters.Add(p_Cate_Code);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                XMS_SC_Data = ds.Tables[0];
            }
            catch(Exception e1)
            {
                
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return XMS_SC_Data;
        }

        //更新xms_sc_data
        public int XMS_SC_Data_Update(string strCon, DataRow dr)
        {
            string con_str = strConn(strCon);
            int SuccessCount = 0;

            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string upd_cmd = "Update XMS_SC_Data "
                                + " set contract_date_s=@contract_date_s,contract_date_e=@contract_date_e,sc_date_s=@sc_date_s,sc_date_e=@sc_date_e "
                                + ",upd_no='System',upd_date=getdate() "
                                + " where ID=@ID";
                SqlCommand com = new SqlCommand(upd_cmd, SqlConn);
                com.Parameters.AddWithValue("@contract_date_s", dr["contract_date_s"]);
                com.Parameters.AddWithValue("@contract_date_e", dr["contract_date_e"]);
                com.Parameters.AddWithValue("@sc_date_s", dr["sc_date_s"]);
                com.Parameters.AddWithValue("@sc_date_e", dr["sc_date_e"]);
                com.Parameters.AddWithValue("@ID", dr["ID"]);
                SqlConn.Open();
                SuccessCount = com.ExecuteNonQuery();
            }
            catch(Exception ex)
            { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return SuccessCount;
        }

        //下截止日
        public int XMS_SC_Data_Update_StopDate(string strCon, DataRow dr)
        {
            string con_str = strConn(strCon);
            int SuccessCount = 0;

            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string upd_cmd = "Update XMS_SC_Data "
                                + " set stop_date=convert(date,getdate()+1),stop_flag='Y'"
                                + ",upd_no='System',upd_date=getdate() "
                                + " where ID=@ID";
                SqlCommand com = new SqlCommand(upd_cmd, SqlConn);
                com.Parameters.AddWithValue("@ID", dr["ID"]);
                SqlConn.Open();
                SuccessCount = com.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return SuccessCount;
        }
        #endregion

        #region SC日結帳務
        public int SC_rebuild_ardaily01(string strCon, string DateS, string DateE, string supdId, int Mode)
        {
            int SuccessCount = 1;
            string Create_Assign = "[sp_ardaily_info_add01]";
            Hashtable ht_assign = new Hashtable();
            Hashtable ht_trash = new Hashtable();

            ht_assign.Add("@date_s", DateS);
            ht_assign.Add("@date_e", DateE);
            ht_assign.Add("@supdid", supdId);
            ht_assign.Add("@merdid", "");
            ht_assign.Add("@mode", Mode);
            DataSet ds1 = IO.SqlSp(strCon, Create_Assign, ht_assign, ref ht_trash);

            return SuccessCount;
        }
        #endregion
    }
}
