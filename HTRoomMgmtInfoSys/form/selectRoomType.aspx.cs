using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class selectRoomType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是不是第一次加载
            if (!IsPostBack)
            {
                BindAll();
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //获取新的页面索引并绑定
            GridView1.PageIndex = e.NewPageIndex;
            BindAll();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取编辑之后的值
            string Rid = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string Rtype = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            int Rprice = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            int Rsize = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text);
            string Rwindow = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            string Rfacility = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text;

            string sql_Update_Roomnumber = string.Format("update roomtype set Rtype='{0}',Rprice={1},Rsize={2},Rwindow='{3}',Rfacility='{4}' where Rid={5}", Rtype, Rprice, Rsize,Rwindow, Rfacility,Rid);
            code.MySqlHelper.ExecuteNonQuery(sql_Update_Roomnumber);
            //退出编辑
            GridView1.EditIndex = -1;
            BindAll();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindAll();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindAll();
        }
        /// <summary>
        /// 查询所有数据并绑定
        /// </summary>
        protected void BindAll()
        {
            string sql_select_roomType = "select * from roomtype";
            DataSet ds= code.MySqlHelper.GetDataSet(sql_select_roomType);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}