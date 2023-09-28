<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPrintingcharges.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
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
                        <th>
                                SNo.  </th>
                           
                           
                            <th  style="text-align:center ">
                                Name of Book  </th>
                           
                            <th  style="text-align:center ">
                                Quantity of Total Supply</th>
                                 <th  style="text-align:center " colspan="2">
                                No of Pages & Rate in Paise </th>
                                <th  style="text-align:center " >
                                Amount of 100% PTG. Charges</th>
                            <th colspan="3"  style="text-align:center ">
                                Consumption of Paper</th>
                          
                                
                        </tr>
                        <tr>
                            <td  style="text-align:center "  ><br /><br />1
                            </td>
                            <td style="text-align:center "><br /><br />2
                            </td >
                            <td style="text-align:center "><br /><br />3
                            </td >
                            <td style="text-align:center " colspan="2"><br /><br />4
                            </td>
                            
                            <td style="text-align:center "><br /><br />5
                            </td>
                            <td style="text-align:center ">Reel in Ton <br /><br />6
                            </td>
                            <td style="text-align:center ">Cover Paper in Sheets <br /><br />7
                            </td>
                            <td style="text-align:center ">23" X 33" <br /> (58.5 X 84 cm) <br /> 8
                            </td>
                           
                        </tr>
                        
                         <tr>
                            <td>1
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                           
                        </tr>
                         <tr>
                            <td>2
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                           
                        </tr>
                         <tr>
                            <td>3
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
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

