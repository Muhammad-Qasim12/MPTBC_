<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderCommercialDetails.aspx.cs" Inherits="Printing_TenderCommercialDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर के कमर्शियल रेट जानकारी डाले</h2>
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
                        <asp:DropDownList ID="ddlTenderID_I" CssClass="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged1"></asp:DropDownList>
                        <label>सेलेक्ट टेंडर	</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlGropuName" CssClass="form-select" runat="server"></asp:DropDownList>
                        <label>ग्रुप का नाम	</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375; " />
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" OnClick="Button3_Click" Text="वापिस जायें " />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="DID" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("DID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">

                                <ItemTemplate><%#Eval("Company") %>  </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2375;&#2335; ">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Text='<%# Eval("Rates") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2376;&#2306;&#2325;">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>L1</asp:ListItem>
                                        <asp:ListItem>L2</asp:ListItem>
                                        <asp:ListItem>L3</asp:ListItem>
                                        <asp:ListItem>L4</asp:ListItem>
                                        <asp:ListItem>L5</asp:ListItem>
                                        <asp:ListItem>L6</asp:ListItem>
                                        <asp:ListItem>L7</asp:ListItem>
                                        <asp:ListItem>L8</asp:ListItem>
                                        <asp:ListItem>L9</asp:ListItem>
                                        <asp:ListItem>L10</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-submit" OnClick="Button2_Click" Text="सुरक्षित करें" Visible="False" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

