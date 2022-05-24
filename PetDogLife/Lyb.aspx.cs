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
             
            

            
            
            bindData();
        }
    }

        /// <summary>
    /// ������
    ///</summary>
    protected void bindData()
    {
        DataPage dp = new DataPage();
        string where = "";

        int total;
        int quan = AspNetPager1.PageSize;
        int index =AspNetPager1.CurrentPageIndex;
        Repeater1.DataSource =dp.pagelist(quan, index, "board", " * ", " id ", where, " id  desc", out total);
        Repeater1.DataBind();
        AspNetPager1.RecordCount = total;
   }

    /// <summary>
    /// ��ҳ
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }



    protected void Button_Click(object sender, EventArgs e)
    {

        //��֤�Ƿ��¼
       if (Session["name"] == null)
        {
            MessageBox.Show(this, "���¼��");
            return;
        }

         //����Sql
         StringBuilder strSql = new StringBuilder();
         strSql.Append(@"insert into board ( lname,title,detail,qtime ) ");
        strSql.Append(@" values (@lname,@title,@detail,@qtime)");

        //���ò���
        SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@lname", SqlDbType.VarChar,50),
            new SqlParameter("@title", SqlDbType.VarChar,50),
            new SqlParameter("@detail", SqlDbType.NText,50000),
            new SqlParameter("@qtime", SqlDbType.DateTime,8)        };

        parameters[0].Value =Session["name"].ToString();
        parameters[1].Value =txt_title.Text;
        parameters[2].Value =txt_detail.Text;
        parameters[3].Value = DateTime.Now;

        //�ύ�����ݿ�
        SqlHelper.ExecuteNonQuery(strSql.ToString(),CommandType.Text, parameters);

        MessageBox.ShowAndRedirect(this, "�ύ�ɹ���", Request.Url.ToString());
    }



    
    
}
