<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actor.aspx.cs" Inherits="Sakila.View.Web.Actor" %>

<%@ Register Src="~/MessageDialog.ascx" TagName="MessageDialog" TagPrefix="modalMessageDialog" %>
<%@ Register Src="~/ConfirmDialog.ascx" TagName="ConfirmDialog" TagPrefix="modalConfirmDialog" %>
<%@ Register Src="~/ActorEdit.ascx" TagName="ActorEdit" TagPrefix="modalActorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSite" runat="server">

    <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <modalActorEdit:ActorEdit ID="mActorEdit" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upMessageDialog" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <modalMessageDialog:MessageDialog ID="mMessageDialog" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upConfirmDialog" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <modalConfirmDialog:ConfirmDialog ID="mConfirmDialog" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-primary">

        <div class="panel-heading">
            <h3 class="panel-title">Atores</h3>
        </div>

        <div class="panel-body">

            <div class="row">
                <div class="col-lg-2 col-xs-4">
                    <asp:TextBox ID="txtFirstName"
                        runat="server"
                        placeholder="Nome"
                        CssClass="form-control"
                        MaxLength="45"/>
                </div>
                <div class="col-lg-2 col-xs-4">
                    <asp:TextBox ID="txtLastName"
                        runat="server"
                        placeholder="Sobrenome"
                        CssClass="form-control"
                        MaxLength="45"/>
                </div>
                <div class="col-lg-1 col-xs-2">
                    <asp:Button ID="btnConsultar"
                        runat="server"
                        Text="Consultar"
                        CssClass="btn btn-sm btn-info form-control"
                        OnClick="btnConsultar_Click" />
                </div>
                <div class="col-lg-1 col-xs-2">
                    <asp:Button ID="btnNovo"
                        runat="server"
                        Text="Novo"
                        CssClass="btn btn-sm btn-success form-control"/>
                </div>
            </div>

            <div style="padding-top: 20px; padding-bottom: 20px;">

                <asp:GridView ID="gvActor" runat="server" AllowPaging="true" CssClass="table table-hover table-condensed"
                    AutoGenerateColumns="false" GridLines="None" PageSize="15" PagerSettings-Mode="NumericFirstLast"
                    OnPageIndexChanging="gvActor_PageIndexChanging"
                    OnRowCommand="gvActor_RowCommand"
                    OnRowDataBound="gvActor_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Literal ID="litActorId" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Literal ID="litFirstName" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sobrenome">
                            <ItemTemplate>
                                <asp:Literal ID="litLastName" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Atualizado em">
                            <ItemTemplate>
                                <asp:Literal ID="litLastUpdate" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnUpdate" runat="server" CssClass="glyphicon glyphicon-pencil"
                                    data-target="#actorEdit"
                                    CommandName="UP"
                                    CommandArgument="<%# ((Sakila.Model.Actor)Container.DataItem).ActorId %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="glyphicon glyphicon-remove"
                                    CommandName="DEL"
                                    CommandArgument="<%# ((Sakila.Model.Actor)Container.DataItem).ActorId %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>
