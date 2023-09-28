<%@ Page Title="ग्रुप निर्माण" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupDetails.aspx.cs" Inherits="Printing_GroupDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>ग्रुप निर्माण</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn-add" Text="नया ग्रुप ऐड करे" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Label ID="lblmsg" runat="server" CssClass="alert alert-success" Style="display: none"></asp:Label>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSearch" runat="server" placeholder="" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        <label>ग्रुप का नंबर टाइप करे </label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-submit" OnClick=" Button1_Click" Text="ग्रुप खोजे" />
                </div>
                <div class="col-md-4 text-right">
                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"
                        OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>2012-13</asp:ListItem>
                        <asp:ListItem>2013-14</asp:ListItem>
                        <asp:ListItem>2014-15</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-12">
                    <asp:Panel runat="server" ID="PnlGrd" GroupingText="ग्रुप की जानकारी" ScrollBars="Auto">
                        <asp:GridView runat="server" ID="grdGroupDetails" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-bordered" AllowPaging="True" PageSize="15"
                            OnPageIndexChanging="grdGroupDetails_PageIndexChanging"
                            OnSelectedIndexChanged="grdGroupDetails_SelectedIndexChanged"
                            DataKeyNames="GrpID_I" OnRowDeleting="grdGroupDetails_RowDeleting">

                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="शैक्षणिक सत्र ">
                                    <ItemTemplate><%# Eval("bankdetails")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ग्रुप का नाम">
                                    <ItemTemplate><%# Eval("groupno_v")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="सब ग्रुप क्रमाक">
                                    <ItemTemplate><%# Eval("bankname_v")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="केटेगरी" Visible="false">
                                    <ItemTemplate><%# Eval("CategoryNo_V")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="शीर्षकों की जानकारी">
                                    <ItemTemplate><%# Eval("titlehindi_v")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पेपर की जानकारी">
                                    <ItemTemplate><%# Eval("PrintingPaperDetails")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="True" />

                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>


