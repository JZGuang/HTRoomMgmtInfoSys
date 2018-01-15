using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class addNewRoomType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string Rtype = Tb_Rtype.Text;//房间类型名称
            int Rprize = Convert.ToInt32(Tb_Rprice.Text);//价格
            int Rsize = Convert.ToInt32(Tb_Rsize.Text);//大小
            string Rwindow = Request.Form["Rwindow"];//窗户
            string Rfacility =string.Empty;//设施
            if (Request.Form["Rfacility"]!=null)
            {
                Rfacility +=Request.Form["Rfacility"].ToString();
            }
            string sql_insert_roomType = string.Format("insert into roomtype values(null,'{0}',{1},{2},'{3}','{4}')", Rtype, Rprize, Rsize, Rwindow, Rfacility);
            int count= code.MySqlHelper.ExecuteNonQuery(sql_insert_roomType);
            if (count>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已成功添加新房型');location.href='createNewOrder.aspx'", true);
            }
        }
    }
}