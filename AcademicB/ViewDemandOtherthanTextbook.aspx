<%@ Page Title="अन्य पाठ्य सामग्री की मांग " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDemandOtherthanTextbook.aspx.cs" 
Inherits="AcademicB_ViewDemandOtherthanTextbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>अन्य पाठ्य सामग्री की मांग </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdCategoryDetails" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="DemandID_I"                             
                            onrowdeleting="GrdCategoryDetails_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdCategoryDetails_PageIndexChanging">
                            <Columns> 
                                <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                  <ItemTemplate>
                                   <%# Container.DataItemIndex+1 %>
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText=" शीर्षक का नाम / Other then TextBook Item" DataField="TitleHindi_V" />
                                <asp:BoundField HeaderText="उप शीर्षक का नाम /  Sub Title" DataField="SubTitleHindi_V"/>
                                <asp:BoundField HeaderText="कुल शीर्षकों की संख्या / Total Demand Quantity" DataField="TotalQty_I" />
                                <asp:BoundField HeaderText="मांग निर्धारण दिनांक / Demand Date " DataFormatString="{0:dd/MM/yyyy}" DataField="DemandGenrationDate_D" />   
                             
                            </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

