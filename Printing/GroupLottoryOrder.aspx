<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupLottoryOrder.aspx.cs" Inherits="Printing_GroupLottoryOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर के ग्रुप में लाटरी नंबर का आवंटन</h2>
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
                        <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                    </asp:DropDownList>
                        <label>सेलेक्ट ग्रुप</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control reqirerd" Enabled="False"></asp:TextBox>
                        <label>लाटरी नंबर	</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" OnClientClick='javascript:return ValidateAllTextForm();' Text="सुरक्षित करें" />
                    &nbsp;&nbsp; &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn btn-submit" OnClick="Button2_Click" Text="मुद्रक द्वारा भरे गए ग्रुप की जानकारी भरे" />
                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-default" OnClick="Button3_Click" Text="वापस जाये " />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LottoryNo" HeaderText="&nbsp;&#2354;&#2366;&#2335;&#2352;&#2368; &#2344;&#2306;&#2348;&#2352;" />
                            <asp:BoundField DataField="GroupName" HeaderText=" &#2327;&#2381;&#2352;&#2369;&#2346;" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

