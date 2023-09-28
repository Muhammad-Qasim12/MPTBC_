<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChallanDetails.aspx.cs" Inherits="Paper_DispatchDetails" Title="पेपर मिल द्वारा सेंट्रल डिपो को डिस्पैच की जानकारी / Dispatch Information Of Paper Mill To Central Depot " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.GrdChallanReel.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.GrdChallanReel.ClientID %>');
            var TargetChildControl = "chkBxSelect";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            //  Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
        function SaveHeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.GrdChallanReel.ClientID %>');
            var TargetChildControl = "chkSelect";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            //  Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        function SaveChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }

    </script>
    <div class="portlet-header ui-widget-header">
        <%--LOI No. (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;
        &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354;
        &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot 
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr>
                <td colspan="4" style="height: 10px;">   शिक्षा सत्र <br />
Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366;
                    &#2344;&#2366;&#2350;<br />
                    Name Of Paper Mill
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%#Eval("PaperType")%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                    L.O.I. No. 
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" CssClass="txtbox reqirerd">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>इनवाईस नंबर<br />
                    Invoice No. 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanNo" Enabled="false" onkeypress="tbx_fnUserName(event, this);" CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>इनवाईस दिनांक<br />
                    Invoice Date 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanDate" Enabled="false" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>जी आर क्रमांक
                    <br />
                    GR No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrNo" Enabled="false" onkeypress="tbx_fnUserName(event, this);" CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>जी आर दिनांक<br />
                    GR Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrDate" Enabled="false" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGrDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>ड्राईवर का मोबाइल न.
                    <br />
                    Mobile No Of Driver 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobileNo" Enabled="false" onkeypress='javascript:tbx_fnInteger(event, this);'
                        CssClass="txtbox" MaxLength="10" Width="238px"></asp:TextBox>
                </td>
                <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Name Of Driver 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDriverName" Enabled="false" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox" MaxLength="100"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2381;&#2352;&#2325; &#2344;.<br />
                    Truck No. 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTruckNo" Enabled="false" onkeypress="tbx_fnAlphaNumeric(event, this);" CssClass="txtbox reqirerd" MaxLength="15"
                        Width="238px"></asp:TextBox>
                </td>
                <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                    Receive Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRecivedDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtRecivedDate_CalendarExtender" runat="server" TargetControlID="txtRecivedDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>

            <tr>
                <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;<br />
                    Warehouse
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlWareHouse" Width="250px" OnInit="ddlWareHouse_Init"
                        CssClass="txtbox reqirerd">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;<span class="gt-baf-word-clickable">गोदाम </span>&#2344;&#2306;&#2348;&#2352;<br />
                    Godown No
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="txtBlockNo" Width="250px"
                        CssClass="txtbox reqirerd" AutoPostBack="True">
                        <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Value="1">1</asp:ListItem>
                          <asp:ListItem Value="2">2</asp:ListItem>
                          <asp:ListItem Value="3">3</asp:ListItem>
                          <asp:ListItem Value="4">4</asp:ListItem>
                         <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>GSR पेज क्रं.<br />
                    GSR Page No
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGSRPageNo" CssClass="txtbox reqirerd" MaxLength="15" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        Width="238px"></asp:TextBox>
                </td>
                <td>GSR सीरियल क्रं.<br />
                    GSR Sr.No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGSRSrNo" CssClass="txtbox reqirerd" MaxLength="15" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>ट्रांसपोर्टर का नाम<br />
                    Name Of Transporter
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTransporterName" CssClass="txtbox reqirerd" MaxLength="250" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        Width="238px"></asp:TextBox>
                </td>
                <td>टिप्पणी<br />
                    Remark
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" CssClass="txtbox" MaxLength="250" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>प्राप्तकर्ता का नाम /Receiver Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEmployee" Width="250px"
                        CssClass="txtbox reqirerd">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnAddChallanDetails" Text="रील /बंडल प्राप्त करें "
                        CssClass="btn" OnClick="btnAddChallanDetailse_Click" />
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
                            <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type ">
                                <ItemTemplate>
                                    <%#Eval("PaperType")%>
                                    <asp:Label ID="lblDisDtl_Id" runat="server" Text='<%#Eval("DisDtl_Id")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("DisTranId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                        Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size ">
                                <ItemTemplate>
                                    <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;(मे. टन) <br>Paper Quantity(Metric Ton) ">
                                <ItemTemplate>
                                    <asp:Label ID="lblVdrSendQty" runat="server" Text='<%#Eval("VdrSendQty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="प्रदाय बंडल/रील<br>Supplied Bundle / Reel ">
                                <ItemTemplate>
                                    <asp:Label ID="lblSndrReel" runat="server" Text='<%#Eval("SndrReel")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;(मे. टन) <br>Receive Quantity(Metric Ton) ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRecivedQty" OnTextChanged="txtRecivedQty_TextChanged" AutoPostBack="true" Text='<%#Eval("ReceivedQty") %>' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                        CssClass="txtbox reqirerd" MaxLength="8" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="कुल बंडल/रील<br>Total Bundle / Reel">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNoOfReels" OnTextChanged="txtNoOfReels_TextChanged" AutoPostBack="true" Text='<%#Eval("NoOfReels") %>' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                        CssClass="txtbox reqirerd" MaxLength="8" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <table>
                        <tr>
                            <td>नोट :-प्राप्त रील/बंडल में कुल</td>
                            <td>
                                <asp:TextBox ID="txtDefReel" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' ReadOnly="true"
                                    CssClass="txtbox reqirerd" Width="40" MaxLength="8" runat="server"></asp:TextBox>
                            </td>
                            <td>रील/बंडल कटी प्राप्त हुई जिसमें कुल</td>
                            <td>
                                <asp:TextBox ID="txtDefWt" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    CssClass="txtbox reqirerd" Width="40" MaxLength="8" runat="server"></asp:TextBox></td>
                            <td>मे. टन थब्बा निकलने की संभाबना है | </td>
                        </tr>
                        <%-- <tr>
                            <td> Note :-Total  </td>
                            <td></td>
                            <td>Reels Found Defected Damang Reel Recevied Out Of</td>
                            <td> </td>
                            <td> M. Ton Possibility of Wastage. </td>
                        </tr>--%>
                    </table>

                </td>
            </tr>

            <tr>
                <td colspan="1" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" Visible="false" />
                </td>
                <td colspan="1" style="height: 10px;">
                    <asp:Button runat="server" ID="btnPrint" Text="प्राप्ति रसीद / Receipt"
                        CssClass="btn" OnClick="btnPrint_Click" Visible="false" />

                </td>
                <td colspan="2" style="height: 10px; text-align: left;"></td>
            </tr>
        </table>
    </div>
    <cc1:CalendarExtender ID="txtChallanDate_CalendarExtender" runat="server" TargetControlID="txtChallanDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 750px; margin-left: -12%; margin-top: -5%">

        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <table class="tab">
            <tr>
                <th colspan="2">डिलीवरी चालान की जानकारी / Information Of Delivery Challan
                </th>
            </tr>

            <tr>
                <td>चालान क्रमांक<br />
                    Challan No.
                </td>
                <td>
                    <asp:Label ID="lblChallanNoRole" runat="server"></asp:Label>
                </td>
            </tr>

        </table>
        <table width="100%">
            <tr>
                <td colspan="2" style="text-align: center;">
                    <div style="overflow-x: auto; min-height: 150px; max-height: 310px; width: 100%;">
                        <asp:GridView ID="GrdChallanReel" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false" ShowFooter="true"
                            OnRowDataBound="GrdChallanReel_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="चुने<br>Select">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkBxSaveHeader" runat="server" onclick="javascript:SaveHeaderClick(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblDelivery_Child_Id" runat="server" Text='<%#Eval("Delivery_Child_Id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <b>Total :</b>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="कुल शीट प्रति बंडल <br> Total Sheets Per Bundle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFTotalSheets" runat="server" Font-Bold="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="कटी रील/बंडल ">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDefectiveReel" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="रील/बंडल  नंबर">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="नेट वजन (K.G.)<br>Net Weight(K.G.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFNetWt" runat="server" Font-Bold="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रॉस वजन (K.G.)<br>Gross Weight(K.G.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFGrossWt" runat="server" Font-Bold="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnRoleAdd" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        CssClass="btn" OnClick="btnRoleAdd_Click" />
                </td>
            </tr>
        </table>

    </div>







    <div id="BillDivPrint" class="popupnew" style="display: none; width: 750px; margin-left: -12%; margin-top: -5%">
        <div align="left">
            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">प्रिंट</a>
        </div>
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDivPrint').style.display='none';">Close</a>
        </div>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <table width="100%">
                <tr>
                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" केन्द्रीय भंडार "
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">अरेरा हिल्स , भोपाल (म.प्र) 462011<br />
                        दूरभाष - 0755-2550727, 2551294, 2551565, फैक्स - 2551145,
                    <br />
                        ई-मेल - infomptbc@mp.gov.in, वेबसाइट- mptbc.nic.in
                    </td>
                </tr>
                <tr>
                    <td width="100%;" colspan="4" style="text-align: left;">शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server" Font-Bold="true"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">
                        <asp:Label ID="lblTitle" runat="server" Text="प्राप्ति रसीद"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 12px; text-align: right;"></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                        <table width="100%">


                            <tr>
                                <td width="50%" style="text-align: left">GSR पेज क्रं. :<asp:Label ID="lblGSRPagePrint" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td width="50%" style="text-align: right">दिनांक :<asp:Label ID="lblReceiptPrint" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2">वाहन क्रमांक :<asp:Label ID="lblVehicleNoPrint" runat="server" Font-Bold="true"></asp:Label>
                                    के द्वारा प्राप्त कुल रील / बंडल संख्या
                                    <asp:Label ID="lblReceiptReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                    जिसमें डैमेज रील / बंडल संख्या
                                    <asp:Label ID="lblDamajReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                    प्राप्त की गई |
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" style="height: 25px"></td>
                                <td width="50%"></td>
                            </tr>
                            <tr>
                                <td width="50%">स्टोरकीपर
                                </td>
                                <td width="50%" style="text-align: right">डिपो प्रबंधक
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" style="text-align: left;">..................................
                                </td>
                                <td width="50%" style="text-align: right">.................................
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";

        }
        function BillPrint() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDivPrint').style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
</asp:Content>
