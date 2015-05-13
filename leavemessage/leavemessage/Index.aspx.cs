using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using System.Text;


namespace leavemessage
{
    public partial class Index : System.Web.UI.Page
    {
        string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPageData();
        }

        private void BindPageData()
        {
            Info message = new Info();
            DataSet ds = message.GetMessages();
            gvMessage.DataSource = ds;
            gvMessage.DataBind();
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            title.Text = string.Empty;
            qq.Text = string.Empty;
            lvMessage.Text = string.Empty;
            yzm.Text = string.Empty;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Info message = new Info();
            ///发表留言
            if (message.AddMessage(title.Text, lvMessage.Text, qq.Text) > 0)
            {	///重新显示数据		
                BindPageData();
                title.Text = string.Empty;
                qq.Text = string.Empty;
                lvMessage.Text = string.Empty;
                yzm.Text = string.Empty;
            }
        }
    }
}