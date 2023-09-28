<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRINTERRENEWAL.aspx.cs" Inherits="CentralPaperDepot_CentralPaperDetailst" Title="Printer Renewal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box<div class="box table-responsive">">
        <div class="card-header">
            <h2>
                <span><%--Printer Registration Renewal--%>प्रिंटर रिन्यूअल </span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table style="width: 920px">
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" class="tab">
                            <tr>
                                <th style="width: 100px">
                                   <%--Printer Registration No--%>प्रिंटर रजिस्ट्रेशन क्रमांक </th>
                                <th style="width: 100px">
                                    <%--Registration Date--%> रजिस्ट्रेशन दिनांक 
                                </th>
                                <th style="width: 100px">
                                <%--Name of Printer--%>प्रिंटर का नाम 
                                    </th>
                                <th style="width: 100px">
                                    <%--Full Address--%>प्रिंटर का  पता 
                                </th>
                               <th style="width: 100px">
                                   
                                </th>
                               
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                  R001 </td>
                                <td style="width: 100px">
                                    02/02/2015
                                </td>
                                <td style="width: 100px">
                                     M/s Ajanta Printer</td>
                                <td style="width: 100px">
                                    A4</td>
                               
                                <td style="width: 100px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">रिन्यूअल की जानकारी भरने के लिये क्लिक करे </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
     <div id="Messages" style="display: none; width:50%; left:5%" class="popupnew" runat="server">
        <h2>
            &nbsp;</h2>
         <div style="width:100%">
            <p>
                <table class="tab">
                <tr>
                        <th colspan="3" style="width: 100px">
                           <%--Fill Renewal Detail--%>रिन्यूअल जानकारी
                        </th>
                        
                        
                    </tr>
                    <tr>
                        <th style="width: 100px">
                          <%-- Renewal Date--%>रिन्यूअल दिनांक 
                        </th>
                        <th style="width: 100px">
                            <%--Renewal Fee(Rs)--%>रिन्यूअल राशि (रुपये मे )
                        </th>
                        <th style="width: 100px">
                            <%--Renewal Details--%>रिन्यूअल जानकारी  <br />(DD/chq./Cash)</th>
                            
                             <th style="width: 100px">
                            <%--Renewal Details--%>रिन्यूअल दिनांक से   <br /> </th>
                            <th style="width: 100px">
                            <%--Renewal Details--%>रिन्यूअल दिनांक तक    <br /> </th>
                        
                    </tr>
                    
                    <tr>
                        
                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="txtbox" Width="65px"></asp:TextBox></td>
                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox" Width="65px"></asp:TextBox></td>
                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox" TextMode="MultiLine"
                                Width="156px"></asp:TextBox></td>
                                 <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"  
                                Width="60px"></asp:TextBox></td>
                                 <td style="width: 60px; height: 23px">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"  
                                Width="60px"></asp:TextBox></td>
                    </tr>
                </table>
            </p>
            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="सेव करे " /></div>
    </div>
</asp:Content>

