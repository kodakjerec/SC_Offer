using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC_DAO;
using SC_LIB;

namespace SC_Offer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox2.Text = "test";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "application/pdf";// "application/octet-stream"; //application/x-zip-compressed
                Response.AddHeader("Content-Disposition", "attachment;filename=Agreement.pdf");
                string filename = Server.MapPath("download/Agreement.pdf");
                Response.TransmitFile(filename);
                Response.Flush();
                Response.End();
                Response.Close();
            }
            catch (Exception ex)
            {
 
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Label1.Text = DateTime.Now.AddMinutes(-5).ToString();
            //Response.Cookies["AAA"].Value = "123";
            //Response.Cookies["Test"].Expires = DateTime.Now.AddDays(10);

            Response.Write("<Script>window.showModalDialog('SCMain.aspx','','DialogWidth:800px,DialogHeight:600px');</Script><base target='_self'>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Check ck = new Check();
            bool bl_ = ck.ChkConDate("10048644", "2014-05-30", "DC1");
            Label1.Text = "";
        }
    }
}
