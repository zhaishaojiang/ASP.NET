<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="leavemessage.Reply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>回复留言</title>
    <link href="App_Themes/ReplyCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="reply_author">
            <label>作者QQ：</label>
            <asp:TextBox ID="qq" runat="server"></asp:TextBox>
        </div>
        <div class="reply_content">
            <label>回复内容：</label>
            <asp:TextBox ID="reply_message" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="submit_button">
            <asp:Button ID="submit" runat="server" Text="提交" OnClick="submit_click"  />
            <asp:Button ID="reset" runat="server" Text="清空" OnClick="reset_click" />
        </div>
    </div>
    </form>
</body>
</html>
