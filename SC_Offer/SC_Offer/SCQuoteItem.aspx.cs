using System;
using System.Collections;
using System.Data;
using SC_DAO;
using SC_LIB;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class SCQuoteItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_Submit.Visible = true;
            if (!IsPostBack)
            {
                DAOOffer DAO = new DAOOffer();
                ViewTable1();
                hid_SysOfferNo.Value = Request.QueryString["No"] == null ? "0000000000000" : Request.QueryString["No"].ToString();
                hid_Obj.Value = Request.QueryString["Obj"] == null ? "XXXX" : Request.QueryString["Obj"].ToString();
                hid_DC.Value = Request.QueryString["DC"] == null ? "XXXX" : Request.QueryString["DC"].ToString();
                if (hid_Obj.Value == "XXXX")
                {
                    Response.Redirect("SCError.aspx");
                }
                else
                {
                    CreateCtr();
                    GetData();
                    hid_Change.Value = "0";
                }
            }
        }

        /// <summary>
        /// 影響範圍TempTable
        /// </summary>
        private void ViewTable1()
        {
            if (ViewState["Area"] == null)
            {
                DataTable dtArea = new DataTable();
                dtArea.Columns.Add("CityID", typeof(string));
                dtArea.Columns.Add("City", typeof(string));
                ViewState["Area"] = dtArea;
            }
        }

        /// <summary>
        /// 取得報價單資料
        /// </summary>
        private void GetData()
        {
            DataTable dtSCList = new DataTable();
            DAOOffer DAO = new DAOOffer();
            string strOfferNo = string.Empty;
            string strDC = string.Empty;
            try
            {
                strOfferNo = hid_SysOfferNo.Value;
                strDC = hid_DC.Value;
                dtSCList = DAO.dtSCList("EDI", strOfferNo, strDC);
                hid_City.Value = dtSCList.Rows[0]["Contract_Ares"] == null ? "" : dtSCList.Rows[0]["Contract_Ares"].ToString();
                hid_XmsSc.Value = dtSCList.Rows[0]["Auto_Ord"] == null ? "" : dtSCList.Rows[0]["Auto_Ord"].ToString();
                ShowData(dtSCList);
                GVBind(dtSCList);
                ViewState["dtSCList"] = dtSCList;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 建控制項
        /// </summary>
        private void CreateCtr()
        {
            ControlBind CB = new ControlBind();
            DAOOffer DAO = new DAOOffer();

            try
            {
                CB.DropDownListBind(ref ddl_Ares, DAO.dtList("EDI", "Contract_Ares"), "Field_Code", "Field_Name", "請選擇", "");
                //CB.DropDownListBind(ref ddl_End, DAO.dtList("EDI", "End_Proc"), "Field_Code", "Field_Name", "請選擇", "");
                CB.RadioBtnListBind(ref rbt_Tax, DAO.dtList("EDI", "Tax_Include"), "Field_Code", "Field_Name");
                CB.DropDownListBind(ref ddl_ObjectType, DAO.dtList("EDI", "Object_Type"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_EndProc, DAO.dtList("EDI", "End_Proc"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_WorkName, DAO.dtTypeFee("EDI", hid_Obj.Value, "", "", ""), "Work_Code", "Work_Name", "請選擇", "");
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// Print資料
        /// </summary>
        /// <param name="dt"></param>
        private void ShowData(DataTable dt)
        {
            lblOfferNoEx.Text = dt.Rows[0]["Offer_No_Ext"] == null ? "" : dt.Rows[0]["Offer_No_Ext"].ToString();
            lblObject.Text = dt.Rows[0]["SupName"] == null ? "" : dt.Rows[0]["SupName"].ToString();
            rbt_Tax.SelectedValue = dt.Rows[0]["Tax_Include"] == null ? "" : dt.Rows[0]["Tax_Include"].ToString();
            //ddl_End.SelectedValue = dt.Rows[0]["End_Proc"] == null ? "" : dt.Rows[0]["End_Proc"].ToString();
            txb_EffectDateS.Text = dt.Rows[0]["Effect_Dates"] == null ? "" : dt.Rows[0]["Effect_Dates"].ToString();
            txb_EffectDateE.Text = dt.Rows[0]["Effect_Datee"] == null ? "" : dt.Rows[0]["Effect_Datee"].ToString();
            //rbt_OT.SelectedValue = dt.Rows[0]["OT_Flg"] == null ? "" : dt.Rows[0]["OT_Flg"].ToString();
            txb_Memo.Text = dt.Rows[0]["HMemo"] == null ? "" : dt.Rows[0]["HMemo"].ToString();
            lbl_DC.Text = dt.Rows[0]["DC"] == null ? "" : dt.Rows[0]["DC"].ToString();
            hid_OTFlg.Value = dt.Rows[0]["OT_Flg"] == null ? "" : dt.Rows[0]["OT_Flg"].ToString();
            rbt_OT.SelectedValue = dt.Rows[0]["OT_Flg"] == null ? "" : dt.Rows[0]["OT_Flg"].ToString();
            rbt_AutoOrder.SelectedValue = dt.Rows[0]["Auto_Ord"] == null ? "" : dt.Rows[0]["Auto_Ord"].ToString();
            Area();
        }

        /// <summary>
        /// 切割影響範圍
        /// </summary>
        private void Area()
        {
            //List<string> Lt = new List<string>();
            DataTable dtTemp = (DataTable)ViewState["Area"];
            string strAreaList = hid_City.Value;
            string strAreaID = string.Empty;
            string strArea = string.Empty;
            for (int i = 0; i < strAreaList.Length; i++)
            {
                ddl_Ares.SelectedValue = strAreaList.Substring(i, 1);
                strAreaID = ddl_Ares.SelectedValue;
                strArea = ddl_Ares.SelectedItem.Text;
                dtTemp.Rows.Add(new object[] { strAreaID, strArea });
            }

            ViewState["Area"] = dtTemp;
            gv_Area.DataSource = dtTemp;
            gv_Area.DataBind();
            ddl_Ares.SelectedValue = String.Empty;
        }

        /// <summary>
        /// GridView建立
        /// </summary>
        /// <param name="Dt"></param>
        private void GVBind(DataTable Dt)
        {
            gv_List.DataSource = Dt;
            gv_List.DataBind();
        }

        /// <summary>
        /// 影響範圍建立
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_Area_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int GVIndex = Convert.ToInt32(e.CommandArgument);//點選的資料行索引
            DataTable dt = (DataTable)ViewState["Area"];
            try
            {
                switch (e.CommandName)
                {
                    case "Delete_Edu":
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (GVIndex == i)
                            {
                                hid_City.Value = string.Empty;
                                dt.Rows.RemoveAt(i);
                                gv_Area.DataSource = dt;
                                gv_Area.DataBind();
                                for (int j = 0; j < dt.Rows.Count; j++)//紀錄影響範圍
                                {
                                    hid_City.Value += dt.Rows[j]["CityID"] == null ? "" : dt.Rows[j]["CityID"].ToString();
                                }
                            }
                        }
                        hid_Change.Value = "1";
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 新增影響範圍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_InsAres_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = (DataTable)ViewState["Area"];
            string strAreaID = ddl_Ares.SelectedValue;
            string strArea = ddl_Ares.SelectedItem.Text;
            string strListArea = string.Empty;
            hid_City.Value = string.Empty;
            string ErrMsg = string.Empty;
            try
            {
                if (strAreaID == String.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('請選擇區域!!')", true);
                    return;
                }
                if (dtTemp.Rows.Count == 0)
                {
                    dtTemp.Rows.Add(new object[] { strAreaID, strArea });

                }
                else
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        strListArea += dtTemp.Rows[i]["CityID"] == null ? "" : dtTemp.Rows[i]["CityID"].ToString();
                    }
                    if (!strListArea.Contains(strAreaID))
                    {
                        dtTemp.Rows.Add(new object[] { strAreaID, strArea });
                    }
                }
                ViewState["Area"] = dtTemp;
                gv_Area.DataSource = dtTemp;
                gv_Area.DataBind();
                ddl_Ares.SelectedValue = String.Empty;

                for (int i = 0; i < dtTemp.Rows.Count; i++)//紀錄影響範圍
                {
                    hid_City.Value += dtTemp.Rows[i]["CityID"] == null ? "" : dtTemp.Rows[i]["CityID"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
            //hid_Change.Value = "1";
        }

        /// <summary>
        /// 建GrideViewd控制項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //ControlBind CB = new ControlBind();
            //DAOOffer DAO = new DAOOffer();
            //DataTable dtObj = (DataTable)ViewState["Obj"];
            //DataTable dtObjType = (DataTable)ViewState["ObjType"];
            //DataTable dtEP = (DataTable)ViewState["EndProc"];

            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        string strWorkCode = ((HiddenField)e.Row.Cells[1].FindControl("hid_WorkCode")).Value;
            //        string strObj = ((HiddenField)e.Row.Cells[6].FindControl("hid_ObjType")).Value;
            //        string strEndProc = ((HiddenField)e.Row.Cells[10].FindControl("hid_EndProc")).Value;
            //        DropDownList ddl_Work = (DropDownList)(e.Row.Cells[1].FindControl("ddl_WorkName"));
            //        DropDownList ddl_Obj = (DropDownList)(e.Row.Cells[6].FindControl("ddl_ObjType"));
            //        DropDownList ddl_End = (DropDownList)(e.Row.Cells[10].FindControl("ddl_EndProc"));
            //        CB.DropDownListBind(ref ddl_Work, dtObj, "Work_Code", "Work_Name", null, "");
            //        CB.DropDownListBind(ref ddl_Obj, dtObjType, "Field_Code", "Field_Name", null, "");
            //        CB.DropDownListBind(ref ddl_End, dtEP, "Field_Code", "Field_Name", null, "");
            //        ddl_Work.SelectedValue = strWorkCode;
            //        ddl_Obj.SelectedValue = strObj;
            //        ddl_End.SelectedValue = strEndProc;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// 作業名稱同步異動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_WorkName_SelectedIndexChanged2(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DAOOffer DAO = new DAOOffer();
            GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
            try
            {
                if (row != null)
                {
                    int i = row.RowIndex;//取得點選row
                    DropDownList dl_WorkName = (DropDownList)gv_List.Rows[i].FindControl("ddl_WorkName");
                    Label lb_Charge_Cate = (Label)gv_List.Rows[i].FindControl("lbl_Charge_Cate");
                    Label lb_Work_Type = (Label)gv_List.Rows[i].FindControl("lbl_Work_Type");
                    Label lb_Charge_Type = (Label)gv_List.Rows[i].FindControl("lbl_Charge_Type");
                    Label lb_Chage_Amount = (Label)gv_List.Rows[i].FindControl("lbl_Chage_Amount");
                    HiddenField hd_Charge_Cate = (HiddenField)gv_List.Rows[i].FindControl("hid_Charge_Cate");
                    HiddenField hd_Work_Type = (HiddenField)gv_List.Rows[i].FindControl("hid_Work_Type");
                    HiddenField hd_Charge_Type = (HiddenField)gv_List.Rows[i].FindControl("hid_Charge_Type");
                    string strWorkCode = dl_WorkName.SelectedValue.ToString();
                    string strObjectNo = hid_Obj.Value;

                    dt = DAO.dtTypeFee("EDI", strObjectNo, strWorkCode, "", "");
                    lb_Charge_Cate.Text = dt.Rows[0]["ChargeCateName"] == null ? "" : dt.Rows[0]["ChargeCateName"].ToString();
                    lb_Work_Type.Text = dt.Rows[0]["WorkTypeName"] == null ? "" : dt.Rows[0]["WorkTypeName"].ToString();
                    lb_Charge_Type.Text = dt.Rows[0]["ChargeTypeName"] == null ? "" : dt.Rows[0]["ChargeTypeName"].ToString();
                    lb_Chage_Amount.Text = dt.Rows[0]["Chage_amount"] == null ? "" : dt.Rows[0]["Chage_amount"].ToString();
                    hd_Charge_Cate.Value = dt.Rows[0]["Charge_Cate"] == null ? "" : dt.Rows[0]["Charge_Cate"].ToString();
                    hd_Work_Type.Value = dt.Rows[0]["Work_Type"] == null ? "" : dt.Rows[0]["Work_Type"].ToString();
                    hd_Charge_Type.Value = dt.Rows[0]["Charge_Type"] == null ? "" : dt.Rows[0]["Charge_Type"].ToString(); ;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            Check ck = new Check();
            bool blSCDei = false;
            bool blXMS = true;
            string ErrMsg = string.Empty;
            string strOffNo = lblOfferNoEx.Text.Trim();
            string strSysNo = hid_SySNo.Value;
            string strArea = hid_DC.Value;
            string strDC = string.Empty;

            try
            {
                string strWorkCode = ddl_WorkName.SelectedValue;
                string strWorkName = ddl_WorkName.SelectedItem.Text;
                string strEndProc = ddl_EndProc.SelectedValue;
                string strObjectType = ddl_ObjectType.SelectedValue;
                string strObjectCode = txb_ObjectCode.Text.Trim();
                string strOfferQty = txb_OfferQty.Text.Trim();
                string strCtrDateS = txb_ContractDateS.Text.Trim();
                string strCtrDateE = txb_ContractDateE.Text.Trim();
                string strSCDateS = txb_ScDateS.Text.Trim();
                string strSCDateE = txb_ScDateE.Text.Trim();
                string strChargeCate = hid_ChargeCate.Value;
                string strWorkType = hid_WorkType.Value;
                string strChargeType = hid_ChargeType.Value;
                string strChageAmount = lbl_ChageAmount.Text;
                string strMemo = txb_MemoD.Text.Trim();
                string StopDate = txb_StopDate.Text.Trim();
                string StopFlag = string.Empty;
                string AutoOrd = hid_XmsSc.Value.ToString();
                string DC2XD_S = txb_DC2XD_DateS.Text.Trim();
                string DC2XD_E = txb_DC2XD_DateE.Text.Trim();
                string AmountDateS = txb_AmountDateS.Text.Trim();
                string AmountDateE = txb_AmountDateE.Text.Trim();

                switch (strArea)
                {
                    case "1":
                        strDC = "DC1";
                        break;
                    case "2":
                        strDC = "DC2";
                        break;
                    case "3":
                        strDC = "DC3";
                        break;
                    default:
                        strDC = string.Empty;
                        break;

                }
                if (StopDate == string.Empty)
                {
                    StopFlag = "N";
                    StopDate = null;
                }
                else
                {
                    StopFlag = "Y";
                }


                if (strWorkCode.Length == 0)
                {
                    ErrMsg += "請選擇作業名稱!!!" + " \\n";
                }
                if (strEndProc.Length == 0)
                {
                    ErrMsg += "請選擇後續處理!!!" + " \\n";
                }
                if (strObjectType.Length == 0)
                {
                    ErrMsg += "請選擇作業商品!!!" + " \\n";
                }
                if (strObjectCode.Length == 0)
                {
                    ErrMsg += "請填寫商品代碼!!!" + " \\n";
                }
                if (strOfferQty.Length == 0)
                {
                    ErrMsg += "請填寫數量!!!" + " \\n";
                }
                if (strCtrDateS.Length == 0)
                {
                    ErrMsg += "請填寫合約起日!!!" + " \\n";
                }
                if (strCtrDateE.Length == 0)
                {
                    ErrMsg += "請填寫合約迄日!!!" + " \\n";
                }
                //if (AmountDateS.Length == 0)
                //{
                //    ErrMsg += "請填寫計價期間起日!!!" + " \\n";
                //}
                //if (AmountDateE.Length == 0)
                //{
                //    ErrMsg += "請填寫計價期間迄日!!!" + " \\n";
                //}
                //if (strSCDateS.Length == 0)
                //{
                //    ErrMsg += "請填寫SC補貨起日!!!" + " \\n";
                //}
                //if (strSCDateE.Length == 0)
                //{
                //    ErrMsg += "請填寫SC補貨迄日!!!" + " \\n";
                //}
                if (ErrMsg.Length == 0)
                {
                    if (ck.strSEDate(strCtrDateS, strCtrDateE))
                    {
                        ErrMsg += "合約起日不可大於合約迄日!!!" + " \\n";
                    }
                    if (strSCDateS != string.Empty || strSCDateE != string.Empty)
                    {
                        if (ck.strSEDate(strSCDateS, strSCDateE))
                        {
                            ErrMsg += "SC補貨起日不可大於SC補貨迄日!!!" + " \\n";
                        }
                    }
                    if (DC2XD_S != string.Empty || DC2XD_E != string.Empty)
                    {
                        if (ck.strSEDate(DC2XD_S, DC2XD_E))
                        {
                            ErrMsg += "DC2XD起日不可大於DC2XD迄日!!!" + " \\n";
                        }
                    }
                    if (AmountDateS != string.Empty && AmountDateE != string.Empty)
                    {
                        if (ck.strSEDate(AmountDateS, AmountDateE))
                        {
                            ErrMsg += "計價期間起日不可大於計價期間迄日!!!" + " \\n";
                        }
                    }

                    if (strCtrDateS != string.Empty && strSCDateS != string.Empty)
                    {
                        if (ck.strSEDate(strCtrDateS, strSCDateS))
                        {
                            ErrMsg += "合約起日不可大於SC銷補起日!!!" + " \\n";
                        }
                    }

                    if (strSCDateS != string.Empty && strCtrDateE != string.Empty )
                    {
                        if (ck.strSEDate(strSCDateS, strCtrDateE))
                        {
                            ErrMsg += "SC銷補起日不可大於合約迄日!!" + " \\n";
                        }
                    }

                    if (strSCDateE != string.Empty && DC2XD_S != string.Empty)
                    {
                        string DC2DXDateSDef = (Convert.ToDateTime(strSCDateE).AddDays(1)).ToString();
                        if (ck.strSEDate(DC2DXDateSDef, DC2XD_S))
                        {
                            ErrMsg += "DC2XD起日需大於SC銷補迄日一日以上!!!" + " \\n";
                        }
                    }
                }
                if (ErrMsg.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }
                blSCDei = DAO.UpSCDei("EDI", strSysNo, strChargeCate, strWorkCode, strWorkType, strWorkName, strChargeType, strChageAmount, strObjectType, strObjectCode, strOfferQty, strMemo, strEndProc, strCtrDateS, strCtrDateE, strSCDateS, strSCDateE, StopDate, DC2XD_S, DC2XD_E, AmountDateS, AmountDateE);
                if (strObjectType == "0" && blSCDei)
                {
                    blXMS = DAO.UpXnsSCData("EEPDC", strDC, strObjectCode, strCtrDateS, strCtrDateE, strSCDateS, strSCDateE, StopFlag, StopDate,DC2XD_S,DC2XD_E);
                }
                //if (blSCDei && blXMS)
                //{
                //    //Response.Write("<script>alert('更新成功!'); parent.location.href='SCMain.aspx'; </script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('更新成功!!')", true);
                //}

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Del_Click(object sender, EventArgs e)
        {
            DAOOffer DAO = new DAOOffer();
            bool DelSec = false;
            try
            {
                string strSysNo = hid_SySNo.Value;
                DelSec = DAO.DelSCDetail("EDI", strSysNo);
                if (DelSec)
                {
                    //Response.Write("<script>alert('刪除成功!'); parent.location.href='SCMain.aspx'; </script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('刪除成功!'); ", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('刪除失敗!!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SCQueryQuote.aspx");
        }

        /// <summary>
        /// 列印報價單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Print_Click(object sender, EventArgs e)
        {
            string strObj = hid_Obj.Value;
            string strSCNO = hid_SysOfferNo.Value;
            string strDC = hid_DC.Value;
            string Path = "http://192.168.110.70/Smart-Query//squery.aspx?GUID=&SQ_AutoLogout=true&filename=WMSA004&path=DRP&RPT=WMSA004_Rpt1&Object_No=" + strObj + "&offer_No_Ext=" + strSCNO + "&Contract_Ares=" + strDC;
            Response.Write("<script>window.open('" + Path + "' ,'','height=600,width=800,scrollbars=yes,menubar=no,location=no');</script>");
            //Response.Redirect("http://tw.yahoo.com");
            //Response.Write("<script>alert('更新成功!'); location.href='http://tw.yahoo.com'; </script>");
        }

        protected void btn_UpdateHD_Click(object sender, EventArgs e)
        {
            string strChgHer = hid_Change.Value;
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            Check ck = new Check();
            string ErrMsg = string.Empty;
            bool blUpHead = false;
            try
            {
                if (strChgHer == "1")//判別表頭有異動
                {
                    string OfferNo = hid_SysOfferNo.Value;
                    string Contract_Ares = hid_City.Value;//檢核地區
                    string Tax_Include = rbt_Tax.SelectedValue;
                    //string End_Proc = ddl_End.SelectedValue;
                    string Effect_Dates = txb_EffectDateS.Text.Trim();//檢核起始
                    string Effect_Datee = txb_EffectDateE.Text.Trim();
                    string Memo = txb_Memo.Text.Trim();
                    string strDC = hid_DC.Value;

                    string strOT=rbt_OT.SelectedValue;
                    string strAO=rbt_AutoOrder.SelectedValue;
                    #region 檢核
                    if (Contract_Ares.Length == 0)
                    {
                        ErrMsg += "請加入影響範圍!!!" + " \\n";
                    }
                    if (Effect_Dates.Length == 0 || Effect_Datee.Length == 0)
                    {
                        ErrMsg += "合約有效期不可為空!!!" + " \\n";
                    }

                    if (ErrMsg.Length == 0)
                    {
                        bool ckEfDate = ck.strSEDate(Effect_Dates, Effect_Datee);
                        if (ckEfDate)
                        {
                            ErrMsg += "報價有效期起日不可大於迄日!!" + " \\n";
                        }
                    }
                    if (ErrMsg.Length > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                        return;
                    }
                    #endregion

                    blUpHead = DAO.UpSCHead("EDI", Contract_Ares, Tax_Include, Effect_Dates, Effect_Datee, OfferNo, Memo, strDC, strOT, strAO);
                    if (blUpHead)
                    {
                        Response.Write("<script>alert('更新成功!'); parent.location.href='SCMain.aspx'; </script>");
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('更新失敗!!!')", true);
            }
        }

        protected void gv_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dtSCList = new DataTable();
            DataTable dtTemp = new DataTable();

            try
            {
                if (e.CommandArgument.ToString() == string.Empty)
                {
                    dtSCList = (DataTable)ViewState["dtSCList"];
                    GridViewRow Row = ((GridViewRow)((WebControl)(e.CommandSource)).NamingContainer);
                    hid_SySNo.Value = ((HiddenField)Row.Cells[0].FindControl("hid_SysNo")).Value;
                    string strSysNo = hid_SySNo.Value.ToString();
                    DataRow[] rows = dtSCList.Select("SysNO='" + strSysNo + "'");
                    dtTemp = dtSCList.Clone();
                    foreach (DataRow row in rows)
                    {
                        dtTemp.ImportRow(row);
                    }
                    if (ddl_WorkName.Items.FindByValue(dtTemp.Rows[0]["Work_Code"] == null? "" : dtTemp.Rows[0]["Work_Code"].ToString()) !=null )
                    {
                        ddl_WorkName.SelectedValue = dtTemp.Rows[0]["Work_Code"] == null ? "" : dtTemp.Rows[0]["Work_Code"].ToString();
                    }

                    lbl_ChargeCate.Text = dtTemp.Rows[0]["Charge_CateN"] == null ? "" : dtTemp.Rows[0]["Charge_CateN"].ToString();
                    hid_ChargeCate.Value = dtTemp.Rows[0]["Charge_Cate"] == null ? "" : dtTemp.Rows[0]["Charge_Cate"].ToString();
                    lbl_WorkType.Text = dtTemp.Rows[0]["Work_TypeN"] == null ? "" : dtTemp.Rows[0]["Work_TypeN"].ToString();
                    hid_WorkType.Value = dtTemp.Rows[0]["Work_Type"] == null ? "" : dtTemp.Rows[0]["Work_Type"].ToString();
                    lbl_ChargeType.Text = dtTemp.Rows[0]["Charge_TypeN"] == null ? "" : dtTemp.Rows[0]["Charge_TypeN"].ToString();
                    hid_ChargeType.Value = dtTemp.Rows[0]["Charge_Type"] == null ? "" : dtTemp.Rows[0]["Charge_Type"].ToString();
                    lbl_ChageAmount.Text = dtTemp.Rows[0]["Chage_Amount"] == null ? "" : dtTemp.Rows[0]["Chage_Amount"].ToString();
                    ddl_EndProc.SelectedValue = dtTemp.Rows[0]["End_Proc"] == null ? "" : dtTemp.Rows[0]["End_Proc"].ToString();
                    ddl_ObjectType.SelectedValue = dtTemp.Rows[0]["Object_Type"] == null ? "" : dtTemp.Rows[0]["Object_Type"].ToString();
                    txb_ObjectCode.Text = dtTemp.Rows[0]["Object_Code"] == null ? "" : dtTemp.Rows[0]["Object_Code"].ToString();
                    txb_OfferQty.Text = dtTemp.Rows[0]["Offer_Qty"] == null ? "" : dtTemp.Rows[0]["Offer_Qty"].ToString();
                    txb_ContractDateS.Text = dtTemp.Rows[0]["Contract_Dates"] == null ? "" : dtTemp.Rows[0]["Contract_Dates"].ToString();
                    txb_ContractDateE.Text = dtTemp.Rows[0]["Contract_Datee"] == null ? "" : dtTemp.Rows[0]["Contract_Datee"].ToString();
                    txb_ScDateS.Text = dtTemp.Rows[0]["Sc_date_S"] == null ? "" : dtTemp.Rows[0]["Sc_date_S"].ToString();
                    txb_ScDateE.Text = dtTemp.Rows[0]["Sc_date_E"] == null ? "" : dtTemp.Rows[0]["Sc_date_E"].ToString();
                    txb_DC2XD_DateS.Text = dtTemp.Rows[0]["dc2xd_date_s"] == null ? "" : dtTemp.Rows[0]["dc2xd_date_s"].ToString();
                    txb_DC2XD_DateE.Text = dtTemp.Rows[0]["dc2xd_date_e"] == null ? "" : dtTemp.Rows[0]["dc2xd_date_e"].ToString();
                    txb_MemoD.Text = dtTemp.Rows[0]["Memo"] == null ? "" : dtTemp.Rows[0]["Memo"].ToString();
                    txb_StopDate.Text = dtTemp.Rows[0]["stop_date"] == null ? "" : string.Format("{0:yyyy-MM-dd}", dtTemp.Rows[0]["stop_date"]);
                    txb_AmountDateS.Text = dtTemp.Rows[0]["AmountDateS"] == null ? "" : string.Format("{0:yyyy-MM-dd}", dtTemp.Rows[0]["AmountDateS"]);
                    txb_AmountDateE.Text = dtTemp.Rows[0]["AmountDateE"] == null ? "" : string.Format("{0:yyyy-MM-dd}",dtTemp.Rows[0]["AmountDateE"]);
                    txb_ContractDateS.Enabled = false;
                    txb_ScDateS.Enabled = false;
                    //txb_DC2XD_DateS.Enabled = false;
                    //txb_AmountDateS.Enabled = false;
                    btn_Submit.Attributes.Add("style", "display:none");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_List.PageIndex = e.NewPageIndex;
                DataTable Dt = (DataTable)ViewState["dtSCList"];
                gv_List.DataSource = Dt;
                gv_List.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }


        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            Check ck = new Check();
            bool blSCDei = false;
            bool blXMS = true;
            string ErrMsg = string.Empty;
            string strOffNo = lblOfferNoEx.Text.Trim();
            //string strSysNo = hid_SySNo.Value;
            string strArea = hid_DC.Value;
            string strDC = string.Empty;
            string strObjectNo = hid_Obj.Value.ToString();
            try
            {
                string strOfferNo=lblOfferNoEx.Text;
                string strWorkCode = ddl_WorkName.SelectedValue;
                string strWorkName = ddl_WorkName.SelectedItem.Text;
                string strEndProc = ddl_EndProc.SelectedValue;
                string strObjectType = ddl_ObjectType.SelectedValue;
                string strObjectCode = txb_ObjectCode.Text.Trim();
                string strOfferQty = txb_OfferQty.Text.Trim();
                string strCtrDateS = txb_ContractDateS.Text.Trim();
                string strCtrDateE = txb_ContractDateE.Text.Trim();
                string strSCDateS = txb_ScDateS.Text.Trim();
                string strSCDateE = txb_ScDateE.Text.Trim();
                string strChargeCate = hid_ChargeCate.Value;
                string strWorkType = hid_WorkType.Value;
                string strChargeType = hid_ChargeType.Value;
                string strChageAmount = lbl_ChageAmount.Text;
                string strMemo = txb_MemoD.Text.Trim();
                string StopDate = txb_StopDate.Text.Trim();
                string StopFlag = string.Empty;
                string CreatDate = DateTime.Now.ToString();
                string Dc2Xd_DateS = txb_DC2XD_DateS.Text.Trim();
                string Dc2Xd_DateE = txb_DC2XD_DateE.Text.Trim();
                string AmountDateS = txb_AmountDateS.Text.Trim();
                string AmountDateE = txb_AmountDateE.Text.Trim();
                string strOTFlg = hid_OTFlg.Value;
                string strOnceOrder = string.Empty;
                string strAutoOrder = hid_XmsSc.Value.ToString()=="0"?"Y":"N";
                switch (strArea)//倉別
                {
                    case "1":
                        strDC = "DC1";
                        break;
                    case "2":
                        strDC = "DC2";
                        break;
                    case "3":
                        strDC = "DC3";
                        break;
                    default:
                        strDC = string.Empty;
                        break;

                }
                if (StopDate == string.Empty)//判別停止日
                {
                    StopFlag = "N";
                    StopDate = null;
                }
                else
                {
                    StopFlag = "Y";
                }
                if (strOTFlg == "0")
                {
                    strOnceOrder = "N";
                }
                else
                {
                    strOnceOrder = "Y";
                }

                if (strWorkCode.Length == 0)
                {
                    ErrMsg += "請選擇作業名稱!!!" + " \\n";
                }
                if (strEndProc.Length == 0)
                {
                    ErrMsg += "請選擇後續處理!!!" + " \\n";
                }
                if (strObjectType.Length == 0)
                {
                    ErrMsg += "請選擇作業商品!!!" + " \\n";
                }
                if (strObjectCode.Length == 0)
                {
                    ErrMsg += "請填寫商品代碼!!!" + " \\n";
                }
                if (strOfferQty.Length == 0)
                {
                    ErrMsg += "請填寫數量!!!" + " \\n";
                }
                if (strCtrDateS.Length == 0)
                {
                    ErrMsg += "請填寫合約起日!!!" + " \\n";
                }
                if (strCtrDateE.Length == 0)
                {
                    ErrMsg += "請填寫合約迄日!!!" + " \\n";
                }
                if (strSCDateS.Length == 0)
                {
                    ErrMsg += "請填寫SC補貨起日!!!" + " \\n";
                }
                if (strSCDateE.Length == 0)
                {
                    ErrMsg += "請填寫SC補貨迄日!!!" + " \\n";
                }
                if (ErrMsg.Length == 0)
                {
                    if (ck.strSEDate(strCtrDateS, strCtrDateE))
                    {
                        ErrMsg += "合約起日不可大於合約迄日!!!" + " \\n";
                    }
                    if (strSCDateS.Length != 0)
                    {
                        if (ck.strSEDate(strSCDateS, strSCDateE))
                        {
                            ErrMsg += "SC補貨起日不可大於SC補貨迄日!!!" + " \\n";
                        }
                    }
                    if (Dc2Xd_DateS.Length != 0)
                    {
                        if (ck.strSEDate(Dc2Xd_DateS, Dc2Xd_DateE))
                        {
                            ErrMsg += "DC2XD起日不可大於DC2XD迄日!!!" + " \\n";
                        }
                    }
                    if (AmountDateS.Length != 0)
                    {
                        if (ck.strSEDate(AmountDateS, AmountDateE))
                        {
                            ErrMsg += "計價期間起日不可大於迄日!!!" + " \\n";
                        }
                    }

                    if (strCtrDateS.Length != 0 && strSCDateS.Length != 0)
                    {
                        if (ck.strSEDate(strCtrDateS, strSCDateS))
                        {
                            ErrMsg += "合約起日不可大於SC銷補起日!!!" + " \\n";
                        }
                    }
                    if (Dc2Xd_DateS.Length != 0 && strSCDateE.Length != 0)
                    {
                        string DC2DXDateSDef = (Convert.ToDateTime(strSCDateE).AddDays(1)).ToString();
                        if (ck.strSEDate(DC2DXDateSDef, Dc2Xd_DateS))
                        {
                            ErrMsg += "DC2XD起日需大於SC銷補迄日一日以上!!!" + " \\n";
                        }
                    }
                    if (strCtrDateE.Length != 0 && strSCDateS.Length != 0)
                    {
                        if (ck.strSEDate(strSCDateS, strCtrDateE))
                        {
                            ErrMsg += "SC銷補起日不可大於合約迄日!!!" + " \\n";
                        }
                    }
                }
                if (ErrMsg.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }
                if (strSCDateS.Length==0)
                {
                    blSCDei = DAO.InsItem("EDI", strOffNo, strOffNo, strObjectNo, strChargeCate, strWorkCode, strWorkName, strChargeType, strChageAmount, strObjectType, strObjectCode, strOfferQty, CreatDate, strWorkType, strMemo, strArea, strEndProc, strCtrDateS, strCtrDateE, AmountDateS, AmountDateE);
                }
                else
                {
                    blSCDei = DAO.InsItem("EDI", strOffNo, strOffNo, strObjectNo, strChargeCate, strWorkCode, strWorkName, strChargeType, strChageAmount, strObjectType, strObjectCode, strOfferQty, CreatDate, strWorkType, strMemo, strArea, strEndProc, strCtrDateS, strCtrDateE, strSCDateS, strSCDateE, Dc2Xd_DateS, Dc2Xd_DateE, AmountDateS, AmountDateE);
                }

                if (strObjectType == "0" )
                {
                    if (Dc2Xd_DateS.Length == 0)
                    {
                        blXMS = DAO.InsXmsSCData("EEPDC", strDC, strObjectCode, strCtrDateS, strCtrDateE, strSCDateS, strSCDateE, strOnceOrder, strAutoOrder, strOfferNo);
                    }
                    else 
                    {
                        blXMS = DAO.InsXmsSCData("EEPDC", strDC, strObjectCode, strCtrDateS, strCtrDateE, strSCDateS, strSCDateE, strOnceOrder, Dc2Xd_DateS, Dc2Xd_DateE, strAutoOrder, strOfferNo);
                    }
                }
                if (blSCDei && blXMS)
                {
                    Response.Write("<script>alert('新增成功!!!'); parent.location.href='SCMain.aspx'; </script>");
                }
                else
                {
                    Response.Write("<script>alert('新增失敗!!!'); parent.location.href='SCMain.aspx'; </script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        protected void ddl_WorkName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DAOOffer DAO = new DAOOffer();
                string strObjectNo = hid_Obj.Value;
                string strWorkCode = ddl_WorkName.SelectedValue;
                dt = DAO.dtTypeFee("EDI", strObjectNo, strWorkCode, "", "");
                lbl_ChargeCate.Text = dt.Rows[0]["ChargeCateName"] == null ? "" : dt.Rows[0]["ChargeCateName"].ToString();
                lbl_WorkType.Text = dt.Rows[0]["WorkTypeName"] == null ? "" : dt.Rows[0]["WorkTypeName"].ToString();
                lbl_ChargeType.Text = dt.Rows[0]["ChargeTypeName"] == null ? "" : dt.Rows[0]["ChargeTypeName"].ToString();
                lbl_ChageAmount.Text = dt.Rows[0]["Chage_amount"] == null ? "" : dt.Rows[0]["Chage_amount"].ToString();
                hid_ChargeCate.Value = dt.Rows[0]["Charge_Cate"] == null ? "" : dt.Rows[0]["Charge_Cate"].ToString();
                hid_WorkType.Value = dt.Rows[0]["Work_Type"] == null ? "" : dt.Rows[0]["Work_Type"].ToString();
                hid_ChargeType.Value = dt.Rows[0]["Charge_Type"] == null ? "" : dt.Rows[0]["Charge_Type"].ToString();
                txb_MemoD.Text = dt.Rows[0]["Memo"] == null ? "" : dt.Rows[0]["Memo"].ToString();

            }
            catch (Exception ex)
            {
            }
        }

        protected void btn_Del_Click1(object sender, EventArgs e)
        {
            try 
            {
                bool DelSec = false;
                
                ArrayList arr_index = new ArrayList();
                foreach (GridViewRow row in gv_List.Rows)
                {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("CheckBox1");
                    if (chk.Checked)
                    {
                        string no = ((HiddenField)row.Cells[0].FindControl("hid_SysNo")).Value;
                        arr_index.Add(no);                       
                    }
                }
                if (arr_index.Count == 0)
                {
                    ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "alert('請勾選欲刪除資料!!!')", true);
                    return;
                }
                else
                {
                    int Count = 1;
                    for (int i = 0; i < arr_index.Count; i++)
                    {
                        DAOOffer DAO = new DAOOffer();

                        string strSysNo = arr_index[i] == null ? "" : arr_index[i].ToString();

                        //ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "alert('pass!!!')", true);

                        DelSec = DAO.DelSCDetail("EDI", strSysNo);
                        if (!DelSec)
                        {
                            ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "alert('第" + Count + "筆資料刪除失敗!!!')", true);
                        }
                        Count++;
                    }
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('刪除成功!');", true);
                    GetData();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊部!');", true);
            }
        }

    }
}
