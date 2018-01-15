using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class orderStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAll();
            }
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAll();
        }
        /// <summary>
        /// 查询所有并绑定
        /// </summary>
        protected void BindAll()
        {
            string sql_select_Ooperatop = string.Format("select Uid from admin where Uname='{0}'", Session["userName"].ToString());
            int Ooperator= Convert.ToInt32(code.MySqlHelper.ExecuteScalar(sql_select_Ooperatop));
            string sql_select_Order = string.Format("SELECT Oid,OcreateTime,Oorigin,Oroom,Opeople,CidNumber,Cname,Csex,Cphone,Odays,OstayTime,OleaveTime,Ocondition,Uname FROM `order` INNER JOIN client ON `order`.OclientInfo = client.Cid INNER JOIN admin ON `order`.Ooperator = admin.Uid WHERE OclientInfo = Cid AND Ooperator = Uid AND Ooperator='{0}'", Ooperator);
            DataSet ds = code.MySqlHelper.GetDataSet(sql_select_Order);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Btn_out_Click(object sender, EventArgs e)
        {
            ExportGridViewForUTF8(GridView1, "订单信息表_"+Session["userName"].ToString() + DateTime.Now.ToShortDateString() + ".xls");//调用导出方法
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
    }
}