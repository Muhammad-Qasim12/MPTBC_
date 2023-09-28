<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTtenderwisePrinterMIS.aspx.cs" Inherits="Printing_TextBooksToBePrinted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span> टेंडर के अनुसार  प्रिंटर की जानकारी  </span></h2>
        </div>
        <div class="PLR10">
        <table width="100%" cellpadding="5" class="MT10" style="font-weight: bold;" cellspacing="0">
                <tr>
    <td>टेंडर का विवरण 
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td> 
    <td>शैक्षणिक सत्र  
        <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Text="Select"></asp:ListItem>
        </asp:DropDownList>
    </td> 
                 
            </table>
            <table width="100%" cellpadding="5" cellspacing="0" class="tab">
                 <tr>
                          
                          <th>टेंडर में दर देनेवाले कुल  प्रिंटर की संख्या   </th>
                          <th>टेंडर में दर देनेवाले पंजीकृत  प्रिंटर की संख्या </th>
                          <th>टेंडर में दर देनेवाले अपंजीकृत  प्रिंटर की संख्या  </th>
                          <th><%--Approx. qty. of printing paper in tons--%>टेंडर में दर देनेवाले अपंजीकृत प्रिंटर में से पंजीयन फॉर्म लेनेवाले प्रिंटर की संख्या</th>
                          
                          <th>टेंडर में दर देनेवाले प्रिंटर में से पंजीयन फॉर्म में पूर्ण दस्तावेज़ देनेवाले प्रिंटर संख्या </th>
                          
                          </tr>
                          <tr>
                       
                          <td>100</td>
                          <td>60</td>
                          <td>40</td>
                          <td>20</td>
                          <td>40 </td>
                          
                          
                  </tr>
                 
            </table>
            </div>
            </div>
</asp:Content>

