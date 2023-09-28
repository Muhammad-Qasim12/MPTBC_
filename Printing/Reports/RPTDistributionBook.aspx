<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTDistributionBook.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span><%--Distribution of Books--%> </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>वित्तीय सत्र   </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>प्रिंटर का नाम </td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="M/s R.K.Printers"></asp:ListItem><asp:ListItem Text="M/s Hiteck Printers"></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
   
    
  
    
    
   
                            
                          
     <table class="tab">
                        <tr>
                        <th>
                                SNo.  </th>
                           
                           <th  style="text-align:center ">
                                Supl.PO & Distribution ORD.  </th>
                            <th  style="text-align:center ">
                                Name of Book  </th>
                           
                            <th  style="text-align:center ">
                               BPL</th>
                                 <th  style="text-align:center "  >
                              HSD </th>
                                <th  style="text-align:center " >
                                IND</th>
                            <th   style="text-align:center ">
                                UJN </th>
                                 <th    style="text-align:center ">
                             GWL </th>
                           <th    style="text-align:center ">
                               GUNA</th>
                               <th    style="text-align:center ">
                              JBL</th>
                               <th    style="text-align:center ">
                              SEONI</th>
                               <th    style="text-align:center ">
                              SHAHDOL</th>
                               <th    style="text-align:center ">
                              TOTAL(QTY)</th>
                                
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
                            
                            <td style="text-align:center ">5
                            </td>
                            <td style="text-align:center ">6
                            </td>
                            <td style="text-align:center ">7
                            </td>
                                <td style="text-align:center ">8
                            </td>
                                <td style="text-align:center ">9
                            </td>
                                <td style="text-align:center ">10
                            </td>
                              <td style="text-align:center ">11
                            </td>
                                <td style="text-align:center ">12
                            </td>
                                <td style="text-align:center ">13
                            </td>
                        </tr>
                        
                         <tr >
                            <td rowspan="2" style="text-align:center "  >1
                            </td>
                            
                            <td style="text-align:center ">DIST.ORD.
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
                              <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                        </tr>
                        <tr>
                           
                            <td style="text-align:center ">SUPPLY
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
                              <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" style="text-align:center "  >2
                            </td>
                            <td style="text-align:center "> DIST.ORD
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
                              <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center ">
                            </td>
                        </tr>
                      <tr>
                            
                            <td style="text-align:center ">SUPPLY
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
                              <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                                <td style="text-align:center "> 
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="12" >
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

