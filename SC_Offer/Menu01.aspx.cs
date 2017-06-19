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
    public partial class Menu01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init_tree("");
                TreeView1.CollapseAll();
            }
        }

        /// <summary>
        /// 初始化樹狀選單
        /// </summary>
        /// <param name="p"></param>
        private void init_tree(string profile)
        {
            DAOTree DAO = new DAOTree();
            try
            {
                DataTable Pgm = DAO.dtPgm("EDI", profile);
                DataTable Parent = DAO.dtParent("EDI",profile);
                addnode(ref TreeView1, Pgm, Parent);
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 建立選單節點
        /// </summary>
        /// <param name="tv_treeview">選單</param>
        /// <param name="dt_Pgm">子節點</param>
        /// <param name="dt_Parent">父節點</param>
        /// <param name="dt_WebPage">相關網頁</param>
        private void addnode(ref TreeView tv_treeview, DataTable dt_Pgm, DataTable dt_Parent)
        {
            foreach (DataRow Parentrow in dt_Parent.Rows)
            {
                TreeNode ParentNode = new TreeNode();
                ParentNode.Text = Parentrow[1].ToString();
                ParentNode.Value = Parentrow[0].ToString();
                ParentNode.SelectAction = TreeNodeSelectAction.Expand;
                foreach (DataRow Pgmrow in dt_Pgm.Rows)
                {
                    TreeNode PgmNode = new TreeNode();
                    if (Pgmrow[0].ToString() == Parentrow[0].ToString())
                    {
                        PgmNode.Text = Pgmrow[4].ToString();
                        PgmNode.Value = Pgmrow[4].ToString();
                        PgmNode.NavigateUrl = Pgmrow[3].ToString();
                        PgmNode.Target = "right";
                        ParentNode.ChildNodes.Add(PgmNode);
                    }
                }
                tv_treeview.Nodes.Add(ParentNode);
            }
        }
    }
}
