using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ExcelTool;

namespace SC_Offer
{
    public partial class note : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string str = FileUpload1.PostedFile.FileName;//舊的IE才有用....
                return;
                if (FileUpload1.HasFile)
                {
                    string file = FileUpload1.FileName;
                    string path = HttpContext.Current.Request.MapPath("~/007.xls");
                    //this.FileUpload1.SaveAs(path + FileUpload1.FileName);
                    this.FileUpload1.SaveAs(path);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('成功!!!!')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('請指定Excel檔案!!')", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RdExcel RdEx = new RdExcel();
            string steErr = string.Empty;
            string path = HttpContext.Current.Request.MapPath("~/007.xls");
            DataTable dt = new DataTable();
            dt = RdEx.dtExcel(path, "工作表1", "No",0, ref steErr);

            Label1.Text = steErr;

            GridView1.DataSource = dt;
            GridView1.DataBind();


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.MapPath("~/007.xls");
            File.Delete(path);//刪除資料
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string strM = "test-100";
            int i = strM.IndexOf("-");
            Label1.Text = strM.Substring(0,i);
        }
    }
}
