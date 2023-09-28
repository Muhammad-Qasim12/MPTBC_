<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterGroupAllotment.aspx.cs" Inherits="Printing_PrinterGroupAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर में मुद्रक द्वारा भरे गए ग्रुप की जानकारी</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" CssClass="form-select reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTenderID_I" CssClass="form-select reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"></asp:DropDownList>
                        <label>सेलेक्ट टेंडर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>मुद्रक का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control reqirerd" Height="82px" TextMode="MultiLine" Width="666px"></asp:TextBox>
                        <label>प्रदाय ग्रुप का नाम</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" Text="सुरक्षित करें" OnClientClick='javascript:return ValidateAllTextForm();' />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" OnClick="Button2_Click" Text="टेंडर इंट्री पेज पर वापस जाये" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="क्रमांक">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Company" HeaderText="मुद्रक का नाम" />
                            <asp:BoundField DataField="GroupNO" HeaderText="प्रदाय ग्रुप का नाम" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

