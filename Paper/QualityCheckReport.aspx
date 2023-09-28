<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="QualityCheckReport.aspx.cs" Inherits="Paper_QualityCheckReport" Title="क्वालिटी चेक रिपोर्ट / Quality Check Report "%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Quality check Report--%>&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368;
        &#2330;&#2375;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;/ Quality Check Report
    </div>
    <div class="portlet-content"><div class="table-responsive">
        <table width="100%">
            <tr><span style="padding-left:5px;color:Red;">*</span>
                    <td style="text-align: left" width="20%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Acadmic Year :
                    </td>
                    <td style="text-align: left" colspan="3">
                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init" AutoPostBack="true"  Width="245px" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                   
                </tr>
            <tr>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <%--Vendor name (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366;
                    &#2344;&#2366;&#2350;<br /> Paper Mill Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendorFill" Width="250px" CssClass="txtbox reqirerd"
                        AutoPostBack="True" OnInit="ddlVendorFill_Init" OnSelectedIndexChanged="ddlVendorFill_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqddlVendorFill"
                        runat="server" ErrorMessage="Please select Vendor Name." ControlToValidate="ddlVendorFill"
                        ValidationGroup="Save" InitialValue="Select">*</asp:RequiredFieldValidator>
                </td>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.<br /> L.O.I. No.
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLOIFill" Width="250px" 
                        CssClass="txtbox reqirerd" AutoPostBack="True" 
                        onselectedindexchanged="ddlLOIFill_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqddlLOIFill"
                        runat="server" ErrorMessage="Please select LOI No." ControlToValidate="ddlLOIFill"
                        ValidationGroup="Save" InitialValue="Select">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &#2360;&#2376;&#2306;&#2346;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />Sample No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSampleNo" Enabled="false" MaxLength="10" CssClass="txtbox reqirerd"
                        Width="240px"  onkeypress="tbx_fnAlphaNumeric(event, this);" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator3"
                        runat="server" ErrorMessage="Please Enter Sample No." ControlToValidate="txtSampleNo"
                        ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
                <td><span style="padding-left:5px;color:Red;">*</span>
                  मिल से आये हुये सैंपल की दिनांक<br />Date Of Sample Received from Paper Mill
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSampleDrawDate"  MaxLength="10" CssClass="txtbox reqirerd"
                        Width="240px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator4"
                        runat="server" ErrorMessage="Please Enter Draw Date." ControlToValidate="txtSampleDrawDate"
                        ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                <td><span style="padding-left:5px;color:Red;">*</span>
                   सैंपल निकालने का स्थान<br />Sample Taking Place
                </td>
                <td>
                 
                 <asp:DropDownList ID="ddlSampleFrom" runat="server" CssClass="txtbox reqirerd"  Width="250px" >
                 <asp:ListItem Text="सेंट्रल डेपो से प्राप्ति के समय"></asp:ListItem>
                 <asp:ListItem Text="सेंट्रल डेपो से जारी करते समय"></asp:ListItem>
                 <asp:ListItem Text="मुद्रणालय स्तर पर"></asp:ListItem>
                 </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator5"
                        runat="server" ErrorMessage="Please Enter Sample No." ControlToValidate="ddlSampleFrom"
                        ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
                <td>
                 
                </td>
                <td>
                 
                </td>
            </tr>
            <tr>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <%--Paper type--%>&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Paper Type
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPaperType" Width="250px" CssClass="txtbox reqirerd"
                        AutoPostBack="True" OnInit="ddlPaperType_Init" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqddlPaperType"
                        runat="server" ErrorMessage="Please Select Paper Type." ControlToValidate="ddlPaperType"
                        InitialValue="Select" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <%--Paper Size--%>&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; <br /> Paper Size
                </td>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <asp:DropDownList runat="server" ID="ddlPaperSize" Width="250px" CssClass="txtbox reqirerd">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqddlPaperSize"
                        runat="server" ErrorMessage="Please Select Paper Size." ControlToValidate="ddlPaperSize"
                        InitialValue="Select" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <%--LAB name (--%>&#2354;&#2376;&#2348; &#2325;&#2366; &#2344;&#2366;&#2350;<br /> Lab Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLabName" CssClass="txtbox reqirerd" Width="250px"
                        AutoPostBack="True" OnInit="ddlLabName_Init" OnSelectedIndexChanged="ddlLabName_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqtxtPBGNO"
                        runat="server" ErrorMessage="Please Select Lab Name." InitialValue="Select" ControlToValidate="ddlLabName"
                        ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <%--LAB Address (--%>&#2354;&#2376;&#2348; &#2325;&#2366; &#2346;&#2340;&#2366;<br /> Lab Address
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLabAddress" TextMode="MultiLine" ReadOnly="true"
                        Width="248px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <%--Sample Send Date (--%>पेपर सेक्शन से लैब में भेजने की दिनांक <br />Sample Send Date From Paper Mill To Lab
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSendDate" MaxLength="10" CssClass="txtbox reqirerd" Width="240px"></asp:TextBox>
                     
                </td>
                <td>
                    <%--Report Received Date (--%>&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqtxtRecivedDate"
                        runat="server" ErrorMessage="Please Enter Receive Date." ControlToValidate="txtRecivedDate"
                        ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display:none">
                <td><span style="padding-left:5px;color:Red;">*</span>
                    लैब से प्राप्त होने की दिनांक <br /> Received Date From Lab</td>
                <td>
                    <asp:TextBox runat="server" ID="txtRecivedDate" MaxLength="10" CssClass="txtbox required"
                        Width="240px"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRecivedDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="display:none">
                <td>
                    &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />Report No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtReportNo"    onkeypress="tbx_fnUserName(event, this);"  MaxLength="30" CssClass="txtbox" Width="240px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="Please Enter Report No." ControlToValidate="txtReportNo"
                        ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Report Date
                </td>
                <td><span style="padding-left:5px;color:Red;">*</span>
                    <asp:TextBox runat="server" ID="txtReportDate"  MaxLength="10" CssClass="txtbox required" Width="240px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator2"
                        runat="server" ErrorMessage="Please Enter Report Date." ControlToValidate="txtReportDate"
                        ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display:none">
                <td>
                    <%--Inspection Report (--%> &#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339;
                    &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;<br />Inspection Report
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtInspectionReport" MaxLength="200" CssClass="txtbox"
                        TextMode="MultiLine" Width="240px" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtInspectionReport',200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqtxtInspectionReport"
                        runat="server" ErrorMessage="Please Enter Inspection Report." ControlToValidate="txtInspectionReport"
                        ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
                    &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; |<br />Upload Quality Report
                </td>
                <td>
                    <asp:FileUpload ID="fileUp1" runat="server" Width="250px" />
                </td>
            </tr>
            <tr style="display:none">
                <td>
               

                    <%--Quality check Pass--%>&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368;
                    &#2330;&#2375;&#2325; &#2346;&#2366;&#2360;<br />Quality Check Pass
                </td>
                <td>
                    <asp:RadioButtonList ID="rbQualitycheck" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Selected="True" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <%--Upload Quality Report --%>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnADD" CssClass="btn"  ValidationGroup="Add"
                        Text="&#2354;&#2376;&#2348; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                        OnClick="btnADD_Click" />
                </td>
            </tr>
            <tr style="display:none">
                <td colspan="4">
                    <asp:CheckBox ID="chkSample" runat="server" Text="&#2325;&#2381;&#2351;&#2366; &#2310;&#2346; &#2360;&#2376;&#2306;&#2346;&#2354; &#2309;&#2344;&#2381;&#2351; &#2354;&#2376;&#2348; &#2325;&#2379; &#2349;&#2375;&#2332;&#2344;&#2366; &#2330;&#2366;&#2361;&#2340;&#2375; &#2361;&#2376; ?<br> Do You Want To Send Sample To Other Lab ?"
                        Visible="false" AutoPostBack="True" ForeColor="#339933" OnCheckedChanged="chkSample_CheckedChanged" />
                </td>
            </tr>
            <tr style="display:none">
                <td colspan="4">
                    <asp:GridView ID="GrdOfficerDetail" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        OnRowDataBound="GrdOfficerDetail_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2354;&#2376;&#2348; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Lab Name ">
                                <ItemTemplate>
                                    <asp:Label ID="lblLabName" runat="server" Text='<%#Eval("LabName") %>'></asp:Label>
                                    <asp:Label ID="lblLabTrId_I" runat="server" Text='<%#Eval("LabTrId_I") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblLabInspChild_Id_I" runat="server" Text='<%#Eval("LabInspChild_Id_I") %>'
                                        Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperType" runat="server" Text='<%#Eval("PaperType") %>'></asp:Label>
                                    <asp:Label ID="lblPaperType_I" Visible="false" runat="server" Text='<%#Eval("PaperType_I") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" &#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperSize_V" runat="server" Text='<%#Eval("PaperSize_V") %>'></asp:Label>
                                    <asp:Label ID="lblPaperMstrTrId_I" Visible="false" runat="server" Text='<%#Eval("PaperMstrTrId_I") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2360;&#2376;&#2306;&#2346;&#2354; &#2360;&#2375;&#2306;&#2337; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Sample Send Date ">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleSendDate_D" runat="server" Text='<%#Eval("SampleSendDate_D") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2360;&#2376;&#2306;&#2346;&#2354; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Sample Received Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleReceiveDate_D" runat="server" Text='<%#Eval("SampleReceiveDate_D") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> Report No">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportNo" runat="server" Text='<%#Eval("ReportNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br> Report Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportDate" runat="server" Text='<%#Eval("ReportDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;<br>Inspection Report">
                                <ItemTemplate>
                                    <asp:Label ID="lblLabInspectionReport_V" runat="server" Text='<%#Eval("LabInspectionReport_V") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2330;&#2375;&#2325; &#2346;&#2366;&#2360; <br>Quality Check Status ">
                                <ItemTemplate>
                                    <asp:Label ID="lblQualityCheckStatus_I" Visible="false" runat="server" Text='<%#Eval("QualityCheckStatus_I") %>'></asp:Label>
                                    <asp:Label ID="lblQualityCheckStatus" runat="server" Text='<%#Eval("QualityCheckStatus") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;<br>View Quality Report">
                                <ItemTemplate>
                                    <asp:Label ID="lblLabInspectionFile_V" runat="server" Text='<%#Eval("LabInspectionFile_V") %>'
                                   Visible="false"     ></asp:Label>
                                    <asp:Panel ID="Pnl11K" runat="server" Visible='<%#(Eval("LabInspectionFile_V").ToString().Equals("")||Eval("LabInspectionFile_V").ToString().Equals("#"))?true:false %>'>
                                    <a href='#'>&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Report</a>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Visible='<%#(Eval("LabInspectionFile_V").ToString().Equals("")||Eval("LabInspectionFile_V").ToString().Equals("#"))?false:true %>'>
                                    <a href='<%#"../PaperUploadedFile/"+Eval("LabInspectionFile_V") %>'>&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Report</a>
                                    </asp:Panel>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" Visible="false" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;/Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                        </Columns>
                         <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
            <tr >
                <td>
                    <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;<br />Remark
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" MaxLength="200" TextMode="MultiLine" Width="240px"
                        onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr style="display:none">
                <td colspan="4" style="height: 10px;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
           <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td>  
                    <td colspan="3">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        ValidationGroup="Save" CssClass="btn" OnClick="btnSave_Click"  OnClientClick="return ValidateAllTextForm();" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px;">
                </td>
            </tr>
        </table></div>
    </div>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtSampleDrawDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSendDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtReportDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <asp:HiddenField ID="hdnFile" runat="server" />
    <asp:ValidationSummary ID="VsAdd" ValidationGroup="Add" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <asp:ValidationSummary ID="VsSave" ValidationGroup="Save" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
</asp:Content>
