<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertDepoStock.aspx.cs" Inherits="Depo_InsertDepoStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>ओपनिंग स्टॉक हेतु नंबरिंग प्रकिया</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlClass" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>कक्षा</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>माध्यम का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">योजना</asp:ListItem>
                            <asp:ListItem Value="2">सामान्य</asp:ListItem>
                        </asp:RadioButtonList>
                        <label>पुस्तक का प्रकार</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>डिपो का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="form-select" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                        </asp:DropDownList>
                        <label>वेयरहाउस</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2306;">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <%# Eval("TitleHindi_V") %>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleID_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="txtPerBundleBook" runat="server" Text='<%# Eval("BookNumber") %>'></asp:Label></ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTotlebundle" runat="server" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2361;&#2354;&#2366; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbundleFrom" runat="server" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2361;&#2354;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbookNoFrom" runat="server" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="सुरक्षित करें" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

