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
    public partial class SCObjGoo : System.Web.UI.Page
    {
        private string strObj = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strObj = Request.QueryString["Obj"] == null ? "0000000000000" : Request.QueryString["Obj"].ToString();
                DataTable dtSup = new DataTable();
                dtSup = GetDate();
                if (dtSup.Rows.Count > 0)
                {
                    lbl_Obj.Text = dtSup.Rows[0]["SupName"] == null ? "" : dtSup.Rows[0]["SupName"].ToString();
                }
            }
        }

        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                gv_List.PageIndex = e.NewPageIndex;
                BindGv();
            }
            catch (Exception ex)
            { }
        }

        protected void btn_Query_Click(object sender, EventArgs e)
        {
            DataTable dtItemList = new DataTable();
            try
            {
                dtItemList = GetDate();
                ViewState["ItemList"] = dtItemList;
                BindGv();
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable GetDate()
        {
            DataTable dtObj = new DataTable();
            DAOOffer DAO = new DAOOffer();
            string strItemID = txb_ItemID.Text.Trim();
            try
            {
                dtObj = DAO.dtSup("DC01", strObj, "", strItemID);
            }
            catch (Exception ex)
            {
            }
            return dtObj;
        }

        private void BindGv()
        {
            DataTable dt = (DataTable)ViewState["ItemList"];
            gv_List.DataSource = dt;
            gv_List.DataBind();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            DataTable dtObjItem = (DataTable)ViewState["ObjItem"];
            bool blItem = true;
            try
            {
                for (int i = 0; i < gv_List.Rows.Count; i++)//判別勾選更新資料
                {
                    CheckBox chk = (CheckBox)gv_List.Rows[i].Cells[0].FindControl("CheckBox1");
                    string strItemID = string.Empty;
                    string strItemName = string.Empty;
                    if (chk.Checked)
                    {
                        strItemID = gv_List.Rows[i].Cells[1].Text;
                        strItemName = gv_List.Rows[i].Cells[2].Text;
                        for (int j = 0; j < gv_AddList.Rows.Count; j++)
                        {
                            string strAddItem = gv_AddList.Rows[i].Cells[0].Text;
                            if (strAddItem == strItemID)
                            {
                                blItem = false;
                            }
                        }
                        if (blItem)
                        {
                            dtObjItem.Rows.Add(new object[] { strItemID, strItemName });
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void ViewTable()
        {
            try
            {
                if (ViewState["ObjItem"] == null)
                {
                    DataTable dtItem = new DataTable();
                    dtItem.Columns.Add("ItemID", typeof(string));//貨號
                    dtItem.Columns.Add("ItemName", typeof(string));//品名
                    ViewState["ObjItem"] = dtItem;
                }
            }
            catch (Exception ex)
            {
            }
        }


        protected void gv_AddList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int GVIndex = Convert.ToInt32(e.CommandArgument);//點選的資料行索引
            DataTable dt = (DataTable)ViewState["ObjItem"];
            try
            {
                switch (e.CommandName)
                {
                    case "Delete_Edu":
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (GVIndex == i)
                            {
                                dt.Rows.RemoveAt(i);
                                gv_AddList.DataSource = dt;
                                gv_AddList.DataBind();
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try 
            {

            }
            catch (Exception ex)
            {
            }
        }


    }
}
