<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoChallanRateculcutebyHo.aspx.cs" Inherits="Depo_DepoChallanRateculcutebyHo" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       #ctl00_ContentPlaceHolder1_ddlPrinterName label {
  /**display: block;*/
  padding-left: 23px;
  text-indent: -15px;
  float: left;
}

.chkChoice input 
{ 
    width: 13px;
  height: 13px;
  padding: 0;
  margin:0;
  vertical-align: bottom;
  position: relative;
  top: -1px;
  *overflow: hidden;
  float: left;
}

.chkChoice td 
{ 
    padding-left: 10px; 
}

.PnlDesign
{
            border: solid 1px #000000;
            height: 150px;
            width: 330px;
            overflow-y:scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
}
    </style>
     <script type="text/javascript">
         var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
         var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2> &#2348;&#2381;&#2354;&#2377;&#2325;&#2357;&#2366;&#2352; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2357;&#2381;&#2351;&#2351; &#2325;&#2366; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2360;&#2381;&#2340;&#2352; &#2346;&#2352; &#2325;&#2368; &#2327;&#2312; &#2327;&#2339;&#2344;&#2366;</h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td>प्रकार </td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" >
                            <asp:ListItem Value="1">ब्लॉक  प्रदाय</asp:ListItem>
                            <asp:ListItem Value="2">अन्तरडिपो </asp:ListItem>
                             <asp:ListItem Value="3">अन्य पाठ्य सामग्री  </asp:ListItem>
                            <asp:ListItem Value="4">ब्लॉक  प्रदाय एवं अन्य पाठ्य सामग्री  </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
                <tr style="display:none" id="a" runat="server" >
                    <td>
                        <asp:Label ID="LblDistrict" runat="server" Width="263px">&#2332;&#2367;&#2354;&#2366;/ District Name :</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDistrict" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onselectedindexchanged="DdlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;/Bolck Name</td>
                    <td>
                        <asp:DropDownList ID="ddlBlock" runat="server"  CssClass="txtbox reqirerd">
                            </asp:DropDownList></td>
                    <td>
                        &nbsp;</td>
                </tr>
                
                <tr style="display:none" id="a1" runat="server" >
                    <td>
                        डिपो का नाम
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>
               <div style="overflow: auto" class="rdlc">
                    <rsweb:reportviewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                        Width="100%" Height="800px">
                    </rsweb:reportviewer>
                </div>
        </div>
    </div>
</asp:Content>

