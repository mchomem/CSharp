<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActorEdit.ascx.cs" Inherits="Sakila.View.Web.ActorEdit" %>

<asp:Panel ID="actorEdit" runat="server" CssClass="modal fade" role="dialog" TabIndex="-1" OnPreRender="actorEdit_PreRender">

    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Ator</h4>
            </div>

            <div class="modal-body">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblEditFirstName" runat="server" Text="Nome" CssClass="control-label" />
                                <asp:TextBox ID="txtEditFirstName" runat="server" CssClass="form-control" MaxLength="45"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblEditLastName" runat="server" Text="Sobrenome" CssClass="control-label" />
                                <asp:TextBox ID="txtEditLastName" runat="server" CssClass="form-control" MaxLength="45"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblLastUpdate" runat="server" Text="Atualizado em" CssClass="control-label" />
                                <asp:TextBox ID="txtLastUpdate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Savar" data-dismiss="modal" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>

</asp:Panel>
