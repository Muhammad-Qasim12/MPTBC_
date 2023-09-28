<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewMoreDetails.aspx.cs" Inherits="Depo_ViewMoreDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type = "text/javascript">
      function PrintPanel() {
          var panel = document.getElementById("<%=Panel1.ClientID %>");

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
    <a href="#" class="btn"  onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
     
    <table width="100%" cellspacing="4" cellpadding="4" border="1" >
         <% 
             dt = obCommonFuction.FillDatasetByProc(@"SELECT case when GroupID=1 then 'A' when GroupID=2 then 'B'
when GroupID=3 then 'C' when GroupID=3 then 'D' when GroupID=4 then 'D' End GroupID, acb_vitrannirdesh.orderNo,
case when REPLACE(VOderID,'A','')=807 then concat(REPLACE(VOderID,'A',''),'-', '07-05-2018') else REPLACE(VOderID,'A','A')  end VOderID ,
case when ifnull(acb_vitrannirdesh.demandtype,0)<2 then case when REPLACE(VOderID,'A','')=807 then concat(REPLACE(VOderID,'A',''),'-', '07-05-2018') else REPLACE(VOderID,'A','A')  end else acb_vitrannirdesh.letterno  end VOderID1,FullAddress_V,NameofPress_V,gm.GroupNo_V,SubTitleHindi_V,case when DepoID=50 then 'RSK' else 
DepoName_V end DepoName_V,  SUM(TotalNoOFBooks) AS TotalNoOFBooks,
acb_vitrannirdesh.TitleID,acb_vitrannirdesh.SubTitleID,
acb_vitrannirdesh.SubTitleID,case when SubTitleHindi_V='.' then TitleHindi_V else  CONCAT(TitleHindi_V,'(',SubTitleHindi_V,')') end TitleHindi_V,

''groupname, 
fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear)perbundalbook,
CASE WHEN MOD(SUM(TotalNoOFBooks),fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear))=0 THEN
CONCAT('Pack ',
 ROUND(SUM(TotalNoOFBooks)/fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear),0)) 
 ELSE
CONCAT('Pack ',
 floor(SUM(TotalNoOFBooks)/fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear)),
 '  Loose 1','(',MOD(SUM(TotalNoOFBooks),fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear)),' Book )' ) 
END 
 Pack,
MOD(SUM(TotalNoOFBooks),fn_getacb_perbundalbook(acb_subtitle.SubTitleID_I,acb_vitrannirdesh.acyear)) Loosebook,DATE_FORMAT(OrderDate,'%d-%m-%Y') vitdate
  ,case when DepoID=50 then 1 else  CASE WHEN SubTitleID=173 THEN TotalID*3   WHEN SubTitleID=174 THEN TotalID*1 END end TotalN 

FROM acb_vitrannirdesh INNER JOIN acb_groupmaster gm ON acb_vitrannirdesh.VGrpID=gm.GrpID_I
INNER JOIN acb_titledetail ON acb_titledetail.TitleID_I=acb_vitrannirdesh.TitleID
INNER JOIN acb_subtitle ON acb_subtitle.SubTitleID_I=acb_vitrannirdesh.SubTitleID
INNER JOIN pri_printerregistration_t ON pri_printerregistration_t.Printer_RedID_I=PrinterID
left JOIN adm_depomaster_m ON adm_depomaster_m.DepoTrno_I=DepoID 
WHERE acb_vitrannirdesh.orderno='" + Request.QueryString["id"].ToString() + "' and acb_vitrannirdesh.Acyear='" + Request.QueryString["Year"] + "' GROUP BY VGrpID, acb_vitrannirdesh.TitleID,acb_vitrannirdesh.SubTitleID,DepoName_V");

             //if (Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString()) >= 197 && Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString()) <= 206)
             //{
             //    GridView2.DataSource = dt.Tables[0];
             //    GridView2.DataBind();
             //}
             //else
             //{ }
                 GridView1.DataSource = dt.Tables[0];
                 GridView1.DataBind();
            

             dtt = obCommonFuction.FillDatasetByProc("SELECT DATE_FORMAT( LetterDate_D,'%d/%m/%Y') LetterDate_D,CASE   WHEN  `DemandFrom_I`=24 THEN 'समग्र शिक्षा अभियान भोपाल '  WHEN  `DemandFrom_I`=1 THEN 'R.S.K.'  WHEN DemandFrom_I=2 THEN ' राष्ट्रीय माध्यमिक शिक्षा अभियान , भोपाल'  WHEN DemandFrom_I=3 THEN '&#2360;&#2306;&#2360;&#2381;&#2325;&#2371;&#2340; &#2348;&#2379;&#2352;&#2381;&#2337;' WHEN DemandFrom_I=4 THEN '&#2361;&#2376;&#2342;&#2352;&#2366;&#2348;&#2366;&#2342; &#2335;&#2368; &#2348;&#2368; &#2360;&#2368; ' WHEN DemandFrom_I=5 then '&#2352;&#2366;&#2359;&#2381;&#2335;&#2381;&#2352;&#2368;&#2351; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;&#2367;&#2325; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2309;&#2349;&#2367;&#2351;&#2366;&#2344;' WHEN DemandFrom_I=6 then 'CPI'  END DemandFrom_I  FROM`dib_demand` WHERE `LetterNo_V`='" + dt.Tables[0].Rows[0]["VOderID"].ToString() + "'");
           
                                 %>
        <tr><td colspan="3" align="center" >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; : <%=Request.QueryString["Year"] %> &#2325;&#2375; &#2354;&#2367;&#2319; &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2337;&#2367;&#2346;&#2379;&#2357;&#2377;&#2352; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;</td></tr>

        <tr><td colspan="3" align="center" ><%=dtt.Tables[0].Rows[0]["DemandFrom_I"].ToString() %>&nbsp;&#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;. &nbsp; : <%=dt.Tables[0].Rows[0]["VOderID1"].ToString() %>  दिनांक : <%=dtt.Tables[0].Rows[0]["LetterDate_D"].ToString() %></td></tr>

        <tr><td class="auto-style1">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td><td><%=dt.Tables[0].Rows[0]["orderNo"].ToString() %></td><td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <%=dt.Tables[0].Rows[0]["vitdate"].ToString() %></td></tr>

        <tr><td class="auto-style1">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td><td colspan="2"><%=dt.Tables[0].Rows[0]["NameofPress_V"].ToString() %> <br /> <%=dt.Tables[0].Rows[0]["FullAddress_V"].ToString() %></td></tr>

        <tr><td class="auto-style1">
            <%--<% if (Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString()) >= 197 && Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString ()) <= 206) 
               {%>
            &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; 
            <%}else {%> <%} %>--%>
            &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
           


            </td><td colspan="2"><%=dt.Tables[0].Rows[0]["TitleHindi_V"].ToString() %></td></tr>

        <tr><td class="auto-style1">
            <%--<% if (Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString()) >= 197 && Convert.ToInt32(dt.Tables[0].Rows[0]["orderNo"].ToString ()) <= 206) 
               {
               
              %>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <%}else { %><%} %>--%>

             <asp:Label ID="Label2" runat="server" Text="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;"></asp:Label>
            
            </td><td><%=dt.Tables[0].Rows[0]["perbundalbook"].ToString() %></td><td>&#2327;&#2381;&#2352;&#2369;&#2346; :<%=dt.Tables[0].Rows[0]["GroupID"].ToString() %></td></tr>

        <tr><td colspan="3">&nbsp;</td></tr>

        <tr><td colspan="3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                        <ItemTemplate>
                                  <%# Container.DataItemIndex+1 %>
                              </ItemTemplate>
                    </asp:TemplateField>
                          <%-- <asp:BoundField DataField="GroupNo_V" HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350; " />--%>
                         <%--  <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; "  />--%>
                          <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    <asp:BoundField DataField="TotalNoOFBooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                    <asp:BoundField DataField="pack" HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  " />
                </Columns>
            </asp:GridView>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                        <ItemTemplate>
                                  <%# Container.DataItemIndex+1 %>
                              </ItemTemplate>
                    </asp:TemplateField>
                          <%-- <asp:BoundField DataField="GroupNo_V" HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350; " />--%>
                         <%--  <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; "  />--%>
                          <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    <asp:BoundField DataField="TotalNoOFBooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340;  OMR Sheet &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                   
                    
                      
                    <asp:TemplateField HeaderText="No of Cartons">
                        <ItemTemplate>
                          <%#Eval("TotalN") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    
                      
                </Columns>
            </asp:GridView>
            </td></tr>

        <tr><td colspan="3"> <br /><br /><br /><br />
                  <center>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;उपमहाप्रबंधक ( वितरण&nbsp; )
                      <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; <br />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2349;&#2379;&#2346;&#2366;&#2354; </center> 
           </td></tr>

    </table>

</asp:Content>

