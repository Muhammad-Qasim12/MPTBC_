<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewCommercialBid.aspx.cs" Inherits="Paper_ViewCommercialBid" Title="कमर्शियल बिड का तुलनात्मक पत्रक / Comparative Form Of Commercial Bid  " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>कमर्शियल बिड का तुलनात्मक पत्रक / Comparative Form Of Commercial Bid </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
     <div class="table-responsive">       <table width="100%">
                <tr>
                 <td style="text-align: left" width="30%">
                                    <a  class="btn" href="CommercialBid.aspx">
                                        
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                                    </a>
                                </td>
                      <td style="text-align: right" width="30%">
                            &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Acadmic Year :
                        </td>
                          <td style="text-align: right">
                              <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                        </td>
                                <td style="text-align: right" width="75%">
                                    <asp:TextBox ID="txtSearch" runat="server"  MaxLength="200" Width="300px"  placeholder="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; &#2326;&#2379;&#2332;&#2375; / Search By Tender Name"></asp:TextBox>
                                </td>
                                <td style="text-align: left" width="5%">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn"   Text="&#2326;&#2379;&#2332;&#2375; / Search" 
                                        onclick="btnSearch_Click"/>
                                </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="5">
                        <asp:GridView ID="GrdTenderInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="TenderTrId_I"
                             AllowPaging="True" OnPageIndexChanging="GrdTenderInfo_PageIndexChanging"
                            OnRowDataBound="GrdTenderInfo_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.<br> Tender No.">
                                    <ItemTemplate>
                                        <%#Eval("TenderNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="टेंडर का नाम<br> Tender Name">
                                    <ItemTemplate>
                                        <%#Eval("WorkName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
<%--                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Tender Type">
                                    <ItemTemplate>
                                        <%#Eval("TenderType_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )<br> E.M.D. Amount">
                                    <ItemTemplate>
                                        <%#Eval("EMDAmount_N")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br> Submission Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenderSubmissionDate_D" runat="server" Text='<%#Eval("TenderSubmissionDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="टेक्निकल बिड खोलने की दिनांक  <br> Technical Bid Opening Date">
                                        <ItemTemplate>
                                           <%#Eval("TechDate")%> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="टेक्निकल बिड खोलने का समय <br>Technical Bid Opening Time">
                                        <ItemTemplate>
                                            <%#Eval("TechTime")%> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="कमर्शियल बिड ओपन करने की दिनांक<br> Commercial Bid Opening Date">
                                        <ItemTemplate>
                                             <%#Eval("CommDate")%> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="कमर्शियल बिड ओपन करने का समय<br> Commercial Bid Opening Time">
                                        <ItemTemplate>
                                             <%#Eval("CommTime")%> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br> Edit">
                                    <ItemTemplate>
                                          <asp:Panel ID="pnlEdit" runat="server" Visible='<%# bool.Parse(Eval("EnableStatus").ToString()) %>'>
                                        <a href="CommercialBid.aspx?ID=<%# new APIProcedure().Encrypt( Eval("TenderTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                            &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/ Edit</a> 
                                              </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table></div>
        </div>
    </div>
</asp:Content>
