using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class cleanReminder : System.Web.UI.Page
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
            string Rprincipal = GridView1.Rows[index].Cells[1].Text;
            //TODO
            //连接短信API给负责人Rprincipal发短信

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已确提醒负责人！');location.href='cleanReminder.aspx'", true);

        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAll();
        }
        protected void BindAll()
        {
            string sql_select_roomNumber = "SELECT Rnumber,Rprincipal FROM roomnumber WHERE Rcondition='空房，未打扫'";
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_roomNumber);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}