<%@ Page Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_TenderfeeDetailsfinance.aspx.cs" Inherits="Printing_VIEW_TenderfeeDetailsfinance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .pnl {
            z-index: 1200;
        }
    </style>

    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Tender Fees Details </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;/Add New Record"
                            OnClick="btnSave_Click" Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Button ID="btnSave0" runat="server" CssClass="btn" Text=""
                            OnClick="btnSave0_Click" Width="250px" />--%><%--<a href="ptg4_f001.xlsx" class="btn" target="_blank" >LUN &#2325;&#2366; &#2319;&#2325;&#2381;&#2360;&#2354; &#2347;&#2377;&#2352;&#2381;&#2350;&#2375;&#2335; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; </a>--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>


                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdTenderDetails" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="TenderId_I"
                             AllowPaging="True"
                            > 
                          
                            <Columns>
                               <%-- <asp:BoundField HeaderText="NIT &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2346;&#2348;&#2381;&#2354;&#2367;&#2358;&#2367;&#2306;&#2327; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; / NIT Publish Date" DataField="NITDate_D" DataFormatString="{0:MMMM d,yyyy}" />--%>
                                <%--   <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335; &#2347;&#2368;&#2360; (Rs.)" DataField="TenderDocFee_N" /> --%>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  (1)">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                        <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("lunlist") %>'/>--%>
                                        <asp:HiddenField ID="HDNTenID" runat="server" Value='<%# Eval("TenderId_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;  (2)" DataField="AcdmicYr_V" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;  (3)" DataField="TenderType_V" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  (4)" DataField="TenderNo_V" />
                                 <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  (5)">
                                    <ItemTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Width="200px" Height="100px" ScrollBars="Both" >

                                            <%#Eval("GroupNO_V") %>
                                        </asp:Panel>
                                    </ItemTemplate>


                                 </asp:TemplateField> 


                                <asp:BoundField HeaderText="LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;   " DataField="LUNSendNo_V" Visible="false" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2375; &#2354;&#2367;&#2319; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; " DataField="LUNDate_D" DataFormatString="{0:MMMM d,yyyy}" Visible="false" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2360;&#2348;&#2350;&#2367;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;  (6)" DataField="TenderSubmissionDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;  (7)" DataField="TechBidopeningDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;  (8)" DataField="CommecialBidOpeningdate_D" DataFormatString="{0:MMMM d,yyyy}" />

                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352;  &#2347;&#2368;&#2360;  &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Tender Fees Detail (9)">
                                    <ItemTemplate>


                                        <asp:LinkButton runat="server" ID="pnlTenderid" PostBackUrl='<%# "PRI0044_TenderfeeTransfer.aspx?ID="+ new APIProcedure().Encrypt(Eval("TenderId_I").ToString())   %>' Text="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368;  &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; "></asp:LinkButton>



                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352;  &#2347;&#2368;&#2360;  &#2325;&#2366; &#2360;&#2381;&#2335;&#2375;&#2335;&#2360; /Tender Fees Status (10) ">
                                    <ItemTemplate>

                                        
                                        <asp:Panel ID="pn1a" runat="server" Visible='<%# Eval("STATUS").ToString()=="0" ? false  : true %>'>
                                            
                                                &#2347;&#2366;&#2311;&#2344;&#2375;&#2306;&#2360; &#2325;&#2379;&#2306; &#2349;&#2375;&#2332; &#2342;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; </a>
                                        </asp:Panel>
                                        
                                        <asp:Panel ID="Panel1a" runat="server" Visible='<%#Eval("STATUS").ToString().Equals("1")?false:true%>'>
                                            <asp:LinkButton ID="lnBtnViewAcceptance" runat="server" OnClick="lnBtnViewAcceptance_Click"
                                                Text="&#2347;&#2366;&#2311;&#2344;&#2375;&#2306;&#2360; &#2325;&#2379;&#2306; &#2349;&#2375;&#2332;&#2375; "></asp:LinkButton>
                                             </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>                                 
                                     
                                     
                                
                                
                                
                                <asp:CommandField ShowDeleteButton="True" Visible="False" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                        </asp:GridView>

                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

