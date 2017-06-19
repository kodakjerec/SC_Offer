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
    public partial class SCTypeQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_Count.Visible = false;
                CreateCtl();
            }
        }


        /// <summary>
        /// 產生控制項
        /// </summary>
        private void CreateCtl()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();
            try
            {
                CB.DropDownListBind(ref ddl_ChargeCate, DAO.dtList("EDI", "Charge_Cate"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_ChargeType, DAO.dtList("EDI", "Charge_Type"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_WorkType, DAO.dtList("EDI", "Work_Type"), "Field_Code", "Field_Name", "請選擇", "");
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            DataTable dt = new DataTable();
            DAOOffer DAO = new DAOOffer();
            try
            {
                string WorkName = txb_WorkName.Text.Trim();
                string Object = txb_Object.Text.Trim();
                string ChargeCate = ddl_ChargeCate.SelectedValue.ToString();
                string ChargeType = ddl_ChargeType.SelectedValue.ToString();
                string WorkType = ddl_WorkType.SelectedValue.ToString();
                dt = DAO.dtOfferTypeFee("EDI", WorkName, Object, WorkType, ChargeCate, ChargeType);
                Session["dtOfferTypeFee"] = dt;
                GVBind(dt);
                lbl_Count.Visible = true;
                lbl_Count.Text = "共" + dt.Rows.Count.ToString() + "筆";
                CleanCtrl();
            }
            catch (Exception ex)
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

        /// <summary>
        /// 清空欄位
        /// </summary>
        private void CleanCtrl()
        {
            txb_WorkName.Text = string.Empty;
            txb_Object.Text = string.Empty;
            ddl_ChargeCate.SelectedIndex = 0;
            ddl_ChargeType.SelectedIndex = 0;
            ddl_WorkType.SelectedIndex = 0;
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
                dt = (DataTable)Session["dtOfferTypeFee"];
                gv_List.PageIndex = e.NewPageIndex;
                GVBind(dt);
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
                    string strWorkCode = ((HiddenField)Row.Cells[0].FindControl("hid_WorkCode")).Value;
                    string strObj = ((HiddenField)Row.Cells[0].FindControl("hid_Obj")).Value;
                    Path = string.Format("SCTypeFee.aspx?WorkCode={0}&ObjNo={1}", strWorkCode, strObj);
                    Response.Redirect(Path);
                }
            }
            catch (Exception ex)
            { }
        }

    }
}
