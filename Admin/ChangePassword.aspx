<%@ Page Title="&#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2348;&#2342;&#2354;&#2375;&#2306; / Change Password" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <script type="text/javascript">
          function CheckPwd() {
              var Password = document.getElementById('<%=txtPassword.ClientID%>').value;
            var rex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%*&?])[A-Za-z\d#$@!%&*?]{8,}$/;
            if (rex.test(Password) == true) {
                document.getElementById('<%=mainDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "";

                return true;
            }
            else {

                document.getElementById('<%=mainDiv.ClientID%>').style.display = "Block";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "Password Must Be Minimum 8 Characters At Least 1 Upper Case 1 Lower Case 1 Number And 1 Special Characters.";
                document.getElementById('<%=txtPassword.ClientID%>').value = "";
                return false;
            };
        }
        function ConfirmPwd() {
            if (document.getElementById('<%=txtPassword.ClientID%>').value == document.getElementById('<%=txtConfirmPassword.ClientID%>').value) {
                document.getElementById('<%=mainDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "";

                return true;
            }
            else {
                document.getElementById('<%=mainDiv.ClientID%>').style.display = "Block";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "Password Not Matched.";
                document.getElementById('<%=txtConfirmPassword.ClientID%>').value = "";
                return false;
            }
        }
    </script>
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2348;&#2342;&#2354;&#2375;&#2306; / Change Password</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">                
                </asp:Label>
            </asp:Panel>
            <table>
                <tr>
                    <td>
                        &#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / User Name
                    </td>
                    <td>
                        <asp:Label ID="lblLoginUserName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2346;&#2367;&#2331;&#2354;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; / Last Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtOldPassword" TextMode="Password" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2344;&#2351;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; / New Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="txtbox reqirerd" runat="server" onblur="return CheckPwd();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2344;&#2351;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2325;&#2344;&#2381;&#2347;&#2352;&#2381;&#2350; &#2325;&#2352;&#2375;&#2306; / Confirm  New Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" CssClass="txtbox reqirerd"  onblur="return ConfirmPwd();"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" OnClick="btnSave_OnClick" OnClientClick='javascript:return ValidateAllTextForm();'
                            CssClass="btn" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
