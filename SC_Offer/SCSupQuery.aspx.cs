using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SC_DAO;
using SC_LIB;

namespace SC_Offer
{
    public partial class SCSupQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_Count.Visible = false;
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊部!!')", true);
            }
        }

        /// <summary>
        /// I/O資料
        /// </summary>
        public void GetData()
        {
            DAOOffer DAO = new DAOOffer();
            DataTable dtSupInf = new DataTable();
            string strSupId = string.Empty;
            string strSupName = string.Empty;
            strSupId = txb_SupID.Text.Trim();
            strSupName = txb_SupName.Text.Trim();
            dtSupInf = DAO.dtSupInf("EDI", strSupId, strSupName);
            int Count = dtSupInf.Rows.Count;
            if (Count == 0)
            {
                lbl_Count.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('查無資料!!')", true);
            }
            else
            {
                lbl_Count.Visible = true;
                lbl_Count.Text = "共"+Count.ToString()+"筆";
                Session["SupInf"] = dtSupInf;
                BindGV(dtSupInf);
            }
        }

        /// <summary>
        /// GridView建置
        /// </summary>
        /// <param name="dt"></param>
        public void BindGV(DataTable dt)
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
                dt = (DataTable)Session["SupInf"];
                gv_List.PageIndex = e.NewPageIndex;
                BindGV(dt);
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 點選GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument.ToString() == string.Empty)
                {
                    if (e.CommandName == "Select")
                    {
                        GridViewRow Row = ((GridViewRow)((WebControl)(e.CommandSource)).NamingContainer);
                        string SupID = ((HiddenField)Row.Cells[0].FindControl("hid_SupSn")).Value;
                        string Path = string.Empty;
                        Path = string.Format("SCSupSet.aspx?SupNo={0}", SupID);
                        Response.Redirect(Path);
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

    }
}
