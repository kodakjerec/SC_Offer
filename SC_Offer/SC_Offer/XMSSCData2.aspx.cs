using System;
using System.Data;
using SC_DAO;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC_LIB;

namespace SC_Offer
{
    public partial class XMSSCData2 : System.Web.UI.Page
    {
        SC_DAO.XMSSCData xmsscdata = new SC_DAO.XMSSCData();
        ControlBind CB = new ControlBind();
        DAOOffer DAO = new DAOOffer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CB.DropDownListBind(ref ddl_S_qthe_SiteNo, DAO.dtList("EDI", "Contract_Ares"), "Field_Code", "Field_Name", "請選擇", "");
                ddl_S_qthe_SiteNo.SelectedIndex = 1;
                txb_DateS.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txb_DateE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        protected void btn_Query_Click(object sender, EventArgs e)
        {
            string site_no = ddl_S_qthe_SiteNo.SelectedValue;
            string sup_no = txb_supdid.Text;
            string dates = txb_DateS.Text;
            string datee = txb_DateE.Text;
            if (site_no == "1")
                site_no = "DC01";
            if (site_no == "2")
                site_no = "DC02";
            if (site_no == "3")
                site_no = "DC03";

            string ErrMsg = "";
            string SuccessMsg = "";

            #region Error_control
            if (dates == "")
                ErrMsg += "起日";
            if (datee == "")
                ErrMsg += "迄日";
            if (ErrMsg != "")
            {
                lbl_Count.Text = "沒輸入 " + ErrMsg;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "HideProgressBar()", true);        
                return;
            }
            #endregion

            //重新產生日結檔
            try
            {
                DateTime Bdate = DateTime.Parse(dates),
                         Edate = DateTime.Parse(datee);

                xmsscdata.SC_rebuild_ardaily01(site_no, dates, datee, sup_no, 0);
                xmsscdata.SC_rebuild_ardaily01(site_no, dates, datee, sup_no, 1);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            if (ErrMsg != "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "alert('失敗 " + ErrMsg + "')", true);
                return;
            }
            else
            {
                SuccessMsg += "重新產生日結檔 完成<br/>";
            }

            if (ErrMsg != "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "alert('失敗 " + ErrMsg + "')", true);
                return;
            }
            else
            {
                SuccessMsg += "複製日結檔 完成<br/>";
                SuccessMsg += "請重新查詢計價金額是否正確<br/>";

            }
            lbl_Count.Text="成功 " + SuccessMsg;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "alert", "HideProgressBar()", true);
                
        }



    }
}
