<%@ Page Title=" डिलीवरी चालान की जानकारी / Information Of Delivery Challan" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DeliveryReelEntry.aspx.cs" Inherits="PaperVendor_DeliveryReelEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function ValidAmt(id) {
            var Amount = id.value;

            var FrtChar = Amount.substring(0, 1);
            if (FrtChar == "0" || FrtChar == "-") {
                alert("Invalid Weight.");

                id.value = "";
                return false;
            }
            else {
                return true;

            }
        }
        function GrossWt() { 
            var NetWet = document.getElementById('<%=txtNetWet.ClientID%>').value; 
         
            if (document.getElementById('<%=HiddenField1.ClientID%>').value == "1975") {
                if (NetWet != "") {
                    document.getElementById('<%=txtGrossWt.ClientID%>').value = parseFloat(NetWet) + 6;
                }
           }
            else{ document.getElementById('<%=txtGrossWt.ClientID%>').value = parseFloat(NetWet) + 5;} 

        }

    </script>
    <div class="portlet-header ui-widget-header">
        डिलीवरी चालान की जानकारी / Information Of Delivery Challan
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr>
                <td colspan="4" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                    Challan No.
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlChallanNo" Width="250px" CssClass="txtbox reqirerd"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlLOINo_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>                        
                    </asp:DropDownList>
                    <asp:HiddenField ID="HDN_PaperCategory" runat="server" />
                </td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <td>
                    शिक्षा सत्र
                    <br />
                    Acadmic Year :
                </td>
                <td>
                    <asp:Label ID="lblAcYear" runat="server"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init" Visible="false"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <table class="tab">
                        <tr>
                            <th>
                                <%--Paper Category--%>पेपर का प्रकार
                                <br />
                                Paper Type
                            </th>
                            <th>
                                <%--Paper Size--%>पेपर का आकार<br />
                                Paper Size
                            </th>
                            <th><%=hTotBundleReel%></th>
                            <th><%=hTotSheetsPerReemBundle%>
                            </th>
                            <th><%=hRollNo%></th>
                            <th>&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)<br />
                                Net Weight(K.G.)
                            </th>
                            <th>&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br />
                                Gross Weight(K.G.)
                            </th>
                            <th>
                                <asp:CheckBox ID="chkAutoBundel" runat="server"  Text="Auto Generate Bundle Nos" Visible="false"   />

                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlPaperType" runat="server" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" OnInit="ddlPaperType_Init">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqddlPaperType" ForeColor="Red" runat="server"
                                    ErrorMessage="Please select paper type." InitialValue="Select" ControlToValidate="ddlPaperType"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlPaperSize" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPaperSize_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqddlPaperSize" ForeColor="Red" runat="server"
                                    ErrorMessage="Please select paper size." InitialValue="Select" ControlToValidate="ddlPaperSize"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblTotReel" runat="server" Text="0"></asp:Label>
                            </td>
                              <td>
                                <asp:TextBox runat="server" ID="txtTotalSheets" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="15" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RqTotalSheets" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter total sheets." InitialValue="0" ControlToValidate="txtTotalSheets"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRollNo" 
                                    MaxLength="12" Width="100px" onkeypress="return fnonlyNos11(event,this);"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter roll no." InitialValue="0" ControlToValidate="txtRollNo"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                              
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNetWet" onblur="return ValidAmt(this);" onchange="GrossWt();"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="8" Width="100px" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter net wt." InitialValue="0" ControlToValidate="txtNetWet"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtGrossWt" onblur="return ValidAmt(this);" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="8" Width="100px" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                    ErrorMessage="Please enter gross wt." InitialValue="0" ControlToValidate="txtGrossWt"
                                    Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnADD" CssClass="btn" ValidationGroup="VV" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                                    OnClick="btnADD_Click" OnClientClick="return fnvalidate_txt();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        OnRowDataBound="GrdWorkPlan_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
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
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="रोल नंबर<br>Roll No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                  <b>Total : </b>
                                </FooterTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="कुल शीट प्रति रीम/बंडल <br> Total Sheets Per Reem / Bundle">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                 <asp:Label ID="lblFTotalSheets" runat="server"  Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="नेट वजन (K.G.)<br>Net Weight(K.G.)">
                                <ItemTemplate>
                                    <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:Label ID="lblFNetWt" runat="server"  Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ग्रॉस वजन (K.G.)<br>Gross Weight(K.G.)">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:Label ID="lblFGrossWt" runat="server"  Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
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
                    <asp:HiddenField ID="HDN_PaperType_I" runat="server" />
                     <asp:HiddenField ID="HDN_PaperSize" runat="server" />
                     <asp:HiddenField ID="HDN_VendorCode" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <script language="Javascript" type="text/javascript">
        function fnonlyNos11(e, t) {
            try {
                if (window.event) {

                    var charCode = window.event.keyCode;

                }

                else if (e) {

                    var charCode = e.which;

                }

                else { return true; }

                if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                    return false;

                }

                return true;

            }

            catch (err) {

                // alert(err.Description);

            }

        }

        function fnvalidate_txt() {
            if (document.getElementById("<%=ddlPaperType.ClientID%>").value == "Select") {
                 alert("Please select paper type.");
                 return false;
             }

             if (document.getElementById("<%=ddlPaperSize.ClientID%>").value == "Select") {
                 alert("Please select paper size.");
                 return false;
             }

             if (document.getElementById("<%=txtRollNo.ClientID%>").value == "") {
                 alert("Please enter roll no.");
                 return false;
             }

             if (document.getElementById("<%=txtNetWet.ClientID%>").value == "" || document.getElementById("<%=txtNetWet.ClientID%>").value == "0") {
                 alert("Please enter Net Wt");
                 return false;
             }

             if (document.getElementById("<%=txtGrossWt.ClientID%>").value == "" || document.getElementById("<%=txtGrossWt.ClientID%>").value == "0") {
                 alert("Please enter Net Wt");
                 return false;
             }

             if (document.getElementById("<%=ddlPaperType.ClientID%>").value == "2") {
                 if (document.getElementById("<%=txtTotalSheets.ClientID%>").value == "" || document.getElementById("<%=txtTotalSheets.ClientID%>").value == "0") {
                     alert("Please enter total sheets.");
                     return false;
                 }
             }

             if (document.getElementById("<%=ddlPaperType.ClientID%>").value == "1" && document.getElementById("<%=HDN_PaperCategory.ClientID%>").value == "Sheet") {
                 if (document.getElementById("<%=txtTotalSheets.ClientID%>").value == "" || document.getElementById("<%=txtTotalSheets.ClientID%>").value == "0") {
                     alert("Please enter total sheets.");
                     return false;
                 }
             }

             return true;
         }

    </script>
</asp:Content>
