using System;
using System.Data;
using System.Web.UI.WebControls;
using SC_DAO;
using SC_LIB;

namespace SC_Offer
{
    public partial class SCTypeDiscount : System.Web.UI.Page
    {
        DAOOffer DAO = new DAOOffer();

        #region Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateCtl();
            }
        }

        /// <summary>
        /// 產生控制項
        /// </summary>
        private void CreateCtl()
        {
            ControlBind CB = new ControlBind();

            CB.DropDownListBind(ref ddl_SiteNo, DAO.dtList("EDI", "Contract_Ares"), "Field_Code", "Field_Name", "全部", "");
            CB.DropDownListBind(ref ddl_Acci_id, DAO.dtTypeDiscount_Acci_Query("EDI"), "I_acci_seq", "S_acci_Name", "全部", "");
        }
        #endregion

        #region Query
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            DataTable dt = new DataTable();

            string SiteNo = ddl_SiteNo.SelectedValue
                , VendorNo = txb_VendorNo.Text.Trim()
                , AcciId = ddl_Acci_id.SelectedValue;

            dt = DAO.dtTypeDiscount("EDI", SiteNo, VendorNo, AcciId);
            if (dt.Rows.Count > 0)
            {
                OpenDiv(0);
            }
            Session["dtOfferTypeFee"] = dt;
            GVBind(dt);
            Cre_ErrMsg.Text = "共" + dt.Rows.Count.ToString() + "筆";

            CleanCtrl();
        }

        /// <summary>
        /// 開啟新增視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Open_Click(object sender, EventArgs e)
        {
            OpenDiv(1);
        }

        /// <summary>
        /// 開啟刪除視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Del_Open_Click(object sender, EventArgs e)
        {
            OpenDiv(2);
        }

        private void OpenDiv(int Type)
        {
            div_Update.Visible = false;
            div_Add.Visible = false;
            div_Del.Visible = false;
            switch (Type)
            {
                case 0:
                    div_Update.Visible = true; break;
                case 1:
                    div_Add.Visible = true; break;
                case 2:
                    div_Del.Visible = true; break;
            }
        }
        #endregion

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
        /// 清空欄位
        /// </summary>
        private void CleanCtrl()
        {
            ddl_SiteNo.SelectedIndex = 0;
            txb_VendorNo.Text = string.Empty;
        }

        /// <summary>
        /// GridView換頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["dtOfferTypeFee"];
            gv_List.PageIndex = e.NewPageIndex;
            GVBind(dt);
        }

        /// <summary>
        /// Button_批次修改折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_EditDiscount_Header_Click(object sender, EventArgs e)
        {
            string ErrMsg = "";
            string Discount = ((TextBox)gv_List.HeaderRow.FindControl("txb_Discount_Header")).Text;
            foreach (GridViewRow row in gv_List.Rows)
            {
                ((TextBox)row.Cells[4].FindControl("txb_Discount")).Text = Discount;        
            }
            if (ErrMsg == "")
                ErrMsg = "修改完畢，請記得 更新本頁資訊";

            Cre_ErrMsg.Text = ErrMsg.Replace("\n", "<br/>");
        }
        #endregion

        #region Update
        //更新本頁資訊
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string Sn = "";
            string Discount = "";
            string ErrMsg = "";

            foreach (GridViewRow row in gv_List.Rows)
            {
                Sn = ((HiddenField)row.Cells[4].FindControl("hid_Sn")).Value;
                Discount = ((TextBox)row.Cells[4].FindControl("txb_Discount")).Text;
                bool IsOK = DAO.dtTypeDiscount_Update("EDI", Sn, Discount);
                if (IsOK == false)
                {
                    ErrMsg += Sn + "修改失敗" + Environment.NewLine;
                }
            }
            if (ErrMsg == "")
                ErrMsg = "修改完畢，請重新查詢";

            Cre_ErrMsg.Text = ErrMsg.Replace("\n", "<br/>");
        }
        #endregion

        #region ADD
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string VendorNo = txb_VendorNo_Add.Text
                  , G21_Discount = txb_G21_Add.Text
                  , G22_Discount = txb_G22_Add.Text
                  , G23_Discount = txb_G23_Add.Text;
            DAO.dtTypeDiscount_Add("EDI", VendorNo, G21_Discount, G22_Discount, G23_Discount);

            Cre_ErrMsg.Text = VendorNo + " 已經新增三倉三種價格，共9筆費用資料";
        }
        #endregion

        #region DEL
        protected void btn_Del_Click(object sender, EventArgs e)
        {
            string VendorNo = txb_VendorNo_Del.Text;
            bool IsOK = DAO.dtTypeDiscount_Del("EDI", VendorNo);
            if (IsOK)
                Cre_ErrMsg.Text = VendorNo + " 三倉資料都已刪除";
            else
                Cre_ErrMsg.Text = VendorNo + " 刪除失敗或沒有該廠商資料";
        }
        #endregion
    }
}
