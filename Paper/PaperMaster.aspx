<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaperMaster.aspx.cs" Inherits="Paper_PaperMaster" Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Paper Master " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        
        function OnchangeName() {
            
            if (document.getElementById('<%=ddlPaperCategory.ClientID%>').value == "Sheet") {
                document.getElementById('<%=DivLbl.ClientID%>').innerHTML = "&#2327;&#2339;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2358;&#2368;&#2335; &#2325;&#2366; &#2357;&#2332;&#2344; (&#2327;&#2381;&#2352;&#2366;&#2350;) <br />For Calculation Weight Of Sheet (Gram)";
            }
            else {
                document.getElementById('<%=DivLbl.ClientID%>').innerHTML = "&#2327;&#2339;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2352;&#2368;&#2354; &#2325;&#2366; &#2357;&#2332;&#2344; (&#2327;&#2381;&#2352;&#2366;&#2350;) <br /> For Calculation Weight Of Reel (Gram)";
            }
        }
       
         

           
    </script>
    <div class="portlet-header ui-widget-header">
        <%--View Demand Grouping From Printing--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Paper Master 
    </div>
    <div class="table-responsive">
    <div class="portlet-content">
        <table width="100%">
            <tr>
                <td>
                    *&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br />Paper Type
                </td>
                <td>
                    <asp:DropDownList ID="ddlPaperType" runat="server" Width="309px" 
                        CssClass="txtbox reqirerd" AutoPostBack="True" oninit="ddlPaperType_Init" 
                        onselectedindexchanged="ddlPaperType_SelectedIndexChanged">
                      
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>*
              &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2327;&#2369;&#2339;&#2357;&#2340;&#2381;&#2340;&#2366;(&#2344;&#2366;&#2350;) <br /> Quality Of Paper</td>
                <td>
                    <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="txtbox reqirerd" 
                        oninit="ddlPaperSize_Init" Width="309px">
                        
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td>*
              &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2325;&#2375;&#2335;&#2375;&#2327;&#2352;&#2368; <br /> Category Of Paper</td>
                <td>
                    <asp:DropDownList ID="ddlPaperCategory" runat="server" CssClass="txtbox reqirerd" onchange="OnchangeName();"   Width="309px">
                    <asp:ListItem Text="Reel"></asp:ListItem>
                    <asp:ListItem Text="Sheet"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>*
                    GSM
                </td>
                <td>
                    <asp:TextBox ID="txtSize" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'
                        CssClass="txtbox reqirerd" Width="50px" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>*
                    &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; <br /> Paper Size
                </td>
                <td>
                    <asp:TextBox ID="txtQuality" runat="server" Width="300px" MaxLength="70"  onkeypress="tbx_fnAlphaNumeric(event, this);" CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label id="DivLbl" runat="server">&#2327;&#2339;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2358;&#2368;&#2335; &#2325;&#2366; &#2357;&#2332;&#2344; (&#2327;&#2381;&#2352;&#2366;&#2350;) <br /> For Calculation Weight Of Sheet (Gram)</asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="txtSheetWt" runat="server"  MaxLength="10" Width="309px"    onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368; <br /> Remark
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" MaxLength="100" Width="309px"   onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',100);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td >
                      <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px;">
                   
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>
