using System;
using System.Data;
using SC_DAO;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class XMSSCData : System.Web.UI.Page
    {
        SC_DAO.XMSSCData xmsscdata = new SC_DAO.XMSSCData();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Form_Contrl
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                string goo_no = txb_goo_no.Text.Trim();
                dt = xmsscdata.XMS_SC_Data("eepdc", goo_no);
                Session["XMSSCData"] = dt;
                GVBind(dt);
                lbl_Count.Visible = true;
                lbl_Count.Text = "共" + dt.Rows.Count.ToString() + "筆";
            }
            catch
            {
            }
        }
        /// <summary>
        /// GridView建置
        /// </summary>
        /// <param name="dt"></param>
        private void GVBind(DataTable dt)
        {
            gv_List.DataSource = dt;
            gv_List.DataBind();
        }
        private void GVBind()
        {
            gv_List.DataSource = (DataTable)Session["XMSSCData"];
            gv_List.DataBind();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //取得最新的DataTable
            DataTable dt = (DataTable)Session["XMSSCData"];

            GridViewRow row = gv_List.Rows[e.NewEditIndex];
            if (dt.Rows[row.DataItemIndex]["stop_date"].ToString() != "")
            {
                Response.Write("合約已截止不可修改");
            }
            else
            {
                gv_List.EditIndex = e.NewEditIndex;
                GVBind();
            }
        }

        protected void gv_List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_List.EditIndex = -1;
            GVBind();
        }

        protected void gv_List_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //取得最新的DataTable
            DataTable dt = (DataTable)Session["XMSSCData"];

            #region 更新欄位資料
            GridViewRow row = gv_List.Rows[e.RowIndex];
            DataRow dr = dt.Rows[row.DataItemIndex];
            dr["contract_date_s"] = ((TextBox)row.FindControl("txb_contract_date_s")).Text.Trim();
            dr["contract_date_e"] = ((TextBox)row.FindControl("txb_contract_date_e")).Text.Trim();
            dr["sc_date_s"] = ((TextBox)row.FindControl("txb_sc_date_s")).Text.Trim();
            dr["sc_date_e"] = ((TextBox)row.FindControl("txb_sc_date_e")).Text.Trim();

            int SuceessCount = xmsscdata.XMS_SC_Data_Update("eepdc", dr);
            if (SuceessCount > 0)
            {
                Response.Write("更新成功，筆數 " + SuceessCount.ToString());
            }
            #endregion
            gv_List.EditIndex = -1;
            GVBind();
        }

        protected void gv_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btn_Stop_date")
            {
                //取得最新的DataTable
                DataTable dt = (DataTable)Session["XMSSCData"];

                //更新截止日期
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_List.Rows[index];
                DataRow dr = dt.Rows[row.DataItemIndex];
                xmsscdata.XMS_SC_Data_Update_StopDate("eepdc", dr);
                btn_Query_Click(sender, e);
                GVBind();
            }
        }

        #endregion

        #region Form_View
        /// <summary>
        /// 換頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                gv_List.PageIndex = e.NewPageIndex;
                GVBind();
            }
            catch
            { }
        }


        /// <summary>
        /// 截止日Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Button btn = ((Button)e.Row.Cells[8].Controls[0]);
                    Label lbl = (Label)e.Row.FindControl("Label8");
                    if (lbl==null)
                        lbl = (Label)e.Row.FindControl("Label9");
                    if (btn.Text != "")
                    {
                        btn.Enabled = false;

                    }
                    else
                    {
                        if (lbl.Text == "Y")
                        {
                            btn.Text = "級配";
                            btn.Enabled = false;
                        }
                        else
                            btn.Text = "截止合約";
                    }
                }
            }
        }
        #endregion


    }
}
