<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="leavemessage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="App_Themes/IndexCss.css" rel="stylesheet" />
    <title>留言板</title>
    <script src="App_Themes/IndexJs.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
        <div id="title1">
            <h1>留言板</h1>
        </div>
        <div id="nav">
            <ul>
                <li><a href="#">首页</a></li>
				<li><a href="LeaveManage.aspx">留言管理</a></li>
				<li><a href="About.aspx">关于</a></li>
            </ul>
        </div>
        <asp:GridView ID="gvMessage" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table class="Table">
                            <tr>
                                <td>作者QQ：<%# Eval("QQ") %>[<%# Eval("CreateDate") %>]留言</td>
                            </tr>
                            <tr>
                                <td>&nbsp;&nbsp;标题：<%# Eval("Title") %></td>
                            </tr>
                            <tr>
                                <td><%# Eval("Message") %></td>
                            </tr>
                            <tr class="footLink">
                                <td>
                                    <li><a href="###" id="unfold" onmousedown="show()">展开</a></li>
                                    <li><a href="###" id="fold" onmousedown="hide()">收起</a></li>
                                    <li><a href="Reply.aspx?MessageID=<%# Eval("ID") %>">我要回复</a></li>
                                    <li><a href="#message">我要留言</a></li>
                                    <div>
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <a name="message"></a>
        <div class="leave">
            <div class="leave_title">
                <label>留言标题：</label>
                <asp:TextBox ID="title" runat="server"></asp:TextBox>
            </div>
            <div class="leave_author">
                <label>作者QQ：</label>
                <asp:TextBox ID="qq" runat="server"></asp:TextBox>
            </div>
            <div class="leave_content">
                <label>留言内容：</label>
                <asp:TextBox ID="lvMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="yanzhengma">
            <label>验证码：</label>
            <asp:TextBox ID="yzm" runat="server"></asp:TextBox>
            <img src="yzm.aspx" id="img" alt="验证码图片" />
            <a href="javascript:void(0)" onclick="change()">更换验证码</a>
        </div>
        <div class="submit_button">
            <asp:Button ID="submit" runat="server" Text="发表" OnClick="submit_Click" />
            <asp:Button ID="reset" runat="server" Text="清除" OnClick="reset_Click" />
        </div>
    </div>
    </form>
</body>
</html>
