using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public partial class member_Default  : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Session["name"] != null)
        {
            ViewState["url"] = Request.UrlReferrer.ToString();
            //��ʼ��
            chushi();
        }
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    protected void chushi()
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(@"select * from productAssess where oid='" + Request.QueryString["oid"]+"' and pid="+Request.QueryString["pid"]);

        //���ݱ�ŵõ���Ӧ�ļ�¼
        DataSet ds = SqlHelper.ExecuteforDataSet(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            rblstar.SelectedValue = ds.Tables[0].Rows[0]["star"].ToString();
            txt_memo.Text = ds.Tables[0].Rows[0]["memo"].ToString();
            btnPass.Enabled = false;

        } 
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMess_Click(object sender, EventArgs e)
    {

        //����Sql
        StringBuilder strSql = new StringBuilder();
        strSql.Append(@"insert into ProductAssess ( pid,oid,lname,star,memo,atime ) ");
        strSql.Append(@" values (@pid,@oid,@lname,@star,@memo,@atime)");

        //���ò���
        SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@pid", SqlDbType.Int,4),
            new SqlParameter("@oid", SqlDbType.VarChar,50),
            new SqlParameter("@lname", SqlDbType.VarChar,50),
            new SqlParameter("@star", SqlDbType.VarChar,50),
            new SqlParameter("@memo", SqlDbType.VarChar,500),
            new SqlParameter("@atime", SqlDbType.DateTime,8)       };

        parameters[0].Value = Request.QueryString["pid"];
        parameters[1].Value = Request.QueryString["oid"];
        parameters[2].Value = Session["name"].ToString();
        parameters[3].Value = rblstar.SelectedValue;
        parameters[4].Value = txt_memo.Text;
        parameters[5].Value = DateTime.Now;

        //�ύ�����ݿ�
            SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);

        MessageBox.ShowAndRedirect(this, "����ɹ���", ViewState["url"].ToString());
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["url"].ToString());
    }
}
