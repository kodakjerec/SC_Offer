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
    public partial class SCTypeFee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hid_WorkCode.Value = Request.QueryString["WorkCode"] == null ? "" : Request.QueryString["WorkCode"].ToString();
                hid_ObjNO.Value = Request.QueryString["ObjNo"] == null ? "" : Request.QueryString["ObjNo"].ToString();
                CtrDDL();
                if (hid_WorkCode.Value == string.Empty)//判別新增or更新 新增:0 更新:1
                {
                    hid_Status.Value = "0";
                    lbl_Attribute.Text = "作業類別費用新增";
                    txb_WorkName.Visible = true;
                    txb_Object.Visible = true;
                    lb_WokName.Visible = false;
                    lb_Object.Visible = false;
                    btn_Del.Visible = false;
                    btn_Cancel.Visible = false;
                }
                else
                {
                    hid_Status.Value = "1";
                    lbl_Attribute.Text = "作業類別費用異動";
                    txb_WorkName.Visible = false;
                    txb_Object.Visible = false;
                    lb_WokName.Visible = true;
                    lb_Object.Visible = true;
                    btn_Del.Visible = true;
                    btn_Cancel.Visible = true;
                    btn_Obj.Visible = false;
                    GetDate();
                }
            }
        }

        /// <summary>
        /// 產生控制項
        /// </summary>
        public void CtrDDL()
        {
            DAOOffer DAO = new DAOOffer();
            ControlBind CB = new ControlBind();
            try
            {
                CB.DropDownListBind(ref ddl_ChargeCate, DAO.dtList("EDI", "Charge_Cate"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_ChargeType, DAO.dtList("EDI", "Charge_Type"), "Field_Code", "Field_Name", "請選擇", "");
                CB.DropDownListBind(ref ddl_WorkType, DAO.dtList("EDI", "Work_Type"), "Field_Code", "Field_Name", "請選擇", "");
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 確認(新增/修改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string strStatus = hid_Status.Value;
            if (strStatus == "0")//判別新增/修改 新增:0 修改:1
            {
                AddFee();
            }
            else
            {
                UpFee();
            }
        }

        /// <summary>
        /// 帶入預修改資料
        /// </summary>
        private void GetDate()
        {
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            string strWorkCode = hid_WorkCode.Value;
            string strObjCode = hid_ObjNO.Value;
            try
            {
                dt = DAO.dtTypeFee("EDI", strObjCode, strWorkCode, "", "");
                if (dt.Rows.Count > 0)
                {
                    lb_WokName.Text = dt.Rows[0]["Work_Name"] == null ? "" : dt.Rows[0]["Work_Name"].ToString();
                    lb_Object.Text = dt.Rows[0]["ObjName"] == null ? "" : dt.Rows[0]["ObjName"].ToString();
                    ddl_ChargeCate.SelectedValue = dt.Rows[0]["Charge_Cate"] == null ? "" : dt.Rows[0]["Charge_Cate"].ToString();
                    ddl_ChargeType.SelectedValue = dt.Rows[0]["Charge_Type"] == null ? "" : dt.Rows[0]["Charge_Type"].ToString();
                    txb_Amount.Text = dt.Rows[0]["Chage_amount"] == null ? "" : dt.Rows[0]["Chage_amount"].ToString();
                    ddl_WorkType.SelectedValue = dt.Rows[0]["Work_Type"] == null ? "" : dt.Rows[0]["Work_Type"].ToString();
                    txb_Memo.Text = dt.Rows[0]["Memo"] == null ? "" : dt.Rows[0]["Memo"].ToString();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 清空控制項
        /// </summary>
        private void CleanCrl()
        {
            txb_WorkName.Text = string.Empty;
            txb_Object.Text = string.Empty;
            ddl_ChargeCate.SelectedIndex = 0;
            ddl_ChargeType.SelectedIndex = 0;
            txb_Amount.Text = string.Empty;
            ddl_WorkType.SelectedIndex = 0;
            txb_Memo.Text = string.Empty;
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void AddFee()
        {
            bool blSec = false;
            DAOOffer DAO = new DAOOffer();
            string Work_Name = txb_WorkName.Text.Trim();
            string Object_No = txb_Object.Text.Trim();//1260
            string Charge_Cate = ddl_ChargeCate.SelectedValue;
            string Charge_Type = ddl_ChargeType.SelectedValue;
            string Amount = txb_Amount.Text.Trim();
            string Work_Type = ddl_WorkType.SelectedValue;
            string Memo = txb_Memo.Text.Trim();
            string ErrMsg = string.Empty;

            try
            {
                if (Work_Name.Length == 0)
                {
                    ErrMsg += "請輸入作業名稱!!" + " \\n";
                }
                if (Object_No.Length == 0)
                {
                    ErrMsg += "請輸入作業對象!!" + " \\n";
                }
                if (Charge_Cate.Length == 0)
                {
                    ErrMsg += "請選擇作業大類!" + " \\n";
                }
                if (Charge_Type.Length == 0)
                {
                    ErrMsg += "請輸入作業收費類型!!" + " \\n";
                }
                if (Object_No.Length == 0)
                {
                    ErrMsg += "請輸入對應金額!!" + " \\n";
                }
                if (Object_No.Length == 0)
                {
                    ErrMsg += "請輸入作業類型!!" + " \\n";
                }
                if (ErrMsg.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }

                blSec = DAO.InsTypeFree("EDI", Work_Name, Object_No, Charge_Cate, Charge_Type, Amount, Work_Type, Memo);
                if (blSec)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增成功!!')", true);
                    CleanCrl();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增失敗!!')", true);
                }

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('新增失敗!!')", true);
            }
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        private void UpFee()
        {
            DAOOffer DAO = new DAOOffer();
            bool blSecUp = false;
            string ErrMsg = string.Empty;
            string WorkCode = hid_WorkCode.Value;
            string Charge_Cate = ddl_ChargeCate.SelectedValue;
            string Charge_Type = ddl_ChargeType.SelectedValue;
            string Amount = txb_Amount.Text.Trim();
            string Work_Type = ddl_WorkType.SelectedValue;
            string Memo = txb_Memo.Text.Trim();
            try 
            {
                if (Charge_Cate.Length == 0)
                {
                    ErrMsg += "請選擇作業大類!!!" + " \\n";
                }
                if (Charge_Type.Length == 0)
                {
                    ErrMsg += "請選擇收費類型!!!" + " \\n";
                }
                if (Amount.Length == 0)
                {
                    ErrMsg += "請輸入收費金額!!!" + " \\n";
                }
                if (Work_Type.Length == 0)
                {
                    ErrMsg += "請選擇作業類型!!!" + " \\n";
                }

                if (ErrMsg.Length == 0)
                {
                    blSecUp = DAO.UpTypeFee("EDI", WorkCode, Charge_Cate, Charge_Type, Amount, Work_Type,Memo);
                    if (blSecUp)
                    {
                        Response.Write("<script>alert('更新成功!'); location.href='SCTypeQuery.aspx'; </script>");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('更新失敗!!')", true);
                        return;
                    }
                }
                else 
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('" + ErrMsg + "')", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('更新失敗!!')", true);
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
            string WorkCode=hid_WorkCode.Value;
            bool blSeDel = false;
            try
            {
                blSeDel = DAO.DelTypeFee("EDI", WorkCode);
                if (blSeDel)
                {
                    Response.Write("<script>alert('刪除成功!!'); location.href='SCTypeQuery.aspx'; </script>");

                }
                else 
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('刪除失敗!!')", true);
                    return;
                }

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "alert", "alert('刪除失敗!!')", true);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script> location.href='SCTypeQuery.aspx'; </script>");
        }
    }
}
