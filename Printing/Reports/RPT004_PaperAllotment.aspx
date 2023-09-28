<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT004_PaperAllotment.aspx.cs" EnableEventValidation="false" Inherits="Printing_Reports_RPT004_PaperAllotment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
       &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Demand Details
        </div>
        <div class="portlet-content">

        <div class="table-responsive">
        
        <table width="100%">
                            
                            <tr>
                            <td  >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:<asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" 
                            onselectedindexchanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                            </asp:DropDownList>
                                </td>

                            <td  >
                        <asp:Label ID="Medium" runat="server" >Medium Name </asp:Label>
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox" 
                            AutoPostBack="False" onselectedindexchanged="DdlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                            </td>
                            </tr>


                            <tr>
                            <td >&#2337;&#2367;&#2346;&#2379; &#2330;&#2369;&#2344;&#2375; / Depot :  &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp<asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox" 
                            AutoPostBack="False" onselectedindexchanged="DdlDepot_SelectedIndexChanged">
                            <asp:ListItem>select..</asp:ListItem>
                            <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                            <asp:ListItem>&#2349;&#2379;&#2346;&#2366;&#2354;  </asp:ListItem>
                            <asp:ListItem>&#2357;&#2367;&#2342;&#2367;&#2358;&#2366;  </asp:ListItem>
                            <asp:ListItem>&#2352;&#2368;&#2357;&#2366;  </asp:ListItem>
                        </asp:DropDownList>
                                </td>

                            <td>
                        <asp:Label ID="LblClass" runat="server" >&#2325;&#2325;&#2381;&#2359;&#2366; / Class:</asp:Label>
                        <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" 
                            AutoPostBack="False" onselectedindexchanged="DdlClass_SelectedIndexChanged">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
                            </td>
                            </tr>
</table>
 
 <table width="100%">
   
   <tr> <td colspan="7">
   <div runat="server" id = "ExportDiv">  
  


         <table align = "center"  width="100%" >
       <tr><td   colspan="2"  style="text-align:center;font-weight:bold;font-family:Verdana;font-size:18px;" > 
          &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;

           </td></tr>
      <tr>
          <td align = "center"  colspan="2"  style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center> " &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; "</center> 

          </td></tr>

                <tr>
          <td align = "center" colspan="2"   style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center>&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;) 462011</center> 

          </td></tr>
          <tr>
            <td align = "center"  colspan="2""  style="text-align:center;font-family:Verdana;font-size:14px;" >
                 <div style="text-align:center;line-height:1.5">
                 &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727, 2551294, 2551565, &#2347;&#2376;&#2325;&#2381;&#2360; - 2551145, <br />
&#2312;-&#2350;&#2375;&#2354; - infomptbc@mp.gov.in, &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335;- mptbc.nic.in</div>

              </td>

          </tr>
              <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">

             &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
         </div>
                  </td>
                  </tr>
 <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">
          <asp:Label ID="lblTitle" runat="server" ></asp:Label></div>
          </td></tr>
          
                            <tr>

                            <td colspan="2">
                            <asp:GridView ID="gvPapCalculation" runat="server"  AutoGenerateColumns="False"   CssClass="tab" OnRowDataBound="gvPapCalculation_RowDataBound" ShowFooter="True"     >
                                    <Columns>
                                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / SNo &lt;/br&gt; 1">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Title &lt;/br&gt; 2"><ItemTemplate>
                                                 <%# Eval("TitleHindi_V")%>

                                                                                                                    </ItemTemplate></asp:TemplateField>
                                     
                                          <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class &lt;br&gt; 3"><ItemTemplate><%# Eval("cLASSDET_V")%></ItemTemplate></asp:TemplateField>
                                         
                                         
                                          <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages &lt;br&gt; 4"><ItemTemplate><%# Eval("Pages_n")%></ItemTemplate></asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; / Alloted Scheme Book &lt;br&gt; 5">
                                                <ItemTemplate>   <asp:Label ID="L1" runat="server" Text='<%# Eval("noofBookYojna")%>'></asp:Label></ItemTemplate>
                                             
                                            </asp:TemplateField> 
                                       
                                        <asp:TemplateField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; /Alloted General Book &lt;br&gt; 6">
                                            <ItemTemplate>

                                                   <asp:Label ID="L2" runat="server" Text='<%# Eval("noofBookSamana")%>'></asp:Label>
                                            </ItemTemplate></asp:TemplateField> 
                                        

                                         <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;  / Total Allotment Book &lt;br&gt; 7"><ItemTemplate>
                                            <asp:Label ID="L3" runat="server" Text='<%# Eval("totnoofbooks")%>'></asp:Label>

                                                                                                                                          </ItemTemplate></asp:TemplateField> 
                                         
                                          <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; ) /Printing Paper (in TON) &lt;br&gt; 8">
                                              <ItemTemplate >
                                               <asp:Label ID="L4" runat="server" Text='<%# Eval("qty_pripaper")%>'></asp:Label></ItemTemplate>

                                          </asp:TemplateField> 
                       <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) / Cover Paper (in Sheets) &lt;br&gt; 9"><ItemTemplate>
                          
                           <asp:Label ID="L5" runat="server" Text='<%# Eval("qty_Covpaper")%>'></asp:Label>

                                                                                                                                       </ItemTemplate></asp:TemplateField>                    
                                         
                       

                                        	
                                       
                                         
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <EditRowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                </asp:GridView>
                                     
                            </td>
                            </tr> 
                            </table>
                           
                             </div > 
                             </td></tr>
                            <tr>
                            <td colspan="2">
                            
                             <asp:Button ID="btnExport" runat="server" Text="Export to Excel" 
                                    CssClass="btn_gry" onclick="btnExport_Click" />
          </td>
                            </tr>
                            
 </table> 
        
   
        </div>

        </div> 


</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            height: 48px;
        }
    </style>
</asp:Content>


