<%@ Page Title="मुद्रणालय स्तर पर निरिक्षण की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI007_Inspection.aspx.cs" Inherits="Printing_PRI007_Inspection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">मुद्रणालय स्तर पर निरिक्षण की जानकारी / Inspection of Printing Press </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                      <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


                     <table width="100%">
                     <tr>
                     <td>निरिक्षण दिनांक / Inspection Date</td>
                     <td>
                     <asp:TextBox runat="server" ID="txtInspectiondate_D" CssClass="txtbox reqirerd" ></asp:TextBox>

                      <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtInspectiondate_D" TargetControlID="txtInspectiondate_D" runat="server"></cc1:CalendarExtender>
                      <cc1:MaskedEditExtender ID="MasktxtInspectiondate_D" TargetControlID="txtInspectiondate_D"  Mask="99/99/9999" UserDateFormat="None"  MaskType="Date" runat="server"></cc1:MaskedEditExtender>
        

                     </td>

                     <td>निरीक्षण का स्तर </td>
                     <td>मुद्रणालय स्तर पर</td>

                     </tr>

                     <tr>
                     <td>मुद्रणालय का नाम / Printer Name</td>
                     <td>
                     <asp:DropDownList runat="server" ID="ddlPrinter_RedID_I" CssClass="txtbox reqirerd" >
                     </asp:DropDownList>
                     </td>

                     </tr>


                     <tr>
                     <td>अधिकारी का नाम / Officer Name</td>
                     <td>
                      <asp:TextBox runat="server" ID="txtOfficerName_V" CssClass="txtbox reqirerd" ></asp:TextBox>

                     </td>

                     <td>पद / Designation</td>
                     <td>
                      <asp:TextBox runat="server" ID="txtOfficerDesignation_V" CssClass="txtbox reqirerd" ></asp:TextBox>

                     </td>
                     </tr>

                     <tr>
                     <td>निरिक्षण रिपोर्ट / Inspection Report</td>

                     <td colspan="3">
                      <asp:TextBox runat="server" ID="txtInspectionReport_V" CssClass="txtbox reqirerd" ></asp:TextBox>

                     </td>
                     </tr>


                     <tr>
                     <td>रिपोर्ट अपलोड करे / Upload Document</td>

                     <td colspan="3">
                      <asp:FileUpload runat="server" ID="fileInspectionReportFile_V" CssClass="txtbox reqirerd" />
                     <asp:Label runat="server" ID="lblInspectionReportFile_V"></asp:Label>
                     </td>
                     </tr>


                     <tr>
                     <td></td>
                     <td>
                     
                     <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="सुरक्षित करे / Save " OnClick="btnSave_Click" />
                     <asp:Button runat="server" ID="btnback" CssClass="btn" Text="वापस जाये / Back " OnClick="btnback_Click"/>
                     </td>
                     </tr>

                     </table>


                     </div>  
                     </div>

                     </asp:Content>

