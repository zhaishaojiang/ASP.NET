using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace leavemessage
{
    public class Info
    {
        public Info()    //构造函数
        { 
            
        }
        public DataSet GetMessages()   //获取留言信息
        {
            //获取连接字符串
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            //创建连接
            SqlConnection con = new SqlConnection(connectionString);
            //创建SQL语句
            string cmdText = "select * from Message order by CreateDate desc";
            //创建SqlDataAdapter
            SqlDataAdapter da = new SqlDataAdapter(cmdText, con);
            //定义DataSet
            DataSet ds = new DataSet();
            try
            {
                //打开连接
                con.Open();
                //填充数据
                da.Fill(ds, "DataTable");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public int AddMessage(string title,string message,string qq)    //添加留言信息
        {
            //获取连接字符串
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            //创建连接
            SqlConnection con = new SqlConnection(connectionString);
            //创建SQL语句
            string cmdText = "insert into Message(Title,Message,CreateDate,QQ) values(@Title,@Message,GETDATE(),@QQ)";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            //创建参数并赋值
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@Message", SqlDbType.Text);
            cmd.Parameters.Add("@QQ", SqlDbType.NVarChar, 12);
            cmd.Parameters[0].Value = title;
            cmd.Parameters[1].Value = message;
            cmd.Parameters[2].Value = qq;
            int result = -1;
            try
            {
                //打开连接
                con.Open();
                //操作数据，返回的值为实际操作的数据条数
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception(ex.Message, ex);
            }
            finally
            { 
                //关闭连接
                con.Close();
            }
            return result;
        }
        public int DeleteMessage(int messageId) //删除留言信息
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string cmdText = "delete Message where Id = @Id";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int, 4);
            cmd.Parameters[0].Value = messageId;
            int result = -1;
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public int AddReply(string message,string qq,int messageId)  //添加回复信息
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string cmdText = "insert into Reply(Reply,CreateDate,QQ,MessageId) values(@Reply,GETDATE(),@QQ,@MessageId)";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.Parameters.Add("@Reply", SqlDbType.NVarChar, 1000);
            cmd.Parameters.Add("@QQ", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@MessageId", SqlDbType.Int, 4);
            cmd.Parameters[0].Value = message;
            cmd.Parameters[1].Value = qq;
            cmd.Parameters[2].Value = messageId;
            int result = -1;
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public DataSet GetReplyByMessage(int messageId) //获取回复信息
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string cmdText = "select * from Reply where MessageId = @MessageId order by CreateDate desc";
            SqlDataAdapter da = new SqlDataAdapter(cmdText, con);
            da.SelectCommand.Parameters.Add("@MessageId", SqlDbType.Int, 4);
            da.SelectCommand.Parameters[0].Value = messageId;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "DataTable");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}