<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherthanInterdepo.aspx.cs" Inherits="Depo_OtherthanInterdepo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <div class="box table-responsive">
        <div class="card-header">
            <h2 class="auto-style1">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351;&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2309;&#2306;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2347;&#2352; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                        <asp:DropDownList ID="ddlFyYr" runat="server" >
                        </asp:DropDownList>
                    </td>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>&nbsp;.
                        <asp:DropDownList ID="ddlLetterNo" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlLetterNo_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
                    <td>
                                <asp:DropDownList ID="ddlSub" runat="server" CssClass="txtbox"
                                    >
                                </asp:DropDownList>
                              
                    </td>
                    <td>&nbsp;</td>
                    <td>
                                    <asp:Button ID="Button12" runat="server" CssClass="btn" Text="Show Report" 
                                        onclick="Button12_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                                    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" OnClick="btnExport_Click" Text="Export to Excel"   />
                                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel();" Text="Export to PDF &amp; Print" />
                                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="ExportDiv" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" >
                            <Columns>
                                <asp:BoundField DataField="Year" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;" />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" />
                                <asp:BoundField DataField="a" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; " />
                                <asp:BoundField DataField="b" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; " />
                                <asp:BoundField DataField="TotalNoofBooks" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2379;." />
                                <asp:BoundField DataField="OrderDate" HeaderText="&#2321;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                            </Columns>
                        </asp:GridView></div>
                    </td>
                </tr></table> </div> </div>   <script type = "text/javascript">
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
                                                      </script>
                                                      </asp:Content>

