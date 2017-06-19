using System;
using System.IO;
using System.Data;
using SC_DAO;
using SC_LIB;
using ExcelTool;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC_Offer
{
    public partial class SCQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewTable1();
                CrtDDL1();
                pnl_Item.Visible = false;
                txb_EffectDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_EffectDateE.Text = txb_EffectDateS.Text;
            }
        }

        /// <summary>
        /// 建置影響範圍TempTable
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
        /// 建置報價細項TempTable
        /// </summary>
        private void ViewTable2()
        {
            if (ViewState["OfferItem"] == null)
            {
                DataTable dtItem = new DataTable();
                dtItem.Columns.Add("Offer_No_Ext", typeof(string));//外部報價單號
                dtItem.Columns.Add("Offer_No", typeof(string));//報價系統單號
                dtItem.Columns.Add("Object_No", typeof(string));//對象
                dtItem.Columns.Add("Charge_Cate", typeof(string));//作業大類
                dtItem.Columns.Add("Charge_CateName", typeof(string));//作業大類名稱
                dtItem.Columns.Add("Work_Code", typeof(string));//作業系統碼
                dtItem.Columns.Add("Work_Name", typeof(string));//作業名稱
                dtItem.Columns.Add("Charge_Type", typeof(string));//收費類型
                dtItem.Columns.Add("Charge_TypeName", typeof(string));//收費類型名稱
                dtItem.Columns.Add("Chage_amount", typeof(string));//應對金額
                dtItem.Columns.Add("Object_Type", typeof(string));//作業商品
                dtItem.Columns.Add("Object_TypeName", typeof(string));//作業商品名稱
                dtItem.Columns.Add("Object_Code", typeof(string));//作業商品代碼
                dtItem.Columns.Add("Offer_Qty", typeof(string));//作業量
                dtItem.Columns.Add("Work_Type", typeof(string));//作業類型代碼
                dtItem.Columns.Add("Work_TypeName", typeof(string));//作業類型名稱
                dtItem.Columns.Add("Memo", typeof(string));//備註
                dtItem.Columns.Add("End_Proc", typeof(string));//後續處理
                dtItem.Columns.Add("Contract_Dates", typeof(string));//合約起日
                dtItem.Columns.Add("Contract_Datee", typeof(string));//合約迄日
                dtItem.Columns.Add("Sc_date_S", typeof(string));//開始補貨起日
                dtItem.Columns.Add("Sc_date_E", typeof(string));//開始補貨迄日
                dtItem.Columns.Add("Dc2Xd_date_S", typeof(string));//DX2XD起日
                dtItem.Columns.Add("Dc2Xd_date_E", typeof(string));//DX2XD迄日
                dtItem.Columns.Add("AmountDateS", typeof(string));//計費起日
                dtItem.Columns.Add("AmountDateE", typeof(string));//計費迄日
                ViewState["OfferItem"] = dtItem;
            }
        }

        /// <summary>
        /// Header下拉是選單產生
        /// </summary>
        private void CrtDDL1()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();//ddl_Ares
            try
            {
                CB.DropDownListBind(ref ddl_Ares, DAO.dtList("EDI", "Contract_Ares"), "Field_Code", "Field_Name", "請選擇", "");

                CB.RadioBtnListBind(ref rbt_Tax, DAO.dtList("EDI", "Tax_Include"), "Field_Code", "Field_Name");
                rbt_Tax.SelectedIndex = 1;
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// Item下拉式選單產生
        /// </summary>
        private void CrtDDL2()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();//ddl_Ares
            try
            {
                CB.DropDownListBind(ref ddl_End, DAO.dtList("EDI", "End_Proc"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_ObjType, DAO.dtList("EDI", "Object_Type"), "Field_Code", "Field_Name", "請選擇", "");
                CB.CheckBoxListBind(ref cbl_Wotk, DAO.dtTypeFee("EDI", txb_Object.Text.Trim(), "", "", ""), "Work_Code", "Name");
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 確定單號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            DataTable dtSCNO = new DataTable();
            DAOOffer DAO = new DAOOffer();
            Check ck = new Check();
            string strSysOfferNo = string.Empty;
            string ErrMsg = string.Empty;
            try
            {
                if (txb_Object.Text.Trim().Length == 0)
                {
                    ErrMsg += "請輸入報價對象!!!" + " \\n";
                }
                if (txb_Object.Text.Trim().Length != 4)
                {
                    ErrMsg += "報價對象只能四碼!!!" + " \\n";
                }
                if (hid_City.Value == string.Empty)
                {
                    ErrMsg += "請加入影響範圍!!!" + " \\n";
                }
                if (ErrMsg.Length == 0)
                {
                    if (ck.strSEDate(txb_EffectDateS.Text.Trim(), txb_EffectDateE.Text.Trim()))
                    {
                        ErrMsg += "報價有效起日不可大於迄日!!!" + " \\n";
                    }
                }
                if (ErrMsg.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }
                pnl_Header.Enabled = false;
                pnl_Item.Visible = true;
                CrtDDL2();
                ViewTable2();
                dtSCNO = DAO.dtSCNO("EDI", txb_Object.Text);
                if (dtSCNO.Rows.Count == 0)
                {
                    hid_SysOfferNo.Value = "SC" + string.Format("{0:yyyyMMdd}", DateTime.Now) + "000A";
                }
                else
                {
                    strSysOfferNo = dtSCNO.Rows[0]["Offer_No"].ToString();
                    string newSCNO = GetSCNO(strSysOfferNo);
                    hid_SysOfferNo.Value = newSCNO;
                }
                ful_InGoo.Visible = false;
                btn_InGoo.Visible = false;
                CleanCtr();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }
        /// <summary>
        /// 取得英文單號
        /// A=1 B=2 C=3 D=4 E=5 F=6 G=7 H=8 I=9 0=0
        /// </summary>
        /// <param name="SCNORight4">序號</param>
        /// <returns></returns>
        private string GetSCNO(string SCNO)
        {
            string output = "";
            int cut = 4;
            int ascii = 0;
            int intentValue = 0;
            double level = 0;
            //字串-->數字
            output = SCNO.Substring(10, 4);

            while (output.Length > 0)
            {
                ascii = Convert.ToInt32(output.Substring(cut - 1, 1)[0]);
                if (ascii > 64)
                {
                    intentValue += (int)Math.Pow(10, level) * (ascii - 64);
                }
                else
                {
                    intentValue += (int)Math.Pow(10, level) * 0;
                }
                cut--;
                level++;
                output = output.Substring(0, cut);
            }

            //+1
            intentValue += 1;
            level = 0;

            //數字-->字串
            while (intentValue > 0)
            {
                level += 1;
                if ((intentValue % 10) > 0)
                    output = Convert.ToChar((int)intentValue % 10 + 64).ToString() + output;
                else
                    output = "0" + output;
                intentValue = intentValue / 10;
            }

            //補零
            output = output.PadLeft(4, '0');
            output = SCNO.Substring(0, 10) + output;
            return output;
        }


        protected void ddl_Ares_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_InsAres_Click(sender, e);
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
                    //for (int i = 0; i < dtTemp.Rows.Count; i++)
                    //{
                    //    string dtAreaID = dtTemp.Rows[i]["CityID"] == null ? "" : dtTemp.Rows[i]["CityID"].ToString();
                    //    if (strAreaID != dtAreaID)
                    //    {
                    //        dtTemp.Rows.Add(new object[] { strAreaID, strArea });
                    //    }
                    //}
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
        }

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
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 清除控制項
        /// </summary>
        public void CleanCtr()
        {
            ddl_ObjType.Text = string.Empty;
            txb_Qty.Text = string.Empty;
            txb_ObjCode.Text = string.Empty;
            for (int i = 0; i < cbl_Wotk.Items.Count; i++)
            {
                cbl_Wotk.Items[i].Selected = false;
            }
            ddl_End.SelectedIndex = 1;
            txb_ContractDateS.Text = txb_EffectDateS.Text;
            txb_ContractDateE.Text = txb_EffectDateE.Text;
            txb_ScDateS.Text = txb_EffectDateS.Text;
            txb_ScDateE.Text = txb_EffectDateE.Text;
            txb_DC2XD_DateS.Text = string.Empty;
            txb_DC2XD_DateE.Text = string.Empty;
            txb_AmountDateS.Text = txb_EffectDateS.Text;
            txb_AmountDateE.Text = txb_EffectDateE.Text;
        }

        protected void gv_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_List.PageIndex = e.NewPageIndex;
                DataTable Dt = (DataTable)ViewState["OfferItem"];
                gv_List.DataSource = Dt;
                gv_List.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        /// <summary>
        /// 選擇作業名稱帶出收費大類、收費類型、金額、作業類型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //DAOOffer DAO = new DAOOffer();
            //try
            //{
            //    string strWorkCode = ddl_Work.SelectedValue.ToString();
            //    string strObjectNo = txb_Object.Text.Trim();
            //    dt = DAO.dtTypeFee("EDI", strObjectNo, strWorkCode, "", "");
            //    lblAmount.Text = dt.Rows[0]["Chage_amount"] == null ? "" : dt.Rows[0]["Chage_amount"].ToString();
            //    lblCharge.Text = dt.Rows[0]["ChargeCateName"] == null ? "" : dt.Rows[0]["ChargeCateName"].ToString();
            //    hid_Charge.Value = dt.Rows[0]["Charge_Cate"] == null ? "" : dt.Rows[0]["Charge_Cate"].ToString();
            //    lblChrType.Text = dt.Rows[0]["ChargeTypeName"] == null ? "" : dt.Rows[0]["ChargeTypeName"].ToString();
            //    hid_ChrType.Value = dt.Rows[0]["Charge_Type"] == null ? "" : dt.Rows[0]["Charge_Type"].ToString();
            //    lblWorkType.Text = dt.Rows[0]["WorkTypeName"] == null ? "" : dt.Rows[0]["WorkTypeName"].ToString();
            //    hid_WorkType.Value = dt.Rows[0]["Work_Type"] == null ? "" : dt.Rows[0]["Work_Type"].ToString();

            //}
            //catch (Exception ex)
            //{ }
        }

        protected void gv_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int GVIndex = Convert.ToInt32(e.CommandArgument);//點選的資料行索引
            DataTable dt = (DataTable)ViewState["OfferItem"];
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
                                gv_List.DataSource = dt;
                                gv_List.DataBind();
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 存入175資料
        /// </summary>
        /// <returns></returns>
        public bool InsData(string strArea)
        {
            DAOOffer DAO = new DAOOffer();
            bool SecIns = false;
            DataTable dtOfferItem = (DataTable)ViewState["OfferItem"];
            bool blHeader = false;
            bool blItem = false;
            try
            {
                /*Header*/
                string Offer_No_Ext = hid_SysOfferNo.Value;
                string Offer_No = hid_SysOfferNo.Value;
                string Object_No = txb_Object.Text.Trim();
                string Contract_Ares = hid_City.Value;
                string Tax_Include = rbt_Tax.SelectedValue.ToString();
                //string Charge_Cate = "";
                string Effect_Dates = txb_EffectDateS.Text.Trim();
                string Effect_Datee = txb_EffectDateE.Text.Trim();
                string strMemo = txb_MemoH.Text.Trim();
                string OtFlg = rbt_OT.SelectedValue;
                string AutOrd = rbt_AutoOrder.SelectedValue;
                //blHeader = DAO.InsHead("EDI", Offer_No_Ext, Offer_No, Object_No, Contract_Ares, Tax_Include, "0", End_Proc, Effect_Dates, Effect_Datee, Contract_Dates, Contract_Datee, strMemo, strArea, OtFlg);
                blHeader = DAO.InsHead("EDI", Offer_No_Ext, Offer_No, Object_No, Contract_Ares, Tax_Include, "0", Effect_Dates, Effect_Datee, strMemo, strArea, OtFlg, AutOrd);

                /*Detail*/
                for (int i = 0; i < dtOfferItem.Rows.Count; i++)
                {
                    //string Offer_No_Ext=(GridView)gv_List.Rows[i].Cells[0].Text;
                    //string Offer_No=txb_OfferNo.Text.Trim();
                    //string Object_No=txb_Object.Text.Trim();
                    string Charge_Cate = dtOfferItem.Rows[i]["Charge_Cate"] == null ? "" : dtOfferItem.Rows[i]["Charge_Cate"].ToString();
                    string Work_Code = dtOfferItem.Rows[i]["Work_Code"] == null ? "" : dtOfferItem.Rows[i]["Work_Code"].ToString();
                    string Work_Name = dtOfferItem.Rows[i]["Work_Name"] == null ? "" : dtOfferItem.Rows[i]["Work_Name"].ToString();
                    string Charge_Type = dtOfferItem.Rows[i]["Charge_Type"] == null ? "" : dtOfferItem.Rows[i]["Charge_Type"].ToString();
                    string Chage_amount = dtOfferItem.Rows[i]["Chage_amount"] == null ? "" : dtOfferItem.Rows[i]["Chage_amount"].ToString();
                    string Object_Type = dtOfferItem.Rows[i]["Object_Type"] == null ? "" : dtOfferItem.Rows[i]["Object_Type"].ToString();
                    string Object_Code = dtOfferItem.Rows[i]["Object_Code"] == null ? "" : dtOfferItem.Rows[i]["Object_Code"].ToString();
                    string Offer_Qty = dtOfferItem.Rows[i]["Offer_Qty"] == null ? "" : dtOfferItem.Rows[i]["Offer_Qty"].ToString();
                    string Create_Date = DateTime.Now.ToString();
                    string Work_Type = dtOfferItem.Rows[i]["Work_Type"] == null ? "" : dtOfferItem.Rows[i]["Work_Type"].ToString();
                    string Memo = dtOfferItem.Rows[i]["Memo"] == null ? "" : dtOfferItem.Rows[i]["Memo"].ToString();
                    string End_Proc = dtOfferItem.Rows[i]["End_Proc"] == null ? "" : dtOfferItem.Rows[i]["End_Proc"].ToString();
                    string Contract_Dates = dtOfferItem.Rows[i]["Contract_Dates"] == null ? "" : dtOfferItem.Rows[i]["Contract_Dates"].ToString();
                    string Contract_Datee = dtOfferItem.Rows[i]["Contract_Dates"] == null ? "" : dtOfferItem.Rows[i]["Contract_Datee"].ToString();
                    string SCDateS = dtOfferItem.Rows[i]["Sc_date_S"] == null ? "" : dtOfferItem.Rows[i]["Sc_date_S"].ToString();
                    string SCDateE = dtOfferItem.Rows[i]["Sc_date_E"] == null ? "" : dtOfferItem.Rows[i]["Sc_date_E"].ToString();
                    string Dc2Xd_DateS = dtOfferItem.Rows[i]["Dc2Xd_date_S"] == null ? "" : dtOfferItem.Rows[i]["Dc2Xd_date_S"].ToString();
                    string Dc2Xd_DateE = dtOfferItem.Rows[i]["Dc2Xd_date_E"] == null ? "" : dtOfferItem.Rows[i]["Dc2Xd_date_E"].ToString();
                    string strAmountDateS = dtOfferItem.Rows[i]["AmountDateS"] == null ? "" : dtOfferItem.Rows[i]["AmountDateS"].ToString();
                    string strAmountDateE = dtOfferItem.Rows[i]["AmountDateE"] == null ? "" : dtOfferItem.Rows[i]["AmountDateE"].ToString();

                    if (SCDateS == string.Empty)
                    {
                        blItem = DAO.InsItem("EDI", Offer_No_Ext, Offer_No, Object_No, Charge_Cate, Work_Code, Work_Name, Charge_Type, Chage_amount, Object_Type, Object_Code, Offer_Qty, Create_Date, Work_Type, Memo, strArea, End_Proc, Contract_Dates, Contract_Datee, strAmountDateS, strAmountDateE);
                    }
                    else
                    {
                        blItem = DAO.InsItem("EDI", Offer_No_Ext, Offer_No, Object_No, Charge_Cate, Work_Code, Work_Name, Charge_Type, Chage_amount, Object_Type, Object_Code, Offer_Qty, Create_Date, Work_Type, Memo, strArea, End_Proc, Contract_Dates, Contract_Datee, SCDateS, SCDateE, Dc2Xd_DateS, Dc2Xd_DateE, strAmountDateS, strAmountDateE);
                    }
                }
                if (blHeader && blItem)
                {
                    SecIns = true;
                }
                else
                {
                    SecIns = false;
                }
            }
            catch (Exception ex)
            {
                SecIns = false;
            }
            return SecIns;
        }

        /// <summary>
        /// 確定資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ItemSubmit_Click(object sender, EventArgs e)
        {
            bool SecData = true;
            bool SecXMS = true;
            DataTable dtArea = new DataTable();

            #region 錯誤處理
            string ErrMsg = "";
            DataTable dtOfferItem = (DataTable)ViewState["OfferItem"];
            foreach (DataRow dr in dtOfferItem.Rows)
            {
                //貨號
                if (dr["object_code"].ToString() == string.Empty)
                    ErrMsg += "未輸入貨號";

                //數量
                try
                {
                    int Chk_Offer_qty = Convert.ToInt32(dr["offer_qty"].ToString());
                }
                catch
                {
                    ErrMsg += dr["object_code"].ToString() + " 數量不正確";
                }

                //退回方式
                if (dr["End_Proc"].ToString() == string.Empty)
                    ErrMsg += dr["object_code"].ToString() + "未指定退回方式";

                //合約起日
                if(dr["Contract_Dates"].ToString() == string.Empty)
                    ErrMsg += dr["object_code"].ToString() + "未指定合約起日";

                //合約迄日
                if (dr["Contract_Datee"].ToString() == string.Empty)
                    ErrMsg += dr["object_code"].ToString() + "未指定合約迄日";
            }
            if (ErrMsg != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                return;
            }
            #endregion

            try
            {
                dtArea = (DataTable)ViewState["Area"];
                for (int i = 0; i < dtArea.Rows.Count; i++)
                {
                    string strArea = dtArea.Rows[i]["CityID"] == null ? "" : dtArea.Rows[i]["CityID"].ToString();
                    SecData = InsData(strArea);
                    SecXMS = InsEepDC(strArea);

                }

                if (SecData && SecXMS)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增成功!!')", true);
                    //Response.Redirect("SCQuote.aspx");
                    Response.Write("<script>alert('新增成功!'); parent.location.href='SCMain.aspx'; </script>");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增失敗!!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增失敗!!')", true);
            }
        }

        /// <summary>
        /// 加入報價明細
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ItemIns_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = (DataTable)ViewState["OfferItem"];
            DAOOffer DAO = new DAOOffer();
            Check ck = new Check();
            string ErrMsg = string.Empty;
            int CountCBL = 0;
            try
            {
                for (int i = 0; i < cbl_Wotk.Items.Count; i++)
                {
                    if (cbl_Wotk.Items[i].Selected)
                    {
                        CountCBL++;
                    }
                }
                if (CountCBL == 0)
                {
                    ErrMsg += "請選擇作業名稱!!" + " \\n";
                }

                if (ddl_ObjType.SelectedValue == string.Empty)
                {
                    ErrMsg += "請選擇作業作業商品!!" + " \\n";
                }
                if (txb_ObjCode.Visible)
                {
                    if (txb_ObjCode.Text.Trim().Length == 0)
                    {
                        ErrMsg += "請選擇作業商品代碼!!" + " \\n";
                    }
                }
                if (!txb_ObjCode.Visible)
                {
                    if (ViewState["Goo_no"] == null)
                    {
                        ErrMsg += "請匯入商品代碼資料!!" + " \\n";
                    }
                }
                if (txb_Qty.Text.Trim().Length == 0)
                {
                    ErrMsg += "請選擇作業商品代碼!!" + " \\n";
                }
                if (txb_EffectDateS.Text.Trim() == string.Empty || txb_EffectDateE.Text.Trim() == string.Empty)
                {
                    ErrMsg += "報價有效期不可為空!!!" + " \\n";
                }
                if (txb_ContractDateS.Text.Trim() == string.Empty || txb_ContractDateE.Text.Trim() == string.Empty)
                {
                    ErrMsg += "合約期間日期不可為空!!!" + " \\n";
                }
                if (ddl_End.SelectedValue == string.Empty)
                {
                    ErrMsg += "請選擇後續處理方式!!!" + " \\n";
                }
                if (ErrMsg.Length == 0)
                {
                    if (txb_EffectDateS.Text.Trim() != string.Empty && txb_EffectDateE.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_EffectDateS.Text.Trim(), txb_EffectDateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "報價有效期起日不可大於迄日!!" + " \\n";
                        }
                    }
                    if (txb_ContractDateS.Text.Trim() != string.Empty && txb_ContractDateE.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_ContractDateS.Text.Trim(), txb_ContractDateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "合約期間起日不可大於迄日!!" + " \\n";
                        }
                    }
                    if (txb_ScDateS.Text.Trim() != string.Empty && txb_ScDateE.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_ScDateS.Text.Trim(), txb_ScDateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "SC開始補貨起日不可大於迄日!!" + " \\n";
                        }
                    }
                    if (txb_AmountDateS.Text.Trim() != string.Empty && txb_AmountDateE.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_AmountDateS.Text.Trim(), txb_AmountDateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "計價期間起日不可大於迄日!!" + " \\n";
                        }
                    }
                    if (txb_ContractDateS.Text.Trim() != string.Empty && txb_ScDateS.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_ContractDateS.Text.Trim(), txb_ScDateS.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "合約起日不可大於SC銷補起日!!" + " \\n";
                        }
                    }
                    if (txb_ContractDateE.Text.Trim() != string.Empty && txb_ScDateS.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_ScDateS.Text.Trim(), txb_ContractDateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "SC銷補起日不可大於合約迄日!!" + " \\n";
                        }
                    }
                    if (txb_ScDateE.Text.Trim() != string.Empty && txb_DC2XD_DateS.Text.Trim() != string.Empty)
                    {
                        string DC2DXDateSDef = (Convert.ToDateTime(txb_ScDateE.Text.Trim()).AddDays(1)).ToString();
                        bool ckDate = ck.strSEDate(DC2DXDateSDef, txb_DC2XD_DateS.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "DC2XD起日需大於SC銷補迄日一日以上!!" + " \\n";
                        }
                    }
                    if (ddl_ObjType.SelectedValue == "0")
                    {
                        bool blConDate = false;//確認合約日期有無重疊
                        bool blSCDate = false;//確認SC消捕日期有無重疊
                        DataTable dtArea = (DataTable)ViewState["Area"];
                        for (int i = 0; i < dtArea.Rows.Count; i++)
                        {
                            string strArea = dtArea.Rows[i]["CityID"] == null ? "" : dtArea.Rows[i]["CityID"].ToString();
                            string strDC = string.Empty;

                            if (strArea == "1")
                            {
                                strDC = "DC1";
                            }
                            else
                            {
                                strDC = "DC2";
                            }

                            blConDate = ck.ChkConDate(txb_ObjCode.Text.Trim(), txb_ContractDateS.Text.Trim(), strDC);
                            blSCDate = ck.ChkSCData(txb_ObjCode.Text.Trim(), txb_ScDateS.Text.Trim(), strDC);
                        }
                        if (blConDate)
                        {
                            ErrMsg += "合約起日不可小於前次合約迄日!!!" + " \\n";
                        }
                        if (blSCDate)
                        {
                            ErrMsg += "SC消補起日不可小於前次迄日!!!" + " \\n";
                        }
                    }

                    if (txb_DC2XD_DateS.Text.Trim() != string.Empty && txb_DC2XD_DateE.Text.Trim() != string.Empty)
                    {
                        bool ckDate = ck.strSEDate(txb_DC2XD_DateS.Text.Trim(), txb_DC2XD_DateE.Text.Trim());
                        if (ckDate)
                        {
                            ErrMsg += "DC2XD起日不可大於迄日!!" + " \\n";
                        }
                    }
                }

                if (ViewState["Goo_no"] != null)//Excel匯入
                {
                    DataTable dtGoo = (DataTable)ViewState["Goo_no"];
                    for (int j = 0; j < dtGoo.Rows.Count; j++)
                    {
                        if (dtGoo.Rows[j][0].ToString().Trim().Length > 0)
                        {
                            for (int i = 0; i < cbl_Wotk.Items.Count; i++)
                            {
                                if (cbl_Wotk.Items[i].Selected)
                                {
                                    DataTable dtWork = new DataTable();
                                    string strWork_Code = cbl_Wotk.Items[i].Value == null ? "" : cbl_Wotk.Items[i].Value.ToString();
                                    string strObjectNo = txb_Object.Text.Trim();
                                    dtWork = DAO.dtTypeFee("EDI", strObjectNo, strWork_Code, "", "");
                                    string strOffer_No_Ext = hid_SysOfferNo.Value;
                                    string strOffer_No = hid_SysOfferNo.Value.ToString();
                                    string strObject_No = txb_Object.Text.Trim().ToUpper();
                                    string strCharge_Cate = dtWork.Rows[0]["Charge_Cate"] == null ? "" : dtWork.Rows[0]["Charge_Cate"].ToString();
                                    string strChargeCateName = dtWork.Rows[0]["ChargeCateName"] == null ? "" : dtWork.Rows[0]["ChargeCateName"].ToString();
                                    string strWork_Name = cbl_Wotk.Items[i].Text == null ? "" : cbl_Wotk.Items[i].Text.ToString().Substring(0, cbl_Wotk.Items[i].Text.ToString().IndexOf("-"));
                                    string strCharge_Type = dtWork.Rows[0]["Charge_Type"] == null ? "" : dtWork.Rows[0]["Charge_Type"].ToString();
                                    string strChargeTypeName = dtWork.Rows[0]["ChargeTypeName"] == null ? "" : dtWork.Rows[0]["ChargeTypeName"].ToString();
                                    string strChage_Amount = dtWork.Rows[0]["Chage_amount"] == null ? "" : dtWork.Rows[0]["Chage_amount"].ToString();
                                    string strObject_Type = ddl_ObjType.SelectedValue.ToString();
                                    string strObject_TypeName = ddl_ObjType.SelectedItem.Text.ToString();
                                    string strObject_Code = dtGoo.Rows[j][0].ToString().ToUpper(); //txb_ObjCode.Text.Trim().ToUpper();
                                    string strOffer_Qty = txb_Qty.Text.Trim().ToUpper();
                                    string strWorkType = dtWork.Rows[0]["Work_Type"] == null ? "" : dtWork.Rows[0]["Work_Type"].ToString();
                                    string strWorkTypeName = dtWork.Rows[0]["WorkTypeName"] == null ? "" : dtWork.Rows[0]["WorkTypeName"].ToString();
                                    string strMemo = dtWork.Rows[0]["Memo"] == null ? "" : dtWork.Rows[0]["Memo"].ToString();
                                    string strEnd = ddl_End.SelectedValue;
                                    string strCtrDates = txb_ContractDateS.Text.Trim();
                                    string strCtrDatee = txb_ContractDateE.Text.Trim();
                                    string strScDateS = txb_ScDateS.Text.Trim();
                                    string strScDateE = txb_ScDateE.Text.Trim();
                                    string strDC2XD_DateS = txb_DC2XD_DateS.Text.Trim();
                                    string strDC2XD_DateE = txb_DC2XD_DateE.Text.Trim();
                                    string strAmountDateS = txb_AmountDateS.Text.Trim();
                                    string strAmountDateE = txb_AmountDateE.Text.Trim();

                                    dtTemp.Rows.Add(new object[] { strOffer_No_Ext, strOffer_No, strObject_No, strCharge_Cate,strChargeCateName, strWork_Code 
                                    ,strWork_Name,strCharge_Type,strChargeTypeName,strChage_Amount,strObject_Type,strObject_TypeName,strObject_Code,strOffer_Qty
                                    ,strWorkType,strWorkTypeName,strMemo,strEnd,strCtrDates,strCtrDatee,strScDateS,strScDateE,strDC2XD_DateS,strDC2XD_DateE,strAmountDateS,strAmountDateE});
                                }
                            }
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < cbl_Wotk.Items.Count; i++)
                    {
                        if (cbl_Wotk.Items[i].Selected)
                        {
                            DataTable dtWork = new DataTable();
                            string strWork_Code = cbl_Wotk.Items[i].Value == null ? "" : cbl_Wotk.Items[i].Value.ToString();
                            string strObjectNo = txb_Object.Text.Trim();
                            dtWork = DAO.dtTypeFee("EDI", strObjectNo, strWork_Code, "", "");
                            string strOffer_No_Ext = hid_SysOfferNo.Value;
                            string strOffer_No = hid_SysOfferNo.Value.ToString();
                            string strObject_No = txb_Object.Text.Trim().ToUpper();
                            string strCharge_Cate = dtWork.Rows[0]["Charge_Cate"] == null ? "" : dtWork.Rows[0]["Charge_Cate"].ToString();
                            string strChargeCateName = dtWork.Rows[0]["ChargeCateName"] == null ? "" : dtWork.Rows[0]["ChargeCateName"].ToString();
                            string strWork_Name = cbl_Wotk.Items[i].Text == null ? "" : cbl_Wotk.Items[i].Text.ToString().Substring(0, cbl_Wotk.Items[i].Text.ToString().IndexOf("-"));
                            string strCharge_Type = dtWork.Rows[0]["Charge_Type"] == null ? "" : dtWork.Rows[0]["Charge_Type"].ToString();
                            string strChargeTypeName = dtWork.Rows[0]["ChargeTypeName"] == null ? "" : dtWork.Rows[0]["ChargeTypeName"].ToString();
                            string strChage_Amount = dtWork.Rows[0]["Chage_amount"] == null ? "" : dtWork.Rows[0]["Chage_amount"].ToString();
                            string strObject_Type = ddl_ObjType.SelectedValue.ToString();
                            string strObject_TypeName = ddl_ObjType.SelectedItem.Text.ToString();
                            string strObject_Code = txb_ObjCode.Text.Trim().ToUpper();
                            string strOffer_Qty = txb_Qty.Text.Trim().ToUpper();
                            string strWorkType = dtWork.Rows[0]["Work_Type"] == null ? "" : dtWork.Rows[0]["Work_Type"].ToString();
                            string strWorkTypeName = dtWork.Rows[0]["WorkTypeName"] == null ? "" : dtWork.Rows[0]["WorkTypeName"].ToString();
                            string strMemo = dtWork.Rows[0]["Memo"] == null ? "" : dtWork.Rows[0]["Memo"].ToString();
                            string strEnd = ddl_End.SelectedValue;
                            string strCtrDates = txb_ContractDateS.Text.Trim();
                            string strCtrDatee = txb_ContractDateE.Text.Trim();
                            string strScDateS = txb_ScDateS.Text.Trim();
                            string strScDateE = txb_ScDateE.Text.Trim();

                            string strDC2XD_DateS = txb_DC2XD_DateS.Text.Trim();
                            string strDC2XD_DateE = txb_DC2XD_DateE.Text.Trim();
                            string strAmountDateS = txb_AmountDateS.Text.Trim();
                            string strAmountDateE = txb_AmountDateE.Text.Trim();

                            dtTemp.Rows.Add(new object[] { strOffer_No_Ext, strOffer_No, strObject_No, strCharge_Cate,strChargeCateName, strWork_Code 
                ,strWork_Name,strCharge_Type,strChargeTypeName,strChage_Amount,strObject_Type,strObject_TypeName,strObject_Code,strOffer_Qty
                ,strWorkType,strWorkTypeName,strMemo,strEnd,strCtrDates,strCtrDatee,strScDateS,strScDateE,strDC2XD_DateS,strDC2XD_DateE,strAmountDateS,strAmountDateE});
                        }
                    }
                }
                ViewState["OfferItem"] = dtTemp;
                gv_List.DataSource = dtTemp;
                gv_List.DataBind();
                btn_ItemSubmit.Visible = true;
                CleanCtr();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('系統異常請洽資訊人員!!')", true);
            }
        }

        protected void rbl_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string strWay = rbl_Way.SelectedValue;
            try
            {
                //    switch (strWay)
                //    {
                //        case "00":

                //            break;
                //        case "01":
                //            break;
                //    }
                //   hid_Way.Value = rbl_Way.SelectedValue;

            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 新增到EEPDC
        /// </summary>
        /// <param name="strArea"></param>
        /// <returns></returns>
        private bool InsEepDC(string strArea)
        {
            string strDC = string.Empty;
            string strOT = string.Empty;
            string XMSOT = string.Empty;
            DAOOffer DAO = new DAOOffer();
            DataTable DtItem = new DataTable();
            bool blInsXmsSCData = true;
            string srtTempGoo = string.Empty;
            try
            {
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
                        strDC = "";
                        break;
                }
                strOT = rbt_OT.SelectedValue;
                switch (strOT)//
                {
                    case "0":
                        XMSOT = "N";
                        break;
                    case "1":
                        XMSOT = "Y";
                        break;
                    default:
                        XMSOT = "N";
                        break;
                }
                DtItem = (DataTable)ViewState["OfferItem"];

                for (int i = 0; i < DtItem.Rows.Count; i++)
                {
                    string strOfferNo = DtItem.Rows[i]["Offer_No"] == null ? "" : DtItem.Rows[i]["Offer_No"].ToString();
                    string strGoo_no = DtItem.Rows[i]["Object_Code"] == null ? "" : DtItem.Rows[i]["Object_Code"].ToString();
                    string strContract_date_s = DtItem.Rows[i]["Contract_Dates"] == null ? "" : DtItem.Rows[i]["Contract_Dates"].ToString();
                    string strContract_date_e = DtItem.Rows[i]["Contract_Datee"] == null ? "" : DtItem.Rows[i]["Contract_Datee"].ToString();
                    string strSCDateS = DtItem.Rows[i]["Sc_date_S"] == null ? "" : DtItem.Rows[i]["Sc_date_S"].ToString();
                    string strSCDateE = DtItem.Rows[i]["Sc_date_E"] == null ? "" : DtItem.Rows[i]["Sc_date_E"].ToString();
                    string strOnceOrder = XMSOT;
                    string strObjectType = DtItem.Rows[i]["Object_Type"] == null ? "" : DtItem.Rows[i]["Object_Type"].ToString();
                    string strDC2XDs = DtItem.Rows[i]["Dc2Xd_date_S"] == null ? "" : DtItem.Rows[i]["Dc2Xd_date_S"].ToString();
                    string strDC2XDe = DtItem.Rows[i]["Dc2Xd_date_E"] == null ? "" : DtItem.Rows[i]["Dc2Xd_date_E"].ToString();
                    string strAutoOrder = rbt_AutoOrder.SelectedValue == "0" ? "Y" : "N";
                    if (strObjectType == "0" && srtTempGoo != strGoo_no)
                    {
                        if (strDC2XDs.Length == 0)
                            blInsXmsSCData = DAO.InsXmsSCData("EEPDC", strDC, strGoo_no, strContract_date_s, strContract_date_e, strSCDateS, strSCDateE, strOnceOrder, strAutoOrder, strOfferNo);
                        else
                        {
                            blInsXmsSCData = DAO.InsXmsSCData("EEPDC", strDC, strGoo_no, strContract_date_s, strContract_date_e, strSCDateS, strSCDateE, strOnceOrder, strDC2XDs, strDC2XDe, strAutoOrder, strOfferNo);
                        }
                        srtTempGoo = strGoo_no;
                    }
                }
            }
            catch (Exception ex)
            {
                blInsXmsSCData = false;
            }
            return blInsXmsSCData;
        }

        protected void ddl_ObjType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strObjType = string.Empty;
            strObjType = ddl_ObjType.SelectedValue.ToString();
            try
            {
                if (strObjType == "0")
                {
                    ful_InGoo.Visible = true;
                    btn_InGoo.Visible = true;
                }
                else
                {
                    ful_InGoo.Visible = false;
                    btn_InGoo.Visible = false;
                    txb_ObjCode.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Excel匯入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_InGoo_Click(object sender, EventArgs e)
        {
            RdExcel RdEx = new RdExcel();
            string steErr = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                if (ful_InGoo.HasFile)
                {
                    string file = ful_InGoo.FileName;
                    string path = HttpContext.Current.Request.MapPath("~/TempItem.xls");
                    this.ful_InGoo.SaveAs(path);
                    dt = RdEx.dtExcel(path, "工作表1", "No", 0, ref steErr);
                    txb_ObjCode.Visible = false;
                    ViewState["Goo_no"] = dt;
                    File.Delete(path);//刪除暫存資料
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('匯入完成!!')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('請指定Excel檔案!!')", true);
                    return;
                }

            }
            catch (Exception ex)
            { }
        }

        //public bool ChkConDate(string ItemID,string ConDate,string DC)
        //{
        //    bool blCkConDate=false;
        //    DAOOffer DAO = new DAOOffer();
        //    DataTable dt=new DataTable();
        //    dt = DAO.CKConDate("eepdc", ItemID, ConDate, DC);
        //    if (dt.Rows.Count > 0)
        //    {
        //        blCkConDate = true;
        //    }
        //    return blCkConDate;
        //}
    }
}
