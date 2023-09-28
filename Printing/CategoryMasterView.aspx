<%@ Page Title="Category Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryMasterView.aspx.cs" Inherits="Printing_CategoryMasterView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>Category Master</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="Add New Data"
                        OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-12">
                    <asp:GridView ID="GrdCategoryDetails" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered" DataKeyNames="CatID_I"
                        OnRowDeleting="GrdCategoryDetails_RowDeleting" AllowPaging="True"
                        OnPageIndexChanging="GrdCategoryDetails_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Category Number" DataField="CategoryNo_V" />
                            <asp:BoundField HeaderText="Text Color Scheme" DataField="ColorSchText_V" />
                            <asp:BoundField HeaderText="Cover Paper color scheme " DataField="ColorSchCoverPaper_V" />
                            <asp:BoundField HeaderText="Printing Paper Details" DataField="PrintingPaperInformation" />
                            <asp:BoundField HeaderText="Cover Paper Details" DataField="CoverPaperinformation" />
                            <asp:BoundField HeaderText="Binding Detail" DataField="Bindingdetail_V" />
                            <asp:TemplateField HeaderText="Edit/Update">
                                <ItemTemplate>
                                    <a href="CategoryMas.aspx?ID=<%#new APIProcedure().Encrypt(Eval("CatID_I").ToString()) %>" class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="#" ItemStyle-Width="60">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="Delete" class="btn btn-sm btn-danger" Text='<i class="bi bi-trash"></i>' OnClientClick="return confirm('The item will be deleted. Are you sure want to continue?');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


