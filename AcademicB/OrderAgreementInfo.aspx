<%@ Page Title="कार्यादेश एवं अनुबंध की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="OrderAgreementInfo.aspx.cs" Inherits="AcademicB_OrderAgreementInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>कार्यादेश एवं अनुबंध की जानकारी / Work Order and Agrement Information</span></h2>
        </div>
        <div id="messageDiv" runat="server" class="form-message">
            <span>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2319;&#2357;&#2306; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Work Order and Agrement Information</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">

                <tr>
                    <td>
                        <asp:Label ID="LblAcYear" runat="server" Width="125px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;/Printer                       
                        
                         <asp:DropDownList ID="ddlPrinter_regid_i" runat="server" CssClass="txtbox" OnInit="ddlPrinter_regid_i_Init" OnSelectedIndexChanged="ddlPrinter_regid_i_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>&#2335;&#2375;&#2306;&#2337;&#2352;/Tender No <span class="required">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTenderID_I" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>

                    <td>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/LOI Date <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLOIDate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/LOI Number
                    </td>
                    <td>
                        <asp:TextBox ID="txtLOINo_V" runat="server" MaxLength="12" onkeypress='javascript:tbx_fnAlphaNumericType1(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>

                    <td>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;/Upload Work Order
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/WorkOrder No
                    </td>
                    <td>
                        <asp:TextBox ID="txtWorkorderNo_V" onkeypress='javascript:tbx_fnAlphaNumericType1(event, this);' runat="server" MaxLength="12" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>


                    <td>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/WorkOrder Date <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWODate_D" runat="server" MaxLength="10"
                            CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtWODate_D_CalendarExtender" runat="server" TargetControlID="txtWODate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>


                        <%--  <cc1:MaskedEditExtender ID="MasktxtEst_WODate_D" TargetControlID="txtWODate_D" Mask="99/99/9999" UserDateFormat="None" CultureName="en-GB" MaskType="Date" runat="server"></cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtLOIDate_D" Mask="99/99/9999" UserDateFormat="None" CultureName="en-GB" MaskType="Date" runat="server"></cc1:MaskedEditExtender>--%>
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="GRPID_I"
                            OnRowDataBound="GrdGroupDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GRPID_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Group No">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("groupno_v") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;" DataField="GroupNO_V" />--%>
                                <asp:BoundField HeaderText="शीर्षक/Title" DataField="TitleHindi_V" />
                                <%--<asp:BoundField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" DataField="Noofpages" />--%>
                                <asp:BoundField HeaderText="कुल संख्या/Total Allotment" DataField="TotNoOfBooks" />
                                <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375;)/ Printing Quantity(Ton)" DataField="Qty_PriPaper" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;/Printer Name" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="निर्धारित मूल्य (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;)/Rate (Rs.)" DataField="rate" />

                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2379; &#2349;&#2375;&#2332;&#2375;" OnClientClick='javascript:return ValidateAllTextForm();'
                            OnClick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </td>

                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">

        function MaxLengthCount(txt, MaxLen) {
            var txtBox = document.getElementById(txt);
            var len = MaxLen;


            if (txtBox.value.length > len) {

                txtBox.value = txtBox.value.substring(0, len);
                alert("Character length is Exeed from " + len);
            }
            else { }
        }
    </script>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLOIDate_D"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

