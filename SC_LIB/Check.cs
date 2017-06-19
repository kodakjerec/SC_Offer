using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SC_DAO;

namespace SC_LIB
{
    public class Check
    {
        /// <summary>
        /// 檢查起訖日
        /// </summary>
        /// <returns></returns>
        public bool strSEDate(string sDate, string eDate)
        {
            DateTime S = Convert.ToDateTime(sDate);
            DateTime E = Convert.ToDateTime(eDate);
            if (S > E)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 檢查新合約起日不能在舊合約範圍內
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="ConDate"></param>
        /// <param name="DC"></param>
        /// <returns></returns>
        public bool ChkConDate(string ItemID, string ConDate, string DC)
        {
            bool blCkConDate = false;
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            dt = DAO.CKConDate("eepdc", ItemID, ConDate, DC,"");
            if (dt.Rows.Count > 0)
            {
                blCkConDate = true;
            }
            return blCkConDate;
        }

        /// <summary>
        /// SC消補日期起日不可在舊合約內
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="SCDateS"></param>
        /// <param name="DC"></param>
        /// <returns></returns>
        public bool ChkSCData(string ItemID, string SCDateS, string DC)
        {
            bool blChkSCData = false;
            DAOOffer DAO = new DAOOffer();
            DataTable dt = new DataTable();
            dt = DAO.CKConDate("eepdc", ItemID, "", DC, SCDateS);
            if (dt.Rows.Count > 0)
            {
                blChkSCData = true;
            }
            return blChkSCData;
        }
    }
}
