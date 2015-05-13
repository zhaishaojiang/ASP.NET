<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #change{
            display:block;
            cursor:pointer;
        }
    </style>
    <script type="text/javascript">
        function chang() {
            document.getElementById('im').src = document.getElementById('im').src + '?' + 1;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
            <FooterStyle BackColor="Blue" Font-Bold="true" ForeColor="White" />
            <RowStyle BackColor="Red" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="学号"/>
                <asp:BoundField DataField="name" HeaderText="姓名"/>
                <asp:BoundField DataField="age" HeaderText="年龄"/>
            </Columns>
        </asp:GridView>
        <img src="yzm.aspx" alt="点击刷新" id="im" />
        <span id="change" onclick="chang()" >genghuan</span>
        <a href="javascript:void(0)" onclick="chang()">刷新验证码</a>
        <a href="javascript:void(0)" onclick="document.getElementById('im').src = document.getElementById('im').src +'?'+ Math.random();"  title="看不清,单击改变验证码"> 换一张</a>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>