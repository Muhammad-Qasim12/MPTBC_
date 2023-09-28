<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DIB_014_TenderEvaluation.aspx.cs" Inherits="Paper_TenderEvaluation"
    Title="&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325; " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Evaluation--%>&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354;
                    &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325;
                    &#2346;&#2340;&#2381;&#2352;&#2325; / Comparative Chart for Insurance Tender Commercial Bid </span>
            </h2>
        </div>
        <div class="table-responsive">
            <table>
                <tr>
                    <td>
                        <b>
                            <%--Tender No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;. / Tender No.</b>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlTenderType" AutoPostBack="True" CssClass="txtbox reqirerd"
                            OnInit="ddlTenderType_Init" OnSelectedIndexChanged="ddlTenderType_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
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
                                            <%--RFP No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Tender No.
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Tender Date
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%><b>&#2348;&#2368;&#2350;&#2366;
                                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2360;&#2375;) /Insurance Date From </b>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblInsuranceDateFrom_D" Text='<%#Eval("InsuranceDateFrom_D")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%><b>&#2348;&#2368;&#2350;&#2366;
                                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2340;&#2325;) / Insurance Date To</b>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblInsuranceDateTo_D" Text='<%#Eval("InsuranceDateTo_D")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Name of Work (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Tender Name</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderWork" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Type (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/ Type of Tender
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339; Tender Details </b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblTenderDtl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--EMD. (--%>&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367;
                                            (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; ) / E.M.D. Amount(Rs.) </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEMd" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;(&#2352;&#2369;&#2346;&#2351;&#2375;
                                            &#2350;&#2375; )Tender Fees(Rs.) </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderFee" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2309;&#2306;&#2340;&#2367;&#2350; &#2340;&#2367;&#2341;&#2367; /Last Date of Tender Submission</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblSubDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnReturn"  CssClass="btn" runat="server" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2319;&#2306;" 
                                            onclick="btnReturn_Click" />
                                     </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <%--                <tr>
                    <td>
                        &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375;
                        &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTechnicalBidDate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CxtxtTechnicalBidDate" runat="server" TargetControlID="txtTechnicalBidDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCommercialBidDate" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CEtxtCommercialBidDate" runat="server" TargetControlID="txtCommercialBidDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2352;&#2344;&#2375;
                            &#2357;&#2366;&#2354;&#2368; &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2368;
                            &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/Tenderer Company Information    </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                                <th>
                                    <%--Name Of Company--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; /company
                                </th>
                                <%-- <th>--%>
                                <%--Company Address--%>
                                <%--  &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;--%>
                                <%-- </th>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlVenderFill" CssClass="txtbox reqirerd" OnInit="ddlVenderFill_Init"
                                        OnSelectedIndexChanged="ddlVenderFill_SelectedIndexChanged">
                                        <asp:ListItem Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <%-- <td>
                                    <asp:Label ID="lblCompAdd" runat="server"></asp:Label>
                                </td>--%>
                                <%--                                <td>
                                    <asp:DropDownList runat="server" ID="ddlStatus" Width="80px">
                                        <asp:ListItem Text="Yes"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>                  
                <tr>
                    <td colspan="4">
                      
                                     <table width="100%" class="tab">
                            <tr>
                                <th style="text-align: center;" colspan="3">
                                    <%-- &#2352;&#2368;&#2354; [ &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;) ]--%>
                                    &#2347;&#2381;&#2354;&#2379;&#2335;&#2352; &#2337;&#2367;&#2325;&#2381;&#2354;&#2375;&#2352;&#2375;&#2358;&#2344; /  Floater Declaration 
                                </th>
                                <th style="text-align: center;">
                                    &nbsp;</th>
                                <th style="text-align: center;" colspan="3">
                                    <%--&#2358;&#2368;&#2335; [ &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;) ]--%>
                                    &#2348;&#2352;&#2381;&#2327;&#2354;&#2352;&#2368; / Burglary 
                                </th>
                                <th style="text-align: center;">
                                    &nbsp;</th>
                                <th style="text-align: center;">
                                </th>
                                <th>
                                </th>
                            </tr>
                            <tr>
                                <th style="text-align: center;">
                                    &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350;/ Premium
                                <th style="text-align: center;">
                                   GST
                                </th>
                                <th style="text-align: center;">
                                    &#2309;&#2344;&#2381;&#2351; &#2335;&#2376;&#2325;&#2381;&#2360; /Other Tax
                                </th>
                                <th style="text-align: center;">
                                    SubTotal</th>
                                <th style="text-align: center;">
                                    &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350;/Premium
                                </th>
                                <th style="text-align: center;">
                                      GST
                                </th>
                                <th>
                                    &#2309;&#2344;&#2381;&#2351; &#2335;&#2376;&#2325;&#2381;&#2360; /Other Tax
                                </th>
                                <th>
                                    Total</th>
                                <th>
                                   &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark
                                </th>
                                <th>
                                </th>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtFlNetPremium" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                       Width="80px"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtFlServiceTax" runat="server" CssClass="txtbox reqirerd"  Width="80px" MaxLength="8"
                                        onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtFlOtherTax" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                        Width="80px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="TxtTot1" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                        Width="80px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox></td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtBuNetPremium" runat="server"  Width="80px" CssClass="txtbox reqirerd" MaxLength="8"
                                        onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtBuServiceTax" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                       Width="80px"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtBuOtherTax" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                       Width="80px"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="TxtTot2" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                       Width="80px"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox></td>
                                <td style="text-align: center;">
                                    <asp:TextBox ID="txtRemark" runat="server"  CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAdd" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                                        CssClass="btn" OnClick="btnAdd_Click" OnClientClick="return ValidateAllTextForm();" />
                                </td>
                            </tr>
                        </table>
                           
                   
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdTenderEvaluation" runat="server" AutoGenerateColumns="false"
                            GridLines="None" DataKeyNames="TenderEvaluationTrId_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" OnRowDataBound="GrdTenderEvaluation_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Company">
                                    <ItemTemplate>
                                        <%#Eval("Company_V")%>
                                        <asp:Label ID="lblVenderid_I" runat="server" Text='<%#Eval("Venderid_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%#Eval("TenderEvaluationTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%#Eval("TenderTrId_I")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2340;&#2325;&#2344;&#2367;&#2325;&#2368; &#2309;&#2361;&#2352;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;/ Technical Bid Qualify Status">
                                    <ItemTemplate>
                                        <%#Eval("Qualify_Sts_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2347;&#2381;&#2354;&#2379;&#2335;&#2352; &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350; / Floater Premium ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlPremium" runat="server" Text='<%#Eval("FlPremium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GST">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlServiceTax" runat="server" Text='<%#Eval("FlServiceTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2347;&#2381;&#2354;&#2379;&#2335;&#2352; &#2309;&#2344;&#2381;&#2351; &#2335;&#2376;&#2325;&#2381;&#2360; /Floater Other Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlOtherTax" runat="server" Text='<%#Eval("FlOtherTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2347;&#2381;&#2354;&#2379;&#2335;&#2352; &#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350; /Floater Gross Premium">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlGrossPremium" runat="server" Text='<%#Eval("FlGrossPremium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2369;&#2352;&#2381;&#2327;&#2354;&#2352;&#2368; &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350; / Burglary Premium">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuPremium" runat="server" Text='<%#Eval("BuPremium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GST">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuServiceTax" runat="server" Text='<%#Eval("BuServiceTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2369;&#2352;&#2381;&#2327;&#2354;&#2352;&#2368; &#2309;&#2344;&#2381;&#2351; &#2335;&#2376;&#2325;&#2381;&#2360; / Burglary Other Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuOtherTax" runat="server" Text='<%#Eval("BuOtherTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2369;&#2352;&#2381;&#2327;&#2354;&#2352;&#2368; &#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350; /Burglary Gross Premium ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuGrossPremium" runat="server" Text='<%#Eval("BuGrossPremium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2368;&#2350;&#2367;&#2351;&#2350; / Total Gross Premium" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalGrossPremium" runat="server" Text='<%#Eval("TotalGrossPremium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--   <asp:TemplateField HeaderText="&#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2312;-&#2350;&#2375;&#2354;">
                                <ItemTemplate>
                                    <%#Eval("PaperVendorEmail_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359;  &#2344;&#2306;.">
                                <ItemTemplate>
                                    <%#Eval("PaperVendorContactNo_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" CausesValidation="false"
                                            OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <%#Eval("Company_V")%>
                            <asp:Button runat="server" ID="btnEvalution" Text="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;(&#2311;&#2357;&#2376;&#2354;&#2381;&#2351;&#2370;&#2319;&#2358;&#2344;)"
                                CssClass="btn" OnClick="btnEvalution_Click" CausesValidation="false" Visible="false" />
                        </b>
                    </td>
                </tr>
              
                <tr>
                    <td colspan="4">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="GVEvaluation" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="TenderEvaluationTrId_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false">
                            <Columns>
                                <asp:TemplateField HeaderText="L1 &#2330;&#2369;&#2344;&#2375;&#2306;/Select L1">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rblL1" runat="server" OnCheckedChanged="rblL1_CheckedChanged"
                                            Checked='<%# (Convert.ToString(Eval("Is_L1"))=="1")?true:false%>' AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;/ Valuation">
                                    <ItemTemplate>
                                        L<asp:Label ID="lblL_1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                        <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%# Eval("TenderEvaluationTrId_I") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%# Eval("TenderTrId_I") %>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;/Company">
                                    <ItemTemplate>
                                        <%#Eval("Company_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorAddress_V" runat="server" Text='<%#Eval("PaperVendorAddress_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2351;&#2379;&#2327;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;/Qualify Status">
                                    <ItemTemplate>
                                        <%#Eval("Qualify_Sts_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2352;&#2366;&#2358;&#2367;
                                    (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;)/ Total Gross Premium(Rs.) ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBidRate_N" runat="server" Text='<%#Eval("GrossAmount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="20%" style="padding-left: 10px;">
                        <asp:Label Font-Bold="true" Visible="false" ID="lblRemarkL1" runat="server" 
                        Text="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;:"></asp:Label>
                        
                        <asp:TextBox ID="txtRemarkL1" runat="server" Text='<%# Eval("RemarkL1") %>' TextMode="MultiLine"
                            CssClass="txtbox" Visible="False"></asp:TextBox>&nbsp;&nbsp
                    </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                            CssClass="btn" CausesValidation="false" Visible="false" OnClick="btnSave_Click" />
                        <asp:Label ID="lblTenderAutoNo" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    </asp:Content>

