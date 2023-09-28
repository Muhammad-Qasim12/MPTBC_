<%@ Page Title="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; / Printer Capacity Financial year wise" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI004_PrinterCapacityFinYearWiseallParam.aspx.cs" Inherits="Printing_PRI004_PrinterCapacityFinYearWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header"> &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; / Printer Capacity Financial year wise  </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                     
                     <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


                     <table width="100%" cellpadding="4" cellspacing="4" class="tab" >
                     <tr>
                     <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; /<br />
                         Academic year</td>
                     <td class="auto-style1">
                     <asp:DropDownList runat="server" ID="ddlACYear_I" AutoPostBack="true"  >
                     </asp:DropDownList>
                     
                     </td>
                     <td>
                         &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2330;&#2369;&#2344;&#2375;
                     
                     </td>
                     <td>
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox reqirerd" 
                            onselectedindexchanged="ddlPrinterName_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                     
                     </td>
                     </tr>

                     <tr>
                     <th colspan="2">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;  / Capacity(Ton) </th>
                    
                    <th>&#2342;&#2379; &#2352;&#2306;&#2327;&#2368;&#2351; &#2357;&#2375;&#2348; / Two Color</th>
                    <th>&#2330;&#2366;&#2352; &#2352;&#2306;&#2327;&#2368;&#2351; &#2357;&#2375;&#2348; / Four Color </th>
                    <th>&#2330;&#2366;&#2352; &#2352;&#2306;&#2327;&#2368;&#2351; &#2358;&#2368;&#2335; / Four Color Sheet</th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2350;&#2358;&#2368;&#2344; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span> </th>
                    
                    <th>
                        <asp:TextBox ID="txt1" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" OnTextChanged="txt1_TextChanged" ></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt2" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" OnTextChanged="txt2_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt3" runat="server" Width="84px" onkeypress="tbx_fnSignedNumeric(event, this);" OnTextChanged="txt3_TextChanged"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span></th>
                    
                    <th>
                        <asp:TextBox ID="txt4" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" ></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt5" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt6" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2357;&#2367;&#2354;&#2350;&#2381;&#2348; &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; (&#2335;&#2344; &#2350;&#2375;&#2306;)</th>
                    
                    <th>
                        <asp:TextBox ID="txt7" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"  AutoPostBack="True" OnTextChanged="txt7_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt8" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"  AutoPostBack="True"  OnTextChanged="txt8_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt9" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"  AutoPostBack="True"  OnTextChanged="txt9_TextChanged"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2325;&#2366;&#2352;&#2381;&#2351; &#2357;&#2367;&#2337;&#2381;&#2352;&#2366;</th>
                    
                    <th>
                        <asp:TextBox ID="txt10" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" AutoPostBack="True" OnTextChanged="txt10_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt11" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" AutoPostBack="True" OnTextChanged="txt11_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt12" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" AutoPostBack="True" OnTextChanged="txt12_TextChanged"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2357;&#2367;&#2337;&#2381;&#2352;&#2366; &#2325;&#2366;&#2352;&#2381;&#2351; &#2325;&#2366; &#2342;&#2369;&#2327;&#2344;&#2366; &#2309;&#2341;&#2357;&#2366; &#2408;&#2406; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; &#2332;&#2379; &#2309;&#2343;&#2367;&#2325; &#2361;&#2379; </th>
                    
                    <th>
                        <asp:TextBox ID="txt13" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" OnTextChanged="txt13_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt14" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt15" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2309;&#2343;&#2367;&#2325;&#2340;&#2350; &#2357;&#2352;&#2381;&#2325; &#2350;&#2375;&#2306;&#2344; &#2325;&#2368; &#2358;&#2366;&#2360;&#2381;&#2340;&#2367;(
                         <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;%)</th>
                    
                    <th>
                        <asp:TextBox ID="txt16" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt17" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt18" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="2">&#2325;&#2369;&#2354; &#2325;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;</span> </th>
                    
                    <th>
                        <asp:TextBox ID="txt19" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);" OnTextChanged="txt19_TextChanged"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt20" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                    <th>
                        <asp:TextBox ID="txt21" runat="server" Width="85px" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                         </th>
                     </tr>

                     <tr>
                     <th colspan="5">
                         <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:Button runat="server" ID="BtnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save " OnClick="BtnSave_Click"  CssClass="btn" />
                     <asp:Button runat="server" ID="btnBack" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back" OnClick="btnBack_Click"  CssClass="btn" />

                         </th>
                    
                     </tr>

                     <tr>
                     <th colspan="5">
                         &nbsp;</th>
                    
                     </tr>

                     </table>
                     
                     </div> </div> 
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        width: 82px;
    }
</style>
</asp:Content>


