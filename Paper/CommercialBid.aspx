<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="false" 
    CodeFile="CommercialBid.aspx.cs" Inherits="Paper_CommercialBid" Title="&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325; " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
    <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                    <%--Tender Evaluation--%>&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325; </span>
            </h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td>
                        <b>
                           &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;  <br />Acadmic Year :	</b>
                    </td>
                    <td>
                            <asp:Label ID="lblAcYear" runat="server" ></asp:Label>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <b>
                            <%--Tender No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.<br />Tender No.</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" AutoPostBack="True" CssClass="txtbox reqirerd"
                            OnInit="ddlTenderType_Init" OnSelectedIndexChanged="ddlTenderType_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" runat="server" BorderColor="gray" BorderStyle="solid" BorderWidth="1px">
                            <table width="100%">
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--RFP No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />Tender No.
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Tender Date
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Name of Work (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Tender Name</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderWork" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Type (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />Tender Type
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339; <br />Description</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblTenderDtl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--EMD. (--%>&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367;
                                            (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )<br />E.M.D. Amount</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEMd" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;(&#2352;&#2369;&#2346;&#2351;&#2375;
                                            &#2350;&#2375; )<br />Tender Fee</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderFee" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                                            &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Submission Date</b>
                                    </td>
                                    <td >
                                        <asp:Label ID="lblSubDt" runat="server"></asp:Label>
                                    </td>
                                      <td>&#2325;&#2369;&#2354; &#2357;&#2366;&#2306;&#2331;&#2367;&#2340; &#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br />
Total Required Paper Quantity</td><td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td >
                    &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br />Technical Bid Opening Date </td>
                                        <td ><asp:TextBox ID="txtTechnicalBidDate" runat="server" CssClass="txtbox reqirerd"  Enabled="false"
                                        MaxLength="10"></asp:TextBox>
                                   
                    </td>
                                        <td > 	&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;<br />
Technical Bid Opening Time 
                    </td><td ><asp:TextBox ID="txtTechnicalTime" runat="server" CssClass="txtbox reqirerd" Enabled="false"
                                        MaxLength="10"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td >
                   &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
Commercial Bid Opening Date </td>
                                        <td ><asp:TextBox ID="txtCommercialBidDate" runat="server" CssClass="txtbox reqirerd"
                                        MaxLength="10"></asp:TextBox>
                                             <cc1:CalendarExtender ID="CxtxtTechnicalBidDate" runat="server" TargetControlID="txtCommercialBidDate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                   
                    </td>
                                        <td >&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;<br />
Commercial Bid Opening Time 
                    </td><td ><asp:TextBox ID="txtCommTime" runat="server" CssClass="txtbox reqirerd"
                                        MaxLength="10"></asp:TextBox>
                                   
                          <cc1:MaskedEditExtender runat="server" ID="Time15" TargetControlID="txtCommTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditExtender1" ControlExtender="Time15"
                            ControlToValidate="txtCommTime" IsValidEmpty="false" EmptyValueMessage="Time is required." ForeColor="Red"></cc1:MaskedEditValidator>
                                        
                    </td>
                </tr>


                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2352;&#2344;&#2375;
                            &#2357;&#2366;&#2354;&#2368; &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2368;
                            &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; <br /> Details Of Participate Company</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                                <th><span style="padding-left:5px;color:Red;">*</span>
                                    <%--Name Of Company--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; <br />Name Of Company
                                </th>
                                <th>
                                    <%--Company Address--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;<br />Company Address
                                </th>
                                <th>
                                    <%--Qualify Status--%>
                                    &#2340;&#2325;&#2344;&#2367;&#2325;&#2368; &#2309;&#2361;&#2352;&#2381;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;<br />
                                    Status Of Technical Qualification
                                </th>
                              
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlVenderFill" AutoPostBack="True" CssClass="txtbox reqirerd"
                                        OnInit="ddlVenderFill_Init" OnSelectedIndexChanged="ddlVenderFill_SelectedIndexChanged">
                                        <asp:ListItem Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblCompAdd" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlStatus" Width="80px">
                                        <asp:ListItem Text="Yes"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                              
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                                <th style="text-align: center;" colspan="2">
                                    [  &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2346;&#2381;&#2352;&#2340;&#2367; &#2350;&#2368;. &#2335;&#2344;) ]<br /> Rates Per Metric Ton in Rupees 
                                </th>
                                <th style="text-align: center;" colspan="2">
                                    [  &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2346;&#2381;&#2352;&#2340;&#2367; &#2350;&#2368;. &#2335;&#2344;) ]<br /> Rates Per Metric Ton in Rupees 
                                </th>
                                
                                
                            </tr>
                            <tr>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                    &#2348;&#2375;&#2360;&#2367;&#2325; &#2352;&#2375;&#2335;<br /> Basic Rate
                                </td>
                                <td >
                                    <asp:TextBox ID="txtBasicRate" runat="server" CssClass="txtbox reqirerd"  AutoPostBack="true"
                                        MaxLength="12" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtBasicRate_TextChanged"></asp:TextBox>
                                </td>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                   &#2360;&#2375;&#2360; <br /> Cess
                                </td>
                                <td >
                                    <asp:TextBox ID="txtCess" runat="server" CssClass="txtbox reqirerd" MaxLength="10"  AutoPostBack="true"
                                         onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtCess_TextChanged"></asp:TextBox>
                                </td>
                               
                              
                            </tr>
                            <tr>
                                <td >
                                    <span style="padding-left:5px;color:Red;">*</span>
                                    &#2347;&#2381;&#2352;&#2375;&#2335; & &#2309;&#2344;&#2354;&#2379;&#2337;&#2367;&#2306;&#2327; &#2330;&#2366;&#2352;&#2381;&#2332;&#2375;&#2332;(&#2360;&#2349;&#2368; &#2325;&#2352; &#2360;&#2361;&#2367;&#2340;)
                                    <br /> Freight & Unloading Charges(Including all taxes)
                                    
                                </td>
                                <td >
                                     <asp:TextBox ID="txtFUnloading" runat="server" CssClass="txtbox reqirerd" MaxLength="10"  AutoPostBack="true"
                                         onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtFUnloading_TextChanged"></asp:TextBox>
                                </td>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                   &#2319;&#2332;&#2369;&#2325;&#2375;&#2358;&#2344; &#2360;&#2375;&#2360; <br /> Education Cess
                                    </td>
                                <td >
                                    <asp:TextBox ID="txtEduCess" runat="server" CssClass="txtbox reqirerd"   AutoPostBack="true"
                                        MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtEduCess_TextChanged"></asp:TextBox>
                                </td>
                               
                            </tr>
                               <tr>
                                    <td ><span style="padding-left:5px;color:Red;">*</span>
                                   &#2335;&#2381;&#2352;&#2366;&#2306;&#2332;&#2367;&#2335; &#2311;&#2306;&#2358;&#2381;&#2351;&#2379;&#2352;&#2375;&#2306;&#2360; (&#2360;&#2349;&#2368; &#2325;&#2352; &#2360;&#2361;&#2367;&#2340;) <br />
                                    Transit Insurance (Including all taxes)
                                </td>
                                <td >
                                    <asp:TextBox ID="txtInsurange" runat="server" CssClass="txtbox reqirerd"   AutoPostBack="true"
                                        MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtInsurange_TextChanged"></asp:TextBox>
                                </td>

                                
                                <td >
                                    <span style="padding-left:5px;color:Red;">*</span>
                                    &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2319;&#2325;&#2381;&#2360;&#2366;&#2311;&#2332; &#2337;&#2381;&#2351;&#2370;&#2335;&#2368; 
                                    <br /> Central Excise Duty
                                </td>
                                <td >
                                   
                                    <asp:TextBox ID="txtExciseDuty" runat="server" CssClass="txtbox reqirerd"   AutoPostBack="true"
                                        MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                        ontextchanged="txtExciseDuty_TextChanged"></asp:TextBox>

                                </td>
                                
                               
                            </tr>
                            <tr>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                  GST@12%

                                     <%--<asp:DropDownList ID="ddlSTCSt" runat="server">
                                    <asp:ListItem Text="ST"></asp:ListItem>
                                    <asp:ListItem Text="CST"></asp:ListItem>
                                    <asp:ListItem Text="VAT"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                </td>
                                <td >
                                    <asp:TextBox ID="txtStVat" runat="server" CssClass="txtbox reqirerd"  AutoPostBack="true"
                                        MaxLength="10" ></asp:TextBox>
                                </td>
                               <td ><span style="padding-left:5px;color:Red;">*</span>
                                    &#2360;&#2352;&#2330;&#2366;&#2352;&#2381;&#2332;<br /> Surcharge
                                </td>
                                <td >
                                     <asp:TextBox ID="txtSurcharge" runat="server" CssClass="txtbox reqirerd"   AutoPostBack="true"
                                        MaxLength="12" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                         ontextchanged="txtSurcharge_TextChanged"></asp:TextBox>
                                </td>
                              
                            </tr>
                               <tr>
                                <td >
                               &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367; <br /> Total Amount 
                                </td>
                                <td >
                                    <asp:TextBox ID="txtTotalAmt" Enabled="true" runat="server" CssClass="txtbox reqirerd"   
                                        MaxLength="12" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                             &#2349;&#2379;&#2346;&#2366;&#2354; &#2360;&#2375; &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2375; &#2348;&#2368;&#2330; &#2325;&#2368; &#2342;&#2370;&#2352;&#2368; &#2325;&#2367;&#2354;&#2379;&#2350;&#2368;&#2335;&#2352; &#2350;&#2375;&#2306; <br />  Distance Between Paper Mill To Bhopal In K.M.
                                  
                                         
                                </td>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                        <asp:TextBox ID="txtDistanceKm" runat="server" CssClass="txtbox reqirerd"   
                                        MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                       
                                     </td>
                              
                              
                            </tr>
                             <tr>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                &#2346;&#2381;&#2352;&#2340;&#2367; &#2325;&#2367;&#2354;&#2379;&#2350;&#2368;&#2335;&#2352; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)<br />  Per K.M. Rate(Rupees)
                                
                                </td>
                                <td >
                               <asp:TextBox ID="txtKmRates" runat="server" CssClass="txtbox reqirerd"   
                                        MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                    
                                     </td>
                                <td ><span style="padding-left:5px;color:Red;">*</span>
                                   
                                   
                                    जीएसटी / GST</td>
                                <td >
                                    <asp:TextBox ID="txtGST" runat="server" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="javascript:tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                                </td>
                              
                              
                            </tr>
                            <tr>
                                <td>टिप्पणी
                                    <br>Remark </br>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" onkeypress="tbx_fnAlphaNumericOnly(event, this);" TextMode="SingleLine" Width="309px"></asp:TextBox>
                                </td>
                                <td>कुल राशि (जीएसटी सहित)&nbsp;&nbsp; /<br /> Total Amount including GST</td>
                                <td>
                                    <asp:TextBox ID="txtAmtWithGST" runat="server" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="javascript:tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                               
                                   
                                    
                                </td>
                                <td >
                                        <asp:Button runat="server" ID="btnAdd" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                                        CssClass="btn" OnClick="btnAdd_Click" OnClientClick="return ValidateAllTextForm();" />
                               
                                </td>
                              
                              
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" width="90%">
                        <asp:GridView ID="GrdTenderEvaluation" runat="server" AutoGenerateColumns="false"
                            GridLines="None" DataKeyNames="TenderEvaluationTrId_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="90%" AllowPaging="false" OnRowDataBound="GrdTenderEvaluation_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Company Name">
                                    <ItemTemplate>
                                        <%#Eval("PaperVendorName_V")%>
                                        <asp:Label ID="lblVenderid_I" runat="server" Text='<%#Eval("Venderid_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%#Eval("TenderEvaluationTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%#Eval("TenderTrId_I")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;<br> Company Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorAddress_V" runat="server" Text='<%#Eval("PaperVendorAddress_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2340;&#2325;&#2344;&#2367;&#2325;&#2368; &#2309;&#2361;&#2352;&#2381;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368; <br>Status Of Technical Qualification">
                                    <ItemTemplate>
                                        <%#Eval("Qualify_Sts_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2375;&#2360;&#2367;&#2325; &#2352;&#2375;&#2335;<br> Basic Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBasicRate" runat="server" Text='<%#Eval("BasicRate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2375;&#2360;<br>Cess">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCess" runat="server" Text='<%#Eval("Cess")%>'></asp:Label>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2319;&#2325;&#2381;&#2360;&#2366;&#2311;&#2332; &#2337;&#2381;&#2351;&#2370;&#2335;&#2368; <br>Central Excise Duty">
                                    <ItemTemplate>
                                     <asp:Label ID="lblExciseDuty" runat="server" Text='<%#Eval("ExciseDuty")%>'></asp:Label>   
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2319;&#2332;&#2369;&#2325;&#2375;&#2358;&#2344; &#2360;&#2375;&#2360;<br>Education Cess">
                                    <ItemTemplate>
                                         <asp:Label ID="lblEduCess" runat="server" Text='<%#Eval("EduCess")%>'></asp:Label>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2360;&#2352;&#2330;&#2366;&#2352;&#2381;&#2332;<br>Surcharge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSurcharge" runat="server" Text='<%#Eval("Surcharge")%>'></asp:Label>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText="&#2347;&#2381;&#2352;&#2375;&#2335; & &#2309;&#2344;&#2354;&#2379;&#2337;&#2367;&#2306;&#2327; &#2330;&#2366;&#2352;&#2381;&#2332;&#2375;&#2332;<br>Freight & Unloading Charges">
                                <ItemTemplate>
                                     <asp:Label ID="lblFreightUnloading" runat="server" Text='<%#Eval("FreightUnloading")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="ST/ CST/ VAT">
                                <ItemTemplate>
                                     <asp:Label ID="lblSTCSTVAT" runat="server" Text='<%#Eval("STCSTVAT")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="&#2335;&#2381;&#2352;&#2366;&#2306;&#2332;&#2367;&#2335; &#2311;&#2344;&#2381;&#2360;&#2369;&#2352;&#2366;&#2306;&#2360;<br>Transit Insurance">
                                  <ItemTemplate>
                                     <asp:Label ID="lblInsurance" runat="server" Text='<%#Eval("Insurance")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText ="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;<br>Total Amount">
                                  <ItemTemplate>
                                     <asp:Label ID="lblTotalAmt" runat="server" Text='<%#Eval("TotalAmt")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText ="जीएसटी / GST">
                                  <ItemTemplate>
                                     <asp:Label ID="lblGST" runat="server" Text='<%#Eval("GST")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText ="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367; Total Amount + <br>जीएसटी / GST">
                                  <ItemTemplate>
                                     <asp:Label ID="lblTotalPlusGSTAmt" runat="server" Text='<%#Eval("TotalPlusGSTAmt")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>

                                 <asp:TemplateField HeaderText ="&#2349;&#2379;&#2346;&#2366;&#2354; &#2360;&#2375; &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2375; &#2348;&#2368;&#2330; &#2325;&#2368; &#2342;&#2370;&#2352;&#2368; &#2325;&#2367;&#2354;&#2379;&#2350;&#2368;&#2335;&#2352; &#2350;&#2375;&#2306;<br> Distance Between Paper Mill To Bhopal In K.M.">
                                  <ItemTemplate>
                                     <asp:Label ID="lblDisKm" runat="server" Text='<%#Eval("DisKm")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText ="&#2346;&#2381;&#2352;&#2340;&#2367; &#2325;&#2367;&#2354;&#2379;&#2350;&#2368;&#2335;&#2352; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)<br>Per K.M. Rate(Rupees)">
                                  <ItemTemplate>
                                     <asp:Label ID="lblDisKmAmt" runat="server" Text='<%#Eval("DisKmAmt")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText ="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368; <br>Remark">
                                  <ItemTemplate>
                                     <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark")%>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" CausesValidation="false" OnClientClick="javascript:return confirm('Are you sure to delete ?')"  runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr id ="trTenderEvl" runat="server" visible="false">
                    <td >
                    
                <b>  &#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344; &#2325;&#2352;&#2375;<br /> Evaluation</b>
                    </td>
                    

                    <td >
                     <b>
                            <%--Evaluation --%>
                            <asp:Button runat="server" ID="btnEvalution" Text="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;(&#2311;&#2357;&#2376;&#2354;&#2381;&#2351;&#2370;&#2319;&#2358;&#2344;) / Evaluation"
                                CssClass="btn" OnClick="btnEvalution_Click" CausesValidation="false" Visible="false" />
                        </b>
                   
                    </td>


                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GVEvaluation" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="TenderEvaluationTrId_I" CssClass="tab" EmptyDataText="Record Not Found." 
                            Width="100%" AllowPaging="false" OnRowDataBound="GVEvaluation_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;<br> SrNo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                        L<asp:Label ID="lblL_1" runat="server" ></asp:Label>
                                        <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%# Eval("TenderEvaluationTrId_I") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%# Eval("TenderTrId_I") %>'
                                            Visible="false"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br> Paper Mill Name">
                                    <ItemTemplate>
                                        <%#Eval("PaperVendorName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;<br> Paper Mill Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorAddress_V" runat="server" Text='<%#Eval("PaperVendorAddress_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2351;&#2379;&#2327;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;<br>Status Of Technical Qualification">
                                    <ItemTemplate>
                                        <%#Eval("Qualify_Sts_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2352;&#2366;&#2358;&#2367;
                                    (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;)<br> Financial Amount">
                                    <ItemTemplate>
                                        
                                        <asp:Label ID="lblBidRate_N" runat="server" Text='<%#Eval("BidRate_N")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
         
                <tr>
                      <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                            CssClass="btn"  ValidationGroup="Ga" Visible="false" OnClick="btnSave_Click" />
                        <asp:Label ID="lblTenderAutoNo" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    
</ContentTemplate>

</asp:UpdatePanel>
</asp:Content>
