<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrasnpotrtBillReport.aspx.cs" Inherits="Depo_TrasnpotrtBillReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>परिवहन &#2325;&#2375; &#2348;&#2367;&#2354; की &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transporter Bill Details</h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%" border="1">
                <tr>
                    <td>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / Report" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"> <asp:Panel ID="Panel1" runat="server" Visible="false" >
                                     <center>
                       <table width="100%" align="center"><tr><td align="center" >&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
        <br />
<asp:Label ID="lblAddress" runat="server"></asp:Label>
        <br />
        </b> 
        </td></tr><tr><td>&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
            <asp:Label ID="lblphone" runat="server"></asp:Label>
            , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo" runat="server"></asp:Label>
            &nbsp;
&nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
            <asp:Label ID="lblemailID" runat="server"></asp:Label>
&nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.nic.in</td></tr><tr><td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
            </b> 
                                 &nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            </b> 
            </td></tr><tr><td>  &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2375; &#2348;&#2367;&#2354; &#2325;&#2367; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transporter Bill Details</b> </td></tr></table>
                 <table>
                        <table class="tab">
                            <tr>
                                <th rowspan="2">&#2360;&#2381;&#2341;&#2366;&#2344; &#2325;&#2366; &#2344;&#2366;&#2350; / Place Name
                                   
                                </th>
                                <th rowspan="2">&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2361;&#2375;&#2340;&#2369; &#2348;&#2339;&#2381;&#2337;&#2354; / Payment As Per Bundle</th>
                                <th colspan="2">फुल ट्रक रेट(9 टन) / Full Track Rate</th>
                                <th colspan="2">हाफ ट्रक रेट (4 टन)/ Half Track Rate</th>
                                <th class="auto-style2" colspan="2">प्रति टन </th>
                                <th class="auto-style2" rowspan="2">&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368; Total Amount</th>
                                <th rowspan="2">&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; Transporter Amounts</th>
                            </tr>
                            <tr>
                                <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No.</th>
                                <th>&#2352;&#2366;&#2358;&#2368; / Amount</th>
                                <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /  No. </th>
                                <th>&#2352;&#2366;&#2358;&#2368; / Amount</th>
                                <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/  No. </th>
                                <th>&#2352;&#2366;&#2358;&#2368; / Amount</th>
                            </tr>

                            <tr><% 
//                                    db.execute(@"SELECT BlockNameHindi_V, sum(Amount)Amount, sum(NoofBandal)NoofBandal, case when (sum(NoofBandal)>224) then floor( sum(NoofBandal)/225) end Fulltruk,
//case when (sum(NoofBandal)%225)>=112 then floor( (sum(NoofBandal)%225)/112) end Halftruk ,
//case when (sum(NoofBandal)%225)/112>0 then (sum(NoofBandal)%225)%112 end perbundaltruk ,
//max(FullTruckRate_N)FullTruckRate_N,max(HalfTruckRate_N)HalfTruckRate_N,max(RatePerBundle_N)RatePerBundle_N FROM dpt_transpotbilldetails 
//inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=BlockID
//inner join dpt_transport_m on dpt_transport_m.TransportID_I=TransPoterID
//inner join dpt_transportdetails_t on dpt_transportdetails_t.TransportDetailsID_I=dpt_transport_m.TransportID_I and BlockID_I=BlockID where dpt_transpotbilldetails.TransPoterID=" + DropDownList1.SelectedValue + " group by BlockID,BlockNameHindi_V",DBAccess.SQLType.IS_QUERY );
//                                   ds = db.records();                                                                                                                                                                   
                                 ds=  comp.FillDatasetByProc("Call USP_Dpt_TransportBillReport(" + DropDownList1.SelectedValue + ")");                                                                                                                                                 
               for (int j=0;j<ds.Tables[0].Rows.Count;j++)
               { 
                  %>
                                <td><%=ds.Tables[0].Rows[j]["BlockNameHindi_V"].ToString () %></td>
                                <td><%=ds.Tables[0].Rows[j]["NoofBandal"].ToString () %></td>
                                <td><%=ds.Tables[0].Rows[j]["Fulltruk"].ToString () %></td>
                                <td><%=(Convert.ToDouble(ds.Tables[0].Rows[j]["Fulltruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["FullTruckRate_N"])) %></td>
                                <td><%=ds.Tables[0].Rows[j]["Halftruk"].ToString () %></td>
                                <td><%=(Convert.ToDouble(ds.Tables[0].Rows[j]["Halftruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["HalfTruckRate_N"])) %></td>
                                <td ><%=ds.Tables[0].Rows[j]["perbundaltruk"].ToString () %></td>
                                <td><%=(Convert.ToDouble(ds.Tables[0].Rows[j]["perbundaltruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["RatePerBundle_N"])) %></td>
                                <td ><%=(Convert.ToDouble(ds.Tables[0].Rows[j]["Fulltruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["FullTruckRate_N"])+Convert.ToDouble(ds.Tables[0].Rows[j]["Halftruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["HalfTruckRate_N"])+Convert.ToDouble(ds.Tables[0].Rows[j]["perbundaltruk"])* Convert.ToDouble(ds.Tables[0].Rows[j]["RatePerBundle_N"])) %></td>
                                <td><%=ds.Tables[0].Rows[j]["Amount"].ToString () %></td>
                            </tr><%  } %>
                        </table>
                        
                                     </asp:Panel><asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF"  />
                        <br />
                    </td>
                </tr>
            </table>
          
        </div>
    </div>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Area,Gender and Category wise Distribution of Student</title>');
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

