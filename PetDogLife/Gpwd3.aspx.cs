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




            ShowInfo();
        }
    }

    //��ʼ��
    private void ShowInfo()
    {
        if (Session["l"] != null)
        {
            Literal1.Text = Session["l"].ToString();

        }
    }


    /// <summary>
    /// ע��
    /// </summary>
    protected void ButtonReg_Click(object sender, EventArgs e)
    {
        //����������
        SqlHelper.ExecuteNonQuery("update members set pass='" + txt_pass.Text + "' where lname='" + Session["l"].ToString() + "' ");

        Session.Remove("l");


        MessageBox.ShowAndRedirect(this, "��ϲ���޸ĳɹ������¼��", "login.aspx");
    }



}
