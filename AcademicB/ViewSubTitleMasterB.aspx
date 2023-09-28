<%@ Page Title="उप - शीर्षकों की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewSubTitleMasterB.aspx.cs" Inherits="AcademicB_ViewSubTitleMasterB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>उप - शीर्षकों की जानकारी</span></h2>
        </div>
        <div style="padding: 0 10px;">
        <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td>
             <asp:GridView ID="GrdTitle" runat="server" CssClass="tab" DataKeyNames="SubTitleID_I" AutoGenerateColumns="false" OnPageIndexChanging="GrdTitle_PageIndexChanging"
                OnRowDeleting="GrdTitle_RowDeleting" OnRowEditing="GrdTitle_RowEditing">
                <Columns>
                    <asp:BoundField DataField="SubTitleID_I" HeaderText="उप -शीर्षक आई. डी." ReadOnly="true" />  
                    <asp:BoundField DataField="TitleEnglish_V" HeaderText="शीर्षक का नाम" ReadOnly="true" />                
                      <asp:BoundField DataField="SubTitleHindi_V" HeaderText="उप -शीर्षक का नाम हिंदी में" ReadOnly="true" />                
                    <asp:BoundField DataField="SubTitleEnglish_V" HeaderText="उप -शीर्षक का नाम इंग्लिश में" ReadOnly="true" />
                  
                    <asp:TemplateField HeaderText="डाटा में सुधार करे">
                        <ItemTemplate>
                            <a href="SubTitleMasterB.aspx?ID=<%#Eval("SubTitleID_I") %>">डाटा में सुधार करे</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये"
                                OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
            </asp:GridView>
            </td>
        </tr>
        </table>

           
        </div>
    </div>
</asp:Content>
