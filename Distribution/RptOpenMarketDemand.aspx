<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptOpenMarketDemand.aspx.cs" Inherits="Distribution_RptOpenMarketDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span >&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2361;&#2375;&#2340;&#2369; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; 
                    / Depot wise Textbooks Demand For Open Market Sell
                </span></h2>
        </div>
        <div class="portlet-content">
         <asp:Panel   class="response-msg inf ui-corner-all" runat="server" id="mainDiv" style="display: block;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" 
                    Text="&#2325;&#2371;&#2346;&#2351;&#2366; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;, &#2337;&#2367;&#2346;&#2379; , &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2340;&#2341;&#2366; &#2325;&#2325;&#2381;&#2359;&#2366; &#2330;&#2369;&#2344;&#2375; / Please select Academic Year , Depot , Medium and Class to view demand"
                     class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
            <div class="table-responsive">
            <table style="width: 100%">
                <tr>
                    <td style=" width:185px">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd" >
                            
                        </asp:DropDownList>
                    </td>
                    <td >
                        &#2337;&#2367;&#2346;&#2379; &#2330;&#2369;&#2344;&#2375; / Depot:
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlDepoMaster" runat="server" CssClass="txtbox reqirerd"  OnInit="ddlDepoMaster_Init"
                            Width="150px" >
                        </asp:DropDownList>
                    </td>
                  <td >
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2330;&#2369;&#2344;&#2375; / Medium :
                    </td>
                    <td>
   <asp:DropDownList ID="ddlMedum" runat="server" CssClass="txtbox reqirerd" OnInit="ddlMedum_Init"
                            Width="150">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td  colspan="2">
                 <table >
                            <tr>
                                <td>
                                    &#2325;&#2325;&#2381;&#2359;&#2366; / Class:
                                </td>
                                <td style="border:1px solid  lightgrey">
                                 
                                  <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>  <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" />
                                   <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                    <asp:CheckBoxList ID="ddlClass"   OnInit="ddlClass_Init"  RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left"  runat="server">                                      
                                    </asp:CheckBoxList>
                                </td>
                            </tr>

                        </table>
                    </td>
                    <td style="font-size: medium;" >
                     
                           <asp:Button text="View / &#2342;&#2375;&#2326;&#2375;&#2306; " id="BtnView" runat="server" CssClass="btn" OnClick ="ddlClass_SelectedIndexChanged"/>
                        
                    <%--    <asp:DropDownList ID="ddlClass" runat="server" CssClass="txtbox reqirerd" AutoPostBack="true"
                            OnInit="ddlClass_Init" Width="114px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                    </td>
                   
                </tr></table> 
                <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print"  />

                &nbsp;<asp:Button CssClass="btn" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2319;&#2325;&#2381;&#2360;&#2375;&#2354; &#2350;&#2375;&#2306; &#2354;&#2375;&#2306; |" ID="btnExport" OnClick="btnExport_Click" />

                <div id="ExportDiv" runat="server" >

                    <table width="100%"><tr><td>
                        <center>
                        &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                     
                        " &#2357;&#2367;&#2340;&#2352;&#2339; (&#2309;) &#2358;&#2366;&#2326;&#2366; "<br />
&nbsp;&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;<br />
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :<%=ddlSessionYear.SelectedValue %>&nbsp; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; : <%=ddlDepoMaster.SelectedItem.Text %>&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; : <%=ddlMedum.SelectedItem.Text %> </center></td></tr><tr><td>&nbsp;</td></tr></table>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnDataBound="GrdGroupDetails_DataBound" OnRowCreated ="OnRowCreated">
                     <Columns>
                         <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                         <asp:BoundField DataField="MainDemand" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; " />
                         <asp:BoundField DataField="ExtraDemand" HeaderText="&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340;  &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; 1" />
                         <asp:BoundField DataField="ExtraDemand1" HeaderText="&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340;  &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; 2" />
                         <asp:BoundField DataField="totalDemand" HeaderText="&#2325;&#2369;&#2354; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; " />
                     </Columns>
                </asp:GridView></div>
            </div> </div> </div> 
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
         }

         function CheckAll() {
             var intIndex = 0;
             var rowCount = document.getElementById('<%=ddlClass.ClientID%>').getElementsByTagName("input").length;
             
             for (i = 0; i < rowCount; i++) {

                 if (document.getElementById('chkSelect').checked == true) {
                     document.getElementById("<%=ddlClass.ClientID%>" + "_" + i).checked = true;
                 }

                 else {
                     document.getElementById("<%=ddlClass.ClientID%>" + "_" + i).checked = false;
                 }

             }

         }

        
     </script> 

</asp:Content>

