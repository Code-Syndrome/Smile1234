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
            
            
        }
    }

        /// <summary>
    /// �޸�����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPass_Click(object sender, EventArgs e)
    {
        //�ж��������������Ƿ�һ�£������һ�£��򵯳���ʾ��Ϣ��������
        if (txt_pass2.Text == txt_pass3.Text)
        {
            //�����û���ź�ԭ����õ��û���Ϣ
            SqlDataReader sdr = SqlHelper.ExecuteReader("select * from members where  lname='" + Session["name"].ToString() + "' and pass='" + txt_pass1.Text + "'");

            //�ж�ԭ�����Ƿ���ȷ
            if (sdr.Read())
            {
                //����������
                SqlHelper.ExecuteNonQuery("update members set pass='" + txt_pass2.Text + "' where lname='" + Session["name"].ToString() + "'");
                MessageBox.Show(this, "�޸ĳɹ�!");

            }
            else
            {
                MessageBox.Show(this, "ԭ���벻��ȷ!");
            }
            sdr.Close();
        }
        else
        {
            MessageBox.Show(this, "�����������벻һ��!");
        }
    }


}
