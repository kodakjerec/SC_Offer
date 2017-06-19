using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC_DAO;
using SC_LIB;

namespace SC_Offer
{
    public partial class SCQueryQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_Count.Visible = false;
                txb_EffectDateS.Text = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy-MM-dd");
                CreateCtrl();
            }
        }

        /// <summary>
        /// 建立控制項
        /// </summary>
        private void CreateCtrl()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();
            try
            {
                CB.DropDownListBind(ref ddl_Area, DAO.dtList("EDI", "Contract_Ares"), "Field_Code", "Field_Name", "請選擇", "");
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            string strArea = string.Empty;
            try
            {
                if (ErrMsg.Length == 0)
                {
                    GetData();
                    txb_Object.Text = string.Empty;
                    txb_OfferNoExt.Text = string.Empty;
                    ddl_Area.SelectedValue = string.Empty;
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

        /// <summary>
        /// I/O資料
        /// </summary>
        public void GetData()
        {
            DataTable dtSCOff = new DataTable();
            DAOOffer DAO = new DAOOffer();
            string strOfferNoExt = txb_OfferNoExt.Text.Trim();
            string strObjNo = txb_Object.Text.Trim();
            string strArea = ddl_Area.SelectedValue.ToString();
            string strDT = txb_EffectDateS.Text;
            dtSCOff = DAO.dtOfferHeader("EDI", strOfferNoExt, strObjNo, strArea, strDT);
            Session["SCOff"] = dtSCOff;
            BindGV(dtSCOff);
            lbl_Count.Visible = true;
            lbl_Count.Text = "共" + dtSCOff.Rows.Count.ToString() + "筆";
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
                dt = (DataTable)Session["SCOff"];
                gv_List.PageIndex = e.NewPageIndex;
                BindGV(dt);
            }
            catch (Exception ex)
            { }
        }

        protected void gv_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument.ToString() == string.Empty)
                {
                    GridViewRow Row = ((GridViewRow)((WebControl)(e.CommandSource)).NamingContainer);
                    string Path = string.Empty;
                    string strOfferNO = ((HiddenField)Row.Cells[0].FindControl("hid_SysOfferNo")).Value;
                    string strObj = ((HiddenField)Row.Cells[0].FindControl("hid_Object")).Value;
                    string strDC = ((HiddenField)Row.Cells[0].FindControl("hid_DC")).Value;
                    Path = string.Format("SCQuoteItem.aspx?No={0}&Obj={1}&DC={2}", strOfferNO, strObj, strDC);
                    Response.Redirect(Path);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
