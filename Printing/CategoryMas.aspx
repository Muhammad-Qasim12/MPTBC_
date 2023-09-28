<%@ Page Title="Category Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryMas.aspx.cs" Inherits="Printing_CategoryMas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>Category Master</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <div id="messageDiv" runat="server" class="alert alert-danger" style="display: none;">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCategoryNo_V" runat="server" MaxLength="15"
                            CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);" placeholder="CategoryNo"></asp:TextBox>
                        <label id="Label1" runat="server">Category Number</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label id="Label2" runat="server">Class Name</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtColorSchText_V" runat="server" MaxLength="70" CssClass="form-control reqirerd" placeholder="ColorSchText" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <label id="Label3" runat="server">Text Color Scheme </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtColorSchCoverPaper_V" runat="server" MaxLength="70" CssClass="form-control reqirerd" placeholder="ColorSchCoverPaper" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <label id="Label4" runat="server">Cover Paper Color Scheme</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrintingPaperInformation_V" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label id="Label5" runat="server">Printing Paper Details</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlCoverPaperinformation_V" runat="server"
                            CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>Cover Paper Details</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtBindingdetail_V" runat="server" MaxLength="70" CssClass="form-control reqirerd" placeholder="Bindingdetail" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <label>Binding Details</label>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="Save" OnClientClick='javascript:return ValidateAllTextForm();'
                        OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

