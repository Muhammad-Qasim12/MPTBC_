<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemandReceiveFromDistribution.aspx.cs" Inherits="Paper_DemandGroupingOfDistribution" Title="Demand Grouping Of Distribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="portlet-header ui-widget-header">
                        
                      <%--View Demand Grouping (From Distribution)--%> व्यू डिमांड रिसीव (डिस्ट्रीब्यूशन सेक्शन ) / Demand receive (Distribution Section)
                    </div>
                     <div class="portlet-content">

    
    
   
    
    
    <table width="100%">
    
    
    <tr>
    <td colspan="4">
    <div><%--<b>Financial Year</b>--%><b>वित्तीय वर्ष / Financial Year</b> :  2014-2015</div>
     <div style="height:5px;"></div>
    <div class="box table-responsive">
    <asp:CheckBox  runat="server" Text ="माध्यम के अनुसार " ID="chkMedium" onchange="ShowHide('ctl00_ContentPlaceHolder1_chkMedium','DivMedium');" />
    <asp:CheckBox  runat="server" Text ="कक्षा के अनुसार"  ID="chkClass"  onchange="ShowHide('ctl00_ContentPlaceHolder1_chkClass','divClass');"/>
    <asp:CheckBox  runat="server" Text ="शीर्षक के अनुसार "  ID="ChkTitle"  onchange="ShowHide('ctl00_ContentPlaceHolder1_ChkTitle','divTitle');"/>
    <asp:CheckBox  runat="server" Text ="योजना के अनुसार " ID="ChkScheme" onchange="ShowHide('ctl00_ContentPlaceHolder1_ChkScheme','DivScheme');" />
    <asp:CheckBox  runat="server" Text ="डिपो के अनुसार "  ID="ChkDepot"  onchange="ShowHide('ctl00_ContentPlaceHolder1_ChkDepot','dvDepot');"/>
    
 
    </div>
    <div>
    
    
    <div style="height:5px;"></div>
   <div id="DivMedium" style="display:none;">
    <table width="500px">
   <tr>
   <td style="width:150px"> <asp:Label ID="lblMedium" runat="server" Text="माध्यम चुने / Medium"  ></asp:Label></td> 
   <td> <asp:DropDownList ID="ddlMedium" runat="server"  >
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Hindi Medium"></asp:ListItem>
    <asp:ListItem Text="English Medium"></asp:ListItem>
    <asp:ListItem Text="Urdu Medium"></asp:ListItem>
    </asp:DropDownList></td></tr> </table> 
    </div>
   
   <div style="height:5px;"></div>
   
   <div id="divClass" style="display:none;">
    <table width="500px">
   <tr>
   <td style="width:150px">  <asp:Label ID="Label1" runat="server" Text="कक्षा चुने / Class"  ></asp:Label></td> 
    <td> <asp:DropDownList ID="ddlClass" runat="server"  >
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Class I"></asp:ListItem>
    <asp:ListItem Text="Class II"></asp:ListItem>
    <asp:ListItem Text="Class III"></asp:ListItem>
    </asp:DropDownList></td></tr> </table> 
    </div>
    
    <div style="height:5px;"></div>
    
    <div id="divTitle" style="display:none;">
    <table width="500px">
   <tr>
   <td style="width:150px"> <asp:Label ID="Label2" runat="server" Text="शीर्षक चुने / Title"  ></asp:Label></td> 
   <td><asp:DropDownList ID="DropDownList2" runat="server"  >
    <asp:ListItem Text="Select"></asp:ListItem>
     <asp:ListItem Text="English Reader-5"></asp:ListItem>
    <asp:ListItem Text="Bhasha Bharti-6"></asp:ListItem>
    </asp:DropDownList></td> 
    <td>
    <asp:CheckBox  runat="server" Text =" " ID="chkMedium1" /> 
    </td></tr> </table> 
    </div>
   
   <div style="height:5px;"></div>
   
   
   <div id="DivScheme" style="display:none;">
    <table width="500px">
   <tr>
   <td style="width:150px"><asp:Label ID="Label3" runat="server" Text="योजना चुने / Scheme"  ></asp:Label></td> 
    <td> <asp:DropDownList ID="DropDownList3" runat="server"  >
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Hindi Medium"></asp:ListItem>
    <asp:ListItem Text="English Medium"></asp:ListItem>
    <asp:ListItem Text="Urdu Medium"></asp:ListItem>
    </asp:DropDownList></td></tr> </table> 
    </div>
    
    <div style="height:5px;"></div>
    
    <div id="dvDepot" style="display:none;">
    <table width="500px">
   <tr>
   <td style="width:150px"><asp:Label ID="Label4" runat="server" Text="डिपो का नाम चुने / Depot"  ></asp:Label></td> 
   <td> <asp:DropDownList runat="server" ID="DropDownList4">
    
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Bhopal"></asp:ListItem>
    <asp:ListItem Text="Indore"></asp:ListItem>
    </asp:DropDownList></td></tr> </table> 
   </div>
   
   <div style="height:5px;"></div>
   <div >
       <asp:Button ID="Button1" runat="server" Text="रिपोर्ट देखे" CssClass="btn"  /></div>
   
   </div>
    <div>
    
    
    
    </div>
    
    </td>
    </tr>
    
   <tr>
    <%--<td>Class (कक्षा)</td>
    <td>
    <asp:DropDownList runat="server" ID="ddlClass">
    
    <asp:ListItem Text="English Reader-5"></asp:ListItem>
    <asp:ListItem Text="Bhasha Bharti-6"></asp:ListItem>
    </asp:DropDownList>
    
    </td>
    
    <td>Depot (डिपो का नाम )</td>
    <td>
    <asp:DropDownList runat="server" ID="ddlDepot">
   
    <asp:ListItem Text="Indore"></asp:ListItem>
    </asp:DropDownList>
    </td>
    --%>
     <td colspan="2">पुस्तकों की कुल संख्या / Total No of Books</td>
    <td colspan="2"><asp:TextBox runat="server" ID="txtTotal" Text="148101"> </asp:TextBox></td>
    
    
    </tr>
    
    
   <tr>
   <td>
    
   </td>
   
    
   </tr>
    
   
    
    </table>
    
   
    
    <table class="tab">
    <tr>
   
    <th colspan="6">इंदौर डिपो </th>
    
    </tr>
    
   <tr><th> शीर्षक </th>
   
   <th>कक्षा</th>
   <th><%--Allotment yojna Hindi (In Tn.)--%>आवंटित योजना हिंदी </th>
   <th><%--Allotment Genral Hindi (In Tn.)--%>आवंटित सामान्य  हिंदी </th>
   <th><%--Allotment Grand Total (In Tn.)--%>कुल आवंटन  </th>
    <th>  </th>
   </tr>
    
    <tr>
    <td>English Reader</td>
    <td>5</td>
    <td>12301</td>
    <td>2500</td>
    <td>148101</td>
    <td> <asp:CheckBox  runat="server" Text ="" ID="CheckBox1" /></td>
    </tr>
    
    
     <tr>
    <td>Bhasha Bharti</td>
    <td>6</td>
    <td>126868</td>
    <td>26700</td>
    <td>153568</td>
    <td> <asp:CheckBox  runat="server" Text ="" ID="CheckBox2" />
    </tr>
   
    </table>
    
    </div> 
      <div style="margin-top:15px;margin-bottom:15px;">
        <input id="btntab" value="पेपर का आकलन " type="button"  class="btn" onclick="OpenBill()" />
    </div>
    <div id="dIVpAPEReSTI" style="display:none ;margin-top:15px;">
    <table class="tab">
      <tr>
     <th><%--Title--%> शीर्षक </th>
      <th>कक्षा</th>
     <th><%--Depot--%> डिपो </th>
     <th><%--Approx No of Paper per Book--%>प्रति पुस्तक पेज संख्या </th>
     <th><%--Approx No of Books to be Printed--%> प्रिंट की जानेवाली पुस्तक संख्या  </th>
     <th colspan="3" ><%--Approx Quantity of Printing Paper--%> लगने वाला प्रिंटिंग   पेपर (टन मे )</th>
      <th colspan="3"><%--Approx Quantity of Printing Paper--%> लगने वाला  कवर पेपर (शीट मे )</th>
     <th></th>
     </tr> 
     
      <tr>
     <th><%--Title--%>  </th>
      <th></th>
     <th><%--Depot--%> </th>
     <th><%--Approx No of Paper per Book--%> </th>
     <th><%--Approx No of Books to be Printed--%> </th>
     <th><%--Approx Quantity of Printing Paper--%> 80GSM Reel</th>
     <th><%--Approx Quantity of Printing Paper--%> 70GSM Reel</th>
     <th><%--Approx Quantity of Printing Paper--%> 80GSM Sheet</th>
     <th><%--Approx Quantity of Printing Paper--%> 230GSM MG</th>
     <th><%--Approx Quantity of Printing Paper--%> 250GSM MG</th>
     <th><%--Approx Quantity of Printing Paper--%> 250GSM ArtCard</th>
      
     <th></th>
     </tr> 
     
      <tr>
    
     <td>Bhasha bharti</td>
     <td>5</td>
      <td>Bhopal</td>
     <td>164</td>
     <td>194320</td>
     <td>80.625</td>
      <td></td>
       <td></td>
        <td></td>
         <td></td>
          <td></td>
      <td></td>
     <td></td>
     </tr>
      
      <tr>
    
      <td>Bhasha bharti</td>
      <td>6</td>
     <td>Indore</td>
    <td>308</td>
     <td>197500</td>
     <td>153.896</td>
      <td></td>
       <td></td>
        <td></td>
         <td></td>
          <td></td>
      <td></td>
     <td></td>
     </tr>
      
      </table>
       <div >
        <input id="Text1" value="सुरक्षित करे " type="button" class="btn"  />
    </div>
    </div>
    
 <script>
   function ShowHide(chk,dr)
   {
  var checkbox= document.getElementById(chk);
  var dropdown= document.getElementById(dr);
  
  if(checkbox.checked==true)
  {
  dropdown.style.display="block";
  }
  else{dropdown.style.display="none";}
  
  
//   if( document.getElementById('ctl00_ContentPlaceHolder1_chkMedium').checked==true)
//   {
//   document.getElementById('ctl00_ContentPlaceHolder1_ddlClass').style.display="block";
//   }
//   else
//   {
//   document.getElementById('ctl00_ContentPlaceHolder1_ddlClass').style.display="none";
//   }
   
   }
   
   
   function OpenBill()
   {
   
   
   document.getElementById('dIVpAPEReSTI').style.display="block";
   }
   
   
   
   
   </script>


</asp:Content>

