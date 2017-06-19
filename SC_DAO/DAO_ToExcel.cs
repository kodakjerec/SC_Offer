using System.Data;
using System.Collections;

namespace SC_DAO
{
    public class DAO_ToExcel
    {
        DB_IO io = new DB_IO();

        //SC應收款
        public DataTable dtTypeDiscount_Acci_Query(string strCon, string strMonth)
        {
            DataTable dt = new DataTable();

            string Sql_cmd = "spEDI_SCreports02_Discount";
            Hashtable ht1 = new Hashtable();
            ht1.Add("@Month", strMonth);
            Hashtable ht2 = new Hashtable();
            DataSet ds = io.SqlSp(strCon, Sql_cmd, ht1, ref ht2);
            dt = ds.Tables[0];

            return dt;
        }
    }
}
