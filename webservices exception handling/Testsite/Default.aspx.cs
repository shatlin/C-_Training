using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        callit();


    }

    protected void callit()
    {
        divider.Service ds= new divider.Service();
        Label1.Text = ds.Divide(Convert.ToInt32(TextBox1.Text) , Convert.ToInt32(TextBox2.Text));
    }
}
