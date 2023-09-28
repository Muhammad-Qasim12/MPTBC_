<%@ Page Title="Bill Details" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PRI008_FinalBillDetails.aspx.cs" Inherits="PRI008_FinalBillDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="upPnale" runat="server">
                        <ContentTemplate>
    
    <div class="portlet-header ui-widget-header">
        &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</div>
    
    <div class="portlet-content">
        <table>
            <tr>
                 
            <td>
                <asp:Label ID="LblAcYear" runat="server" Width="200px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                </asp:DropDownList></td>               
            </tr>
        </table>
        <asp:Panel runat="server" ID="pnlMain">
           
             <div style="padding: 10px; font-weight:bold;text-align:center;font-size:19px;">                    
                         VOUCHER   
                  <br /><asp:Label ID="lblMsg" runat="server">FINAL PAYMENT FOR THE YEAR 2017-2018</asp:Label>
                 <asp:Label ID="HDNRedirect" runat="server" Value="" Visible="false" />
                </div>      

            <asp:Panel runat="server" ID="pnlBillDetail" GroupingText="Printer Bill Details"
                Width="1200px">
                <table width="100%">
                   
                    <tr>
                        <td>
                            Name of Printer M/s</td>
                        <td>
                            <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                 </asp:DropDownList>
                        </td>
                       
                    </tr>                  

                     <tr>
                        <td>Name of Book </td>
                        <td>
                            <asp:Label runat="server" ID="Label1" Visible="False"></asp:Label>
                        </td>
                        
                    </tr>

                     <tr>
                        <td>(1) Balance of Printing Charges</td>                         
                        <td><b>Rs.</b>
                            <asp:Label runat="server" ID="Label6" ></asp:Label>
                        </td>
                        
                    </tr>

                    <tr>
                        <td>(2) Balance of Paper Security</td>
                        <td><b>Rs.</b>
                            <asp:Label runat="server" ID="Label2" ></asp:Label>
                        </td>
                        
                    </tr>

                       <tr>
                        <td>(3) Balance Security</td>
                        <td><b>Rs.</b>
                            <asp:Label runat="server" ID="Label3" ></asp:Label>
                        </td>
                    </tr>

                       <tr>
                        <td align="center"><b>Total</b></td>
                       <td><b>Rs.</b>
                            <asp:Label runat="server" ID="Label7"></asp:Label>
                           <span style="font-weight:bold;margin-left:20px;">(A)</span>
                        </td>
                        
                    </tr>

                </table>
            </asp:Panel>
            
            <asp:Panel runat="server" ID="Panel2" GroupingText="DEDUCTIONS" style="font-size:13px;" Width="1200px">
                <table width="100%">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            (1) Penalty for substandard bad Printing
                        </td>
                         <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox1" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" 
                                 >0</asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="3">
                            (2) Penalty for mistakes
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox2" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox2_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>
                     <tr>
                        <td colspan="3">
                            (3) Penalty for delay submission of Proof
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox3" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox3_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                        <td colspan="3">
                            (4) Penalty for Delay supply of Books
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox4" CssClass="txtbox reqirerd"
                             MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox4_TextChanged" 
                                >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     
                     <tr>
                        <td colspan="3">
                            (5) Depot Expenditure on behalf of Printers
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox5" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox5_TextChanged" 
                                >0</asp:TextBox>
                        </td>
                        
                    </tr>

                    <tr>
                        <td colspan="3">
                            (6) Cost of not Salable Books
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox6" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox6_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                        <td colspan="3">
                            (7) Deductions against balance paper with printer
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox7" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox7_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                        <td colspan="3">
                            (8) 2% Income Tax on Rs....................
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox8" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox8_TextChanged" 
                                >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                        <td colspan="3">
                            (9) Transportation Charges on behalf of printer
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox9" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox9_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                        <td colspan="3">
                            (10) Interest on paper cost security
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox10" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox10_TextChanged" 
                                >0</asp:TextBox>
                        </td>
                        
                    </tr>

                    <tr>
                        <td colspan="3">
                            (11) Other deduction if any
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox11" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" OnTextChanged="TextBox11_TextChanged" 
                               >0</asp:TextBox>
                        </td>
                        
                    </tr>

                    <tr>
                        <td colspan="3">
                            (12) 2% witheld Regarding 100% Printing Charges
                        </td>
                        <td><b>Rs.</b>
                            <asp:TextBox runat="server" ID="TextBox12" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                               OnTextChanged="TextBox12_TextChanged">0</asp:TextBox>
                        </td>
                        
                    </tr>

                     <tr>
                       <td colspan="3" align="center"><b>Total</b></td>
                       <td><b>Rs.</b>
                            <asp:Label runat="server" ID="Label8"></asp:Label>
                           <span style="font-weight:bold;margin-left:20px;">(B)</span>
                        </td>
                       
                    </tr>
                    
                </table>
            </asp:Panel>

             <asp:Panel runat="server" ID="Panel1" style="font-size:13px;" Width="1490px">
            <table width="100%">
                <tr>    <td>
                             <b>Net payable A-B</b>
                        </td>
                        <td>
                            <b>Rs. </b><asp:TextBox runat="server" ID="TextBox13" CssClass="txtbox reqirerd" MaxLength="8"                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txt2PerInComeTAX_TextChanged">0</asp:TextBox>
                        </td>
                       
                    </tr>

                <tr>
                    <td colspan="2">
                     
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save " />
                      <asp:HiddenField ID="hdnID" Value="" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>

            </table>
                 </asp:Panel>
            
           
        </asp:Panel>
        
    </div>
        <asp:Button ID="btnForward" runat="server" CssClass="btn" OnClick="btnForward_Click" Text="Save " Visible="False" />
                            <asp:Button ID="btnBack" runat="server" CssClass="btn" OnClick="btnback_Click" Text="Back " Visible="False" />
        </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    
</asp:Content>

