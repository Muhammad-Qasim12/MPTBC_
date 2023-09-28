<%@ Page Title="Checkbox Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI001_CheckboxDetails.aspx.cs" Inherits="Printing_PRI001_CheckboxDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="portlet-header ui-widget-header">चेकलिस्ट की जानकारी </div>
                    <div class="box table-responsive">
   <div>
   
   
                        <asp:Panel ID="pnlChk" runat="server">
                            <div>
                                <asp:HiddenField runat="server" ID="HdnRegChkLSTID_I" Value="0" />
                            </div>
                            <table>
                                <tr>
                                    <td >
                                        
                                        <asp:CheckBox ID="chkRegAmount" runat="server" Text="पंजियन शुल्क रुपये 250/- क्रॉस्ड बैंक ड्राफ्ट (अहस्ताक्षरित) प्रबंध संचालक ,म.प्र. पाठ्यपुस्तक निगम , भोपाल नाम से |" />
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkPressActCert" runat="server" Text="प्रेस एक्ट के अंतर्गत जिला दंडाधिकारी (...................) के समक्ष दिए गए घोषणा पत्र की उनके प्रमाणीकरण सहित सत्य प्रतिलिपि |" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkIncomeTaxClearance" runat="server" Text="इनकम टैक्स क्लीयरेंस के अपटूडेट सर्टिफिकेट की प्रतिलिपि |" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkLastThreeYrsPrinting" runat="server" Text="मुद्रणालय द्वारा पिछले तीनो वर्षों मे मुद्रित की गई कम से कम 5 पुस्तके |" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkMacPurcBillCopy" runat="server" Text="मशीनों के बिलों की छाया प्रतिया |" />
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkInsurance" runat="server" Text="मुद्रणालय के बीमा सम्बन्धी दस्तावेज की छाया प्रति |" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkOther" Text="अन्य" runat="server" onchange="ShowHide('ct100_ContentPlaceHolder1_chkOther','Divtxt');" />
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="Divtxt" style="display: none;">
                                            <asp:TextBox ID="txtOtherDet" runat="server" onkeypress="MaxLengthCount(this,200);tbx_fnAlphaNumericOnly(event, this);" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlChkWithOffset" runat="server">
                            <table>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkProcessCamera" runat="server" Text="प्रोसेस कैमरा 24''X24''1 (एक)" />
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkPlateMat" runat="server" Text="प्लेट बनाने के समस्त साधन" />
                             
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkSingleCallOffset" runat="server" Text="सिंगल कलर आफसेट मशीन, साइज़ 18'' X 24'' या उससे बड़ा -1-(एक)" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:CheckBox ID="chkBindingFacility" runat="server" Text="बीन्डिंग का उपयुक्त व्यवस्था" />
                                     
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text=" सुरक्षित करे / Save  " />
                          
               <asp:Button ID="BtnBack" runat="server" Text="वापस जाये / Back" CssClass="btn"  OnClick ="BtnBack_Click" />
                                
   
   
   
   
   </div>

   </div> 


   <script type="text/javascript">


       function ShowHide(chk, div) {
           var checkbox = document.getElementById(chk);
           var dropdown = document.getElementById(div);



           if (checkbox.checked == true) {
               dropdown.style.display = "block";
           }
           else { dropdown.style.display = "none"; }

           
           
           function MaxLengthCount(txt, MaxLen) {
               var txtBox = document.getElementById(txt);
               var len = MaxLen;


               if (txtBox.value.length > len) {

                   txtBox.value = txtBox.value.substring(0, len);
                   alert("Charactor length is Exeed from " + len);



               }
               else { }

           }

          
       }
   
    </script>

   

</asp:Content>

