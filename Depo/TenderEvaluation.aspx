<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderEvaluation.aspx.cs" Inherits="Paper_TenderEvaluation" Title="Tender Evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Evaluation--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;
                </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                        <b>
                            <%--Tender No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.</b>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlTenderType" Width="300px" AutoPostBack="True"  CssClass="txtbox reqirerd"
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
                                            <%--RFP No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Name of Work (--%>&#2325;&#2366;&#2352;&#2381;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderWork" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Type (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339; </b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblTenderDtl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--EMD. (--%>&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367;
                                            (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEMd" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;(&#2352;&#2369;&#2346;&#2351;&#2375;
                                            &#2350;&#2375; )</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderFee" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                                            &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblSubDt" runat="server"></asp:Label>
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
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2352;&#2344;&#2375;
                            &#2357;&#2366;&#2354;&#2368; &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2368;
                            &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </b>
                    </td>
                </tr>
                  <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                               
                                <th>
                                    <%--Name Of Company--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;
                                </th>
                                <th>
                                    <%--Company Address--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;
                                </th>
                                <th>
                                    <%--Qualify Status--%>
                                    &#2351;&#2379;&#2327;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;
                                </th>
                                <th>
                                    <%--Financial Rate--%>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2352;&#2366;&#2358;&#2367;
                                    (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;)
                                </th>
                                <th>
                                &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;
                                </th>
                            </tr>
                            <tr>
                               
                                <td>
                        <asp:DropDownList runat="server" ID="ddlVenderFill" Width="300px" AutoPostBack="True" 
                                        CssClass="txtbox reqirerd" OnInit="ddlVenderFill_Init" OnSelectedIndexChanged="ddlVenderFill_SelectedIndexChanged"
                           >
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblCompAdd" runat="server" ></asp:Label>
                                </td>
                                <td>
                        <asp:DropDownList runat="server" ID="ddlStatus" Width="50px"
                          >
                            <asp:ListItem Text="Yes"></asp:ListItem>
                        </asp:DropDownList>
                                </td>
                                <td>  <asp:TextBox ID="txtBitAmt" runat="server" CssClass="txtbox reqirerd"  MaxLength="6" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                </td>
                                <td>
                                  <asp:Button runat="server" ID="btnAdd" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                            CssClass="btn" onclick="btnAdd_Click"  OnClientClick="return ValidateAllTextForm();" />
                                
                                </td>
                            </tr>
                          
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">

                 <asp:GridView ID="GrdTenderEvaluation" runat="server" AutoGenerateColumns="false" 
                             GridLines="None" DataKeyNames="TenderEvaluationTrId_I"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%"  
                             AllowPaging="false" onrowdatabound="GrdTenderEvaluation_RowDataBound" >
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                <ItemTemplate>
                                    <%#Eval("PaperVendorName_V")%>
                                    <asp:Label ID="lblVenderid_I" runat="server" Text='<%#Eval("Venderid_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%#Eval("TenderEvaluationTrId_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%#Eval("TenderTrId_I")%>' Visible="false"></asp:Label>
                                    
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;">
                                <ItemTemplate>
                                    
                                    <asp:Label ID="lblPaperVendorAddress_V" runat="server" Text='<%#Eval("PaperVendorAddress_V")%>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2327;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;">
                                <ItemTemplate>
                                    <%#Eval("Qualify_Sts_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2352;&#2366;&#2358;&#2367;
                                    (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;) ">
                                <ItemTemplate>
                                 <asp:Label ID="lblBidRate_N" runat="server" Text='<%#Eval("BidRate_N")%>'></asp:Label>   
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
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>

                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</asp:LinkButton>
                                        
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;">
                                    <ItemTemplate>

                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;</asp:LinkButton>
                                        
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
              
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Evaluation --%>
                            <asp:Button runat="server" ID="btnEvalution" Text="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;(&#2311;&#2357;&#2376;&#2354;&#2381;&#2351;&#2370;&#2319;&#2358;&#2344;)" 
                            CssClass="btn"   
                            onclick="btnEvalution_Click" CausesValidation="false" />
                            </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GVEvaluation" runat="server" AutoGenerateColumns="false" 
                             GridLines="None" DataKeyNames="TenderEvaluationTrId_I"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%"  
                             AllowPaging="false"                             
                            >
                        <Columns>
                            <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;&#2366;&#2306;&#2325;&#2344;">
                                <ItemTemplate>
                                    L<asp:Label ID="lblL_1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                    <asp:Label ID="lblTenderEvaluationTrId_I" runat="server" Text='<%# Eval("TenderEvaluationTrId_I") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblTenderTrId_I" runat="server" Text='<%# Eval("TenderTrId_I") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                <ItemTemplate>
                                    <%#Eval("PaperVendorName_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;">
                                <ItemTemplate>
                                    
                                    <asp:Label ID="lblPaperVendorAddress_V" runat="server" Text='<%#Eval("PaperVendorAddress_V")%>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2327;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2368;">
                                <ItemTemplate>
                                    <%#Eval("Qualify_Sts_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2352;&#2366;&#2358;&#2367;
                                    (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;) ">
                                <ItemTemplate>
                                    <%#Eval("BidRate_N")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                            CssClass="btn"  CausesValidation="false"
                            onclick="btnSave_Click" />
                    
                        <asp:Label ID="lblTenderAutoNo" runat="server" Visible="False"></asp:Label>
                    
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
