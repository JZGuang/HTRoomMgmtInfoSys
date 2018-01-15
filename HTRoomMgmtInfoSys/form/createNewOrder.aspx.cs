using HTRoomMgmtInfoSys.code;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTRoomMgmtInfoSys.form
{
    public partial class createNewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string oCreateTime = DateTime.Now.ToString();//创建时间
            string oOrigin = "线下订单"; //订单来源
            int oRoom = int.Parse(Tb_Oroom.Text); //房间号
            int oPeople = int.Parse(So_Opeople.Value); //人数
            int oDays = int.Parse(Tb_Days.Text);//天数
            string cIdNumber = Tb_CidNumber.Text;//身份证号
            string cName = Tb_Cname.Text;//姓名
            string cSex = Request.Form["Csex"]; //"男";//性别
            //if (Tb_Csex_M.Checked == false)
            //{
            //    cSex = "女";
            //}
            string cPhone = Tb_Cphone.Text;//电话
            string oStayTime = Tb_OstadyTime.Text;//入住时间
            string oCondition = So_Ocondition.Value;//订单状态

            //插入新的客户记录
            string sql_insert_client = "insert into client (CidNumber,Cname,Csex,Cphone) values(@idNum,@name,@sex,@phone)";
            MySqlParameter[] pms_client = new MySqlParameter[]
            {
                new MySqlParameter("@idNum",MySqlDbType.VarChar,20) {Value=cIdNumber },
                new MySqlParameter("@name",MySqlDbType.VarChar,20) {Value=cName },
                new MySqlParameter("@sex",MySqlDbType.VarChar,2) {Value=cSex},
                new MySqlParameter("@phone",MySqlDbType.VarChar,20) {Value=cPhone}

            };
            code.MySqlHelper.ExecuteNonQuery(sql_insert_client, pms_client);
            //获取新客户记录的Cid
            string sql_select_client =string.Format("select Cid from client where CidNumber={0}",cIdNumber);
            int oClientInfo=int.Parse(code.MySqlHelper.ExecuteScalar(sql_select_client).ToString());
            //获取操作员Uid
            string sql_select_admin = string.Format("select Uid from admin where Uname='{0}'", Session["userName"].ToString());
            int oOperator=int.Parse(code.MySqlHelper.ExecuteScalar(sql_select_admin).ToString());
            //插入新的订单记录
            string sql_insert_order = "insert into `order` (OcreateTime,Oorigin,Oroom,Opeople,OclientInfo,Odays,OstayTime,Ooperator,Ocondition) values (@ctime,@org,@room,@people,@client,@days,@stime,@operator,@condition)";
            MySqlParameter[] pms_order = new MySqlParameter[]
            {
                new MySqlParameter("@ctime",MySqlDbType.DateTime,0) {Value=Convert.ToDateTime(oCreateTime) },
                new MySqlParameter("@org",MySqlDbType.VarChar,20) {Value=oOrigin },
                new MySqlParameter("@room",MySqlDbType.Int32,2) {Value=oRoom},
                new MySqlParameter("@people",MySqlDbType.Int32,2) {Value=oPeople},
                new MySqlParameter("@client",MySqlDbType.Int32,20) {Value=oClientInfo},
                new MySqlParameter("@days",MySqlDbType.Int32,4) {Value=oDays},
                new MySqlParameter("@stime",MySqlDbType.DateTime,0) {Value=Convert.ToDateTime(oStayTime)},
                new MySqlParameter("@operator",MySqlDbType.Int32,20) {Value=oOperator},
                new MySqlParameter("@condition",MySqlDbType.VarChar,20) {Value=oCondition },
            };
            int count = code.MySqlHelper.ExecuteNonQuery(sql_insert_order,pms_order);
            //更新房间状态
            string sql_update_roomnumber = string.Empty;
            if (oCondition=="待入住")
            {
                sql_update_roomnumber = string.Format("update roomnumber set Rcondition='已预订' where Rnumber={0}",oRoom);

            }
            else
            {
                sql_update_roomnumber = string.Format("update roomnumber set Rcondition='已入住' where Rnumber={0}", oRoom);
            }
            code.MySqlHelper.ExecuteNonQuery(sql_update_roomnumber);

            if (count>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('已成功创建订单！');location.href='createNewOrder.aspx'", true);
            }


        }
    }
}