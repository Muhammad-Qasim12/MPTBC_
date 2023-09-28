<%@ Page Title="ओपनिंग स्टॉक डाले / Opening Stock" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOpeningStock.aspx.cs" Inherits="Paper_ViewOpeningStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>&#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2337;&#2366;&#2354;&#2375; / Opening Stock
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
      <div class="table-responsive">      <table width="100%">
                <tr>
                    <td style="text-align: left">
                     <%--   <table>
                            <tr>
                                
                                   <td>
                                    <asp:TextBox ID="txtSearch"  runat="server" MaxLength="200" Width="300px"  placeholder="पेपर आकार खोजे "></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे " 
                                        onclick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found."  
                           AllowPaging="false" OnPageIndexChanging="GrdLOI_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                          <asp:Label ID="lblPaperTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperTrId_I")%>'></asp:Label>
                                        <asp:Label ID="lblPaperType_I" runat="server" Visible="false" Text='<%#Eval("PaperType_I")%>'></asp:Label>
                                        <asp:Label ID="lblOpnBal_Id" runat="server" Visible="false" Text='<%#Eval("OpnBal_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                    <ItemTemplate>
                                        <%#Eval("CoverInformation")%>
                                         
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;<br>Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2366;&#2340;&#2381;&#2352;&#2366;<br>Quantity">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'  MaxLength="8" Text='<%#Eval("Qty")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" 
                            OnClientClick="return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save" />
                    </td>
                </tr>
            </table></div>
        </div>
    </div>
</asp:Content>

