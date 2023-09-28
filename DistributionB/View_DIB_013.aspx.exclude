<%@ Page Title="टेक्निकल बिड का तुलनात्मक पत्रक" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_DIB_013.aspx.cs" Inherits="Paper_ViewPPR_002_TechBid" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>टेक्निकल बिड का तुलनात्मक पत्रक</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px"><div class="table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table width="100%">
                            <tr>
                                <td>
                                    <a class="btn" href="DIB_013_TechnicalBid.aspx">
                                        
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;
                                    </a>
                                </td>
                                <td></td>
                                <td></td>
                                <td align="right">
                                    <asp:TextBox ID="txtSearch"  runat="server" MaxLength="200"  placeholder="टेंडर क्र. का नाम खोजे "></asp:TextBox>
                                
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे " 
                                        onclick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">
                        <asp:GridView ID="GrdLabMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." 
                           AllowPaging="True" OnPageIndexChanging="GrdLabMaster_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="टेंडर क्र.">
                                    <ItemTemplate>
                                       
                                            <%#Eval("TenderNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="टेंडर का नाम">
                                    <ItemTemplate>
                                      <%#Eval("WorkName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="बीमा कंपनी का नाम">
                                    <ItemTemplate>
                                        <%#Eval("Company_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="DIB_013_TechnicalBid.aspx?TndId=<%#Eval("TenderTrId_I") %>&VndId=<%#Eval("InsCompanyID_I") %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table></div>
        </div>
    </div>
</asp:Content>

