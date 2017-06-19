using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC_DAO;
using SC_LIB;

namespace SC_Offer
{
    public partial class SCSupSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SupId = Request.QueryString["SupNo"] == null ? "" : Request.QueryString["SupNo"].ToString();
                if (SupId.Length > 0)
                {
                    hid_Sup_Id.Value = SupId;
                }
                else 
                {
                    Response.Redirect("SCError.aspx");
                }
            }
        }



    }
}
