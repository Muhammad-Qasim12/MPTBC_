<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPrintingchargesPayment.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>Printing Charges Detail </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>Academic Year    </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>Name of the Printer</td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="M/s R.K.Printers"></asp:ListItem><asp:ListItem Text="M/s Hiteck Printers"></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
   
    
  
    
    
    <td>
                            
                            </td>
     <table class="tab">
     
     <tr>
                        <th colspan ="4">
                                Payment Made Against
                           
                           
                             </th>
                                
                          
                                
                        
                            <th  style="text-align:center " colspan ="4"  >
                            Printing Security Deposited
                            </th>
                            
                            
                            
                           
                        </tr>
                        
                        
                        <tr>
                        <th>
                                SNo.  </th>
                           
                           
                            <th  style="text-align:center ">
                                Amount (Rs)  </th>
                           
                            <th  style="text-align:center ">
                                Date</th>
                                 <th  style="text-align:center " >
                                Note Sheet <br />Page No  </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center ">Vide MRNo
                            </th >
                            <th style="text-align:center ">Dated
                            </th >
                            <th style="text-align:center " >Amount (Rs)
                            </th>
                            
                            
                           
                        </tr>
                        
                        <tr>
                        <th>
                                1  </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                        <tr>
                        <th>
                                2  </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                        <tr>
                        <th>
                                3 </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                        
                        
                        <tr>
                        <th>
                                  </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                            Total (Rs) - (A)
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                         
                          <tr>
                        <th>
                                  </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                            Amount Released against Printing Security (Rs) - (B)
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                        
                           <tr>
                        <th>
                                  </th>
                           
                           
                            <th  style="text-align:center ">
                                   </th>
                           
                            <th  style="text-align:center ">
                                 </th>
                                 <th  style="text-align:center " >
                                   </th>
                                
                          
                                
                        
                            <th  style="text-align:center "  >
                            </th>
                            <th style="text-align:center "> 
                            </th >
                            <th style="text-align:center "> 
                           Net Payable (Rs) - (A-B)
                            </th >
                            <th style="text-align:center " > 
                            </th>
                            
                            
                           
                        </tr>
                     
                        
                        <tr>
                            <td colspan="8" >
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

