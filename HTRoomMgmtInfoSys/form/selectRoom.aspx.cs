using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class selectRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAll();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if (Tb_price.Text!=""||Tb_type.Text!="")
            {
                BindWithTerm();
            }
            else
            {
                BindAll();
            }
        }

        protected void Btn_seach_Click(object sender, EventArgs e)
        {
            BindWithTerm();
        }
        /// <summary>
        /// 查询绑定所有数据
        /// </summary>
        protected void BindAll()
        {
            string sql_select_Room = "SELECT Rnumber,Rtype,Rprice,Rsize,Rwindow,Rfacility,Rcondition,Rprincipal FROM roomnumber INNER JOIN roomtype ON Rclass = Rid WHERE Rclass = Rid";
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_Room);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        /// <summary>
        /// 条件查询绑定数据
        /// </summary>
        protected void BindWithTerm()
        {
            string r_Type = Tb_type.Text;
            string r_price = Tb_price.Text;
            string sql_select_RoomByTerm = string.Empty;
            //根据查询条件创建SQL语句
            if (r_Type == "")
            {
                if (r_price == "")
                {

                }
                else
                {
                    sql_select_RoomByTerm = "SELECT Rnumber,Rtype,Rprice,Rsize,Rwindow,Rfacility,Rcondition,Rprincipal FROM roomnumber INNER JOIN roomtype ON Rclass = Rid WHERE Rclass = Rid AND Rprice =" + r_price;
                }
            }
            else
            {
                if (r_price == "")
                {
                    sql_select_RoomByTerm = string.Format("SELECT Rnumber,Rtype,Rprice,Rsize,Rwindow,Rfacility,Rcondition,Rprincipal FROM roomnumber INNER JOIN roomtype ON Rclass = Rid WHERE Rclass = Rid AND Rtype ='{0}'", r_Type);
                }
                else
                {
                    sql_select_RoomByTerm = string.Format("SELECT Rnumber,Rtype,Rprice,Rsize,Rwindow,Rfacility,Rcondition,Rprincipal FROM roomnumber INNER JOIN roomtype ON Rclass = Rid WHERE Rclass = Rid AND Rtype ='{0}' AND Rprice={1}", r_Type, r_price);
                }
            }
            try
            {
                //查询
                DataSet ds = code.MySqlHelper.GetDataSet(sql_select_RoomByTerm);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception)
            {

            }
        }



        /// <summary>
        /// 重载，否则出现“类型“GridView”的控件“GridView1”必须放在具有 runat=server 的窗体标... ”的错误
        /// </summary>
        /// <param name="control"></param>
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        /// <summary>
        /// 导出方法
        /// </summary>
        /// <param name="GridView"></param>
        /// <param name="filename">保存的文件名称</param>
        private void ExportGridViewForUTF8(GridView GridView, string filename)
        {
            GridView1.AllowPaging = false; //去除GridView的分页
            BindAll();
            string attachment = "attachment; filename=" + filename;

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", attachment);

            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.ContentType = "application/ms-excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

        }

        protected void Btn_ToExcel_Click(object sender, EventArgs e)
        {
            ExportGridViewForUTF8(GridView1, "房间信息表"+DateTime.Now.ToShortDateString() + ".xls");//调用导出方法
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Rnumber = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string Rcondition= ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            string Rprincipal= ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].Controls[0])).Text;
            string sql_Update_Roomnumber =string.Format("update roomnumber set Rcondition='{0}',Rprincipal='{1}' where Rnumber={2}", Rcondition, Rprincipal, Rnumber);
            code.MySqlHelper.ExecuteNonQuery(sql_Update_Roomnumber);
            GridView1.EditIndex = -1;
            BindAll();
        }
    }
}