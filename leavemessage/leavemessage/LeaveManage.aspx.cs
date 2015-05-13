using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace leavemessage
{
    public partial class leaveManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BinPageDate();
            }
        }
        private void BinPageDate()
        {
            Info message = new Info();
            DataSet ds = message.GetMessages();
            gvMessage.DataSource = ds;
            gvMessage.DataBind();
        }

        protected void gvMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {   //设置新页面，并重新绑定数据
            gvMessage.PageIndex = e.NewPageIndex;
            BinPageDate();
        }

        protected void gvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button button = (Button)e.Row.FindControl("delMessage");
            if (button != null)
            {
                button.Attributes.Add("onclick", "return confirm(\"您确认要删除当前行的留言吗？\");");
            }
        }

        protected void gvMessage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "del")
            {   ///删除选择的留言
                Info message = new Info();
                if (message.DeleteMessage(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {   ///重新绑定数据
                    BinPageDate();
                }
            }
        }

    }
}