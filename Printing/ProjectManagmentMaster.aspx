<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectManagmentMaster.aspx.cs" Inherits="Printing_ProjectManagment" Title="Project Managment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box<div class="box table-responsive">">
 <div class="card-header">
 <h2><span><%--Project Management Timeline--%>&#2346;&#2381;&#2352;&#2379;&#2332;&#2375;&#2325;&#2381;&#2335; &#2350;&#2376;&#2344;&#2375;&#2332;&#2350;&#2375;&#2306;&#2335; &#2335;&#2366;&#2311;&#2350;&#2354;&#2366;&#2311;&#2344; </span></h2>
</div>
     <div class="box table-responsive">
     <table width="100%">
        <tr> 
        <td colspan="7" style="height:10px;">
            <asp:HiddenField ID="HdnTimelineTrno_I" runat="server" Value="0" />
        </td>
        </tr>
 
        <tr>
        <th>&#2357;&#2367;&#2357;&#2352;&#2339;</th>
        <td>
        <asp:DropDownList ID="ddlDescription" runat="server" CssClass="txtbox reqirerd" >
         </asp:DropDownList>
        </td>

        <th>&#2335;&#2366;&#2311;&#2350;&#2354;&#2366;&#2311;&#2344;  (&#2342;&#2367;&#2344;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; )</th>
        <td><asp:TextBox runat="server" ID="txtTimeLineDays" CssClass="txtbox reqirerd" Width="100px" ></asp:TextBox></td>

         <th>&#2335;&#2366;&#2311;&#2350; &#2354;&#2366;&#2311;&#2344; &#2325;&#2367;&#2360;&#2360;&#2375; </th>
        <td>
        <asp:DropDownList ID="ddlTimeline" runat="server" CssClass="txtbox reqirerd" >
         </asp:DropDownList>
        </td>

        <td>
        <asp:Button ID="btnSave" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " CssClass="btn" 
                onclick="btnSave_Click" />
        </td>

        </tr>
         
        <tr> 
        <td colspan="7" style="height:10px;"></td>
        </tr>
 
        <tr>
       <td colspan="7">
       
       <div>

        <asp:Panel runat="server" ID="pnlTimeline" ScrollBars="Auto" >
       
       <asp:GridView runat="server" ID="GrdTimeLineDetail" AutoGenerateColumns="false"  CssClass="tab">
       
       <Columns>
       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
       
       <asp:TemplateField HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339;">
       <ItemTemplate>
       <asp:Label ID="lblTimeLineDescription" runat="server" Text='<%# Eval("TimeLineCompName_V") %>'></asp:Label>
       </ItemTemplate>
       </asp:TemplateField>

       <asp:TemplateField HeaderText="&#2335;&#2366;&#2311;&#2350;&#2354;&#2366;&#2311;&#2344;  (&#2342;&#2367;&#2344;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; )">
        <ItemTemplate>
       <asp:Label ID="lblTimeLineDays" runat="server" Text='<%# Eval("TimelineDay_I") %>'></asp:Label>
       </ItemTemplate>
       </asp:TemplateField>

       <asp:TemplateField HeaderText="&#2335;&#2366;&#2311;&#2350; &#2354;&#2366;&#2311;&#2344; &#2325;&#2367;&#2360;&#2360;&#2375; ">
       <ItemTemplate>
       <asp:Label ID="lblTimeLine" runat="server" Text='<%# Eval("MappingCompName") %>'></asp:Label>
       </ItemTemplate>

       </asp:TemplateField>
       </Columns>
        <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />

       </asp:GridView>



        </asp:Panel> 
       </div>
       </td>
 
        </tr>


 </table> 
    
    <div>
    <%--<asp:Panel runat="server" ID="p" ScrollBars="Auto" >
 <table class="tab">
 <tr>
  <th>Description&#2357;&#2367;&#2357;&#2352;&#2339; </th>
 <th>Timeline(No of Days) &#2335;&#2366;&#2311;&#2350;&#2354;&#2366;&#2311;&#2344;  (&#2342;&#2367;&#2344;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; )</th>
 <th>&#2335;&#2366;&#2311;&#2350; &#2354;&#2366;&#2311;&#2344; &#2325;&#2367;&#2360;&#2360;&#2375;   </th>


 </tr>
 
   <tr>
  <td>Issue of Work Order (&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2344;&#2366;) </td>
 <td>
    </td>
 <td></td>
 </tr>
 
 <tr>
 <td>Execution of Agreement(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2366; &#2344;&#2367;&#2352;&#2381;&#2343;&#2366;&#2352;&#2339; )</td>
 <td> <asp:TextBox ID="TextBox5" runat="server">10</asp:TextBox>
     </td>
 <td><asp:TextBox ID="TextBox8" runat="server">Issue of Work Order</asp:TextBox></td>
 </tr>
 
 
 

 
 <tr>
 <td>Lifting of Paper from Godown (&#2327;&#2379;&#2337;&#2366;&#2313;&#2344; &#2360;&#2375; &#2346;&#2375;&#2346;&#2352; &#2313;&#2336;&#2366;&#2344;&#2366; )</td>
 <td><asp:TextBox ID="TextBox7" runat="server">10</asp:TextBox>
     </td>
 <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
 </tr>
 
 
  <tr>
  <td>Submission of Proof(&#2346;&#2381;&#2352;&#2370;&#2347; &#2360;&#2348;&#2350;&#2367;&#2335; &#2325;&#2352;&#2344;&#2366; )</td>
 <td><asp:TextBox ID="TextBox6" runat="server">10</asp:TextBox>
    </td>
 <td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
 </tr>
 
  <tr>
 <td>Print Order(&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; )</td>
 <td><asp:TextBox ID="TextBox4" runat="server">10</asp:TextBox>
    </td>
 <td><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td>
 </tr>
 
  <tr>
<td>Delivery Date of 50% Books(50% &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2337;&#2367;&#2354;&#2357;&#2352;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</td>
 <td><asp:TextBox ID="TextBox1" runat="server">70</asp:TextBox>
     </td>
 <td><asp:TextBox ID="TextBox12" runat="server">Print Order</asp:TextBox></td>
 </tr>
 
 <tr>
 <td>Delivery Date of next 50% Books(&#2309;&#2327;&#2354;&#2368;  50% &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2337;&#2367;&#2354;&#2357;&#2352;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</td>
 <td><asp:TextBox ID="TextBox2" runat="server">50</asp:TextBox>
     </td>
 <td><asp:TextBox ID="TextBox14" runat="server">Delivery Date of 50% Books</asp:TextBox></td>
 </tr>
 
 <tr>
 <td>Return original CD & Approved Proof (&#2323;&#2352;&#2367;&#2332;&#2367;&#2344;&#2354; CD &#2319;&#2357;&#2306; &#2309;&#2346;&#2381;&#2346;&#2381;&#2352;&#2370;&#2357; &#2346;&#2381;&#2352;&#2370;&#2347; &#2325;&#2379; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2344;&#2366; )</td>
 <td><asp:TextBox ID="TextBox3" runat="server">30</asp:TextBox>
    </td>
 <td><asp:TextBox ID="TextBox13" runat="server">Work Completion</asp:TextBox></td>
 </tr>
 <tr>
 <td></td>
 <td> <asp:Button ID="Button2" runat="server" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; " CssClass="btn" />
    </td>
 <td></td>
 </tr>
 
 
 </table> </asp:Panel>--%>
 
    </div>
    
    </div> </div>

</asp:Content>

