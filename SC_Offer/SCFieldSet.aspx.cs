using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SC_DAO;
using SC_LIB;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class SCFieldSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowIns(false);
                ShowUpdata(false);
            }
            CreateDll();
        }

        private void CreateDll()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();
            try
            {
                CB.DropDownListBind(ref ddl_Cate, DAO.FieldNameList("EDI"), "cate_Code", "Cate_Name", "請選擇", "");
            }
            catch (Exception ex)
            { }
        }

        private void ShowIns(bool blShow)
        {
            lbl_CateName.Visible = blShow;
            txb_CateName.Visible = blShow;
            btn_Ins.Visible = blShow;
        }

        private void ShowUpdata(bool blShow)
        {
            lbl_Item.Visible = blShow;
            ddl_Item.Visible = blShow;
            lbl_ShowName.Visible = blShow;
            txb_ShowName.Visible = blShow;
            btn_Update.Visible = blShow;
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            ShowIns(true);
            ShowUpdata(false);
        }

        protected void btn_Upd_Click(object sender, EventArgs e)
        {
            ShowIns(false);
            ShowUpdata(true);
        }
    }
}
