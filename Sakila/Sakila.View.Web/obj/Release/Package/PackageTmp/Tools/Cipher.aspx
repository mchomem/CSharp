<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cipher.aspx.cs" Inherits="Sakila.View.Web.Tools.Cipher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title></title>
        <script type="text/javascript" src="../Script/jquery-1.12.2.js"></script>
        <script type="text/javascript" src="../Style/bootstrap-3.3.6-dist/js/bootstrap.js"></script>
        <script type="text/javascript" src="../Script/Tools/Cipher.js"></script>
        <link href="../Style/bootstrap-3.3.6-dist/css/bootstrap.css" rel="stylesheet" />
    </head>

    <body>
        <form id="frmCipher" runat="server">
            <div class="panel panel-primary">

                <div class="panel-heading">
                    <h3 class="panel-title">Cipher</h3>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPlainText" runat="server" placeholder="Informe o valor a ser cifrado" CssClass="form-control" MaxLength="200" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtResult" runat="server" placeholder="Resultado" CssClass="form-control" MaxLength="1000" Enabled="false"/>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-lg-1">
                            <asp:Button ID="btnCipher" runat="server" Text="Cifrar" CssClass="btn btn-sm btn-success form-control" OnClick="btnCipher_Click"/>
                        </div>
                        <div class="col-lg-1">
                            <asp:Button ID="btnBackSystem" runat="server" Text="Voltar" CssClass="btn btn-sm btn-default form-control" OnClick="btnBackSystem_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>

</html>
