using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace leavemessage
{
    public partial class Reply : System.Web.UI.Page
    {
        int MessageID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["MessageID"] != null)
            {
                MessageID = Int32.Parse(Request.Params["MessageID"].ToString());
            }
            submit.Enabled = MessageID > 0 ? true : false;
        }
        protected void submit_click(object sender, EventArgs e)
        {
            Info message = new Info();
            ///发表回复
            if (message.AddReply(reply_message.Text,qq.Text, MessageID) > 0)
            {	///重定向到留言页面	
                //Response.Redirect("Index.aspx");
                string url;
                url = "Index.aspx?content" + GetReplyMessage();
                Response.Redirect(url);
                //Session["content"] = GetReplyMessage();
                //Server.Transfer("Index.aspx"); 
            }
        }
        protected void reset_click(object sender, EventArgs e)
        {
            qq.Text = string.Empty;
            reply_message.Text = string.Empty;
        }
        public string GetReplyMessage()
        { 
            Info message = new Info();
            DataSet ds = message.GetReplyByMessage(MessageID);
            StringBuilder returnHtml = new StringBuilder();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                returnHtml.AppendFormat("<div>{0}于[{1}] 回复</div>", row["QQ"], row["CreateDate"]);
                returnHtml.Append("<br />");
                returnHtml.AppendFormat("<div>{0}</div>", row["Reply"]);
                returnHtml.Append("<br />");
            }
            return returnHtml.ToString();
        }    
    }
}