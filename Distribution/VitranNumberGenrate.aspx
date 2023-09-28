<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitranNumberGenrate.aspx.cs" Inherits="Distribution_VitranNumberGenrate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>वितरण निर्देश के लिए नंबर बनाये</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lblmsg" class="notification" runat="server" Text="डाटा देखने की लिए कृपया सभी आप्शन सेलेक्ट करे / Please Select All Options To View Data">
                    </asp:Label>
                </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"></asp:DropDownList>
                        <label id="Label3" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDlOrderNo" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        <label id="Label1" runat="server">आर्डर नंबर  </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtFirstNo" runat="server" class="form-control"></asp:TextBox>
                        <label id="Label2" runat="server">योजना बंडल नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtFirstNo0" runat="server" class="form-control"></asp:TextBox>
                        <label id="Label4" runat="server">सामान्य बंडल नंबर</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

