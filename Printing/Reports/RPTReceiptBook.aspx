<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTReceiptBook.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span> Receipt of Books  </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>Academic Year    </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>Name of the Printer</td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="M/s R.K.Printers"></asp:ListItem><asp:ListItem Text="M/s Hiteck Printers"></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
    <tr>
    
  <td>Print Order No</td>
    <td><asp:DropDownList runat="server" ID="DropDownList2"><asp:ListItem Text="001"></asp:ListItem><asp:ListItem Text="002"></asp:ListItem></asp:DropDownList></td>
    
    <td></td>
    <td></td>
    
    
    </tr>
    
  
    
    
    <td>
                            
                            </td>
     <table class="tab">
                        <tr>
                            <th>
                                Quantity Recevied  </th>
                           
                            <th>
                                Name of Depot </th>
                                 <th>
                                Date of Receipt </th>
                            <th>
                                Depot Expenditure</th>
                          
                                <th>
                                Unsaleable Books </th>
                           <th>
                                File Page No </th>
                                 <th>
                               Remarks</th>
                        </tr>
                        <tr>
                            <td>1
                            </td>
                            <td>2
                            </td>
                            <td>3
                            </td>
                            <td>4
                            </td>
                            <td>5
                            </td>
                            <td>6
                            </td>
                            <td>7
                            </td>
                           
                        </tr>
                        <tr>
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
                            <td>
                            <asp:Button runat="server" ID="Button1" Text="Print " CssClass="btn" />
                            </td>
                            <td>
                             
                           
                            </td>
                            <td>
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

