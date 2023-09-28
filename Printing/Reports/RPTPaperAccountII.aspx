<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPaperAccountII.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>Paper Account II </span></h2>
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
                        <th>
                                SNo.  </th>
                           
                           
                            <th  style="text-align:center ">
                                Description  </th>
                           
                            <th  style="text-align:center ">
                                84 cm Reel Paper (in Ton)</th>
                                 <th  style="text-align:center "  >
                              64 X 86.5 cm <br /> (24" X 34") <br /> Cover Paper </th>
                                <th  style="text-align:center " >
                               58.5 X 84 cm <br /> (23" X 33") <br /> Ream</th>
                          
                                
                        </tr>
                        <tr>
                            <td  style="text-align:center "  >1
                            </td>
                            <td style="text-align:Left ">Total supply of paper & cover paper
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                          
                           
                        </tr>
                        
                         <tr>
                            <td  style="text-align:center "  >2
                            </td>
                            <td style="text-align:Left ">Total consumption of paper / cover paper
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                          
                           
                        </tr>
                         <tr>
                            <td  style="text-align:center "  >3
                            </td>
                            <td style="text-align:Left ">Total balance of paper / cover paper 
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                          
                           
                        </tr>
                         <tr>
                            <td  style="text-align:center "  >4
                            </td>
                            <td style="text-align:Left ">Rate of Paper / Cover paper
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                          
                           
                        </tr>
                         <tr>
                            <td  style="text-align:center "  >5
                            </td>
                            <td style="text-align:Left ">Cost of paper / cover paper which is balance with printer and not returned
                            </td >
                            <td style="text-align:center ">
                            </td >
                            <td style="text-align:center ">
                            </td>
                            
                            <td style="text-align:center ">
                            </td>
                          
                           
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

