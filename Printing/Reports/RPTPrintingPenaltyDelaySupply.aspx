<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPrintingPenaltyDelaySupply.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>Penalty  for Delay Supply of Books </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>Academic Year    </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>Name of the Printer</td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="M/s R.K.Printers"></asp:ListItem><asp:ListItem Text="M/s Hiteck Printers"></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
   
    
  
    
    
   
                            
                          
     <table class="tab">
                        <tr>
                        <th>
                                SNo.  </th>
                           
                           
                            <th  style="text-align:center ">
                                Name of Book  </th>
                           
                            <th  style="text-align:center ">
                                Due Date </th>
                                 <th  style="text-align:center "  >
                              Reason  </th>
                                <th colspan="2" style="text-align:center " >
                                Receipt of Books</th>
                            <th   style="text-align:center ">
                                Delay in Number of Days </th>
                                
                           <th    style="text-align:center ">
                               Total % of Penalty </th>
                               <th    style="text-align:center ">
                              100% Printing Charges </th>
                               <th    style="text-align:center ">
                               Amount of Penalty </th>
                                
                        </tr>
                        <tr>
                            <td  style="text-align:center "  >
                            </td>
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">Qty
                            </td>
                            <td style="text-align:center ">Date
                            </td>
                            <td style="text-align:center "> 
                            </td>
                            <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                               
                           
                        </tr>
                          <tr>
                            <td  style="text-align:center "  >1
                            </td>
                            <td style="text-align:center ">2
                            </td >
                            <td style="text-align:center ">3
                            </td >
                            <td style="text-align:center ">4
                            </td>
                            
                            <td colspan="2" style  ="text-align:center">5
                            </td>
                            
                            <td style="text-align:center ">6
                            </td>
                            <td style="text-align:center ">7
                            </td>
                                <td style="text-align:center ">8
                            </td>
                                <td style="text-align:center ">9
                            </td>
                               
                           
                        </tr>
                        
                         <tr>
                            <td  style="text-align:center "  >
                            </td>
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                               
                           
                        </tr>
                        <tr>
                            <td  style="text-align:center "  >
                            </td>
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                               
                           
                        </tr>
                        <tr>
                            <td  style="text-align:center "  >
                            </td>
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                               
                           
                        </tr>
                    <tr>
                            <td  style="text-align:center "  >
                            </td>
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                            <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                                <td style="text-align:center ">
                            </td>
                               
                           
                        </tr>
                        
                        <tr>
                            <td colspan="9" >
                            <asp:Button runat="server" ID="Button1" Text="Print " CssClass="btn" />
                            </td>
                             <td>
                            </td>
                           
                          
                        </tr>
                    </table>
   
    
    
    
    
    
    
    
    
   
    
    </table>
   
    
    
       </div> 

   <script type="text/javascript">
     function show(){document.getElementById('GroupDiv').style.display="block";}
     
     </script>
</asp:Content>

