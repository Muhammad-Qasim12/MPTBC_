<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTenderInfo.aspx.cs"
    Inherits="AcademicB_ViewTenderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <style>
    .pnl
    {
        z-index:1200;
        
        }
    </style>

<div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>मुद्रण निविदा की जानकारी / Printing Tender Information
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;/New Tender"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdTenderDetails" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="TenderId_I" 
                            OnRowDataBound="GrdTenderDetails_RowDataBound"
                            onrowdeleting="GrdTenderDetails_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdTenderDetails_PageIndexChanging" 
                            onselectedindexchanged="GrdTenderDetails_SelectedIndexChanged">
                            <Columns> 
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                  <ItemTemplate>
                                   <%# Container.DataItemIndex+1 %>
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/Academic Year" DataField="AcdmicYr_V" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/Tender Type" DataField="TenderType_V"/>
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Tender No" DataField="TenderNo_V" />

                               <%-- <asp:BoundField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Group No" DataField="GroupNO_V" />--%>
                               <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Group No">
                                    <ItemTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Width="200px" Height="100px" ScrollBars="Both" >
                                            <%#Eval("GroupNO_V") %>
                                        </asp:Panel>
                                    </ItemTemplate>


                                 </asp:TemplateField>

                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/ Tender Date" DataField="TenderDate_D" DataFormatString="{0:MMMM d,yyyy}"/>
                                <asp:BoundField HeaderText="LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" DataField="LUNSendNo_V" Visible="false"   />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2375; &#2354;&#2367;&#2319; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;" DataField="LUNDate_D" DataFormatString="{0:MMMM d,yyyy}" Visible="false" />
                                <asp:BoundField HeaderText="NIT &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2346;&#2348;&#2381;&#2354;&#2367;&#2358;&#2367;&#2306;&#2327; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; / NIIT  Tender Publication Date" DataField="NITDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                              <%--   <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335; &#2347;&#2368;&#2360; (Rs.)" DataField="TenderDocFee_N" /> --%>
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2360;&#2348;&#2350;&#2367;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/Tender Submission Date" DataField="TenderSubmissionDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/ Technical Bid Opening Date" DataField="TechBidopeningDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/Commercial Bid Opening Date" DataField="CommecialBidOpeningdate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                 
                                  <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/Edit">
                                    <ItemTemplate>
                                    
                                    
                                    <asp:LinkButton runat="server" ID="pnlTenderid" PostBackUrl='<%#"TenderDetailsB.aspx?ID="+ new APIProcedure().Encrypt(Eval("TenderId_I").ToString()) %>' Text="&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;"> </asp:LinkButton>
                                  
                                     
                                   
                                    </ItemTemplate>
                                </asp:TemplateField>   

                                

                                <asp:TemplateField HeaderText="मुद्रक द्वारा भरे गए ग्रुप की जानकारी ">
                                    <ItemTemplate>
                                                                          
                                                 <a href="PrinterGroupAllotment.aspx">मुद्रक द्वारा भरे गए ग्रुप की जानकारी  </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="कमर्शियल रेट जानकारी डाले ">
                                    <ItemTemplate>
                                                                          
                                                 <a href="TenderCommercialDetails.aspx">कमर्शियल रेट जानकारी डाले   </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2319;&#2357;&#2354;&#2369;&#2358;&#2344; &#2325;&#2352;&#2375;/Tender Evaluation">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdnTenEval" runat="server" Value='<%# Eval("TenEvalID_I") %>' />
                                    


                                        <a href="ACB_004_TenderEvaluationDetails.aspx?ID=<%# new APIProcedure().Encrypt(Eval("TenderId_I").ToString()) %>">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2319;&#2357;&#2354;&#2369;&#2358;&#2344; &#2325;&#2352;&#2375; </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        
    </div>

   

</asp:Content>

