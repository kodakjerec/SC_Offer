using System;
using ExcelTool;
using System.Data;
using System.Web.UI;
using SC_DAO;
using SC_LIB;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class SCOffer_ToExcel001 : System.Web.UI.Page
    {
        CrExcel crExcel = new CrExcel();
        DAO_ToExcel DAO = new DAO_ToExcel();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //預設日期
                DateTime dt=DateTime.Now;
                txb_Bmonth_CostIncome.Text = dt.AddMonths(-1).AddDays(-dt.Day + 1).ToString("yyyy/MM");
            }

        }

        //SC應收款明細表(for 財務入帳用)
        protected void btn_CostIncome_Click(object sender, EventArgs e)
        {
            btn_CostIncome.Enabled = false;

            string Bmonth = txb_Bmonth_CostIncome.Text;
            Session["dt_CostIncome"]= DAO.dtTypeDiscount_Acci_Query("EDI", Bmonth);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "HideProgressBar();", true);

            GVBind((DataTable)Session["dt_CostIncome"]);
            btn_CostIncome.Enabled = true;
        }
        protected void btn_CostIncome_ToExcel_Click(object sender, EventArgs e)
        {
            btn_CostIncome.Enabled = false;

            string Bmonth = txb_Bmonth_CostIncome.Text;

            DataTable dt1 = (DataTable)Session["dt_CostIncome"];

            //重新查詢
            if (dt1.Rows.Count <= 0)
            {
                dt1 = DAO.dtTypeDiscount_Acci_Query("EDI", Bmonth);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "HideProgressBar();", true);

            //準備輸出
            Session["AssignList"] = dt1;
            string Path = "3PL_download.aspx?TableName=AssignList&FileName=SC應收款明細表";
            Path = "window.open('" + Path + "','作業對象')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", Path, true);

            btn_CostIncome.Enabled = true;
        }

        #region GridView
        /// <summary>
        /// GridView建置
        /// </summary>
        /// <param name="dt"></param>
        private void GVBind(DataTable dt)
        {
            gv_List.DataSource = dt;
            gv_List.DataBind();
        }
        /// <summary>
        /// GridView換頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["dt_CostIncome"];
                gv_List.PageIndex = e.NewPageIndex;
                GVBind(dt);
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
