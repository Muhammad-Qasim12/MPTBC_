<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTDepoExpenditure.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>Depot Expenditure on Behalf of Printer </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>वित्तीय सत्र  </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>प्रिंटर का नाम </td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="M/s R.K.Printers"></asp:ListItem><asp:ListItem Text="M/s Hiteck Printers"></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
   
    
  
    
    <tr>
    <td colspan="4">
    <table class="tab">
                        <tr>
                        <th>
                               A  </th>
                           
                           
                            <th  style="text-align:left  ">
                                Total Depot Expenditure as per Depot 100% Receipt(Rs)  </th>
                           
                            <th  style="text-align:center ">
                                </th>
                                
                          
                                
                        </tr>
                        <tr>
                            <th>
                               B  </th>
                           
                           
                            <th  style="text-align:left ">
                                Total Depot Expenditure already Deducted in current payments(Rs)  </th>
                           
                            <th  style="text-align:center ">
                                </th>
                          
                           
                        </tr>
                        
                         <tr>
                             <th>
                               C  </th>
                           
                           
                            <th  style="text-align:left ">
                                Depot Expenditure proposed for deduction in final A/c (A-B)(Rs)  </th>
                           
                            <th  style="text-align:center ">
                                </th>
                          
                           
                        </tr>
                         
                         
                         
                        <tr>
                            <td colspan="8" >
                            <asp:Button runat="server" ID="Button1" Text="Print " CssClass="btn" />
                            </td>
                             
                          
                        </tr>
                    </table>
    </td>
    </tr>
     
   
    
    
    
    
    
    
    
    
   
    
    </table>
   
    
    
       </div> 

   <script type="text/javascript">
     function show(){document.getElementById('GroupDiv').style.display="block";}
     
     </script>
</asp:Content>

