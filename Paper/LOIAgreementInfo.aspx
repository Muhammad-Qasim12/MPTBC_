<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LOIAgreementInfo.aspx.cs" Inherits="Paper_LOIAgreementInfo" Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2319;&#2354;.&#2323;.&#2310;&#2312;. (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343;) &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of L.O.I.(Agreement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                <%--LOI To. (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2319;&#2354;.&#2323;.&#2310;&#2312;. (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343;) &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of L.O.I.(Agreement)</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--PBG Amount In Rs. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br /> Tender No.
                    </td>
                    <td>
                        <asp:DropDownList CssClass="txtbox reqirerd" runat="server" ID="ddlTenderNo" Width="312px" AutoPostBack="True"
                            OnInit="ddlTenderNo_Init" OnSelectedIndexChanged="ddlTenderNo_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />
Acadmic Year :
                    </td>
                    <td>
                        <asp:Label ID="lblCurrentDt" runat="server" Visible="false"></asp:Label> <asp:Label ID="lblAcYear" runat="server" Visible="False"></asp:Label>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" >	&#2335;&#2375;&#2306;&#2337;&#2352; &#2361;&#2375;&#2340;&#2369; &#2330;&#2366;&#2361;&#2368; &#2327;&#2312; &#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;(&#2350;&#2375;. &#2335;&#2344;)  <br />


                    </td><td colspan="2"> <asp:Label ID="lblQty" runat="server" ></asp:Label> </td>
                </tr>
               
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--Upload LOI (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br /> L.O.I. No.
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLOINo"  onkeypress="javascript:tbx_fnAlphaNumericType1(event, this);"   Width="300px" MaxLength="30" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--LOI To. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;
                        ( &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;)<br /> L.O.I. To
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlVendorLOITo" Width="312px" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorLOITo_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                       &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2346;&#2340;&#2366; <br /> Address Of Paper Mill
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" ReadOnly="true" runat="server" CssClass="txtbox reqirerd" TextMode="MultiLine"
                            Width="300px"></asp:TextBox>
                    </td>
                    <td> &#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367;
                        &#2325;&#2366; &#2344;&#2366;&#2350;<br /> Contact Person </td>
                    <td>  <asp:TextBox ID="txtContactPerson" ReadOnly="true" runat="server" CssClass="txtbox reqirerd" Width="300px"></asp:TextBox> </td>
                </tr>
                
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                      &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2312;-&#2350;&#2375;&#2354; <br /> E-Mail Of Paper Mill
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="txtbox reqirerd" Width="300px"></asp:TextBox>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                      &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;.<br /> Contact No Of Paper Mill
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactNo" ReadOnly="true" runat="server" CssClass="txtbox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; TIN &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; 
                        <br />TIN No Of Paper Mill
                    </td>
                    <td >
                        <asp:TextBox ID="txtVatTaxNo" runat="server" ReadOnly="true" CssClass="txtbox require" Width="300px"></asp:TextBox>
                    </td>
                    <td> <span style="padding-left:5px;color:Red;">*</span>	 
                        &#2350;&#2367;&#2354; &#2325;&#2379; &#2310;&#2348;&#2306;&#2335;&#2367;&#2340; &#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;(&#2350;&#2375;. &#2335;&#2344;)</td>
                    <td>
                         <asp:TextBox ID="txtalloted" runat="server"  CssClass="txtbox require" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                        <%--PBG Amount In Rs. (--%>&#2360;&#2367;&#2325;&#2381;&#2351;&#2370;&#2352;&#2367;&#2335;&#2368; &#2352;&#2366;&#2358;&#2367;
                        (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )<br /> Security Amount
                    </td>
                    <td colspan="1">
                        <asp:TextBox runat="server" ID="txtPBGAmt" MaxLength="10" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'  CssClass="txtbox reqirerd" Width="300px"></asp:TextBox>
                    </td>
                    <td><span style="padding-left:5px;color:Red;">*</span>
                      <%--Upload LOI (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375;<br /> Upload L.O.I. (in jpg/jpeg/gif/pdf/docx format)</td>
                    <td>
                       <asp:FileUpload runat="server" ID="fileUp1" Width="300px" CssClass="txtbox reqirerd"  ></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                     &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;<br /> Remark
                    </td>
                    <td colspan="3">
                         <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" MaxLength="100"  TextMode="MultiLine"
                          Width="300px" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',100);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                      <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                            CssClass="btn" OnClientClick="return ValidateAllTextForm();" 
                            onclick="btnSave_Click"  />
                    
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                           <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:HiddenField ID="hdnFile" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
