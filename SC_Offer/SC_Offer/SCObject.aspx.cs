using System;
using System.Collections.Generic;
using System.Linq;
using SC_DAO;
using SC_LIB;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class SCObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Query_Click(object sender, EventArgs e)
        {
            DataTable dtSup = new DataTable();
            DAOOffer DAO = new DAOOffer();
            string strSupNo = string.Empty;
            string strSupName = string.Empty;
            try 
            {
                strSupNo = txb_ObjNo.Text.Trim();
                strSupName = txb_ObjName.Text.Trim();
                dtSup = DAO.dtSup("DC01", strSupNo, strSupName);
                Session["Sup"] = dtSup;
                BindGV();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊部!!')", true);
            }
        }

        public void BindGV()
        {
            DataTable Dt = new DataTable();
            Dt = (DataTable)Session["Sup"];
            gv_List.DataSource = Dt;
            gv_List.DataBind();
        }

        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_List.PageIndex = e.NewPageIndex;
                BindGV();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        protected void gv_List_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string _txbSupNo = string.Empty;
            try 
            {
                int index = e.NewEditIndex;
                string SupNo = gv_List.Rows[index].Cells[1].Text;
                string SupSn = gv_List.Rows[index].Cells[2].Text;
                _txbSupNo = "opener.document.form1.txb_Object.value='" + SupNo + "';";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "a", _txbSupNo, true);

                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "c", "window.close();", true);
            }
            catch (Exception ex)
            { }
        }
    }
}
