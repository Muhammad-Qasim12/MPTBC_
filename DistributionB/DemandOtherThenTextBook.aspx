<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DemandOtherThenTextBook.aspx.cs" Inherits="DistributionB_DemandOtherThenTextBook"
    Title="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;</span> / Demand of Other then TextBook Items</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>
                      
                        
                    </td>
                     <td></td>
                    <td></td>
                    <td>
                          </td>
                   
                </tr>
                <tr>
                    <td>  <asp:Button ID="btnNewFreeDistribution" CssClass="btn" OnClick="btnNewFreeDistribution_Click"
                            runat="server" Text="&#2344;&#2312; &#2350;&#2366;&#2306;&#2327;" />
                        </td>
                   
                    <td colspan="3" align="right"> &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Year <asp:DropDownList ID="ddlAcYr" AutoPostBack="true" 
                            CssClass="txtbox" runat="server" 
                            onselectedindexchanged="ddlAcYr_SelectedIndexChanged"></asp:DropDownList> 
                        अन्य पाठ्य सामग्री का नाम / Name of Other then TextBook Item&nbsp;
                        <asp:DropDownList ID="ddlTitle" runat="server" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>                         
                      <br />
                        मांगकर्ता विभाग / Demand from Department
                        <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnSearch" CssClass="btn" OnClick="btnSearch_Click"
                            runat="server" Text="&#2326;&#2379;&#2332;&#2375;&#2306;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdLetterInfo" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            OnRowEditing="GrdLetterInfo_OnRowEditing" OnRowDeleting="GrdLetterInfo_OnRowDeleting">
                            <Columns>
                              
                                <asp:TemplateField HeaderText="क्रमांक/S.No.">
                                    <ItemTemplate>
                                      <%--  <a href="DemandfromOthers.aspx?ID=<%#Eval("demandID_I") %>">
                                            <%# Eval("LetterNo_V")%>
                                        </a>--%>
                                          <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="AcYear" HeaderText="शिक्षा सत्र /Academic Year" />
                                 <asp:BoundField DataField="DepartmentName_V" HeaderText="विभाग का नाम /Demand From Department " />
                               <%-- <asp:BoundField DataField="LetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />--%>
                                  <asp:TemplateField HeaderText="पत्र क्रमांक / Letter No">
                                    <ItemTemplate>
                                        <a href="DemandfromOthers.aspx?ID=<%# new APIProcedure().Encrypt(Eval("demandID_I").ToString()) %>">
                                            <%# Eval("LetterNo_V")%>
                                        </a>
                                         
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="पत्र दिनांक / Letter Date" />
                            
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="अन्य पाठ्य सामाग्री का नाम / Other then TextBook Item" />
                                 <asp:BoundField DataField = "DemandFrom" HeaderText="प्रदाय का प्रकार / Type of Demand" />
                                  <asp:BoundField DataField = "OtherAgencyName_V" HeaderText="अन्य संस्था का नाम / Name of Other Agency" />
                                 <asp:BoundField DataField = "TotalSupply" HeaderText="कुल मांग संख्या /Total Demand" />
                                 <asp:TemplateField Visible="true" HeaderText="देयक निर्माण/Bill Process">
                                    <ItemTemplate>
                                        <a href="DIB_005_ProcessBill.aspx?DemandID=<%# new APIProcedure().Encrypt(Eval("demandID_I").ToString()) %>">
                                           देयक निर्माण/Bill Process
                                        </a>
                                         
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div style="height: 5px;">
            </div>
        </div>
    </div>
</asp:Content>
