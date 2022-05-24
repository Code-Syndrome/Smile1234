using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

 
public partial class news  : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
             
            
            
            
            
        }
    }

        /// <summary>
    /// �û���¼
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
                 //�����û���������õ��û���Ϣ
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select * from members ");
            strSql.Append(@" where lname=@lname and pass=@pass");

            //���ò���
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@lname", SqlDbType.VarChar,50),
            new SqlParameter("@pass", SqlDbType.VarChar,50)     };

            parameters[0].Value = txt_lname.Text;
            parameters[1].Value = txt_pass.Text;

            //�����û���������õ��û���Ϣ
            SqlDataReader sdr = SqlHelper.ExecuteReader(strSql.ToString(),CommandType.Text, parameters);

            //�ж��û��Ƿ����
            if (sdr.Read())
            {
                Session["name"] = sdr["lname"].ToString();         
                Response.Redirect("member/default.aspx");

            }
            else
            {            
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('��¼ʧ�ܣ��û������������');</script>");
            }
    }

    /// <summary>
    /// �˳���¼
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void logLnk_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("default.aspx");
    }



    
    
}
