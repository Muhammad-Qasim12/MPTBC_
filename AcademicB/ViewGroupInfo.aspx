<%@ Page Title="डिमांड ग्रुप की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewGroupInfo.aspx.cs" Inherits="AcademicB_ViewGroupInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>मुद्रण निविदा के लिए ग्रुप निर्माण की जानकारी / Information of Group Creation for Printing Tender </span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले/New Information" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Title:
                         <asp:DropDownList ID="DropDownList1" CssClass="txtbox"
                            runat="server">
                        </asp:DropDownList>
                         <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClientClick="return ValidateAllTextForm1();" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdTitle" runat="server" CssClass="tab" DataKeyNames="GrpID_I" AutoGenerateColumns="false"
                            OnPageIndexChanging="GrdTitle_PageIndexChanging"
                            OnRowDeleting="GrdTitle_RowDeleting" OnRowEditing="GrdTitle_RowEditing">
                            <Columns>
                                 <asp:BoundField DataField="GroupNO_V" HeaderText="ग्रुप नंबर/Goup No." ReadOnly="true" />
                                <asp:BoundField DataField="Title" HeaderText="	शीर्षक का नाम /Title" ReadOnly="true" />
                                                               <asp:BoundField DataField="Transdate_D" DataFormatString="{0:dd/MM/yyyy}" HeaderText="ग्रुप निर्माण दिनांक/Group Creation Date" ReadOnly="true" />
                                <asp:BoundField DataField="GroupName" HeaderText="ग्रुप का नाम/Group Name" ReadOnly="true" />
                                <asp:TemplateField HeaderText="डाटा में सुधार करे/Edit">
                                    <ItemTemplate>
                                        <a href="GroupCreation.aspx?ID=<%#new APIProcedure().Encrypt( Eval("GrpID_I").ToString()) %>">डाटा में सुधार करे</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये"
                                            OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>
