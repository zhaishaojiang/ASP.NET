<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveManage.aspx.cs" Inherits="leavemessage.leaveManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="App_Themes/LeaveMessageCss.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="title">
            <h1>留言管理</h1>
        </div>
        <asp:GridView ID="gvMessage" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeader="False" AllowPaging="True" 
            OnPageIndexChanging="gvMessage_PageIndexChanging" PageSize="5" OnRowDataBound="gvMessage_RowDataBound" OnRowCommand="gvMessage_RowCommand">
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
                            <tr class="delete_leave">
                                <td>
                                    <asp:Button ID="delMessage" class="del_message" CommandArgument='<%# Eval("Id") %>' CommandName="del" 
                                        runat="server" Text="删除该留言" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings  FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
                                NextPageText="下一页" PreviousPageText="上一页" Position="TopAndBottom" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
