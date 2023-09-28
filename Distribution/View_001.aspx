<%@ Page Title="मांग का प्रकार मास्टर / Demand Type Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View_001.aspx.cs" Inherits="Admin_View_001" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>मांग का प्रकार मास्टर / Demand Type Master</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले / New Entry" OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdDemandTypemaster" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            DataKeyNames="DemandTypeId" OnRowDeleting="GrdDemandTypemaster_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdDemandTypemaster_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="क्रमांक / Sr. No. " DataField="DemandTypeId" />
                                <asp:BoundField HeaderText=" मांग का प्रकार (हिंदी) / Demand Type (Hindi)" DataField="DemandTypeHindi" />
                                <asp:BoundField HeaderText=" Demand Type (इंग्लिश) / Demand Type (English)" DataField="DemandTypeEng" />
                                <asp:BoundField HeaderText="विवरण / Discription" DataField="Discription" />
                                <asp:TemplateField HeaderText="डाटा में सुधार करे / Edit">
                                    <ItemTemplate>
                                        <a href="DIS_001_DemandTypeMaster.aspx?ID=<%#Eval("DemandTypeId") %>">डाटा में सुधार करे / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये / Delete"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
