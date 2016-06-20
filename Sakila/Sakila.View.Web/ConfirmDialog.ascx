<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmDialog.ascx.cs" Inherits="Sakila.View.Web.ConfirmDialog" %>

<asp:Panel ID="confirmDialog" runat="server" CssClass="modal fade" role="dialog" TabIndex="-1" OnPreRender="confirmDialog_PreRender">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">

            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Label ID="lblTitleDialog" runat="server" />
                </h4>
            </div>

            <div class="modal-body">
                <asp:Label ID="lblMessage" runat="server" />
            </div>

            <div class="modal-footer">
                <asp:Button ID="btnYes" Text="Sim"  CssClas="btn btn-sm btn-success form-control" runat="server" data-dismiss="modal" OnClick="btnYes_Click"></asp:Button>
                <asp:Button ID="btnNo" Text="Não" CssClas="btn btn-sm btn-success form-control" runat="server" data-dismiss="modal" OnClick="btnNo_Click"></asp:Button>
                <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button>
            </div>

        </div>
    </div>
</asp:Panel>