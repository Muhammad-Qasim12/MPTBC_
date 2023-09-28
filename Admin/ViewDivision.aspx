<%@ Page Title="संभाग (निर्माण/सुधार) / Division (Insert/Update)" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="ViewDivision.aspx.cs" Inherits="Admin_ViewDivision" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>संभाग (निर्माण/सुधार) / Division (Insert/Update)</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले / New Entry"
                            OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdDivision" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="DivisionTrno_I"
                            OnRowDeleting="GrdDivision_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdDivision_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="संभाग का नाम हिन्दी में / Division Name In Hindi" DataField="Division_Name_Hindi_V" />
                                <asp:BoundField HeaderText="संभाग का नाम अंग्रेज़ी में / Division Name In English" DataField="Division_Name_Eng_V" />


                                <asp:TemplateField HeaderText="डाटा में सुधार करे / Edit">
                                    <ItemTemplate>
                                        <a href="DivisionMaster.aspx?ID=<%# new APIProcedure().Encrypt(Eval("DivisionTrno_I").ToString()) %>">डाटा में सुधार करे / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" Visible="false" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये / Remove"
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

