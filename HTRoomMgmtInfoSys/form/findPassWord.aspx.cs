using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class findPassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            //TODO
            //连接短信接口发送验证码
        }

        protected void Btn_V_Click(object sender, EventArgs e)
        {
            string input= Tb_find.Text;
            //TODO
            // 判断用户输入验证码与接口返回是否相同
            //if (input== 正确的验证码 )
            //{

            //}
            //else
            //{

            //}
        }
    }
}