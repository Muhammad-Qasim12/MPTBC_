<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoWiseBookSellingReport.aspx.cs" Inherits="Depo_DepoWiseBookSellingReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box table-responsive">
        <div id="a" runat="server" class="card-header" >
            <h2>&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
        </div>
        <table width="100%">
            <tr>
                <td >&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; </td>
                <td > <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender></td>
                <td >&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; </td>
                <td ><asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td >&#2358;&#2376;&#2325;&#2381;&#2359;&#2367;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                <td >
                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td >
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " OnClick="Button3_Click" />
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="ExportDiv" runat="server">
                    <center><b>
                    <br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></b><br /><br />
                  
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379;  &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField HeaderText="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2312;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="NOOfBooksPraday" />
                            <asp:BoundField HeaderText=" &#2327;&#2339;&#2344;&#2366; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352;  &#2352;&#2366;&#2358;&#2367; " DataField="Tam" />
                           <asp:BoundField DataField="DDamount" HeaderText="&#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2368;" />
                        
                             <asp:BoundField DataField="Distcount" HeaderText="&#2331;&#2370;&#2335; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367;" />
                        
                        
                        </Columns>
                    </asp:GridView>
                    </center>
                        </div> 
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; "  /></td>
            </tr>
        </table>
    </div>
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

              var printWindow = window.open('', '', 'height=400,width=800');
              printWindow.document.write('<html><head><title></title>');
              printWindow.document.write('</head><body >');
              printWindow.document.write(panel.innerHTML);
              printWindow.document.write('</body></html>');
              printWindow.document.close();
              setTimeout(function () {
                  printWindow.print();
              }, 500);
              return false;
          }</script> 
</asp:Content>

