<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTPrintgworkdet.aspx.cs" Inherits="TenderDetail" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
 <div class="card-header">
 <h2><span>पेपर आवंटन/ प्रिंटिंग कागज की मात्रा की जानकारी </span></h2>
</div>
    <div style="padding:0 10px;">
    
    <table width="100%">
     <tr>
    <td>शेक्षणिक सत्र     </td>
    <td><asp:DropDownList runat="server" ID="ddlac"><asp:ListItem Text="2014-2015"></asp:ListItem></asp:DropDownList></td>
   <td>मुद्रणालय का नाम </td>
    <td><asp:DropDownList runat="server" ID="DropDownList1"><asp:ListItem Text="मेसर्स दी सेन्ट्रल प्रेस "></asp:ListItem><asp:ListItem Text="मेसर्स राजीव  प्रेस "></asp:ListItem></asp:DropDownList></td>
    
   
    </tr>
    
    
 
    
    
    <td>
                            
                            </td>
     <table class="tab">
                        <tr>
                         <th> क्रमाक 
                                  </th>
                            <th> पुस्तक का नाम 
                                  </th>
                           
                            <th>
                                प्रष्ठ संख्या  </th>
                                 <th colspan="2" >
                                मुद्रण संख्या  </th>
                               
                            <th>
                                आवंटित संख्या </th>
                          
                                <th>
                               दर प्रति एक हज़ार फॉर्म (रुपये में)  </th>
                           <th>
                                लगनेवाले मुद्रण कागज की  मात्रा  </th>
                                 <th>
                               लगनेवाले कवर कागज की  मात्रा</th>
                        </tr>
                         <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>सामान्य 
                            </td>
                            <td>योजना 
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
                            <td>1 
                            </td>  
                            <td>सहायक वाचन - 8(J)
                            </td>
                            <td>164 
                            </td>
                            <td> 3360
                            </td>
                            <td>190960
                            </td>
                            <td>194320
                            </td>
                            <td>
                            </td>
                            <td>80.625
                            </td>
                            <td>49552
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
                            <td>Total
                            </td>
                             <td>80.625
                            </td>
                            <td>49552
                            </td>
                           
                        </tr>
                        
                        <tr>
                            <td colspan="8" >
                            <asp:Button runat="server" ID="Button1" Text="प्रिंट करे " CssClass="btn" />
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

