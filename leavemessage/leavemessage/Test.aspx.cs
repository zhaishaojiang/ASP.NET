using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Request.QueryString["name"];
            Label2.Text = Request.QueryString["email"]; 
            this.BindGridView();
        }
        private void BindGridView()
        {
            DataTable dtBind = this.getDB();
            this.GridView1.DataSource = dtBind;
            this.GridView1.DataBind();
        }
        /// <summary>
        /// 获取数据源的方法
        /// </summary>
        /// <returns>数据源</returns>
        private DataTable getDB()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("age");
            dt.Rows.Add(new object[] { "000001", "hekui", "26" });
            dt.Rows.Add(new object[] { "000002", "zhangyu", "26" });
            dt.Rows.Add(new object[] { "000003", "zhukundian", "27" });
            dt.Rows.Add(new object[] { "000004", "liyang", "25" });
            dt.Rows.Add(new object[] { "000005", "caili", "27" });
            return dt;
        }
    }
}