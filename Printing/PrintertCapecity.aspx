<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintertCapecity.aspx.cs" Inherits="Printing_PrintertCapecity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <script type = "text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=Panel1.ClientID %>");

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


    <div class="box table-responsive">
         
                
                    
     <div class="portlet-header ui-widget-header"> &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; / Printer Capacity Financial year wise  </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                     
                     <asp:panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:panel>

                     <table width="100%" cellpadding="4" cellspacing="4" class="tab" >
                         
                     <tr>
                     <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; /<br />
                         Academic year</td>
                     <td class="auto-style1">
                     <asp:DropDownList runat="server" ID="ddlACYear_I"   >
                     </asp:DropDownList>
                     
                     </td>
                     <td>
                         &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2330;&#2369;&#2344;&#2375;
                     
                     </td>
                     <td>
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox reqirerd" >
                        </asp:DropDownList>
                     
                     </td>
                     </tr>
                     <tr>
                     <td colspan="4">
                         <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                         
                         <asp:Button ID="Button4" runat="server" CssClass="btn" Text="Print" OnClientClick="return PrintPanel();"  />
                         </td>
                     </tr>


                     </table>
                          <asp:panel ID="Panel1" runat="server" >
                         <div id="Printer" runat="server" visible="false" >
<table width="100%" cellpadding="4" cellspacing="4" class="tab" >
    <tr>
        <th colspan="5" > &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; / Printer Capacity Financial year wise </th>             
        </tr>
    <tr>   
     <th colspan="5" >Academic Year <%=ddlACYear_I.SelectedValue%>  Printer <%=ddlPrinterName.SelectedItem.Text%> </th>
                    
                     
                    
        
                     </tr>
                     <tr>
                     <th>&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                    
                     <th>&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;  / Capacity(Ton) </th>
                    
                    <th>&#2342;&#2379; &#2352;&#2306;&#2327;&#2368;&#2351; &#2357;&#2375;&#2348; / Two Color</th>
                    <th>&#2330;&#2366;&#2352; &#2352;&#2306;&#2327;&#2368;&#2351; &#2357;&#2375;&#2348; / Four Color </th>
                    <th>&#2330;&#2366;&#2352; &#2352;&#2306;&#2327;&#2368;&#2351; &#2358;&#2368;&#2335; / Four Color Sheet</th>
                     </tr>
    <%if ((ds.Tables[0].Rows.Count >0)) 
                          { %> 
                     <tr>
                     <th>1</th>
                    
                     <th>&#2350;&#2358;&#2368;&#2344; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span> </th>
                    
                    <th>
                        
 
                        <%=ds.Tables[0].Rows[0]["Capacity1"].ToString () %></th>
                         
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity2"].ToString () %></th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity3"].ToString () %></th>
                     </tr>

                     <tr>
                     <th>2</th>
                    
                     <th>&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span></th>
                    
                    <th>
                       <%=ds.Tables[0].Rows[0]["Capacity4"].ToString () %></th>
                    <th>
                       <%=ds.Tables[0].Rows[0]["Capacity5"].ToString () %></th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity6"].ToString () %></th>
                     </tr>

                     <tr>
                     <th>3</th>
                    
                     <th> <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span> &#2325;&#2366; 20 &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>
                    
                    <th>
                        <%=ds.Tables[0].Rows[0]["cap20pertwo"].ToString () %></th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["cap20perFour"].ToString () %></th>
                    <th><%=ds.Tables[0].Rows[0]["cap20persheet"].ToString () %> 
                        </th>
                     </tr>

                     <tr>
                     <th>4</th>
                    
                     <th>&#2357;&#2367;&#2354;&#2350;&#2381;&#2348; &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; (&#2335;&#2344; &#2350;&#2375;&#2306;)</th>
                    
                    <th>
                         
                        <%=ds.Tables[0].Rows[0]["Capacity7"].ToString () %> 
                        
                    </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity8"].ToString () %> </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity9"].ToString () %> </th>
                     </tr>

                     <tr>
                     <th>5</th>
                    
                     <th>&#2325;&#2366;&#2352;&#2381;&#2351; &#2357;&#2367;&#2337;&#2381;&#2352;&#2366;</th>
                    
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity10"].ToString () %> </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity11"].ToString () %> </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity12"].ToString () %> </th>
                     </tr>

                     <tr>
                     <th>6</th>
                    
                     <th>&#2357;&#2367;&#2337;&#2381;&#2352;&#2366; &#2325;&#2368; &#2342;&#2379;&#2327;&#2369;&#2344;&#2368; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;<span class="Apple-converted-space">&nbsp;</span></span></th>
                    
                     <th>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["wdrawtwo"])) %> </th>
                    <th>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["wdrawFour"])) %> </th>
                    <th>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["wdrawSheet"])) %> </th>
                     </tr>
    
                     <tr>
                     <th>7</th>
                    
                     <th>&#2357;&#2367;&#2337;&#2381;&#2352;&#2366; &#2325;&#2366;&#2352;&#2381;&#2351; &#2325;&#2366; &#2342;&#2369;&#2327;&#2344;&#2366; &#2309;&#2341;&#2357;&#2366; &#2408;&#2406; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; &#2332;&#2379; &#2309;&#2343;&#2367;&#2325; &#2361;&#2379; </th>
                    
                    <th><%--<%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity10"])*2)>0) 
                          {%>
                        <%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity10"])*2)>Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity120"])) 
                          {%>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity10"])*2) %>
                        <%}else 
                          { %>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity120"]) %>
                        <%} %>
                        <%}else 
                          { %>
                        0
                        <%} %>--%>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity13"]) %>

                       </th>
                    <th>
                           <%--<%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity11"])*2)>0) 
                          {%>
                        <%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity11"])*2)>Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity220"])) 
                          {%>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity11"])*2) %>
                        <%}else 
                          { %>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity220"]) %>
                        <%} %>
                              <%}else 
                          { %>
                        0
                        <%} %>--%>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity14"]) %>
                         </th>
                    <th>
                        <%--<%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity12"])*2)>0) 
                          {%>
                        <%if ((Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity12"])*2)>Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity320"])) 
                          {%>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity12"])*2) %>
                        <%}else 
                          { %>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity320"]) %>
                        <%} %>
                         <%}else 
                          { %>
                        0
                        <%} %>--%>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["Capacity15"]) %>
                         </th>
                     </tr>

                     <tr>
                     <th>8</th>
                    
                     <th>&#2309;&#2343;&#2367;&#2325;&#2340;&#2350; &#2357;&#2352;&#2381;&#2325; &#2350;&#2375;&#2306;&#2344; &#2325;&#2368; &#2358;&#2366;&#2360;&#2381;&#2340;&#2367; </th>
                    
                   <th>
                        <%=ds.Tables[0].Rows[0]["Capacity16"].ToString () %> </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity17"].ToString () %> </th>
                    <th>
                        <%=ds.Tables[0].Rows[0]["Capacity18"].ToString () %> </th>
                     </tr>

                     <tr>
                     <th>9</th>
                    
                     <th>&#2325;&#2369;&#2354; &#2325;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;</span></th>
                    
                   <th>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["totalreduce2"]) %> </th>
                    <th>
                         <%=Convert.ToInt32(ds.Tables[0].Rows[0]["totalreduce4"]) %> </th>
                    <th>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["totalreducesheet"]) %>  </th>
                     </tr>

                     <tr>
                     <th>10</th>
                    
                     <th>&#2358;&#2375;&#2359; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366; (2-9)</span></th>
                    
                     
                   <th>
                        <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["totavailable2"])) %> </th>
                    <th>
                         <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["totavailable4"])) %></th>
                    <th>
                         <%=(Convert.ToInt32(ds.Tables[0].Rows[0]["totavailablesheet"])) %>  </th>
                     </tr>

                    

                     <tr>
                     <th>11</th>
                    
                     <th>&#2357;&#2367;&#2330;&#2366;&#2352; &#2350;&#2375;&#2306; &#2354;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; <span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 15px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(241, 241, 241);">&#2325;&#2381;&#2359;&#2350;&#2340;&#2366;</span></th>
                    
                    <th>
                       <%=Convert.ToInt32(ds.Tables[0].Rows[0]["fintotavailable2"]) %></th>
                    <th>
                       <%=Convert.ToInt32(ds.Tables[0].Rows[0]["fintotavailable4"])%></th>
                    <th>
                        <%=Convert.ToInt32(ds.Tables[0].Rows[0]["fintotavailablesheet"])%></th>
                     </tr>
     <%}
                        %>
                     </table>
                            
                     </div>
                         </asp:panel>
                     </div> </div></div>
</asp:Content>

