using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.from
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Lb_user.Text = "当前用户： " + Session["userName"].ToString() + "";
            }
            catch
            {
                Response.Redirect("login.aspx");//防止非法登录
            }
        }

        protected void Lb_OffLine_Click(object sender, EventArgs e)
        {
            Session.Abandon();//取消Session
            Response.Redirect("login.aspx");
        }
    }
}