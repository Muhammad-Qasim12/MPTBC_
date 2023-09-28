<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VendorAgreement.aspx.cs" Inherits="Paper_VendorAgreement" Title="Vendor Agreement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span><%--Vendor Agreement--%>&#2357;&#2375;&#2306;&#2337;&#2352; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; (&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; )</span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
    
     <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    
    <tr>
    <td><%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
     <td ><asp:DropDownList runat="server" ID="ddlLOIDetails" Width="262px"  
             CssClass="txtbox reqirerd" AutoPostBack="True" oninit="ddlLOIDetails_Init" 
             onselectedindexchanged="ddlLOIDetails_SelectedIndexChanged"  >
     <asp:ListItem Text="Select"></asp:ListItem>
     </asp:DropDownList>
     </td>
     <td><b><%--Date (--%>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </b></td>
    <td><asp:Label ID="lblCurrentDt" runat="server" ></asp:Label></td>
    </tr>
    
    <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
     <tr>
    <td colspan="4">
        <asp:Panel ID="Panel1" runat="server"   BorderColor="gray" BorderStyle="solid" BorderWidth="1px">
        
        <table width="100%">
      <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
   <tr>
   
     <td><b><%--LOI To. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;</b></td>
    <td>
        <asp:Label ID="lblLOITO" runat="server" ></asp:Label></td>
    <%--<td><b>LOI No. (&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.)</b></td>
    <td></td>--%>
    
    </tr>
    
    
     <tr>
    <td><b><%--LOI Date (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </b></td>
    <td>  <asp:Label ID="lblLOIDate" runat="server" ></asp:Label></td>
    
   <td><b><%--Address (--%>&#2346;&#2340;&#2366; </b></td>
    <td>  <asp:Label ID="lblLOIAddress" runat="server" ></asp:Label></td>
    
    
    </tr>
      
    
   <tr>
   
   <td><b><%--PBG Type (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</b></td><td>  <asp:Label ID="lblPBGMode" runat="server" ></asp:Label></td>
   <td><b><%--PBG No. (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2325;&#2381;&#2352;.</b></td><td>  <asp:Label ID="lblPBGNo" runat="server" ></asp:Label></td>
   </tr>
    
     <tr>
   
   <td><b><%--PBG Amount (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367;</b></td><td>  <asp:Label ID="lblPBGAmt" runat="server" ></asp:Label></td>
   <td><b><%--Validity (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366;</b></td><td><asp:Label ID="lblValidityDays" runat="server" ></asp:Label> Days</td>
   </tr>
     
      <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    </table>
        </asp:Panel>
    </td>
    </tr>
      
   <%-- <tr>
    
     <td>Work Order if Any No. (&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;.)</td>
     <td><asp:TextBox runat="server" ID="TextBox3"></asp:TextBox></td>
    
    <td> Date (&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;)</td>
    <td><asp:TextBox runat="server" ID="TextBox1"></asp:TextBox></td>
    
    
    </tr>
    
    <tr>
    
    <td>Attach Work order (&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2360;&#2306;&#2354;&#2327;&#2381;&#2344; &#2325;&#2352;&#2375;)</td>
    <td colspan="3"><asp:FileUpload runat="server" ID="fileup" /></td>
    </tr>--%>
      <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    <tr>
    <td><%--Agreement No. --%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;.</td>
    <td><asp:TextBox ID="txtAgreementNo"  CssClass="txtbox reqirerd" MaxLength="40"  Width="250px"  runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' ></asp:TextBox></td>
    </tr>
    
    
    <tr>
    <td><%--Agreement Date--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
    <td><asp:TextBox ID="txtAgreementDate"  CssClass="txtbox reqirerd" MaxLength="12"  Width="250px"   runat="server"></asp:TextBox>
   
    </td>
    </tr>
    
   
    <tr>
    <td id="PhotoUpload"><%--Upload Agreement--%> &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; |</td>
    <td><asp:FileUpload ID="FileUpload1" runat="server" Width="250px"  /></td>
    </tr>
     <tr>
    <td> <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368; </td>
    <td><asp:TextBox runat="server" ID="txtRemark"  Width="250px" MaxLength="100" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox></td>
    </tr>
     <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
     <tr>
    <td colspan="4">
    <asp:Button runat="server" ID="btnSave" 
            Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "   
            OnClientClick="return ValidateAllTextForm();" CssClass="btn" 
            onclick="btnSave_Click"/>
   
        <asp:HiddenField ID="hdnFile" runat="server" />
   
    </td>
    </tr>
     
      <tr>
    <td colspan="4" >
    
    
    
    </td> </tr> 
         
     
    </table> 
    </div> 
    </div> 
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
  </div>
  

  
  <div id="BillDiv"  class="popupnew" style ="display:none">
   <div align="right" ><a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';" >Close</a></div>
  <table class="tab">
  <tr>
  <th colspan="2"><%--Agreement Details--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </th>
  
  </tr>
  
  <tr>
  <th><%--LOI No. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.)</th>
  <td></td>
  </tr>
  
  <tr>
  <th><%--LOI Date --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</th>
  <td></td>
  </tr>
  
   <tr>
  <th><%--LOI To. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;)</th>
  <td></td>
  </tr>
  
   <tr>
  <th><%--PBG No.--%> (&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2325;&#2381;&#2352;.)</th>
  <td></td>
  </tr>
  
     <tr>
  <th><%--PBG Amount--%> (&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367;)</th>
  <td></td>
  </tr>
  
     <tr>
  <th><%--Validity --%>(&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; )</th>
  <td></td>
  </tr>
  
     <tr>
  <th><%--Agreement No.--%> (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;.)</th>
  <td></td>
  </tr>
  <tr>
  <th><%--Agreement Date--%>(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</th>
  <td></td>
  </tr>
  
  </table>
  
  
    </div>
  
     <script type="text/javascript" >
    function OpenBill()
    {
    document.getElementById('fadeDiv').style.display="block";
    document.getElementById('BillDiv').style.display="block";
   
    }
    
    
    function GenerateAgreement()
    {
    document.getElementById('fadeDiv').style.display="block";
    document.getElementById('DivAgreement').style.display="block";
    
    }
    
    </script>
     <script>

         var Globlephoto = document.getElementById("photoupload").innerHTML;
         $('#ContentPlaceHolder1_FileUpload1').live('change', function () {

             //this.files[0].size gets the size of your file.
             if (this.files[0].size / 1024 > 500) {
                 alert("असफल अपलोड. फाइल साइज़ 500 KB से अधिक है");
                 document.getElementById("PhotoUpload").innerHTML = Globlephoto;

             }

         });
           </script>
     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAgreementDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

