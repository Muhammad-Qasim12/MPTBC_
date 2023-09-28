<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPrinterBooksPrintingDetailsReport.aspx.cs" Inherits="Printing_PrinterBooksPrintingDetailsReport" Title="Printer Books Printing Details Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>मुद्रणालय की पुस्तक प्रिंटिंग की जानकारी  </span></h2>
</div>
    <div style="padding:0 10px;">
     <table width="100%" >
    
    <tr>
    <td>मुद्रणालय का नाम</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td>
    
    <td>प्रगति दिनाक</td>
    
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    
    </tr>
    
    <tr>
    <td colspan="4">
    <table class="tab">
    <tr>
    <th rowspan="2" colspan="3">शीर्षक क्लास ग्रुप का नाम </th>
    <th rowspan="2">शीर्षक के कुल फार्म की संख्या </th>
    <th colspan="3">मुद्रित हो चुके फर्मो का विवरण </th>
    <th colspan="3">मुद्रण मे चल रहे फर्मो का विवरण</th>
    <th rowspan="2">मुद्रित कवर संख्या </th>
    <th rowspan="2">गेदरिंग मे प्रक्रियाधीन पुस्तकों की संख्या </th>
    <th rowspan="2">स्टिचिंग बाइंडिंग प्रक्रिया मे पुस्तकों की संख्या </th>
    <th rowspan="2">फिनिशिंग कटाई मे पुस्तकों की संख्या </th>
    <th rowspan="2">नंबरिंग मे प्रक्रियाधीन पुस्तकों की संख्या </th>
     <th colspan="5">पुस्तक प्रेषण का विवरण </th>
    </tr>
    

    
    <tr>
    <th>फार्म से </th>
    <th>फार्म तक  </th>
    <th>संख्या </th>
    <th>फार्म से </th>
    <th>फार्म तक  </th>
    <th>संख्या </th>
    <th>पुस्तक संख्या </th>
    <th>भंडार का नाम </th>
    <th>ट्रक का नंबर </th>
    <th>ड्राईवर का नाम </th>
    <th>ड्राईवर का मोबाइल नंबर </th>
    </tr>
    
    <tr>
    <td>Bhasha Bharti </td>
    <td>8</td>
    <td>I</td>
    <td>19.25</td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
     <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    
    </tr>
    
    <tr>
    <td>Bhasha Bharti</td>
    <td>5</td>
    <td>A</td>
    <td>17.5</td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    
     <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
     <td colspan="20" >
                            <asp:Button runat="server" ID="Button1" Text="प्रिंट करे " CssClass="btn" />
                            </td>
                          
    </tr>
    
    </table> 
    </td> 
    </tr> </table> 
    </div> </div> 

</asp:Content>

