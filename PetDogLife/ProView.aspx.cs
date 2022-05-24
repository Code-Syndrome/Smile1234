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
            
            show();

            bind();
        }
    }

    /// <summary>
    /// ���ݱ����ʾ��Ӧ����Ϣ
    /// </summary>
    protected void show()
    {
        SqlDataReader sdrproducts = SqlHelper.ExecuteReader("select * from products where pid="+Request.QueryString["id"]);
        if(sdrproducts.Read())
        {
            Literal1.Text = sdrproducts["addtime"].ToString();
            lblpname.Text=sdrproducts["pname"].ToString();
            lblprice.Text=sdrproducts["price"].ToString();
            lblmemo.Text=sdrproducts["memo"].ToString();
            imgpic.ImageUrl = "uploads/"+sdrproducts["pic"].ToString();
            Literal2.Text = sdrproducts["quan"].ToString();

            if(int.Parse(Literal2.Text)<=0)
            {
                Button1.Enabled = false;
                Button1.Text = "���޿��";
            }
        }

      
    }


    /// <summary>
    /// ������
    /// </summary>
    protected void bind()
    {
        DataPage dp = new DataPage();
        string where = " pid=" + Request.QueryString["id"];

        int recordcount;
        int pagesize = this.AspNetPager1.PageSize;
        int pageindex = this.AspNetPager1.CurrentPageIndex;
        Repeater1.DataSource = dp.pagelist(pagesize, pageindex, "productAssess", " * ", "id", where, "id desc", out recordcount);
        Repeater1.DataBind();
    }




    /// <summary>
    /// ��ҳ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }



    /// <summary>
    /// ����-1
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>   
    protected void btnJian_Click(object sender, EventArgs e)
    {
        if (int.Parse(num.Value) > 1)
        {
            num.Value = (int.Parse(num.Value) - 1).ToString();
        }
    }

    /// <summary>
    /// ����+1
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnJia_Click(object sender, EventArgs e)
    {
        if (int.Parse(num.Value) >= int.Parse(Literal2.Text))
        {
            MessageBox.Show(this, "�����������ܴ��ڿ������");
            return;
        }
        num.Value = (int.Parse(num.Value) + 1).ToString();
    }






    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            MessageBox.Show(this, "���ȵ�¼��");
            return;
        }

     

        //�ж������Ƿ���������
        if (!PageValidate.IsNumber(num.Value))
        {
            MessageBox.Show(this, "���������������������룡");
            return;
        }


        if (int.Parse(num.Value) > int.Parse(Literal2.Text))
        {
            MessageBox.Show(this, "�����������ܴ��ڿ������");
            return;
        }

        //�������ﳵ��
        shoppingcart car = new shoppingcart();
        if (Session["car"] != null)
        {   
            car = (shoppingcart)Session["car"];
        }

        car_class product = new car_class(Request.QueryString["id"], lblpname.Text, decimal.Parse(lblprice.Text), int.Parse(num.Value), imgpic.ImageUrl);

        //���뵽���ﳵ
        car.additem(product);

        //�ѹ��ﳵ����Session
        Session["car"] = car;

        MessageBox.ShowAndRedirect(this, "�����ɹ����뷵�أ�", Request.Url.ToString());
    }
}
