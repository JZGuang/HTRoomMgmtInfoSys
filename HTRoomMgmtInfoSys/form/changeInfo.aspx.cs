using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class changeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAll();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Uid = GridView1.Rows[e.RowIndex].Cells[1].Text;
            string Uphone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;

            string sql_Update_Roomnumber = string.Format("update admin set Uphone='{0}' where Uid={1}", Uphone, Uid);
            code.MySqlHelper.ExecuteNonQuery(sql_Update_Roomnumber);
            GridView1.EditIndex = -1;
            BindAll();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindAll();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindAll();
        }

        protected void BindAll()
        {
            string sql_select_roomType =string .Format("select Uid,Uname,Uphone from admin where Uname='{0}'",Session["userName"].ToString());
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_roomType);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}