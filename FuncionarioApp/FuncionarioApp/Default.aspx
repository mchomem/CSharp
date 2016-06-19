<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FuncionarioApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/jquery/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="Scripts/Default.js"></script>
    <link href="Styles/Default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Pesquisar Funcionários</legend>
        <table>
            <thead></thead>
            <tbody>
                <tr>
                    <td>Sexo</td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                            <asp:ListItem Value="F">Feminino</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar (XML)" OnClick="btnPesquisar_Click" />
                    </td>
                    <td>
                        <input id="btnPesquisarJSON" type="button" value="Pesquisar (JSON)" onclick="" />
                    </td>
                </tr>
            </tbody>
            <tfoot></tfoot>
        </table>
    </fieldset>

    <div>
        <asp:GridView ID="gvwFuncionarios" runat="server" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField HeaderText="ID"               DataField="idt_func" />
                <asp:BoundField HeaderText="CPF"              DataField="cpf_func" />
                <asp:BoundField HeaderText="Nome"             DataField="nom_func" />
                <asp:BoundField HeaderText="RG"               DataField="ci_func" />
                <asp:BoundField HeaderText="Email"            DataField="email_func" />
                <asp:BoundField HeaderText="Tel. Residencial" DataField="tel_res_func" />
                <asp:BoundField HeaderText="Tel. Celular"     DataField="tel_cel_func" />
                <asp:BoundField HeaderText="Data Nasc."       DataField="dat_nasc_func" />
                <asp:BoundField HeaderText="Sexo"             DataField="sexo_func" />
            </Columns>
        </asp:GridView>
    </div>

    <div id="divJSON"></div>
</asp:Content>
