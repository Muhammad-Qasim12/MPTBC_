<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PBGInfo.aspx.cs" Inherits="Paper_PBGInfo" Title="PBG Info" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="portlet-header ui-widget-header">
<%--Vendor PBG Info--%>&#2357;&#2375;&#2306;&#2337;&#2352; &#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</div>
                     <div class="portlet-content">
    
    
    <table width="100%">
    
     <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    
    <tr>
    
     <td><%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
     <td>
     <asp:DropDownList runat="server" ID="ddlLOINo" Width="262px" AutoPostBack="True"   CssClass="txtbox reqirerd" 
             oninit="ddlLOINo_Init" onselectedindexchanged="ddlLOINo_SelectedIndexChanged">
     <asp:ListItem Text="Select"></asp:ListItem></asp:DropDownList></td>
    
    <td><%--Entry Date (--%> </td>
    <td></td>
    
    </tr>
     <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    <tr>
    <td colspan="4">
        <asp:Panel ID="Panel1" runat="server"   BorderColor="gray" BorderStyle="solid" BorderWidth="1px" >
        
        <table width="100%" >
     
    <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
     
   <tr>
    
     <td><b><%--LOI To. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;</b></td>
    <td >
        <asp:Label ID="lblVendorName" runat="server" ></asp:Label></td>
    <%--<td><b>LOI No. (&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.)</b></td>
    <td></td>--%>
    
    </tr>
    
    
     <tr>
    <td><b><%--LOI Date (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </b></td>
    <td><asp:Label ID="lblLOIDt" runat="server" ></asp:Label></td>
   
    <td><b><%--Address (--%>&#2346;&#2340;&#2366; </b></td>
    <td><asp:Label ID="lblLOIAddress" runat="server" ></asp:Label></td>
    
   
    </tr>
    
    
   
    <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
    
    
    </table>
        </asp:Panel>
    </td>
    </tr>
    <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
     
     <tr>
  
    <td><%--PBG No. (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2392;.</td>
     <td><asp:TextBox runat="server" ID="txtPBGNO" Width="250px"  
             CssClass="txtbox reqirerd" MaxLength="20"  onkeypress='javascript:tbx_fnAlphaOnly(event, this);' 
              ></asp:TextBox></td>
    </tr>
    <tr>
    
     
    
    <td><%--PBG Mode (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td>
    <td><asp:DropDownList runat="server" ID="ddlPBGMode" Width="262px"  CssClass="txtbox reqirerd">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="BG"></asp:ListItem>
    <asp:ListItem Text="FDR"></asp:ListItem>
    </asp:DropDownList></td>
    
       <td><%--PBG Date (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  </td>
    <td><asp:TextBox runat="server" ID="txtPBGDate" Width="250px" 
            CssClass="txtbox reqirerd" MaxLength="12"></asp:TextBox></td>
 
    </tr>
 
     
   
    
    <tr>
     <td><%--PBG Bank (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2348;&#2376;&#2306;&#2325;</td>
     <td><asp:DropDownList runat="server" ID="ddlBankDetails" Width="262px" CssClass="txtbox reqirerd" 
             oninit="ddlBankDetails_Init" >
     <asp:ListItem Text="Select" Value="0"></asp:ListItem></asp:DropDownList>
     </td>
    
    <td><%--PBG Amount (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )</td>
    <td><asp:TextBox runat="server" ID="txtPBGAmt" Width="250px"  
            CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);' 
            MaxLength="6"></asp:TextBox></td>
    
    
    </tr>
 
  <tr>
    
     <td><%--Validity Period (--%>&#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; &#2360;&#2350;&#2351; </td>
     <td><asp:TextBox runat="server" ID="txtValidityMonth" Width="250px" 
             CssClass="txtbox reqirerd"  onkeypress='javascript:tbx_fnInteger(event, this);' 
             MaxLength="4"></asp:TextBox></td>
    
    <td><%--Till Date (--%>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; </td>
    <td><asp:TextBox runat="server" ID="txtTillDate" CssClass="txtbox reqirerd" 
            Width="250px" MaxLength="12" ></asp:TextBox></td>
  
    
    </tr>
    
    <tr>
    
    <td><%--Generate Agreement (--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2332;&#2366;&#2352;&#2368;</td>
    <td><asp:RadioButtonList ID="rbGAgreement"   runat="server" RepeatDirection="Horizontal" >
    <asp:ListItem Text="&#2361;&#2366;&#2305;" Selected="True" Value="Yes"></asp:ListItem>
    <asp:ListItem Text="&#2344;&#2361;&#2368;&#2306;" Value="No"></asp:ListItem>
        </asp:RadioButtonList></td>
        <td>
         <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
        </td>
        <td><asp:TextBox runat="server" ID="txtRemark"  Width="250px" MaxLength="100" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
        </td>
    </tr>
  <tr>
     <td colspan="3" style="height:10px;"></td>
     </tr>
  
  <tr>
  <td></td>
    <td colspan="3">
    <asp:Button runat="server" ID="btnSave" 
            Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "   
            OnClientClick="return ValidateAllTextForm();"  CssClass="btn" 
            onclick="btnSave_Click"/>
 
    </td>
    </tr>
    <tr>
     <td colspan="4" style="height:10px;"></td>
     </tr>
   
    
    
    </table> 
    </div>
    <script>
            
        var Globlephoto =  document.getElementById("photoupload").innerHTML;
        $('#ContentPlaceHolder1_FlAgrimentFile').live('change', function () {

            //this.files[0].size gets the size of your file.
             if (this.files[0].size / 1024 > 500) {
                 alert("असफल अपलोड. फाइल साइज़ 500 KB से अधिक है");
                  document.getElementById("PhotoUpload").innerHTML=Globlephoto;
                
            }

          });
           </script>
      <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtPBGDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
       <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTillDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

