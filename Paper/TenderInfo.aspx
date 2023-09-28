<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderInfo.aspx.cs" Inherits="Paper_TenderInfo"
    Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Tender" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ValidAmt(id) {
            var Amount = id.value;
            var FrtChar = Amount.substring(0, 1);
            if (FrtChar == "0" || FrtChar == "-") {
                alert("Invalid Amount.");
                id.value = "";
                return false;
            }
            else {
                return true;

            }
        }
    </script>
    <script type = "text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) { 
                        inputList[i].checked = true;
                    }
                    else { 
                        inputList[i].checked = false;
                    }
                }
            }
        }
</script>
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                    <%--Tender Related Information--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368;
                    &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Tender</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Name of Work --%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                        Tender Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNameOfWork" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="150" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                       &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />Academic Year
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                        <asp:Label ID="lblAcYear" runat="server" Visible="False" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2325;&#2381;&#2352;.<br />
                        Tender No
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRFPNo" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                        Tender Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339;<br />
                        Description
                    </td>
                    <td >
                        <asp:TextBox runat="server" ID="txtDetails" TextMode="MultiLine" Width="255px" MaxLength="250"
                            CssClass="txtbox reqirerd" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtDetails',250);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td> <span style="padding-left:5px;color:Red;">*</span><%--Tender Type--%>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />
                        Tender Type </td>
                    <td><asp:Label ID="ddlTenderType" runat="server" Text="Rate Contract"></asp:Label></td>
                </tr>

                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--EMD. (--%>
                        &#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; )<br />
                        E.M.D. Amount
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEMD" Width="250px" MaxLength="12" onblur="return ValidAmt(this);" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360; (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; )<br />
                        Tender Fee
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderFee" Width="250px" onblur="return ValidAmt(this);" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            MaxLength="12" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                        Submission Date
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtTenderSubDt" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;"><span style="padding-left:5px;color:Red;">*</span>&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375;
                        &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        <br />
                        Technical Bid Opening Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CtxtTechnicalDate" runat="server" TargetControlID="txtTechnicalDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375;
                        &#2325;&#2366; &#2360;&#2350;&#2351;
                        <br />
                        Technical Bid Opening Time
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalTime" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="MaskedEditExtender2" TargetControlID="txtTechnicalTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditValidator1" ControlExtender="MaskedEditExtender2"
                            ControlToValidate="txtTechnicalTime" IsValidEmpty="false" EmptyValueMessage="Time is required." ForeColor="Red"></cc1:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;"><span style="padding-left:5px;color:Red;">*</span> &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                        Commercial Bid Opening Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommDate" Width="250px" MaxLength="10" CssClass="txtbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CtxtCommDate" runat="server" TargetControlID="txtCommDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span> &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;<br />
                        Commercial Bid Opening Time
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommTime" Width="250px" MaxLength="10" CssClass="txtbox"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="Time15" TargetControlID="txtCommTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditExtender1" ControlExtender="Time15"
                            ControlToValidate="txtCommTime" IsValidEmpty="false" EmptyValueMessage="Time is required." ForeColor="Red"></cc1:MaskedEditValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="1" style="height: 10px;"> &#2335;&#2375;&#2306;&#2337;&#2352; &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375;
                        <br />
                        Tender Upload
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fileUp1" Width="250px"></asp:FileUpload>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span> कुल वांछित पेपर मात्रा /Total Required Paper Quantity</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtQuantity" Width="250px" MaxLength="100" CssClass="txtbox" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                     
                    </td>
                </tr>

                     <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span> &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                        <br />
                        Paper Type
                    </td>
                    <td>
                       <asp:DropDownList ID="ddlPaperType" runat="server" AutoPostBack="true"
                            CssClass="txtbox reqirerd" OnInit="ddlPaperType_Init" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>&#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325;<br />
                            Comparative Form </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="Tender_Cond_Id" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false"
                            OnRowDataBound="GrdWorkPlan_RowDataBound">
                            <Columns>                              
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;<br> Select">
                                      <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />  &#2330;&#2369;&#2344;&#2375; 
                                          <br> </br>Select
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCheckStatus" runat="server" Text='<%#Eval("CheckStatus")%>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2358;&#2352;&#2381;&#2340;&#2375;<br>Conditions  ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTechn_TrId" runat="server" Text='<%#Eval("Techn_TrId")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTndrCondition" runat="server" Text='<%#Eval("TndrCondition")%>'></asp:Label>
                                        <asp:Label ID="lblTender_Cond_Id" runat="server" Text='<%#Eval("Tender_Cond_Id")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTnd_Cond_Id" runat="server" Text='<%#Eval("Tnd_Cond_Id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <PagerStyle CssClass="Gvpaging" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                        <br />
                        Remark
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px" MaxLength="150"
                            onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save "
                            CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:HiddenField ID="hdnFile" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtTenderSubDt"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>
