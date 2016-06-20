<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sakila.Tests.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
        </title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Nome" />
                <asp:TextBox ID="txtLastName" runat="server" placeholder="Sobrenome" />
                <asp:Button ID="btnQuery" runat="server" Text="Query Actors" OnClick="btnQuery_Click" />
                <asp:Button ID="btnQueryGenericHandler" runat="server" Text="Query Actros GH" OnClick="btnQueryGenericHandler_Click" />
            </div>
            <br />
            <div id="grid" runat="server"></div>
        </form>
    </body>
</html>
