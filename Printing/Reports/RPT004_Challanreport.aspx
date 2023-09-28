<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT004_Challanreport.aspx.cs" Inherits="Printing_Reports_RPT004_Challanreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">
 प्रिंटर चालान की जानकारी / Printer Challan Details
 </div>
        <div class="portlet-content">



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

            प्रिंटर चालान की जानकारी
         </div>
                  </td>
                  </tr>
 <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">
          <asp:Label ID="lblTitle" runat="server" ></asp:Label></div>
          </td></tr>
                 <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" >

        <asp:GridView runat="server" ID="GrdChallan" AutoGenerateColumns="False" 
                CssClass="tab hastable" >
        <Columns>
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ <br> SNo."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="डिपो का नाम / <br> Depot Name"><ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="चालान क्रमांक / <br> Challan No."><ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="चालान दिनांक / <br> Challan Date"><ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक का नाम / <br> Textbook Name "><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक संख्या (सामान्य ) / <br> No of Books (General)"><ItemTemplate><%# Eval("TotalNoOfBooks")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक संख्या (योजना ) / <br> No of Books (Scheme) "><ItemTemplate><%# Eval("TotalNoOfBooksYoj")%></ItemTemplate></asp:TemplateField>
        
       


        <asp:TemplateField>
        <ItemTemplate>
        <a href="PRIN001_ChallanDetails.aspx?Cid=<%# Eval("PriTransID") %>" >&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; </a>
        </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
        </asp:GridView>
        </td>
        </tr>


        <tr>
        <td>
        <asp:Button runat="server" ID="btnExport" CssClass="btn_gry " Text="Export to Excel" />
        </td>
        </tr>
        
        </table>


        </div> 

</asp:Content>

