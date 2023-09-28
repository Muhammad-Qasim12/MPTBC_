﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowTwentyPerReptforbill.aspx.cs" Inherits="Depo_ShowTwentyPerRept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Button ID="btnExport" runat="server" CssClass="btn" 
                            Text="Export to Excel" Visible="false"  />&nbsp;
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
                        
    
    <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 25 % &#2327;&#2339;&#2344;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; 
            </h2>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " CssClass="btn" OnClick="Button1_Click" />
         <div id="ExportDiv" runat="server" >
        <div style="padding: 0 10px;"><%
                                          ds = obj.FillDatasetByProc("call USP_dptGet25Report(" + api.Decrypt(Request.QueryString["ID"]) + ")");                  

                                         if (ds.Tables[0].Rows.Count > 0)
                                         {
               %>
             <table width="100%" style ="font :12px">
             <tr ><td colspan="4"  > <p align="center"><strong>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2354;&#2351; &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;  <%=ds.Tables[0].Rows[0]["DepoName_V"].ToString ()%> </strong> </p>  <p align="center"><strong>
                 &#2350;&#2343;&#2381;&#2351;&#2366;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2349;&#2339;&#2381;&#2337;&#2366;&#2352;            <strong>&#2360;&#2340;&#2381;&#2352;  -  <%=obj.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()%>
                  </strong>
              </p>
            
              </td> </tr>
           <tr>
          <td>&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<%=ds.Tables[0].Rows[0]["LetterNo_V"].ToString() %> /&#2346;&#2366;&#2346;&#2369;&#2344;&#2367;/&#2344;&#2367;&#2327;&#2350; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352;</td><td>&nbsp;</td><td>&#2342;&#2367;&#2344;&#2366;&#2325;.</td><td>
              <%=( ds.Tables[0].Rows[0]["LetterDate"].ToString ())%></td> </tr>
          <tr><td colspan="4"><strong>&#2346;&#2381;&#2352;&#2340;&#2367;
             <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%=ds.Tables[0].Rows[0]["NameofPress_V"].ToString ()%>
              <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <%=ds.Tables[0].Rows[0]["FullAddress_V"].ToString ()%>
              

                              </strong></td> </tr>
          <tr><td colspan="4">&#2357;&#2367;&#2359;&#2351; - &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 25 %  &#2327;&#2339;&#2344;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; .
            </td> </tr>
          <tr><td colspan="4">&#2360;&#2344;&#2381;&#2342;&#2352;&#2381;&#2349; </td> </tr>
          <tr><td colspan="4">1.&#2330;&#2366;&#2354;&#2366;&#2344;/&#2332;&#2368;.&#2310;&#2352;. &#2325;&#2381;&#2352; 
             &nbsp; &#2332;&#2368;.&#2310;&#2352;.&#2342;&#2367;&#2344;&#2366;&#2325;.-  <%=ds.Tables[0].Rows[0]["GRNo_V"]%> / <%=ds.Tables[0].Rows[0]["GRDate_D"].ToString ()%></td> </tr>
          <tr><td colspan="4">2. &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2325; 
              - <%=ds.Tables[0].Rows[0]["Receiveddate_D"].ToString ()%></td> </tr>
          <tr><td colspan="4">3.&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; &#2344;&#2367;&#2350;&#2381;&#2344;&#2366;&#2344;&#2369;&#2360;&#2366;&#2352; &#2361;&#2376; :-</td> </tr>
          <tr><td colspan="4" style="border-color: #000000">
                <table style="width: 100%" border"2" class="tab" >
                        <th rowspan="2" >&#2360;.&#2325;&#2381;&#2352;.
                        </th>
                        <th rowspan="2" >&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                        </th>
                        <th rowspan="2" >&#2310;&#2346;&#2325;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                        </th>
                        <th rowspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352;
                        </th>
                        <th >&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2368; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&nbsp; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                        </th>
                        <th>&nbsp;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354;&#2379; &#2350;&#2375;&#2306; &#2360;&#2375; 25% &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368;  &#2327;&#2339;&#2344;&#2366;
                        </th>
                        <th >25% &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; &#2325;&#2350; &#2346;&#2366;&#2312; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                    <th rowspan="2" >
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;
                        </th>
                    
                        
                        <tr>
                        <td >&#2351;&#2379;&#2327;</td>
                        <td >&#2351;&#2379;&#2327;</td>
                        <td >&#2351;&#2379;&#2327;</td>
                        </tr>
                    
                        
                    <tr>
                        <td style="width: 29px">
                            1</td>
                        <td style="width: 55px">
                            <%=ds.Tables[0].Rows[0]["TitleHindi_V"].ToString ()%></td>
                        <td style="width: 80px">
                            <%=ds.Tables[0].Rows[0]["PacketsSendAsPerChallan"].ToString()%></td>
                        <td style="width: 100px">
                            <%=ds.Tables[0].Rows[0]["NoOfBookCounted_I"].ToString()%></td>
                        <td style="width: 98px">
                            <%=ds.Tables[0].Rows[0]["TotalNoOfBooks"].ToString ()%></td>
                        <td style="width: 92px">
                            <%=Convert.ToDouble(ds.Tables[0].Rows[0]["NofSchemeBook_I"])+Convert.ToDouble(ds.Tables[0].Rows[0]["NoOFgenralBook_I"])%>
                        </td>
                        </td>
                        <td style="width: 100px">
                            <%=Convert.ToDouble ((ds.Tables[0].Rows[0]["TotalNoOfBooks"]))-(Convert.ToDouble(ds.Tables[0].Rows[0]["NofSchemeBook_I"])+Convert.ToDouble(ds.Tables[0].Rows[0]["NoOFgenralBook_I"])) %> </td>
                        <td style="width: 82px"><%=ds.Tables[0].Rows[0]["BookDimention_V"].ToString ()%>
                            </td>
                    </tr>
                </table>
            
              </td> </tr>
          <tr><td colspan="4" class="auto-style1">4. &#2348;&#2306;&#2337;&#2354;&#2379; &#2350;&#2375;&#2306; &#2340;&#2381;&#2352;&#2369;&#2335;&#2367;&#2346;&#2370;&#2352;&#2381;&#2339; &#2319;&#2357;&#2306; &#2326;&#2352;&#2366;&#2348; &#2346;&#2366;&#2312; &#2327;&#2351;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2325;&#2375; &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343; &#2350;&#2375;&#2306;<br />5.&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2375; &#2360;&#2350;&#2325;&#2381;&#2359; &#2325;&#2368; &#2327;&#2351;&#2368; &#2327;&#2339;&#2344;&#2366; &#2325;&#2366; &#2348;&#2339;&#2381;&#2337;&#2354;&#2348;&#2366;&#2352; &#2357;&#2367;&#2357;&#2352;&#2339; :-</td> </tr>
          <tr><td colspan="4">1) &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2366; &#2344;&#2366;&#2350; 
              :-&nbsp; <%=ds.Tables[0].Rows[0]["PrinterCompanyperson_V"].ToString ()%> 
              (2)&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2313;&#2346;&#2360;&#2381;&#2341;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2325;.<%=ds.Tables[0].Rows[0]["PresentDate_D"].ToString ()%></td> </tr>
          <tr><td colspan="4">(3) &#2337;&#2367;&#2346;&#2379; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; &#2326;&#2379;&#2354;&#2375; &#2327;&#2351;&#2375; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368;&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2375; &#2360;&#2350;&#2325;&#2381;&#2359; &#2325;&#2368; &#2327;&#2351;&#2368; &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2366;&#2312; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;.<%=ds.Tables[0].Rows[0]["CheckBundleNoOfBookFirst_I"].ToString()%></td> </tr>
          <tr><td colspan="4">8. &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2357;&#2367;&#2359;&#2381;&#2335;&#2367; &#2337;&#2367;&#2346;&#2379; &#2325;&#2375; &#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2379;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; &#2325;&#2375; &#2346;&#2381;&#2352;&#2359;&#2381;&#2336; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;.<%=ds.Tables[0].Rows[0]["RegisterNo"].ToString ()%>.&#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2325;. 
              <%=ds.Tables[0].Rows[0]["Date_D"].ToString ()%>&#2350;&#2375;&#2306; &#2325;&#2368; &#2327;&#2351;&#2368;.
            </td> </tr>
          <tr><td colspan="4">9 &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; &#2346;&#2325;&#2381;&#2359; &#2350;&#2375;&#2306; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2357;&#2381;&#2351;&#2351; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;):- </td> </tr>
          <tr><td colspan="4">
              <table width="100%" class="tab">
                  <tr>
                      <th >
                          &#2313;&#2340;&#2352;&#2366;&#2312;(&#2352;&#2370;.)</th>
                      <th >
                          &#2330;&#2338;&#2366;&#2312; (&#2352;&#2370;.)</th>
                      <th >
                          &#2309;&#2344;&#2381;&#2351; &#2357;&#2381;&#2351;&#2351;(&#2352;&#2370;.)</th>
                      <th >
                          &#2325;&#2369;&#2354; &#2351;&#2379;&#2327;</th>
                  </tr>
                  <tr>
                      <td >
                          <%=ds.Tables[0].Rows[0]["unLordingCharge_N"].ToString ()%></td>
                      <td >
                          <%=ds.Tables[0].Rows[0]["LordingCharge_N"].ToString ()%></td>
                      <td >
                          <%=ds.Tables[0].Rows[0]["OtherCharges_N"].ToString () %></td>
                      <td >
                          <%=ds.Tables[0].Rows[0]["totalCharge"].ToString ()%></td>
                  </tr>
              </table>
              </td> </tr>
          <tr><td colspan="4">10.&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; <%=ds.Tables[0].Rows[0]["Remarks_V"].ToString ()%></td> </tr>
            <tr><td colspan="4"></td> </tr>  <tr><td colspan="4"></td> </tr>  <tr><td colspan="4"></td> </tr>  <tr><td colspan="4"></td> </tr> 
          <tr><td colspan="4">&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2344;&#2381;&#2341;&#2325;, &#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2346;.&#2325;&#2381;&#2352;. <%=( ds.Tables[0].Rows[0]["LetterNo_V"])%>/&#2349;&#2339;&#2381;&#2337;&#2366;&#2352;/ 
              &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;.<%=( ds.Tables[0].Rows[0]["LetterDate"].ToString ())%></td> </tr>
          <tr><td colspan="4">&#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367;:-&nbsp; &#2346;&#2381;&#2352;&#2348;&#2344;&#2381;&#2343; &#2360;&#2306;&#2330;&#2366;&#2354;&#2325;,&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360;,&#2332;&#2375;&#2354; &#2352;&#2379;&#2337;,&#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2368; &#2323;&#2352; &#2360;&#2370;&#2330;&#2344;&#2366;&#2352;&#2381;&#2341; &#2319;&#2357;&#2306; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2325;&#2366;&#2352;&#2381;&#2351;&#2357;&#2366;&#2361;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340;.</td> </tr>
          <tr><td colspan="4" align="right" ><strong>&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; 
              <%=ds.Tables[0].Rows[0]["DepoName_V"].ToString ()%></strong></td> </tr>
          </table> <%} %>

        </div> 
        </div> </div> 
              <script type = "text/javascript">
                  function PrintPanel() {
                      var panel = document.getElementById("<%=ExportDiv.ClientID %>");

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: left; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
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

