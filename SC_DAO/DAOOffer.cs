using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace SC_DAO
{
    public class DAOOffer
    {
        DB_IO io = new DB_IO();
        public string strConn(string ConL)
        {
            string strCon = string.Empty;
            strCon = ConfigurationManager.AppSettings[ConL];
            //strCon = "Data Source=192.168.100.175 ;Initial Catalog=EDI ;User Id=moci;Password=mociadmin";
            return strCon;
        }

        /// <summary>
        /// 明細清單
        /// </summary>
        /// <param name="strCon">資料庫名稱</param>
        /// <param name="CateCode">類別碼</param>
        /// <returns></returns>
        public DataTable dtList(string strCon, string CateCode)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select 
                                   Cate_Code,
                                   Cate_Name,
                                   Field_Code,
                                   Field_Name
                                   From dbo.SC_Offer_Field_Name 
                                   Where 1=1";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (CateCode.Length > 0)
                {
                    Sql_cmd += "And Cate_Code =@Cate_Code ";
                    SqlParameter p_Cate_Code = new SqlParameter("@Cate_Code", SqlDbType.VarChar);
                    p_Cate_Code.Value = CateCode;
                    com.Parameters.Add(p_Cate_Code);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 作業類別費用
        /// </summary>
        /// <param name="strCon">資料庫名稱</param>
        /// <param name="strObjectNo">作業對象</param>
        /// <param name="strWorkCode">作業系統碼</param>
        /// <param name="strChargeCate">作業大類</param>
        /// <param name="strChargeType">收費類型</param>
        /// <returns></returns>
        public DataTable dtTypeFee(string strCon, string strObjectNo, string strWorkCode, string strChargeCate, string strChargeType)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select 
                                    F.Work_Code,
                                    F.Work_Name,
                                    F.Object_No,
                                    Sup.N_supd_sname,
                                    Sup.N_supd_name,
                                    Sup.N_supd_sname+'('+F.Object_No+')' AS  ObjName,
                                    F.Work_Type,
                                    WT.Field_Name as WorkTypeName,
                                    F.Charge_Cate,
                                    C.Field_Name as ChargeCateName,
                                    F.Charge_Type,
                                    T.Field_Name as ChargeTypeName,
                                    F.Chage_amount,
                                    F.Work_Name +'-'+convert(varchar,F.Chage_amount)+CASE F.Object_No WHEN '0000' THEN '(預設)' ELSE '' END as Name,
                                    F.Memo
                                    From SC_Offer_Type_Fee F
                                    Left Join SC_Offer_Field_Name T on F.Charge_Type=T.Field_Code and T.Cate_Code='Charge_Type'
                                    Left Join SC_Offer_Field_Name C on F.Charge_Cate=C.Field_Code and C.Cate_Code='Charge_Cate'
                                    Left Join SC_Offer_Field_Name WT on F.Work_Type=WT.Field_Code and WT.Cate_Code='Work_Type'
                                    Left Join [172.20.210.10].[pxwms_n].dbo.supplyer_data Sup on Sup.S_supd_id=F.Object_No
                                    Where 1=1 and F.del_flg='0'";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (strWorkCode.Length > 0)
                {
                    Sql_cmd += " And F.Work_Code =@Work_Code ";
                    SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                    p_Work_Code.Value = Convert.ToInt32(strWorkCode);
                    com.Parameters.Add(p_Work_Code);
                }
                if (strObjectNo.Length > 0)
                {
                    Sql_cmd += "And (F.Object_No =@Object_No or F.Object_No='0000') ";
                    SqlParameter p_ObjectNo = new SqlParameter("@Object_No", SqlDbType.VarChar);
                    p_ObjectNo.Value = strObjectNo;
                    com.Parameters.Add(p_ObjectNo);
                }
                if (strChargeCate.Length > 0)
                {
                    Sql_cmd += "And F.Charge_Cate =@Charge_Cate ";
                    SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.Int);
                    p_Charge_Cate.Value = Convert.ToInt32(strChargeCate);
                    com.Parameters.Add(p_Charge_Cate);
                }
                if (strChargeType.Length > 0)
                {
                    Sql_cmd += "And F.Charge_Type =@Charge_Type ";
                    SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.Int);
                    p_Charge_Type.Value = Convert.ToInt32(strChargeType);
                    com.Parameters.Add(p_Charge_Type);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 作業類別費用折扣設定
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="strSiteNo"></param>
        /// <param name="strVendorNo"></param>
        /// <returns></returns>
        public DataTable dtTypeDiscount(string strCon, string strSiteNo, string strVendorNo, string strAcciId)
        {

            DataTable dt = new DataTable();

            string Sql_cmd = @"select 
                Sn
                ,a.Contract_Ares
                ,a.VendorNo
                ,a.Discount
                ,b.S_Acci_Id
                ,b.S_Acci_Name
                ,ALIAS=CASE a.VendorNo WHEN 'ALL' THEN 'ALL' ELSE c.ALIAS END
                ,d.Field_Name
                from SC_Offer_Type_Discount a
                inner join [3PL].dbo.[3PL_BaseAccounting] b
                on a.AccId=b.I_acci_seq
                left join DRP.dbo.DRP_SUPPLIER c
                on a.VendorNo=c.ID
                left join SC_Offer_Field_Name d
                on a.Contract_Ares=d.Field_Code and D.Cate_Code='Contract_Ares'
                where 1=1 ";

            Hashtable ht1 = new Hashtable();

            if (strSiteNo.Length > 0)
            {
                Sql_cmd += " And a.Contract_Ares =@SiteNo ";
                ht1.Add("@SiteNo", strSiteNo);
            }
            if (strVendorNo.Length > 0)
            {
                Sql_cmd += " And a.VendorNo =@VendorNo ";
                ht1.Add("@VendorNo", strVendorNo);
            }
            if (strAcciId.Length > 0)
            {
                Sql_cmd += " And a.AccId =@AcciId ";
                ht1.Add("@AcciId", strAcciId);
            }
            Sql_cmd += " order by Contract_Ares, VendorNo, S_acci_id";

            DataSet ds = io.SqlQuery(strCon, Sql_cmd, ht1);
            dt = ds.Tables[0];

            return dt;
        }
        public DataTable dtTypeDiscount_Acci_Query(string strCon)
        {
            DataTable dt = new DataTable();

            string Sql_cmd = @"Select I_acci_seq,S_acci_name=S_acci_id+','+S_acci_name
                               from [3PL].dbo.[3PL_BaseAccounting]
                               where I_acci_seq in (3,5,6)";
            Hashtable ht1 = new Hashtable();
            DataSet ds = io.SqlQuery(strCon, Sql_cmd, ht1);
            dt = ds.Tables[0];

            return dt;
        }
        public bool dtTypeDiscount_Update(string strCon, string strSn, string strDiscount)
        {
            bool blUp = false;
            try
            {
                int Count = 0;
                string Sql_cmd = @"Update SC_Offer_Type_Discount
                                    Set Discount=@Discount
                                    where Sn=@Sn";
                Hashtable ht1 = new Hashtable();
                ht1.Add("@Sn", strSn);
                ht1.Add("@Discount", strDiscount);
                io.SqlUpdate(strCon, Sql_cmd, ht1, ref Count);

                if (Count > 0)
                    blUp = true;
            }
            catch
            {
                blUp = false;
            }

            return blUp;
        }
        public void dtTypeDiscount_Add(string strCon, string strVendorNo, string strG21Discount, string strG22Discount, string strG23Discount)
        {
            int Count = 0;
            string Sql_cmd = @"Insert Into SC_Offer_Type_Discount
                               values (@Ares,@VendorNo,3,@G21Discount)
                                     ,(@Ares,@VendorNo,5,@G22Discount)
                                     ,(@Ares,@VendorNo,6,@G23Discount)";
            Hashtable ht1 = new Hashtable();
            for (int i = 1; i <= 3; i++)
            {
                ht1 = new Hashtable();
                ht1.Add("@Ares", i);
                ht1.Add("@VendorNo", strVendorNo);
                ht1.Add("@G21Discount", strG21Discount);
                ht1.Add("@G22Discount", strG22Discount);
                ht1.Add("@G23Discount", strG23Discount);
                io.SqlUpdate(strCon, Sql_cmd, ht1, ref Count);
            }
        }
        public bool dtTypeDiscount_Del(string strCon, string strVendorNo)
        {
            bool blUp = false;

            int Count = 0;
            string Sql_cmd = @"Delete from SC_Offer_Type_Discount
                               where VendorNo=@VendorNo";
            Hashtable ht1 = new Hashtable();
            ht1.Add("@VendorNo", strVendorNo);
            io.SqlUpdate(strCon, Sql_cmd, ht1, ref Count);

            if (Count > 0)
                blUp = true;

            return blUp;
        }

        /// <summary>
        /// 新增報價表頭
        /// </summary>
        /// <param name="strCon">資料庫名稱</param>
        /// <param name="Offer_No_Ext">外部報價單號</param>
        /// <param name="Offer_No">系統報價單號</param>
        /// <param name="Object_No">作業對象</param>
        /// <param name="Contract_Ares">影響範圍</param>
        /// <param name="Tax_Include">含稅與否</param>
        /// <param name="Charge_Cate">作業大類</param>
        /// <param name="End_Proc">後續處理</param>
        /// <param name="Effect_Dates">報價有效起日</param>
        /// <param name="Effect_Datee">報價有效迄日</param>
        /// <param name="Contract_Dates">合約期間起日</param>
        /// <param name="Contract_Datee">合約期間迄日</param>
        /// <param name="Memo">備註</param>
        /// <param name="Ware">倉別</param>
        /// <param name="OT_flg">一次性進貨</param>
        /// <returns></returns>
        public bool InsHead(string strCon, string Offer_No_Ext, string Offer_No, string Object_No, string Contract_Ares, string Tax_Include, string Charge_Cate, string Effect_Dates, string Effect_Datee, string Memo, string Ware, string OT_flg, string Auto_Ord)
        {
            bool bolInsHead = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Insert Into SC_Offer_Header(Offer_No_Ext,Offer_No,Object_No,Contract_Ares,Tax_Include,Charge_Cate,Effect_Dates,Effect_Datee,Memo,Ware,OT_Flg,Auto_Ord) 
                                  Values(@Offer_No_Ext,@Offer_No,@Object_No,@Contract_Ares,@Tax_Include,@Charge_Cate,@Effect_Dates,@Effect_Datee,@Memo,@Ware,@OT_Flg,@Auto_Ord) ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_Offer_No_Ext = new SqlParameter("@Offer_No_Ext", SqlDbType.VarChar);
                p_Offer_No_Ext.Value = Offer_No_Ext;
                com.Parameters.Add(p_Offer_No_Ext);
                SqlParameter p_Offer_No = new SqlParameter("@Offer_No", SqlDbType.VarChar);
                p_Offer_No.Value = Offer_No;
                com.Parameters.Add(p_Offer_No);
                SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                p_Object_No.Value = Object_No;
                com.Parameters.Add(p_Object_No);
                SqlParameter p_Contract_Ares = new SqlParameter("@Contract_Ares", SqlDbType.TinyInt);
                p_Contract_Ares.Value = Convert.ToInt32(Contract_Ares);
                com.Parameters.Add(p_Contract_Ares);
                SqlParameter p_Tax_Include = new SqlParameter("@Tax_Include", SqlDbType.Char);
                p_Tax_Include.Value = Tax_Include;
                com.Parameters.Add(p_Tax_Include);
                SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_Cate.Value = Charge_Cate;
                com.Parameters.Add(p_Charge_Cate);
                SqlParameter p_Effect_Dates = new SqlParameter("@Effect_Dates", SqlDbType.Date);
                p_Effect_Dates.Value = Convert.ToDateTime(Effect_Dates);
                com.Parameters.Add(p_Effect_Dates);
                SqlParameter p_Effect_Datee = new SqlParameter("@Effect_Datee", SqlDbType.Date);
                p_Effect_Datee.Value = Convert.ToDateTime(Effect_Datee);
                com.Parameters.Add(p_Effect_Datee);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                p_Ware.Value = Ware;
                com.Parameters.Add(p_Ware);
                SqlParameter p_OT_flg = new SqlParameter("@OT_flg", SqlDbType.VarChar);
                p_OT_flg.Value = OT_flg;
                com.Parameters.Add(p_OT_flg);
                SqlParameter p_Auto_Ord = new SqlParameter("@Auto_Ord", SqlDbType.Char);
                p_Auto_Ord.Value = Auto_Ord;
                com.Parameters.Add(p_Auto_Ord);
                SqlConn.Open();
                com.ExecuteNonQuery();
                bolInsHead = true;
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return bolInsHead;
        }

        /// <summary>
        /// 新增報價明細
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Offer_No_Ext"></param>
        /// <param name="Offer_No"></param>
        /// <param name="Object_No"></param>
        /// <param name="Charge_Cate"></param>
        /// <param name="Work_Code"></param>
        /// <param name="Work_Name"></param>
        /// <param name="Charge_Type"></param>
        /// <param name="Chage_amount"></param>
        /// <param name="Object_Type"></param>
        /// <param name="Object_Code"></param>
        /// <param name="Offer_Qty"></param>
        /// <param name="Create_Date"></param>
        /// <param name="Work_Type"></param>
        /// <param name="Memo"></param>
        /// <param name="Ware"></param>
        /// <returns></returns>
        public bool InsItem(string strCon, string Offer_No_Ext, string Offer_No, string Object_No, string Charge_Cate, string Work_Code, string Work_Name, string Charge_Type, string Chage_amount, string Object_Type, string Object_Code, string Offer_Qty, string Create_Date, string Work_Type, string Memo, string Ware, string End_Proc, string Contract_Dates, string Contract_Datee, string Sc_date_S, string Sc_date_E, string dc2xd_date_s, string dc2xd_date_e, string AmountDateS, string AmountDateE)
        {
            bool bolInsItem = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Insert Into SC_Offer_Detail(Offer_No_Ext, Offer_No, Object_No, Charge_Cate, Work_Code, Work_Name, Charge_Type, Chage_amount, Object_Type, Object_Code, Offer_Qty,Work_Type,Del_Flg,Memo,Ware,End_Proc,Contract_Dates,Contract_Datee,Sc_date_S,Sc_date_E";


                if (dc2xd_date_s != string.Empty)
                {
                    Sql_cmd += ",dc2xd_date_s,dc2xd_date_e";
                }

                if (AmountDateS != string.Empty)
                {
                    Sql_cmd += ",AmountDateS,AmountDateE";
                }
                Sql_cmd += ") Values(@Offer_No_Ext, @Offer_No, @Object_No,@Charge_Cate, @Work_Code, @Work_Name, @Charge_Type, @Chage_amount, @Object_Type, @Object_Code, @Offer_Qty,@Work_Type,'0',@Memo,@Ware,@End_Proc,@Contract_Dates,@Contract_Datee,@Sc_date_S,@Sc_date_E ";

                if (dc2xd_date_s != string.Empty)
                {
                    Sql_cmd += ",@dc2xd_date_s,@dc2xd_date_e ";
                }
                if (AmountDateS != string.Empty)
                {
                    Sql_cmd += " ,@AmountDateS,@AmountDateE";
                }
                Sql_cmd += " ) ";


                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_Offer_No_Ext = new SqlParameter("@Offer_No_Ext", SqlDbType.VarChar);
                p_Offer_No_Ext.Value = Offer_No_Ext;
                com.Parameters.Add(p_Offer_No_Ext);
                SqlParameter p_Offer_No = new SqlParameter("@Offer_No", SqlDbType.VarChar);
                p_Offer_No.Value = Offer_No;
                com.Parameters.Add(p_Offer_No);
                SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                p_Object_No.Value = Object_No;
                com.Parameters.Add(p_Object_No);
                SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_Cate.Value = Charge_Cate;
                com.Parameters.Add(p_Charge_Cate);
                SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                p_Work_Code.Value = Work_Code;
                com.Parameters.Add(p_Work_Code);
                SqlParameter p_Work_Name = new SqlParameter("@Work_Name", SqlDbType.NVarChar);
                p_Work_Name.Value = Work_Name;
                com.Parameters.Add(p_Work_Name);
                SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.Int);
                p_Charge_Type.Value = Charge_Type;
                com.Parameters.Add(p_Charge_Type);
                SqlParameter p_Chage_amount = new SqlParameter("@Chage_amount", SqlDbType.Money);
                p_Chage_amount.Value = Chage_amount;
                com.Parameters.Add(p_Chage_amount);
                SqlParameter p_Object_Type = new SqlParameter("@Object_Type", SqlDbType.Int);
                p_Object_Type.Value = Object_Type;
                com.Parameters.Add(p_Object_Type);
                SqlParameter p_Object_Code = new SqlParameter("@Object_Code", SqlDbType.VarChar);
                p_Object_Code.Value = Object_Code;
                com.Parameters.Add(p_Object_Code);
                SqlParameter p_Offer_Qty = new SqlParameter("@Offer_Qty", SqlDbType.Int);
                p_Offer_Qty.Value = Offer_Qty;
                com.Parameters.Add(p_Offer_Qty);
                SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                p_Work_Type.Value = Work_Type;
                com.Parameters.Add(p_Work_Type);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                p_Ware.Value = Ware;
                com.Parameters.Add(p_Ware);
                SqlParameter p_End_Proc = new SqlParameter("@End_Proc", SqlDbType.TinyInt);
                p_End_Proc.Value = End_Proc;
                com.Parameters.Add(p_End_Proc);
                SqlParameter p_Contract_Dates = new SqlParameter("@Contract_Dates", SqlDbType.Date);
                p_Contract_Dates.Value = Contract_Dates;
                com.Parameters.Add(p_Contract_Dates);
                SqlParameter p_Contract_Datee = new SqlParameter("@Contract_Datee", SqlDbType.Date);
                p_Contract_Datee.Value = Contract_Datee;
                com.Parameters.Add(p_Contract_Datee);
                SqlParameter p_Sc_date_S = new SqlParameter("@Sc_date_S", SqlDbType.Date);
                p_Sc_date_S.Value = Sc_date_S;
                com.Parameters.Add(p_Sc_date_S);
                SqlParameter p_Sc_date_E = new SqlParameter("@Sc_date_E", SqlDbType.Date);
                p_Sc_date_E.Value = Sc_date_E;
                com.Parameters.Add(p_Sc_date_E);
                if (dc2xd_date_s != string.Empty)
                {
                    SqlParameter p_dc2xd_date_s = new SqlParameter("@dc2xd_date_s", SqlDbType.Date);
                    p_dc2xd_date_s.Value = dc2xd_date_s;
                    com.Parameters.Add(p_dc2xd_date_s);
                    SqlParameter p_dc2xd_date_e = new SqlParameter("@dc2xd_date_e", SqlDbType.Date);
                    p_dc2xd_date_e.Value = dc2xd_date_e;
                    com.Parameters.Add(p_dc2xd_date_e);
                }
                if (AmountDateS != string.Empty)
                {
                    SqlParameter p_AmountDateS = new SqlParameter("@AmountDateS", SqlDbType.Date);
                    p_AmountDateS.Value = AmountDateS;
                    com.Parameters.Add(p_AmountDateS);
                    SqlParameter p_AmountDateE = new SqlParameter("@AmountDateE", SqlDbType.Date);
                    p_AmountDateE.Value = AmountDateE;
                    com.Parameters.Add(p_AmountDateE);
                }
                SqlConn.Open();
                com.ExecuteNonQuery();
                bolInsItem = true;
            }
            catch
            {
                bolInsItem = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return bolInsItem;
        }

        public bool InsItem(string strCon, string Offer_No_Ext, string Offer_No, string Object_No, string Charge_Cate, string Work_Code, string Work_Name, string Charge_Type, string Chage_amount, string Object_Type, string Object_Code, string Offer_Qty, string Create_Date, string Work_Type, string Memo, string Ware, string End_Proc, string Contract_Dates, string Contract_Datee, string AmountDateS, string AmountDateE)
        {
            bool bolInsItem = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Insert Into SC_Offer_Detail(Offer_No_Ext, Offer_No, Object_No, Charge_Cate, Work_Code, Work_Name, Charge_Type, Chage_amount, Object_Type, Object_Code, Offer_Qty,Work_Type,Del_Flg,Memo,Ware,End_Proc,Contract_Dates,Contract_Datee";
                if (AmountDateS != string.Empty)
                {
                    Sql_cmd += ",AmountDateS,AmountDateE ";
                }
                Sql_cmd += ") Values (@Offer_No_Ext, @Offer_No, @Object_No,@Charge_Cate, @Work_Code, @Work_Name, @Charge_Type, @Chage_amount, @Object_Type, @Object_Code, @Offer_Qty,@Work_Type,'0',@Memo,@Ware,@End_Proc,@Contract_Dates,@Contract_Datee";
                if (AmountDateS != string.Empty)
                {
                    Sql_cmd += ",@AmountDateS,@AmountDateE ";
                }

                Sql_cmd += ") ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_Offer_No_Ext = new SqlParameter("@Offer_No_Ext", SqlDbType.VarChar);
                p_Offer_No_Ext.Value = Offer_No_Ext;
                com.Parameters.Add(p_Offer_No_Ext);
                SqlParameter p_Offer_No = new SqlParameter("@Offer_No", SqlDbType.VarChar);
                p_Offer_No.Value = Offer_No;
                com.Parameters.Add(p_Offer_No);
                SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                p_Object_No.Value = Object_No;
                com.Parameters.Add(p_Object_No);
                SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_Cate.Value = Charge_Cate;
                com.Parameters.Add(p_Charge_Cate);
                SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                p_Work_Code.Value = Work_Code;
                com.Parameters.Add(p_Work_Code);
                SqlParameter p_Work_Name = new SqlParameter("@Work_Name", SqlDbType.NVarChar);
                p_Work_Name.Value = Work_Name;
                com.Parameters.Add(p_Work_Name);
                SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.Int);
                p_Charge_Type.Value = Charge_Type;
                com.Parameters.Add(p_Charge_Type);
                SqlParameter p_Chage_amount = new SqlParameter("@Chage_amount", SqlDbType.Money);
                p_Chage_amount.Value = Chage_amount;
                com.Parameters.Add(p_Chage_amount);
                SqlParameter p_Object_Type = new SqlParameter("@Object_Type", SqlDbType.Int);
                p_Object_Type.Value = Object_Type;
                com.Parameters.Add(p_Object_Type);
                SqlParameter p_Object_Code = new SqlParameter("@Object_Code", SqlDbType.VarChar);
                p_Object_Code.Value = Object_Code;
                com.Parameters.Add(p_Object_Code);
                SqlParameter p_Offer_Qty = new SqlParameter("@Offer_Qty", SqlDbType.Int);
                p_Offer_Qty.Value = Offer_Qty;
                com.Parameters.Add(p_Offer_Qty);
                SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                p_Work_Type.Value = Work_Type;
                com.Parameters.Add(p_Work_Type);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                p_Ware.Value = Ware;
                com.Parameters.Add(p_Ware);
                SqlParameter p_End_Proc = new SqlParameter("@End_Proc", SqlDbType.TinyInt);
                p_End_Proc.Value = End_Proc;
                com.Parameters.Add(p_End_Proc);
                SqlParameter p_Contract_Dates = new SqlParameter("@Contract_Dates", SqlDbType.Date);
                p_Contract_Dates.Value = Contract_Dates;
                com.Parameters.Add(p_Contract_Dates);
                SqlParameter p_Contract_Datee = new SqlParameter("@Contract_Datee", SqlDbType.Date);
                p_Contract_Datee.Value = Contract_Datee;
                com.Parameters.Add(p_Contract_Datee);

                if (AmountDateS != string.Empty)
                {
                    SqlParameter p_AmountDateS = new SqlParameter("@AmountDateS", SqlDbType.Date);
                    p_AmountDateS.Value = AmountDateS;
                    com.Parameters.Add(p_AmountDateS);
                    SqlParameter p_AmountDateE = new SqlParameter("@AmountDateE", SqlDbType.Date);
                    p_AmountDateE.Value = AmountDateE;
                    com.Parameters.Add(p_AmountDateE);
                }

                SqlConn.Open();
                com.ExecuteNonQuery();
                bolInsItem = true;
            }
            catch
            {
                bolInsItem = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return bolInsItem;
        }

        /// <summary>
        /// 檢核單號
        /// </summary>
        /// <param name="strCon"></param>
        /// <returns></returns>
        public DataTable dtSCNO(string strCon, string sup_no)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select Top 1 Offer_No
                                    from dbo.SC_Offer_Header 
                                    where 
                                    Offer_No like  'SC'+convert(varchar, getdate(), 112)+'%'
                                    order by Offer_No desc";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                com.Parameters.Add("@sup_no", SqlDbType.NVarChar);
                com.Parameters[0].Value = sup_no;
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {

            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 新增作業類別費用
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Work_Name"></param>
        /// <param name="Object_No"></param>
        /// <param name="Charge_Cate"></param>
        /// <param name="Charge_Type"></param>
        /// <param name="Chage_amount"></param>
        /// <returns></returns>
        public bool InsTypeFree(string strCon, string Work_Name, string Object_No, string Charge_Cate, string Charge_Type, string Chage_amount, string Work_Type, string Memo)
        {
            bool SecIns = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);

            try
            {
                string Sql_cmd = @"Insert Into SC_Offer_Type_Fee(Work_Name,Object_No,Charge_Cate,Charge_Type,Chage_amount,Work_Type,del_flg,Memo) 
                                  Values(@Work_Name,@Object_No,@Charge_Cate,@Charge_Type,@Chage_amount,@Work_Type,'0',@Memo)";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_Work_Name = new SqlParameter("@Work_Name", SqlDbType.NVarChar);
                p_Work_Name.Value = Work_Name;
                com.Parameters.Add(p_Work_Name);
                SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                p_Object_No.Value = Object_No;
                com.Parameters.Add(p_Object_No);
                SqlParameter p_Charge_cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_cate.Value = Charge_Cate;
                com.Parameters.Add(p_Charge_cate);
                SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.TinyInt);
                p_Charge_Type.Value = Charge_Type;
                com.Parameters.Add(p_Charge_Type);
                SqlParameter p_Chage_amount = new SqlParameter("@Chage_amount", SqlDbType.Money);
                p_Chage_amount.Value = Chage_amount;
                com.Parameters.Add(p_Chage_amount);
                SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                p_Work_Type.Value = Work_Type;
                com.Parameters.Add(p_Work_Type);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlConn.Open();
                com.ExecuteNonQuery();
                SecIns = true;
            }
            catch
            {
                SecIns = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return SecIns;
        }

        /// <summary>
        /// 查詢報價單(Header)
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Offer_No_Ext"></param>
        /// <param name="Object_No"></param>
        /// <returns></returns>
        public DataTable dtOfferHeader(string strCon, string Offer_No_Ext, string Object_No, string Ware, string EffectDateS)
        {
            string MaxCount = ""; //報表總筆數, 都沒下條件才限制100筆
            if (Offer_No_Ext.Length == 0 && Object_No.Length == 0 && Ware.Length == 0)
                MaxCount = "TOP 100 ";

            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmdA = @"Select " + MaxCount + @"
                                    H.Offer_No,
                                    H.Offer_No_Ext,
                                    H.Object_No,
                                    Sup.ALIAS,
                                    Sup.ALIAS+'('+H.Object_No+')' as SupName,
                                    H.Tax_Include,
                                    Tax.Field_Name as Tax,
                                    H.Ware,
                                    Area.Field_Name as DC,
                                    Convert(varchar(10),H.Effect_Dates,121) as Effect_Dates,
                                    Convert(varchar(10),H.Effect_Datee,121) as Effect_Datee
                                    From (
									Select H.Offer_No,H.Offer_No_Ext,H.Object_No,H.Tax_Include,H.Ware,H.Effect_Dates,H.Effect_Datee,H.End_Proc
									From SC_Offer_Header H With(NOLOCK)
									Left join SC_Offer_Detail D With(Nolock) on H.Offer_No=D.Offer_No and H.Ware=D.Ware
									where 1=1";
                string Sql_cmdB =
                                    @" GROUP BY H.Offer_No,H.Offer_No_Ext,H.Object_No,H.Tax_Include,H.Ware,H.Effect_Dates,H.Effect_Datee,H.End_Proc
									) H
                                    Left Join DRP.dbo.DRP_SUPPLIER Sup with(nolock) on H.Object_No=Sup.ID
                                    Left Join SC_Offer_Field_Name  Tax With(NOLOCK) On Tax.Cate_Code='Tax_Include' and Tax.Field_Code=H.Tax_Include
                                    Left Join SC_Offer_Field_Name  EP With(NOLOCK) On EP.Cate_Code='End_Proc' and EP.Field_Code=H.End_Proc
                                    Left Join SC_Offer_Field_Name  Area With(NOLOCK) On Area.Cate_Code='Contract_Ares' and Area.Field_Code=H.Ware
                                    ";

                SqlCommand com = new SqlCommand(Sql_cmdA + Sql_cmdB, SqlConn);
                if (Offer_No_Ext.Length > 0)
                {
                    Sql_cmdA += " And H.Offer_No =@Offer_No_Ext ";
                    SqlParameter p_Offer_No_Ext = new SqlParameter("@Offer_No_Ext", SqlDbType.VarChar);
                    p_Offer_No_Ext.Value = Offer_No_Ext;
                    com.Parameters.Add(p_Offer_No_Ext);
                }
                if (Object_No.Length > 0)
                {
                    Sql_cmdA += " And H.Object_No =@Object_No ";
                    SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                    p_Object_No.Value = Object_No;
                    com.Parameters.Add(p_Object_No);
                }
                if (Ware.Length > 0)
                {
                    Sql_cmdA += " and H.Ware=@Ware";
                    SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                    p_Ware.Value = Ware;
                    com.Parameters.Add(p_Ware);
                }
                if (EffectDateS.Length > 0)
                {
                    Sql_cmdA += " and H.Effect_DateS>=@EffectDateS";
                    SqlParameter p_ContractDateS = new SqlParameter("@EffectDateS", SqlDbType.VarChar);
                    p_ContractDateS.Value = EffectDateS;
                    com.Parameters.Add(p_ContractDateS);
                }
                Sql_cmdB += " Order  By H.Offer_No DESC";
                com.CommandText = Sql_cmdA + Sql_cmdB;

                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// SC報價清單
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Offer_No"></param>
        /// <returns></returns>
        public DataTable dtSCList(string strCon, string Offer_No, string Ware)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select
                                    Row_number() over(order by OD.SysNO) as Id, 
                                    OD.SysNO,
                                    OD.Offer_No,OD.Offer_No_Ext,
                                    OD.Object_No,Sup.N_supd_sname,
                                    Sup.N_supd_sname+'('+OD.Object_No+')' as SupName,
                                    OD.Charge_Cate,CC.Field_Name as Charge_CateN,
                                    OD.Work_Code,OTF.Work_Name,
                                    OD.Work_Type,WT.Field_Name as Work_TypeN,
                                    OD.Charge_Type,CT.Field_Name as Charge_TypeN,
                                    OD.Object_Type,OT.Field_Name as Object_TypeN,
                                    OD.Ware,Area.Field_Name as DC,
                                    OD.Object_Code,
                                    OD.Offer_Qty,
                                    OD.Chage_Amount,
                                    OD.Memo Memo,
                                    OD.stop_date,
                                    OD.AmountDateS,
                                    OD.AmountDateE,
                                    OH.Tax_Include,Tax.Field_Name as Tax_IncludeN,
                                    OD.End_Proc,Ep.Field_Name as End_ProcN,
                                    OH.Memo HMemo,
                                    OH.OT_Flg,
                                    OH.Contract_Ares,
                                    OH.Auto_Ord,
                                    Convert(varchar(10),OH.Effect_Dates,121) as Effect_Dates,
                                    Convert(varchar(10),OH.Effect_Datee,121) as Effect_Datee,
                                    Convert(varchar(10),OD.Contract_Dates,121) as Contract_Dates,
                                    Convert(varchar(10),OD.Contract_Datee,121) as Contract_Datee,
                                    Convert(varchar(10),OD.Sc_date_S,121) as Sc_date_S,
                                    Convert(varchar(10),OD.Sc_date_E,121) as Sc_date_E,
                                    Convert(varchar(10),OD.dc2xd_date_s,121) as dc2xd_date_s,
                                    Convert(varchar(10),OD.dc2xd_date_e,121) as dc2xd_date_e
                                    From SC_Offer_Detail OD With(nolock)
                                    Inner Join SC_Offer_Header OH on OD.Offer_No=OH.Offer_No and OH.Ware=OD.Ware and OD.Ware=@Ware
                                    Left join SC_Offer_Field_Name CC on CC.Cate_Code='Charge_Cate' and CC.Field_Code=OD.Charge_Cate
                                    LEFT Join SC_Offer_Type_Fee OTF on OTF.Work_Code=OD.Work_Code
                                    Left Join SC_Offer_Field_Name WT With(nolock) on WT.Cate_Code='Work_Type' and WT.Field_Code=OD.Work_Type
                                    Left Join SC_Offer_Field_Name CT With(nolock) on CT.Cate_Code='Charge_Type' and CT.Field_Code=OD.Charge_Type
                                    Left Join SC_Offer_Field_Name OT With(nolock) on OT.Cate_Code='Object_Type' and OT.Field_Code=OD.Object_Type
                                    Left Join SC_Offer_Field_Name Tax With(nolock) on Tax.Cate_Code='Tax_Include' and Tax.Field_Code=OH.Tax_Include
                                    Left Join SC_Offer_Field_Name EP With(nolock) on EP.Cate_Code='End_Proc' and EP.Field_Code=OD.End_Proc
                                    Left Join [172.20.210.10].[pxwms_n].dbo.supplyer_data Sup on Sup.S_supd_id=OD.Object_No
                                    Left Join dbo.SC_Offer_Field_Name Area On Area.Cate_Code='Contract_Ares' and Area.Field_Code=OD.Ware
                                    Where 1=1 and OD.Del_Flg='0'  ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (Offer_No.Length > 0)
                {
                    Sql_cmd += " And OD.Offer_No =@Offer_No ";
                    SqlParameter p_Offer_No = new SqlParameter("@Offer_No", SqlDbType.VarChar);
                    p_Offer_No.Value = Offer_No;
                    com.Parameters.Add(p_Offer_No);
                }
                SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                p_Ware.Value = Ware;
                com.Parameters.Add(p_Ware);

                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 作業類別費用設定清單
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Work_Name"></param>
        /// <param name="Object_No"></param>
        /// <param name="Work_Type"></param>
        /// <param name="Charge_Cate"></param>
        /// <param name="Charge_Type"></param>
        /// <returns></returns>
        public DataTable dtOfferTypeFee(string strCon, string Work_Name, string Object_No, string Work_Type, string Charge_Cate, string Charge_Type)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select OTF.Work_Code,OTF.Work_Name,
                                    OTF.Object_No,Sup.N_supd_sname,
                                    Sup.N_supd_sname+'('+OTF.Object_No+')' as ObjName,
                                    OTF.Work_Type,wt.Field_Name as WTN , 
                                    OTF.Charge_Cate,cc.Field_Name as CCN,
                                    OTF.Charge_Type,ct.Field_Name as CTN,
                                    OTF.Chage_amount
                                    From dbo.SC_Offer_Type_Fee OTF
                                    Left Join SC_Offer_Field_Name wt on wt.Cate_Code='Work_Type' and wt.Field_Code=OTF.Work_Type
                                    Left Join SC_Offer_Field_Name cc on cc.Cate_Code='Charge_Cate' and cc.Field_Code=OTF.Charge_cate
                                    Left Join SC_Offer_Field_Name ct on ct.Cate_Code='Charge_Type' and ct.Field_Code=OTF.Charge_Type
                                    Left Join [172.20.210.10].[pxwms_n].dbo.supplyer_data Sup on Sup.S_supd_id=OTF.Object_No
                                    Where del_flg='0' ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (Work_Name.Length > 0)
                {
                    Sql_cmd += " And OTF.Work_Name Like '%'+@Work_Name +'%' ";
                    SqlParameter p_Work_Name = new SqlParameter("@Work_Name", SqlDbType.NVarChar);
                    p_Work_Name.Value = Work_Name;
                    com.Parameters.Add(p_Work_Name);
                }
                if (Object_No.Length > 0)
                {
                    Sql_cmd += " And OTF.Object_No =@Object_No ";
                    SqlParameter p_Object_No = new SqlParameter("@Object_No", SqlDbType.VarChar);
                    p_Object_No.Value = Object_No;
                    com.Parameters.Add(p_Object_No);
                }
                if (Work_Type.Length > 0)
                {
                    Sql_cmd += " And OTF.Work_Type =@Work_Type ";
                    SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                    p_Work_Type.Value = Work_Type;
                    com.Parameters.Add(p_Work_Type);
                }
                if (Charge_Cate.Length > 0)
                {
                    Sql_cmd += " And OTF.Charge_Cate =@Charge_Cate ";
                    SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                    p_Charge_Cate.Value = Charge_Cate;
                    com.Parameters.Add(p_Charge_Cate);
                }
                if (Charge_Type.Length > 0)
                {
                    Sql_cmd += " And OTF.Charge_Type =@Charge_Type ";
                    SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.TinyInt);
                    p_Charge_Type.Value = Charge_Type;
                    com.Parameters.Add(p_Charge_Type);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];

            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 刪除明細
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="strIndex"></param>
        /// <returns></returns>
        public bool DelSCDetail(string strCon, string strIndex)
        {
            bool DelSec = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Update SC_Offer_Detail Set Del_Flg='1',Upd_Date=GetDate() Where SysNO=@SysNO";
                SqlCommand cmd = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_SysNo = new SqlParameter("@SysNO", SqlDbType.Int);
                p_SysNo.Value = strIndex;
                cmd.Parameters.Add(p_SysNo);
                SqlConn.Open();
                cmd.ExecuteNonQuery();

                DelSec = true;
            }
            catch
            {
                DelSec = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return DelSec;
        }

        /// <summary>
        /// 表頭更新
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Contract_Ares"></param>
        /// <param name="Tax_Include"></param>
        /// <param name="End_Proc"></param>
        /// <param name="Effect_Dates"></param>
        /// <param name="Effect_Datee"></param>
        /// <param name="Contract_Dates"></param>
        /// <param name="Contract_Datee"></param>
        /// <param name="Offer_No"></param>
        /// <param name="Memo"></param>
        /// <returns></returns>
        public bool UpSCHead(string strCon, string Contract_Ares, string Tax_Include, string Effect_Dates, string Effect_Datee, string Offer_No, string Memo, string Ware, string OT_Flg, string Auto_Ord)
        {
            bool blUp = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);

            try
            {
                string Sql_cmd = @"Update SC_Offer_Header
                                    Set Contract_Ares=@Contract_Ares
                                    ,Tax_Include=@Tax_Include
                                    ,Effect_Dates=@Effect_Dates
                                    ,Effect_Datee=@Effect_Datee
                                    ,Up_Date=GetDate()
                                    ,Memo=@Memo
                                    ,OT_Flg=@OT_Flg
                                    ,Auto_Ord=@Auto_Ord
                                    Where Offer_No=@Offer_No and Ware=@Ware";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_Offer_No = new SqlParameter("@Offer_No", SqlDbType.VarChar);
                p_Offer_No.Value = Offer_No;
                com.Parameters.Add(p_Offer_No);
                SqlParameter p_Contract_Ares = new SqlParameter("@Contract_Ares", SqlDbType.TinyInt);
                p_Contract_Ares.Value = Contract_Ares;
                com.Parameters.Add(p_Contract_Ares);
                SqlParameter p_Tax_Include = new SqlParameter("@Tax_Include", SqlDbType.Char);
                p_Tax_Include.Value = Tax_Include;
                com.Parameters.Add(p_Tax_Include);
                SqlParameter p_Effect_Dates = new SqlParameter("@Effect_Dates", SqlDbType.Date);
                p_Effect_Dates.Value = Effect_Dates;
                com.Parameters.Add(p_Effect_Dates);
                SqlParameter p_Effect_Datee = new SqlParameter("@Effect_Datee", SqlDbType.Date);
                p_Effect_Datee.Value = Effect_Datee;
                com.Parameters.Add(p_Effect_Datee);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlParameter p_Ware = new SqlParameter("@Ware", SqlDbType.VarChar);
                p_Ware.Value = Ware;
                com.Parameters.Add(p_Ware);
                SqlParameter p_OT_Flg = new SqlParameter("@OT_Flg", SqlDbType.Char);
                p_OT_Flg.Value = OT_Flg;
                com.Parameters.Add(p_OT_Flg);
                SqlParameter p_Auto_Ord = new SqlParameter("@Auto_Ord", SqlDbType.Char);
                p_Auto_Ord.Value = Auto_Ord;
                com.Parameters.Add(p_Auto_Ord);
                SqlConn.Open();
                com.ExecuteNonQuery();
                blUp = true;

            }
            catch
            {
                blUp = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blUp;
        }


        public bool UpSCDei(string strCon, string strSysNo, string Charge_Cate, string Work_Code, string Work_Type, string Work_Name, string Charge_Type, string Chage_amount, string Object_Type, string Object_Code, string Offer_Qty, string Memo, string End_Proc, string Contract_Dates, string Contract_Datee, string Sc_date_S, string Sc_date_E, string stop_date, string dc2xd_date_s, string dc2xd_date_e, string AmountDateS, string AmountDateE)
        {
            bool blSCDei = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Update dbo.SC_Offer_Detail 
                                    Set Charge_Cate=@Charge_Cate,
                                        Work_Code=@Work_Code,
                                        Work_Type=@Work_Type,
                                        Work_Name=@Work_Name,
                                        Charge_Type=@Charge_Type,
                                        Chage_amount=@Chage_amount,
                                        Object_Type=@Object_Type,
                                        Object_Code=@Object_Code,
                                        Offer_Qty=@Offer_Qty,
                                        Memo=@Memo,
                                        End_Proc=@End_Proc,
                                        Contract_Dates=@Contract_Dates,
                                        Contract_Datee=@Contract_Datee 
                                        ,AmountDateS=@AmountDateS
                                        ,AmountDateE=@AmountDateE
                                        ,Sc_date_S=@Sc_date_S
                                        ,Sc_date_E=@Sc_date_E 
                                        ,dc2xd_date_s=@dc2xd_date_s 
                                        ,dc2xd_date_e=@dc2xd_date_e";

                if (stop_date != null)
                {
                    Sql_cmd += ",stop_date=@stop_date,stop_Flag='Y' ";
                }

                Sql_cmd += " Where SysNO=@SysNO ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_SysNo = new SqlParameter("@SysNO", SqlDbType.Int);
                p_SysNo.Value = strSysNo;
                com.Parameters.Add(p_SysNo);
                SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_Cate.Value = Charge_Cate;
                com.Parameters.Add(p_Charge_Cate);
                SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                p_Work_Code.Value = Work_Code;
                com.Parameters.Add(p_Work_Code);
                SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                p_Work_Type.Value = Work_Type;
                com.Parameters.Add(p_Work_Type);
                SqlParameter p_Work_Name = new SqlParameter("@Work_Name", SqlDbType.NVarChar);
                p_Work_Name.Value = Work_Name;
                com.Parameters.Add(p_Work_Name);
                SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.TinyInt);
                p_Charge_Type.Value = Charge_Type;
                com.Parameters.Add(p_Charge_Type);
                SqlParameter p_Chage_amount = new SqlParameter("@Chage_amount", SqlDbType.Money);
                p_Chage_amount.Value = Chage_amount;
                com.Parameters.Add(p_Chage_amount);
                SqlParameter p_Object_Type = new SqlParameter("@Object_Type", SqlDbType.Int);
                p_Object_Type.Value = Object_Type;
                com.Parameters.Add(p_Object_Type);
                SqlParameter p_Object_Code = new SqlParameter("@Object_Code", SqlDbType.VarChar);
                p_Object_Code.Value = Object_Code;
                com.Parameters.Add(p_Object_Code);
                SqlParameter p_Offer_Qty = new SqlParameter("@Offer_Qty", SqlDbType.Int);
                p_Offer_Qty.Value = Offer_Qty;
                com.Parameters.Add(p_Offer_Qty);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                com.Parameters.Add(p_Memo);
                SqlParameter p_End_Proc = new SqlParameter("@End_Proc", SqlDbType.TinyInt);
                p_End_Proc.Value = End_Proc;
                com.Parameters.Add(p_End_Proc);
                SqlParameter p_Contract_Dates = new SqlParameter("@Contract_Dates", SqlDbType.Date);
                p_Contract_Dates.Value = Contract_Dates;
                com.Parameters.Add(p_Contract_Dates);
                SqlParameter p_Contract_Datee = new SqlParameter("@Contract_Datee", SqlDbType.Date);
                p_Contract_Datee.Value = Contract_Datee;
                com.Parameters.Add(p_Contract_Datee);
                SqlParameter p_AmountDateS = new SqlParameter("@AmountDateS", SqlDbType.Date);
                if (AmountDateS != string.Empty)
                {
                    p_AmountDateS.Value = AmountDateS;
                }
                else
                {
                    p_AmountDateS.Value = DBNull.Value;
                }
                com.Parameters.Add(p_AmountDateS);
                SqlParameter p_AmountDateE = new SqlParameter("@AmountDateE", SqlDbType.Date);
                if (AmountDateE != string.Empty)
                {
                    p_AmountDateE.Value = AmountDateE;
                }
                else
                {
                    p_AmountDateE.Value = DBNull.Value;
                }
                com.Parameters.Add(p_AmountDateE);

                SqlParameter p_Sc_date_S = new SqlParameter("@Sc_date_S", SqlDbType.Date);
                if (Sc_date_S != string.Empty)
                {

                    p_Sc_date_S.Value = Sc_date_S;
                }
                else
                {
                    p_Sc_date_S.Value = DBNull.Value;
                }
                com.Parameters.Add(p_Sc_date_S);
                SqlParameter p_Sc_date_E = new SqlParameter("@Sc_date_E", SqlDbType.Date);
                if (Sc_date_E != string.Empty)
                {
                    p_Sc_date_E.Value = Sc_date_E;
                }
                else
                {
                    p_Sc_date_E.Value = DBNull.Value;
                }
                com.Parameters.Add(p_Sc_date_E);
                SqlParameter p_dc2xds = new SqlParameter("@dc2xd_date_s", SqlDbType.Date);
                if (dc2xd_date_s != string.Empty)
                {
                    p_dc2xds.Value = dc2xd_date_s;
                }
                else
                {
                    p_dc2xds.Value = DBNull.Value;
                }
                com.Parameters.Add(p_dc2xds);
                SqlParameter p_dc2xde = new SqlParameter("@dc2xd_date_e", SqlDbType.Date);
                if (dc2xd_date_e != string.Empty)
                {
                    p_dc2xde.Value = dc2xd_date_e;
                }
                else
                {
                    p_dc2xde.Value = DBNull.Value;
                }
                com.Parameters.Add(p_dc2xde);
                if (stop_date != null)
                {
                    SqlParameter p_stop_date = new SqlParameter("@stop_date", SqlDbType.Date);
                    p_stop_date.Value = stop_date;
                    com.Parameters.Add(p_stop_date);
                }
                SqlConn.Open();
                com.ExecuteNonQuery();
                blSCDei = true;
            }
            catch
            {
                blSCDei = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blSCDei;
        }

        /// <summary>
        /// 更新TypeFee
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Work_Code"></param>
        /// <param name="Charge_Cate"></param>
        /// <param name="Charge_Type"></param>
        /// <param name="Chage_amount"></param>
        /// <param name="Work_Type"></param>
        /// <returns></returns>
        public bool UpTypeFee(string strCon, string Work_Code, string Charge_Cate, string Charge_Type, string Chage_amount, string Work_Type, string Memo)
        {
            bool blUpTypefee = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Update SC_Offer_Type_Fee
                                     Set Work_Type=@Work_Type
                                     ,Charge_Cate=@Charge_Cate
                                     ,Charge_Type=@Charge_Type
                                     ,Chage_Amount=@Chage_Amount
                                     ,Memo=@Memo
                                     Where Work_Code=@Work_Code";

                SqlCommand cmd = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                p_Work_Code.Value = Work_Code;
                cmd.Parameters.Add(p_Work_Code);
                SqlParameter p_Work_Type = new SqlParameter("@Work_Type", SqlDbType.VarChar);
                p_Work_Type.Value = Work_Type;
                cmd.Parameters.Add(p_Work_Type);
                SqlParameter p_Charge_Cate = new SqlParameter("@Charge_Cate", SqlDbType.TinyInt);
                p_Charge_Cate.Value = Charge_Cate;
                cmd.Parameters.Add(p_Charge_Cate);
                SqlParameter p_Charge_Type = new SqlParameter("@Charge_Type", SqlDbType.TinyInt);
                p_Charge_Type.Value = Charge_Type;
                cmd.Parameters.Add(p_Charge_Type);
                SqlParameter p_Chage_Amount = new SqlParameter("@Chage_Amount", SqlDbType.Money);
                p_Chage_Amount.Value = Chage_amount;
                cmd.Parameters.Add(p_Chage_Amount);
                SqlParameter p_Memo = new SqlParameter("@Memo", SqlDbType.NVarChar);
                p_Memo.Value = Memo;
                cmd.Parameters.Add(p_Memo);
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                blUpTypefee = true;
            }
            catch
            {
                blUpTypefee = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blUpTypefee;
        }

        /// <summary>
        /// 刪除作業類別
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="Work_Code"></param>
        /// <returns></returns>
        public bool DelTypeFee(string strCon, string Work_Code)
        {
            bool blDelTypefee = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Update SC_Offer_Type_Fee
                                Set Del_flg='1',Upd_Date=GetDate() 
                                Where Work_Code=@Work_Code";

                SqlCommand cmd = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_Work_Code = new SqlParameter("@Work_Code", SqlDbType.Int);
                p_Work_Code.Value = Work_Code;
                cmd.Parameters.Add(p_Work_Code);
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                blDelTypefee = true;
            }
            catch
            {
                blDelTypefee = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blDelTypefee;
        }

        public DataTable dtSup(string strCon, string SupNo, string SupName)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select S_supd_id
                                    ,N_supd_sname
                                    ,N_supd_name 
                                    From dbo.supplyer_data
                                    where 1=1";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (SupNo.Length > 0)
                {
                    Sql_cmd += " And S_supd_id =@SupNo ";
                    SqlParameter p_SupNo = new SqlParameter("@SupNo", SqlDbType.VarChar);
                    p_SupNo.Value = SupNo;
                    com.Parameters.Add(p_SupNo);
                }
                if (SupName.Length > 0)
                {
                    Sql_cmd += " And N_supd_sname Like '%'+@SupName +'%' ";
                    SqlParameter p_SupName = new SqlParameter("@SupName", SqlDbType.NVarChar);
                    p_SupName.Value = SupName;
                    com.Parameters.Add(p_SupName);
                }

                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }


        /// <summary>
        /// 作業對象
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="SupNo"></param>
        /// <param name="SupName"></param>
        /// <returns></returns>
        public DataTable dtSup(string strCon, string SupNo, string SupName, string strItemId)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select sup.S_supd_id
                                    ,sup.N_supd_name 
                                    ,'('+sup.S_supd_id+')'+sup.N_supd_name as SupName
                                    ,md.S_merd_id
                                    ,md.N_merd_name
                                    From dbo.supplyer_data  sup
                                    Left Join dbo.mer_data md On sup.S_supd_id=md.S_merd_supdid
                                    where 1=1";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (SupNo.Length > 0)
                {
                    Sql_cmd += " And sup.S_supd_id =@SupNo ";
                    SqlParameter p_SupNo = new SqlParameter("@SupNo", SqlDbType.VarChar);
                    p_SupNo.Value = SupNo;
                    com.Parameters.Add(p_SupNo);
                }
                if (SupName.Length > 0)
                {
                    Sql_cmd += " And sup.N_supd_sname Like '%'+@SupName +'%' ";
                    SqlParameter p_SupName = new SqlParameter("@SupName", SqlDbType.NVarChar);
                    p_SupName.Value = SupName;
                    com.Parameters.Add(p_SupName);
                }
                if (strItemId.Length > 0)
                {
                    Sql_cmd += " And md.S_merd_id =@S_merd_id ";
                    SqlParameter p_ItemId = new SqlParameter("@S_merd_id", SqlDbType.VarChar);
                    p_ItemId.Value = strItemId;
                    com.Parameters.Add(p_ItemId);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        #region 寫入87商品資料
        /// <summary>
        /// 寫入87商品資料 (無DC2XD)
        /// </summary>
        /// <returns></returns>
        public bool InsXmsSCData(string strCon, string site_no, string goo_no, string contract_date_s, string contract_date_e, string sc_date_s, string sc_date_e, string Once_Order, string AutoOrd, string strOfferNo)
        {
            bool blXMS = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Insert Into xms_sc_data(site_no,goo_no,pno_code,pno_name,contract_date_s,contract_date_e,sc_flag,sc_date_s,sc_date_e,Once_Order,stop_flag,crt_date,upd_date,auto_order,crt_no,upd_no,SC_Offer_No)
                                    Values(@site_no,@goo_no,'0','一般商品',@contract_date_s,@contract_date_e,'Y',@sc_date_s,@sc_date_e,@Once_Order,'N',getdate(),getdate(),@auto_order,'SCSystem','SCSystem',@SC_Offer_No)";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_SiteNo = new SqlParameter("@site_no", SqlDbType.VarChar);
                p_SiteNo.Value = site_no;
                com.Parameters.Add(p_SiteNo);
                SqlParameter p_GooNo = new SqlParameter("@goo_no", SqlDbType.VarChar);
                p_GooNo.Value = goo_no;
                com.Parameters.Add(p_GooNo);
                SqlParameter p_ContractDateS = new SqlParameter("@contract_date_s", SqlDbType.DateTime);
                p_ContractDateS.Value = contract_date_s;
                com.Parameters.Add(p_ContractDateS);
                SqlParameter p_ContractDateE = new SqlParameter("@contract_date_e", SqlDbType.DateTime);
                p_ContractDateE.Value = contract_date_e;
                com.Parameters.Add(p_ContractDateE);
                SqlParameter p_ScDateS = new SqlParameter("@sc_date_s", SqlDbType.DateTime);
                p_ScDateS.Value = sc_date_s;
                com.Parameters.Add(p_ScDateS);
                SqlParameter p_ScDateE = new SqlParameter("@sc_date_e", SqlDbType.DateTime);
                p_ScDateE.Value = sc_date_e;
                com.Parameters.Add(p_ScDateE);
                SqlParameter p_OnceOrder = new SqlParameter("@Once_Order", SqlDbType.Char);
                p_OnceOrder.Value = Once_Order;
                com.Parameters.Add(p_OnceOrder);
                SqlParameter p_AutoOrd = new SqlParameter("@auto_order", SqlDbType.Char);
                p_AutoOrd.Value = AutoOrd;
                com.Parameters.Add(p_AutoOrd);
                SqlParameter p_OfferNo = new SqlParameter("@SC_Offer_No", SqlDbType.VarChar);
                p_OfferNo.Value = strOfferNo;
                com.Parameters.Add(p_OfferNo);
                SqlConn.Open();
                com.ExecuteNonQuery();
                blXMS = true;

            }
            catch
            {
                blXMS = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blXMS;
        }

        /// <summary>
        /// 寫入87商品資料 (有DC2XD)
        /// </summary>
        /// <returns></returns>
        public bool InsXmsSCData(string strCon, string site_no, string goo_no, string contract_date_s, string contract_date_e, string sc_date_s, string sc_date_e, string Once_Order, string dx2xdS, string dc2xdE, string AutoOrd, string strOfferNo)
        {
            bool blXMS = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Insert Into xms_sc_data(site_no,goo_no,pno_code,pno_name,contract_date_s,contract_date_e,sc_flag,sc_date_s,sc_date_e,dc2xd_flag,dc2xd_date_s,dc2xd_date_e,Once_Order,stop_flag,crt_no,crt_date,upd_no,upd_date,auto_order,SC_Offer_No)
                                    Values(@site_no,@goo_no,'0','一般商品',@contract_date_s,@contract_date_e,'Y',@sc_date_s,@sc_date_e,'Y',@dc2xd_date_s,@dc2xd_date_e,@Once_Order,'N','SCSystem',getdate(),'SC_System',getdate(),@auto_order,@SC_Offer_No)";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlParameter p_SiteNo = new SqlParameter("@site_no", SqlDbType.VarChar);
                p_SiteNo.Value = site_no;
                com.Parameters.Add(p_SiteNo);
                SqlParameter p_GooNo = new SqlParameter("@goo_no", SqlDbType.VarChar);
                p_GooNo.Value = goo_no;
                com.Parameters.Add(p_GooNo);
                SqlParameter p_ContractDateS = new SqlParameter("@contract_date_s", SqlDbType.DateTime);
                p_ContractDateS.Value = contract_date_s;
                com.Parameters.Add(p_ContractDateS);
                SqlParameter p_ContractDateE = new SqlParameter("@contract_date_e", SqlDbType.DateTime);
                p_ContractDateE.Value = contract_date_e;
                com.Parameters.Add(p_ContractDateE);
                SqlParameter p_ScDateS = new SqlParameter("@sc_date_s", SqlDbType.DateTime);
                p_ScDateS.Value = sc_date_s;
                com.Parameters.Add(p_ScDateS);
                SqlParameter p_ScDateE = new SqlParameter("@sc_date_e", SqlDbType.DateTime);
                p_ScDateE.Value = sc_date_e;
                com.Parameters.Add(p_ScDateE);
                SqlParameter p_DC2XDs = new SqlParameter("@dc2xd_date_s", SqlDbType.DateTime);
                p_DC2XDs.Value = dx2xdS;
                com.Parameters.Add(p_DC2XDs);
                SqlParameter p_DC2XDe = new SqlParameter("@dc2xd_date_e", SqlDbType.DateTime);
                p_DC2XDe.Value = dc2xdE;
                com.Parameters.Add(p_DC2XDe);
                SqlParameter p_OnceOrder = new SqlParameter("@Once_Order", SqlDbType.Char);
                p_OnceOrder.Value = Once_Order;
                com.Parameters.Add(p_OnceOrder);
                SqlParameter p_AutoOrd = new SqlParameter("@auto_order", SqlDbType.Char);
                p_AutoOrd.Value = AutoOrd;
                com.Parameters.Add(p_AutoOrd);
                SqlParameter p_OfferNo = new SqlParameter("@SC_Offer_No", SqlDbType.VarChar);
                p_OfferNo.Value = strOfferNo;
                com.Parameters.Add(p_OfferNo);
                SqlConn.Open();
                com.ExecuteNonQuery();
                blXMS = true;
            }
            catch
            {
                blXMS = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blXMS;
        }

        public bool UpXnsSCData(string strCon, string site_no, string goo_no, string contract_date_s, string contract_date_e, string sc_date_s, string sc_date_e, string stop_flag, string stop_date, string DC2XDs, string DC2XDe)
        {
            bool blSCSCDate = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Update xms_sc_data
                                Set contract_date_e=@contract_date_e
                                ,sc_date_e=@sc_date_e
                                ,stop_flag=@stop_flag 
                                ,upd_no='SCSystem'
                                ,upd_date=getdate() ";

                if (stop_date != null)
                {
                    Sql_cmd += ",stop_date=@stop_date ";
                }
                if (DC2XDs.Length > 0)
                {
                    Sql_cmd += ",dc2xd_flag='Y',dc2xd_date_s=@dc2xd_date_s, dc2xd_date_e=@dc2xd_date_e ";
                }
                Sql_cmd += " Where Goo_no=@Goo_no and contract_date_s=@contract_date_s and site_no=@site_no ";

                SqlCommand cmd = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_ContractDateS = new SqlParameter("@contract_date_s", SqlDbType.DateTime);
                p_ContractDateS.Value = contract_date_s;
                cmd.Parameters.Add(p_ContractDateS);
                SqlParameter p_ContractDateE = new SqlParameter("@contract_date_e", SqlDbType.DateTime);
                p_ContractDateE.Value = contract_date_e;
                cmd.Parameters.Add(p_ContractDateE);
                SqlParameter p_ScDateE = new SqlParameter("@sc_date_e", SqlDbType.DateTime);
                p_ScDateE.Value = sc_date_e;
                cmd.Parameters.Add(p_ScDateE);
                SqlParameter p_Goo = new SqlParameter("@Goo_no", SqlDbType.VarChar);
                p_Goo.Value = goo_no;
                cmd.Parameters.Add(p_Goo);
                SqlParameter p_StopFlag = new SqlParameter("@stop_flag", SqlDbType.Char);
                p_StopFlag.Value = stop_flag;
                cmd.Parameters.Add(p_StopFlag);
                if (stop_date != null)
                {
                    SqlParameter p_StopDate = new SqlParameter("@stop_date", SqlDbType.DateTime);
                    p_StopDate.Value = stop_date;
                    cmd.Parameters.Add(p_StopDate);
                }
                SqlParameter p_SiteNo = new SqlParameter("@site_no", SqlDbType.VarChar);
                p_SiteNo.Value = site_no;
                cmd.Parameters.Add(p_SiteNo);
                if (DC2XDs.Length > 0)
                {
                    SqlParameter p_DC2XDs = new SqlParameter("@dc2xd_date_s", SqlDbType.DateTime);
                    p_DC2XDs.Value = DC2XDs;
                    cmd.Parameters.Add(p_DC2XDs);
                    SqlParameter p_DC2XDe = new SqlParameter("@dc2xd_date_e", SqlDbType.DateTime);
                    p_DC2XDe.Value = DC2XDe;
                    cmd.Parameters.Add(p_DC2XDe);

                }

                SqlConn.Open();
                cmd.ExecuteNonQuery();
                blSCSCDate = true;
            }
            catch
            {
                blSCSCDate = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return blSCSCDate;
        }

        public bool InsSCDetail(string strCon)
        {
            bool blIns = false;
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {

            }
            catch
            {

            }
            finally { }
            return blIns;
        }
        #endregion

        /// <summary>
        /// 查詢新合約起日有無在舊合約範圍內
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="GooNo"></param>
        /// <param name="ConDate"></param>
        /// <param name="SiteNo"></param>
        /// <returns></returns>
        public DataTable CKConDate(string strCon, string GooNo, string ConDate, string SiteNo, string SCDate)
        {
            string con_str = strConn(strCon);
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select Site_No
                                    ,Goo_No
                                    ,contract_date_s
                                    ,contract_date_e
                                    ,sc_date_s
                                    ,sc_date_e 
                                    From xms_sc_data 
                                    Where goo_no=@goo_no and Site_No=@Site_No ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter p_ItemId = new SqlParameter("@goo_no", SqlDbType.VarChar);
                p_ItemId.Value = GooNo;
                com.Parameters.Add(p_ItemId);
                SqlParameter p_SiteNo = new SqlParameter("@Site_No", SqlDbType.VarChar);
                p_SiteNo.Value = SiteNo;
                com.Parameters.Add(p_SiteNo);
                if (ConDate.Length > 0)
                {
                    Sql_cmd += " and contract_date_e>@contract_date_e ";
                    SqlParameter p_ContractDate = new SqlParameter("@contract_date_e", SqlDbType.DateTime);
                    p_ContractDate.Value = ConDate;
                    com.Parameters.Add(p_ContractDate);
                }
                if (SCDate.Length > 0)
                {
                    Sql_cmd += " and sc_date_e>@sc_date_e ";
                    SqlParameter p_SC_date_e = new SqlParameter("@sc_date_e", SqlDbType.DateTime);
                    p_SC_date_e.Value = SCDate;
                    com.Parameters.Add(p_SC_date_e);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 選單清單
        /// </summary>
        /// <param name="strCon"></param>
        /// <returns></returns>
        public DataTable FieldNameList(string strCon)
        {
            DataTable dt = new DataTable();
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = "Select cate_Code,Cate_Name From SC_Offer_Field_Name Group by cate_Code,Cate_Name";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 取得供應商Email資訊
        /// </summary>
        /// <param name="strCon"></param>
        /// <param name="strSupID"></param>
        /// <param name="strSupNa"></param>
        /// <returns></returns>
        public DataTable dtSupInf(string strCon, string strSupID, string strSupNa)
        {
            DataTable dt = new DataTable();
            string con_str = strConn(strCon);
            SqlConnection SqlConn = new SqlConnection(con_str);
            try
            {
                string Sql_cmd = @"Select 
                                    SupSn,
                                    SupNa,
                                    SupSn+'-'+SupNa as SupAllNa,
                                    Contacter,
                                    Cellphone,
                                    [add],
                                    Email
                                    From dbo.SC_Offer_SupInf 
                                    where 1=1 ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);
                if (strSupID.Length > 0)
                {
                    Sql_cmd += " And SupSn=@SupSn ";

                    SqlParameter p_SupSn = new SqlParameter("@SupSn", SqlDbType.VarChar);
                    p_SupSn.Value = strSupID;
                    com.Parameters.Add(p_SupSn);
                }
                if (strSupNa.Length > 0)
                {
                    Sql_cmd += " And SupNa like '%'+@SupNa+'%' ";

                    SqlParameter p_SupNa = new SqlParameter("@SupNa", SqlDbType.VarChar);
                    p_SupNa.Value = strSupID;
                    com.Parameters.Add(strSupNa);
                }
                SqlConn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = SqlConn;
                dapter.SelectCommand.CommandText = Sql_cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                dt = ds.Tables[0];

            }
            catch
            {

            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
            return dt;
        }


    }
}
