<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTtenderallotement.aspx.cs" Inherits="Printing_TextBooksToBePrinted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span> टेंडर के ग्रुप आवंटन की जानकारी  </span></h2>
        </div>
        <div class="PLR10">
        <table width="100%" cellpadding="5" class="MT10" style="font-weight: bold;" cellspacing="0">
                <tr>
    <td>टेंडर का नाम 
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td> 
    <td>प्रिंटर का नाम 
        <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td> 
                 
            </table>
            <table width="100%" cellpadding="5" cellspacing="0" class="tab">
                 <tr>
                          <th>ग्रुप क्रमांक </th>
                          <th>पाठ्यपुस्तक एवं कक्षा का नाम </th>
                          <th>अनुमानित पेजों की संख्या </th>
                          <th>अनुमानित मुद्रण हेतु पाठ्यपुस्तको की संख्या </th>
                          <th><%--Approx. qty. of printing paper in tons--%>अनुमानित मुद्रण पेपर की मात्र (टन में )</th>
                          
                          <th>प्रिंटर का नाम </th>
                          <th><%--Required earnest money in Rs.--%>धरोहर राशि  (रूपये में )</th>
                          </tr>
                          <tr>
                          <td>001</td>
                          <td>Bhasha Bharti- 8(i)</td>
                          <td>220</td>
                          <td>110500</td>
                          <td>60</td>
                          <td>M/s Kailash Printer </td>
                          
                          <td>20000/-</td>
                  </tr>
                  <tr>
                          <td>002</td>
                          <td>Bhasha Bharti- 8(K)</td>
                          <td>220</td>
                          <td>193700</td>
                          <td>105</td>
                           <td>M/s Rajeev Printer </td>
                          <td>25000/-</td>
                  </tr>
                  <tr>
                          <td>003</td>
                          <td>Bhasha Bharti- 8(S)</td>
                          <td>220</td>
                          <td>158000</td>
                          <td>85</td>
                           <td>M/s Santosh Printer </td>
                          <td>20000/-</td>
                  </tr>
                  <tr>
                          <td>004</td>
                          <td>Bhasha Bharti- 8(L)</td>
                          <td>220</td>
                          <td>166300</td>
                          <td>90</td>
                           <td>M/s Golden Printer </td>
                          <td>20000/-</td>
                  </tr>
                
                  <tr>
                            <td colspan="7" >
                            <asp:Button runat="server" ID="Button1" Text="प्रिंट करे  " CssClass="btn" />
                            </td>
                  </tr>
            </table>
            </div>
            </div>
</asp:Content>

