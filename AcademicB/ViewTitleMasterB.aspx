<%@ Page Title="अन्य पाठ्य सामाग्री के शीर्षकों की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewTitleMasterB.aspx.cs" Inherits="AcademicB_ViewTitleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>अन्य पाठ्य सामाग्री के शीर्षकों की जानकारी</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="नया डाटा डाले" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:GridView ID="GrdTitle" runat="server" CssClass="table table-bordered table-hover" DataKeyNames="TitleID_I" AutoGenerateColumns="false"
                        OnPageIndexChanging="GrdTitle_PageIndexChanging"
                        OnRowDeleting="GrdTitle_RowDeleting" OnRowEditing="GrdTitle_RowEditing">
                        <Columns>
                            <%--<asp:BoundField DataField="TitleID_I" HeaderText="शीर्षक आई. डी." ReadOnly="true" />  --%>
                            <asp:TemplateField HeaderText="क्रमांक">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="शीर्षक का नाम हिंदी में" ReadOnly="true" />
                            <asp:BoundField DataField="TitleEnglish_V" Visible="false" HeaderText="शीर्षक का नाम इंग्लिश में" ReadOnly="true" />
                            <asp:TemplateField HeaderText="उप-शीर्षकों की जानकारी">
                                <ItemTemplate>
                                    <a href="SubTitleMasterB.aspx?ID=<%# new APIProcedure().Encrypt(Eval("TitleID_I").ToString()) %>">उप-शीर्षक</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                <ItemTemplate>
                                    <a href="TitleMasterB.aspx?ID=<%# new APIProcedure().Encrypt(Eval("TitleID_I").ToString()) %>" class="btn btn-sm btn-primary"><i class="bi bi-pencil"></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये"
                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
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
