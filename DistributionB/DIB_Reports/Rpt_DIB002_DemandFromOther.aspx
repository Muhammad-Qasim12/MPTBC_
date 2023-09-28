<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_DIB002_DemandFromOther.aspx.cs" Inherits="DistributionB_DIB_Reports_Rpt_DIB002_DemandFromOther" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
             <tr>
                    <td width="15%">
                        &#2360;&#2306;&#2349;&#2366;&#2327; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td width="15%">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="15%">
                        &#2332;&#2367;&#2354;&#2375; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td width="20%">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox reqirerd">
                           <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                        </asp:DropDownList>
                        </td>
                   <td>
                   <asp:Button ID="btnSave" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" runat="server" OnClientClick='javascript:return ValidateAllTextForm();' OnClick="btnSave_Click" CssClass="btn"/>
                   </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: center" style="overflow:auto;">
                        <asp:GridView ID="GrdViewOtherDemand" runat="server" AutoGenerateColumns="true" 
                            CssClass="tab" AllowPaging="True" PageSize="50">
                            <Columns>
                              <asp:TemplateField HeaderText="S.No.">
                                  <ItemTemplate>
                                      <%# Container.DataItemIndex+1 %>
                                  </ItemTemplate>
                              </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                         <asp:Button ID="btnExport" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; Excel &#2350;&#2375;&#2306; &#2349;&#2375;&#2332;&#2375;&#2306;"
                            OnClick="btnExport_Click" />
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

