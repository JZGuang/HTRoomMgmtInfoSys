using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class waitCancelOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAll();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            string Oid = GridView1.Rows[index].Cells[2].Text;
            string sql_update_order_condition = "update `order` set Ocondition='已取消' where Oid=" + Oid;
            int count = code.MySqlHelper.ExecuteNonQuery(sql_update_order_condition);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已取消订单！');location.href='waitCancelOrder.aspx'", true);
            }
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAll();
        }
        protected void BindAll()
        {
            string sql_select_Order = "SELECT Oid,OcreateTime,Oorigin,Oroom,Opeople,CidNumber,Cname,Csex,Cphone,Odays,OstayTime,OleaveTime,Ocondition,Uname FROM `order` INNER JOIN client ON `order`.OclientInfo = client.Cid INNER JOIN admin ON `order`.Ooperator = admin.Uid WHERE OclientInfo = Cid AND Ooperator = Uid AND Ocondition='待取消'";
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_Order);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}