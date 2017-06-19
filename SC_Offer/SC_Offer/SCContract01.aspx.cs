using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SC_DAO;

namespace SC_Offer
{
    public partial class SCContract01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Search_Click
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            string strArea = string.Empty;
            try
            {
                strArea = DropDownList_siteno.SelectedValue.ToString();
                if (strArea.Length == 0)
                {
                    ErrMsg += "請選擇物流中心!!" + " \\n";
                }
                if (ErrMsg.Length == 0)
                {
                    GetData();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊部!!')", true);
            }
        }
        #endregion

        #region 抓xms_sc_data
        //get xms_SC_Data
        private void GetData()
        {
            DataTable dtSCOff = new DataTable();
            DAOOffer DAO = new DAOOffer();
            string strstrno = tb_strno.Text.Trim();
            string strgoono = tb_goono.Text.Trim();
            string strArea = DropDownList_siteno.SelectedValue.ToString();
            dtSCOff = DAO.CKConDate("eepdc", strgoono, "", strArea, "");
            Session["SC_xms_sc_data"] = dtSCOff;
            BindGV(dtSCOff);
            lbl_Count.Visible = true;
            lbl_Count.Text = "共" + dtSCOff.Rows.Count.ToString() + "筆";
        }

        //GridView建置
        public void BindGV(DataTable dt)
        {
            gv_List.DataSource = dt;
            gv_List.DataBind();
        }

        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt1 = (DataTable)Session["SC_xms_sc_data"];
            }
        }

        //GridView_Show
        #endregion


    }
}
