using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class findpwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_find_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from admin where Uphone='" + Tb_name.Text+"'";
            int count=Convert.ToInt32(code.MySqlHelper.ExecuteScalar(sql));
            string v = Tb_v.Text;
            if (count>0)//加条件v
            {
                string sql_f = "select UpassWord from admin where Uphone='" + Tb_name.Text + "'";
                MySqlDataReader dr= code.MySqlHelper.ExecuteReader(sql_f);
                string pwd = string.Empty;
                while (dr.Read())
                {
                    pwd = dr.GetString(0);
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('您的密码是："+ pwd + "  请您牢记！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('未查询到相关用户！');", true);
            }
        }
    }
}