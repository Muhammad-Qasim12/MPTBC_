<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPaperReceivingProgressReport.aspx.cs" Inherits="Printing_PaperReceivingProgressReport" Title="Paper Receiving Progress Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>मुद्रणालय द्वारा प्राप्त किये गए कागज की जानकारी </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%" >
    
    <tr>
    <td>मुद्रणालय का नाम </td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td>
    
    <td>प्रगति दिनाक </td>
    
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    
    </tr>
    <tr>
     <td colspan="4" >
                            <asp:Button runat="server" ID="Button1" Text="प्रिंट करे " CssClass="btn" />
                            </td>
                          
    </tr>
    <tr>
    <td colspan="4">
    <div>
    
    <asp:Panel runat="server" ID="pnlgrid" ScrollBars="Auto" >
    
    <table class="tab">
    <tr>
    <th rowspan="2">शीर्षक का नाम </th>
    <th rowspan="2">क्लास </th>
    <th rowspan="2">ग्रुप </th>
    <th rowspan="2">प्रष्ठ संख्या </th>
    <th rowspan="2">आवंटित मुद्रण संख्या </th>
    <th colspan="2">लगने वाला कागज (टन ) </th>
    <th colspan="2">मुद्रणालय द्वारा प्राप्त किया गया कागज(टन )</th>
    </tr>
    
    <tr>
    <th>मुद्रण </th>
    <th>कवर </th>
    
     <th>मुद्रण </th>
    <th>कवर </th>
    
    </tr>
    
    <tr>
    <td>Bhasha Bharti 1</td>
    <td>8</td>
    <td>I</td>
    <td>308</td>
    <td>114600</td>
    <td>0</td>
    <td>0</td>
    <td>0</td>
    <td>0</td>
    </tr>
    
    
     <tr>
    <td>Bhasha Bharti 1</td>
    <td>5</td>
    <td>A</td>
    <td>280</td>
    <td>332760</td>
    <td>0</td>
    <td>0</td>
    <td>0</td>
    <td>0</td>
    </tr>
     
    </table>
    </asp:Panel>
    </div>
    
    
    
    </td>
    </tr>
    
    </table>
    
    
    </div> 
    </div> 


</asp:Content>

