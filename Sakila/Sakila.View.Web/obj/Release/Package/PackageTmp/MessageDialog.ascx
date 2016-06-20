<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageDialog.ascx.cs" Inherits="Sakila.View.Web.MessageDialog" %>

<asp:Panel ID="messageDialog" runat="server" CssClass="modal fade" role="dialog" TabIndex="-1" OnPreRender="messageDialog_PreRender">
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
                <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button>
            </div>

        </div>
    </div>
</asp:Panel>