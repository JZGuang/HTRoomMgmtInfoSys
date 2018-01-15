using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class addNewRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDDL();
        }
        /// <summary>
        /// 绑定DDL
        /// </summary>
        protected void BindDDL()
        {
            string sql_select_RType = "select Rid,Rtype from roomtype";
            DDL_Rtype.DataSource= code.MySqlHelper.GetDataSet(sql_select_RType);
            DDL_Rtype.DataValueField = "Rid";
            DDL_Rtype.DataTextField = "Rtype";
            DDL_Rtype.DataBind();
            DDL_Rtype.Items.Insert(0, new ListItem("", ""));//插入空项
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            int rNumber = Convert.ToInt32(Tb_Rnumber.Text);
            int rId = Convert.ToInt32(DDL_Rtype.SelectedItem.Value);
            string rType = So_Rcondition.Value;
            string rPrincipal = Tb_Rprincipal.Text;

            string sql_insert_roomnumber = string.Format("insert into roomnumber values({0},{1},'{2}','{3}')", rNumber, rId, rType, rPrincipal);
            int count= code.MySqlHelper.ExecuteNonQuery(sql_insert_roomnumber);
            if (count>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已成功添加客房！');location.href='addNewRoom.aspx'", true);
            }
            
        }
    }
}