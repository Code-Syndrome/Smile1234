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
    /// ע��
    /// </summary>
    protected void ButtonReg_Click(object sender, EventArgs e)
    {

        //��֤�û����Ƿ��Ѿ�����
        if (!(SqlHelper.GetCount("select count(*) from members where lname = '" + txt_lname.Text + "' ") > 0))
        {
            MessageBox.Show(this, "���û��������ڣ����������룡");
            return;
        }


        Response.Redirect("gpwd2.aspx?l=" + txt_lname.Text);
    }



    
    
}
