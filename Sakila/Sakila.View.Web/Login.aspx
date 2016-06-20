<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sakila.View.Web.Login" %>

<%@ Register Src="~/MessageDialog.ascx" TagName="MessageDialog" TagPrefix="modalMessageDialog" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script type="text/javascript" src="Scripts/jquery-1.12.2.js"></script>
        <link href="Styles/bootstrap-3.3.6-dist/css/bootstrap.css" rel="stylesheet" />
    
        <!-- Bootstrap core CSS -->
        <%--<link href="../../dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <%--<link href="../../assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet" />--%>

        <!-- Custom styles for this template -->
        <link href="Styles/Login.css" rel="stylesheet" />

        <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
        <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
        <%--<script src="../../assets/js/ie-emulation-modes-warning.js"></script>--%>

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->
        <title></title>
    </head>

    <body>
        <div class="container">
            <form id="frmLogin" runat="server" class="form-signin">
                <asp:ScriptManager ID="ScriptManagerLogin" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upMessageDialog" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <modalMessageDialog:MessageDialog ID="mMessageDialog" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <h2 class="form-signin-heading">Sakila</h2>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Usuário" Style="margin-bottom:10px;" MaxLength="20"/>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Senha" TextMode="Password" Style="margin-bottom:10px;" MaxLength="200"/>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" />
            </form>
        </div>

        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <%--<script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>--%>
    </body>

</html>
