<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="VendorLOI.aspx.cs" Inherits="Paper_VendorLOI" Title="Vendor LOI" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <%--Vendor LOI--%>&#2357;&#2375;&#2306;&#2337;&#2352; &#2319;&#2354;.&#2323;.&#2310;&#2312;.
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Tender No.--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderNo" Width="312px" AutoPostBack="True"
                            OnInit="ddlTenderNo_Init" OnSelectedIndexChanged="ddlTenderNo_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Date (--%>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:Label ID="lblCurrentDt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLOINo" MaxLength="30" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                    </td>
                    <td>
                        <%--LOI To. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;
                        ( &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;)
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlVendorLOITo" Width="312px">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2340;&#2366;
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAddress" ReadOnly="true" runat="server" CssClass="txtbox" TextMode="MultiLine" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"
                           ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367;
                        &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtContactPerson" ReadOnly="true" runat="server" CssClass="txtbox" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="40"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2312;-&#2350;&#2375;&#2354;
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="txtbox" MaxLength="30" ></asp:TextBox>
                    </td>
                    <td>
                        &#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359;
                        &#2344;&#2306;.
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactNo" ReadOnly="true" runat="server" CssClass="txtbox" onblur='javascript:fnIsValidPhoneFormat(this);' MaxLength="10"></asp:TextBox>
                
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2357;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2357;&#2375;&#2335; &#2335;&#2376;&#2325;&#2381;&#2360;
                        &#2344;&#2306;.
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtVatTaxNo" runat="server" ReadOnly="true" CssClass="txtbox" MaxLength="20" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--PBG Amount In Rs. (--%>&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367;
                        (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )
                    </td>
                    <td colspan="1">
                        <asp:TextBox runat="server" ID="txtPBGAmt" MaxLength="12" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                    </td>
                    <td id="photoupload">
                      <%--Upload LOI (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375;</td>
                    <td>
                       <asp:FileUpload runat="server" ID="fileUp1"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                     &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                    </td>
                    <td colspan="3">
                         <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" MaxLength="100" 
                             onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);" 
                             Height="100px" Width="369px"
                         ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;"
                            CssClass="btn" OnClientClick="return ValidateAllTextForm();" 
                            onclick="btnSave_Click"  />
                    
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        
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
     <script>

         var Globlephoto = document.getElementById("photoupload").innerHTML;
         $('#ContentPlaceHolder1_fileUp1').live('change', function () {

             //this.files[0].size gets the size of your file.
             if (this.files[0].size / 1024 > 500) {
                 alert("&#2309;&#2360;&#2347;&#2354; &#2309;&#2346;&#2354;&#2379;&#2337;. &#2347;&#2366;&#2311;&#2354; &#2360;&#2366;&#2311;&#2395; 500 KB &#2360;&#2375; &#2309;&#2343;&#2367;&#2325; &#2361;&#2376;");
                 document.getElementById("PhotoUpload").innerHTML = Globlephoto;

             }

         });
           </script>
</asp:Content>
