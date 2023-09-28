<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DispatchDetails.aspx.cs" Inherits="Paper_DispatchDetails" Title="पेपर मिल द्वारा सेंट्रल डिपो को डिस्पैच की जानकारी / Dispatch Information Of Paper Mill To Central Depot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    function ValidMobileNo() {
        <%--var MobileNo = document.getElementById("<%=txtMobileNo.ClientID %>").value;
        var FrtChar = MobileNo.substring(0, 1);
        if (MobileNo.length < 10 || MobileNo.length > 10 || FrtChar == 0) {
            alert("Invalid Mobile No.");
            document.getElementById("<%=txtMobileNo.ClientID %>").value = "";
            return false;
        }
        else {
            return true;

        }--%>
    }
    function ValidAmt(id) {
        var Amount = id.value;
       
        var FrtChar = Amount.substring(0, 1);
        if (FrtChar == "0" || FrtChar == "-" || FrtChar == "") {
            alert("Invalid Quantity.");
            
            id.value = "0";
            return false;
        }
        else {
            return true;

        }
    }
   
</script>
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;
        &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354;
        &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr>
                <td colspan="4" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td>
                   शिक्षा सत्र <br />Acadmic Year :
                </td>
                <td>
                   <asp:Label ID="lblAcYear" runat="server" Visible="false"></asp:Label>
                     <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init" Visible="false"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />L.O.I. No.
                </td>
                <td>
                   <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" CssClass="txtbox reqirerd"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlLOINo_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>
                    &#2311;&#2344;&#2357;&#2377;&#2311;&#2360; &#2344;&#2306;&#2348;&#2352;<br />Invoice No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanNo"
                        CssClass="txtbox reqirerd" MaxLength="20" Width="238px"></asp:TextBox>
                </td>
                <td>
                    &#2311;&#2344;&#2357;&#2377;&#2311;&#2360; दिनांक <br />Invoice  Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 	ड्राईवर का मोबाइल न. <br />Mobile No Of Driver
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobileNo" onblur="return ValidMobileNo();" onkeypress='javascript:tbx_fnInteger(event, this);'
                        CssClass="txtbox" MaxLength="10" Width="238px"></asp:TextBox>
                </td>
                <td>
                    &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Name Of Driver
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDriverName" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox" MaxLength="100" Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &#2335;&#2381;&#2352;&#2325; &#2344;. <br />Truck No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTruckNo" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        MaxLength="15" Width="238px"></asp:TextBox>
                </td>
                <td>
                    आर्डर नंबर<br /> Order No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtOrderNo" CssClass="txtbox reqirerd" MaxLength="20"
                        onkeypress="tbx_fnUserName(event, this);" Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    जी आर क्रमांक <br />
                     GR No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrNo" onkeypress="tbx_fnUserName(event, this);"
                        CssClass="txtbox reqirerd" MaxLength="20" Width="238px"></asp:TextBox>
                </td>
                <td>
                    जी आर दिनांक<br />
                    GR Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGrDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right" > <div style="float:right;font-weight:bold;">सभी यूनिट मेट्रिक टन मे / All Unit In Metric Ton </div></td>

            </tr>
            <tr>
                <td colspan="4">
                    <table class="tab">
                        <tr>
                            <th>
                                <%--Paper Category--%>पेपर का प्रकार<br />Paper Type
                            </th>
                            <th>
                                <%--Paper Size--%>पेपर का आकार<br />Paper Size
                            </th>
                            <th>
                                <%--Paper Quantity(In Tn.)--%>&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;
                                <br />Paper Quantity
                            </th>
                            <th>
                                &#2358;&#2375;&#2359; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;  <br /> Remaining Quantity
                            </th>
                            <th>
                                <%--Target Supply Date--%>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368;
                                &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;  <br />Supply Quantity
                            </th>
                            <th>
                               बंडल/रील की संख्या <br /> No Of Bundle / Reel
                            </th>
                            <th>
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlPaperType" runat="server" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" OnInit="ddlPaperType_Init">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlPaperSize" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox runat="server" Text="0" ID="txtPaperQty" ReadOnly="true" Width="100px"
                                    MaxLength="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFieldPqty" ForeColor="Red" runat="server" ErrorMessage="Please enter quantity."
                                    ControlToValidate="txtPaperQty" InitialValue="0" Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblRemainingQty" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtVdrSendQty" onblur="return ValidAmt(this);" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="10" Width="100px" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter quantity." InitialValue="0" ControlToValidate="txtVdrSendQty"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNoOfSndReel" onblur="return ValidAmt(this);" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="10" Width="100px" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter reel." InitialValue="0" ControlToValidate="txtNoOfSndReel"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnADD" CssClass="btn" ValidationGroup="VV" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                                    OnClick="btnADD_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        OnRowDataBound="GrdWorkPlan_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पेपर का प्रकार<br> Paper Type">
                                <ItemTemplate>
                                    <%#Eval("PaperType")%>
                                    <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lblDisDtl_Id" runat="server" Text='<%#Eval("DisDtl_Id")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Paper Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperQuantity_N" runat="server" Text='<%#Eval("PaperQuantity_N")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;  <br>Supply Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblVdrSendQty" runat="server" Text='<%#Eval("VdrSendQty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" बंडल/रील की संख्या <br>No Of Bundle / Reel">
                                <ItemTemplate>
                                    <asp:Label ID="lblSndrReel" runat="server" Text='<%#Eval("SndrReel")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')"
                                        runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:CalendarExtender ID="txtChallanDate_CalendarExtender" runat="server" TargetControlID="txtChallanDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>
