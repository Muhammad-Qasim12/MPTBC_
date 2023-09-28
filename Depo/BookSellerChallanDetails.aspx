<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerChallanDetails.aspx.cs" Inherits="Depo_BookSellerChallanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
        <table width="100%">
            
                         <asp:Button ID="Button1" runat="server" Text="&#2350;&#2369;&#2326;&#2381;&#2351; &#2346;&#2371;&#2359;&#2381;&#2336; &#2346;&#2352; &#2332;&#2366;&#2351;&#2375; " CssClass="btn" OnClick="Button1_Click" Visible="False" />
                        
        <tr id="ar" runat="server" >
                    <td style="text-align: left">
                       Select Book Seller 
                    </td> <td><asp:DropDownList ID="ddlBookSllerName" runat="server" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlBookSllerName_SelectedIndexChanged"></asp:DropDownList> </td>
            <td>Challan NO </td><td><asp:DropDownList ID="DropDownList1" runat="server" 
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" 
                           ></asp:DropDownList></td>

                </tr>
        <tr>
                    <td style="text-align: left" colspan="4">
                       
                        
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false" >
                            <div id="ExportDiv" runat="server">  
                            <table Width="100%">
                                <tr>
                                    <td colspan="7">

  <center>
                                      <b> M.P.TEXT BOOK CORPORATION</b> <br /> 
                                        <br />
                                      <b>  <asp:Label ID="lblDepoName" runat="server" Text="Label"></asp:Label></b> <br /> <br />
      &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :&nbsp;&nbsp;
      <asp:Label ID="lblFYear" runat="server"></asp:Label>
      
      <asp:Label ID="lblCurrentDate" runat="server" Visible="false"></asp:Label>
                                       <br /><br /> </center></td>
                                </tr>
                               
                                <tr>
                                    <td><%=ddlBookSllerName.SelectedItem.Text %></td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352;/Reg.No <%=book.Tables[0].Rows[0]["RegistrationNo_V"].ToString ()%></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2344;&#2306;&#2348;&#2352; /Cash Memo No <%=book1.Tables[0].Rows[0]["ChallanNo_V"].ToString ()%></td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Date <%=book1.Tables[0].Rows[0]["OrderDate_D"].ToString ()%></td>
                                </tr>
                                <tr>
                                    <td>&#2348;&#2376;&#2306;&#2325; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2344;&#2306;&#2348;&#2352; /Bank Draft No <%=book.Tables[0].Rows[0]["DDNouber"].ToString ()%></td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Bank Name <%=book.Tables[0].Rows[0]["BankName"].ToString ()%></td>
                                </tr>
                                <tr>
                                    <td>&#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; /Draft Amount <%=book.Tables[0].Rows[0]["TotalRate"].ToString ()%></td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="&#2346;&#2367;&#2331;&#2354;&#2366; &#2348;&#2330;&#2368; &#2352;&#2366;&#2358;&#2367;" Visible="False"></asp:Label>
                                        &nbsp; :
                                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table Width="100%" border="2" class="tab">
                                <tr>
                                    <th>&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Sr.No</th>
                                    <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Name of Book</th>
                                    <th>&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; /Bundle Details</th>
                                    <th>&#2335;&#2379;&#2335;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/No of Book </th>
                                    <th>&#2352;&#2375;&#2335; /Rate (Rs)</th>
                                    <th>&#2352;&#2366;&#2358;&#2368;/Amount (Rs)</th>
                                </tr>
                                <tr><% HidDraftAmount.Value = Convert.ToString(book.Tables[0].Rows[0]["TotalRate"]);
                                        for (int i = 0; i < book1.Tables[0].Rows.Count; i++)
                                       {
                                           j = j + 1;
                                           totalrate = Convert.ToDouble(book1.Tables[0].Rows[i]["NOOfBooks"]) * Convert.ToDouble(book1.Tables[0].Rows[i]["Rate_N"]);
                                      totalAllAmount=totalAllAmount+totalrate;
                                          // , totalRate, totalAllAmount;
                                      totalRate = totalRate + Convert.ToDouble(book1.Tables[0].Rows[i]["Rate_N"]);
                                           tatalbook=tatalbook+Convert.ToDouble (book1.Tables[0].Rows[i]["NOOfBooks"]);
                                             %>
                                    <td><%=j%></td>
                                    <td><%=book1.Tables[0].Rows[i]["Title"].ToString ()%></td>
                                    <td>
                                        
                                      <%-- &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; : <%=book1.Tables[0].Rows[i]["BundleNo_I"].ToString () %>
                                        ,&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;.(<%=book1.Tables[0].Rows[i]["RemaingLoose_V"].ToString () %>)--%></td>
                                    <td><%=book1.Tables[0].Rows[i]["NOOfBooks"].ToString ()%></td>
                                    <td><%=book1.Tables[0].Rows[i]["Rate_N"].ToString ()%></td>
                                    <td><%=totalrate%></td>
                                </tr><%}
                                         hdNetAmount.Value =Convert.ToString(totalAllAmount);
                                         HdCommisionAmount.Value =Convert.ToString ((totalAllAmount * Categorya) / 100);
                                       %>
                                <tr>
                                    <td colspan="3"></td>
                                    <td><%=tatalbook %></td>
                                    <td><%=totalRate%></td>
                                    <td><%=totalAllAmount %></td>
                                </tr>
                                <tr>
                                    <td colspan="6"> 
                                        <table cellpadding="10" cellspacing="10" width="100%">
                                            <tr>
                                                <td>&#2360;&#2325;&#2354; &#2352;&#2366;&#2358;&#2367; /Gross Amount (Rs.)</td>
                                                <td><%=totalAllAmount %></td>
                                                <td>&#2348;&#2376;&#2306;&#2325; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2352;&#2366;&#2358;&#2367; /Draft Amount (Rs.)</td>
                                                <td><%=Convert.ToDecimal(book.Tables[0].Rows[0]["TotalRate"])+Convert.ToDecimal (Label2.Text)%></td>
                                            </tr>
                                            <tr>
                                                <td>&#2331;&#2370;&#2335; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; /Commission Amount (Rs)</td>
                                                <td><%=(totalAllAmount*Categorya)/100%></td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;/Net Amount (Rs)</td>
                                                <td><%=totalAllAmount-((totalAllAmount*Categorya)/100)%></td>
                                                <td>&#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2367;/Net Balance (Rs) </td>
                                                <td><%=((Convert.ToDouble(book.Tables[0].Rows[0]["TotalRate"])+ Convert.ToDouble(Label2.Text)+((totalAllAmount*Categorya)/100))-totalAllAmount)%></td>
                                            </tr>
                                            <tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr><tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr><tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Receiver Sign</td>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style1">StoreKeeper Sign</td>
                                                <td class="auto-style1"></td>
                                            </tr>
                                            <tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td> </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Depot Manager </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table></div> 
                        </asp:Panel>
                       
                         <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                                OnClientClick="return PrintPanel();" Text="&#2348;&#2367;&#2354; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; "  />

                        <asp:HiddenField ID="HidDraftAmount" runat="server" />
                        <asp:HiddenField ID="HdCommisionAmount" runat="server" />
                        <asp:HiddenField ID="hdNetAmount" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td> 

                </tr>
    
                </table>
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

