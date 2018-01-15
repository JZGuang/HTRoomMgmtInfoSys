using HTRoomMgmtInfoSys.code;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class deleteInvalidOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //查询出无效订单
            string sql_select_invalidOrder = "SELECT Oid,OcreateTime,Oorigin,Oroom,CidNumber,Cname,Cphone,OleaveTime,Ocondition FROM `order` INNER JOIN client ON OclientInfo = client.Cid WHERE Ocondition = '已离店' OR Ocondition = '已取消' AND OclientInfo = client.Cid";
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_invalidOrder);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        //protected void Turn_Click(object sender, EventArgs e)
        //{
        //    GridView1.PageIndex = int.Parse(((TextBox)GridView1.BottomPagerRow.FindControl("txtGoPage")).Text) - 1;
        //    GridView1.DataBind();//对GridView进行再次绑定  
        //}

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string sql_delete_invalidOrder = "delete from `order` where Oid=" + id;
            code.MySqlHelper.ExecuteNonQuery(sql_delete_invalidOrder);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已成功删除该订单！');location.href='deleteInvalidOrder.aspx'", true);
        }
    }
}