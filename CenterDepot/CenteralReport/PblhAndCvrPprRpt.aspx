<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PblhAndCvrPprRpt.aspx.cs" Inherits="Paper_PublishAndCoverPaperAllotmentAndSupplyReport"
    Title="&#2350;&#2367;&#2354;&#2348;&#2366;&#2352; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2319;&#2357;&#2306; &#2325;&#2357;&#2381;&#2361;&#2352; &#2325;&#2366;&#2327;&#2332; &#2310;&#2357;&#2306;&#2335;&#2344; &#2357; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Mill Wise Printing & Cover Paper Allotment" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2350;&#2367;&#2354;&#2348;&#2366;&#2352; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2319;&#2357;&#2306; &#2325;&#2357;&#2381;&#2361;&#2352; &#2325;&#2366;&#2327;&#2332; &#2310;&#2357;&#2306;&#2335;&#2344; &#2357; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Mill Wise Printing & Cover Paper Allotment</div>
     <div class="portlet-content">
  
          <div class="table-responsive">  
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;<br />Academic Year 
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlYear" Width="250px" CssClass="txtbox reqirerd"
                            OnInit="ddlYear_Init">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left">
                     <div style="float:left;margin-left:0px;padding-left:0px;">
                     <center>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                       Width="100%"     Height="657px">
                        </rsweb:ReportViewer></center></div>
                    </td>
                </tr>
            </table>
            
         
        </div>
    </div>
    
</asp:Content>
