<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="UserMaster.aspx.cs" Inherits="Admin_UserMaster" 
    Title="&#2351;&#2370;&#2332;&#2352; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; (निर्माण/सुधार) / User Registration (Insert/Update)" %>

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
                
                document.getElementById('<%=mainDiv.ClientID%>').style.display="Block";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML=  "Password Must Be Minimum 8 Characters At Least 1 Upper Case 1 Lower Case 1 Number And 1 Special Characters.";
                document.getElementById('<%=txtPassword.ClientID%>').value = "";
                return false;
            };
        }
        function ConfirmPwd() {
            if (document.getElementById('<%=txtPassword.ClientID%>').value == document.getElementById('<%=txtRePassword.ClientID%>').value) {
                document.getElementById('<%=mainDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "";

                return true;
            }
            else {
                document.getElementById('<%=mainDiv.ClientID%>').style.display = "Block";
                document.getElementById('<%=lblmsg.ClientID%>').innerHTML = "Password Not Matched.";
                document.getElementById('<%=txtRePassword.ClientID%>').value = "";
                return false;
            }
        }
    </script>
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2351;&#2370;&#2332;&#2352; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; (निर्माण/सुधार) / User Registration (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px 20px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlUserMaster" Visible="false" runat="server">
                <table width="100%">
                    <tr>
                        <td  width="10%">
   <asp:Button ID="btnNewUser" OnClick="btnNewUser_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2351;&#2370;&#2332;&#2352; &#2332;&#2379;&#2396;&#2375;&#2306; / Add New User"
                    CssClass="btn"></asp:Button>
                        </td>
                        <td width="10%"></td>
                        <td width="70%" style="text-align:right;">

                           
                        </td>
                        <td width="10%" style="text-align:right;">
  
                        </td>

                    </tr>

                </table>

             

                  <table>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td>रोल / Role:</td>
                        <td>
                            <asp:DropDownList ID="ddlSearchRole" runat="server"></asp:DropDownList></td>
                        <td>यूजर नाम या अधिकारी / संस्था का नाम / User Name /Officer Or Orgnization Name:</td>
                        <td>
                            <asp:TextBox ID="txtSearchUser" runat="server"></asp:TextBox>
                          <asp:Button ID="btnSearch"
                            runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report "
                            OnClick="btnSearch_Click" />

                        </td>
                    </tr>
                </table>
              
                

                <asp:GridView ID="gvUserMaster" CssClass="tab" AutoGenerateColumns="false" PageSize="30"
                    AllowPaging="true" OnPageIndexChanging="gvUserMaster_PageIndexChanging" OnRowEditing="gvUserMaster_RowEditing"
                    OnRowDeleting="gvUserMaster_RowDeleting" runat="server">
                    <Columns>
                        <asp:BoundField DataField="UserID_I" ReadOnly="true" HeaderText="&#2351;&#2370;&#2332;&#2352;  &#2310;&#2312;. &#2337;&#2368;. / User ID " />
                        <asp:BoundField DataField="Username_V" ReadOnly="true" HeaderText="&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / User Name" />
                        <asp:BoundField DataField="Role_V" ReadOnly="true" HeaderText="&#2352;&#2379;&#2354; / Role" />
                        <asp:BoundField DataField="UserType_V" ReadOnly="true" HeaderText="&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / User Type" />
                         <asp:BoundField DataField="LoginSts" ReadOnly="true" HeaderText="&#2354;&#2377;&#2327; &#2311;&#2344; &#2325;&#2366; &#2360;&#2381;&#2340;&#2352; / Login Status" />
                            <asp:BoundField DataField="Password_V" ReadOnly="true" HeaderText="	&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; / User Password" />  
                         <asp:BoundField DataField="CoreSts" ReadOnly="true" HeaderText="&#2325;&#2379;&#2352; &#2350;&#2377;&#2337;&#2351;&#2369;&#2354; &#2325;&#2366; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352; / Core Module Rights" />  
                        <asp:TemplateField HeaderText="&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Officer Name">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("EmployeeID_I") %>' Visible="false"></asp:Label>
                                 <asp:Label ID="lblUserFromDPHO" runat="server" Text='<%#Eval("UserFromDPHO") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblUserDpt_I" runat="server" Text='<%#Eval("UserDpt_I") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblBranchId" runat="server" Text='<%#Eval("BranchId") %>' Visible="false"></asp:Label>
                                 <asp:Label ID="lblCoreRoleId" runat="server" Text='<%#Eval("CoreRoleId") %>' Visible="false"></asp:Label>
                                 <asp:Label ID="lblRoleAccess" runat="server" Text='<%#Eval("RoleAccess") %>' Visible="false"></asp:Label>
                                <%#Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                            Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; / Edit" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="gvlblRoleTrno" Visible="false" runat="server" Text='<%# Eval("RoleTrno_I") %>'></asp:Label>
                                <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                <asp:HiddenField ID="hdnUserTrno" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewUser" runat="server" Width="100%">
                <table  >

                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblErrorMessage" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br /> User Name
                        </td>
                        <td >
                            <asp:TextBox ID="txtUsername" MaxLength="30" CssClass="txtbox reqirerd" Width="200px" runat="server">
                            </asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td >&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> User Type
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlUserType" runat="server" Width="212px"  CssClass="txtbox reqirerd">
                                <asp:ListItem Value="Management" Text="Management"></asp:ListItem>
                                <asp:ListItem Value="System Admin" Text="System Admin"></asp:ListItem>
                                <asp:ListItem Value="Departmental User" Text="Departmental User"></asp:ListItem>
                                <asp:ListItem Value="External User" Text="External User"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td >&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2357;&#2367;&#2349;&#2366;&#2327; <br /> User Department
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlUserDepart" runat="server" Width="212px" OnInit="ddlUserDepart_Init"  CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td >&#2348;&#2367;&#2395;&#2344;&#2360;  &#2352;&#2379;&#2354; <br /> Business Role
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlRole" runat="server" Width="212px"  CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                    </tr>
                  
                     <tr>
                    <td>
                        <%--Officer name (--%>&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Officer Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOfficeName" runat="server"  OnInit="ddlOfficeName_Init" CssClass="txtbox reqirerd"
                            Width="212px">
                        </asp:DropDownList>
                    </td>
                         </tr>
                     
                       <tr id="trLoginSts" runat="server" visible="false">
                        <td >&#2354;&#2377;&#2327; &#2311;&#2344; &#2325;&#2366; &#2360;&#2381;&#2340;&#2352; <br /> Login Status
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlLoginStatus" runat="server" Width="212px">
                                <asp:ListItem Text="UnBlock"></asp:ListItem>
                                <asp:ListItem Text="Block"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                         <tr >
                        <td >&#2325;&#2379;&#2352; &#2350;&#2377;&#2337;&#2351;&#2369;&#2354; &#2325;&#2366; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;<br /> Core Module Rights 
                        </td>
                        <td align="left">
                              <asp:CheckBoxList id ="chkCoreModuleRights" runat="server"  AutoPostBack="true"  CssClass=" reqirerd" OnSelectedIndexChanged="chkCoreModuleRights_CheckedChanged" >
                                <asp:ListItem>Business Module</asp:ListItem>
                                 <asp:ListItem>Code Module</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="trBranchId" runat="server" visible="false">
                        <td > &#2358;&#2366;&#2326;&#2366; &#2325;&#2366; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;<br />Branch Rights
                        </td>
                        <td align="left">
                             <asp:DropDownList ID="ddlUserFrom" runat="server" Width="212px" AutoPostBack="true" OnSelectedIndexChanged="ddlUserFrom_SelectedIndexChanged">
                                <asp:ListItem Value="00001" Text="HO"></asp:ListItem>
                                <asp:ListItem Value="00002" Text="Depo"></asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                       <tr id="trCoreRole" runat="server" visible="false">
                        <td >&#2325;&#2379;&#2352;  &#2352;&#2379;&#2354; <br /> Core Role
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlCoreRole" runat="server" Width="212px" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                    <td>
                        &#2358;&#2366;&#2326;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Branch Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBranchName" runat="server"  OnInit="ddlBranchName_Init" CssClass="txtbox reqirerd"
                            Width="212px">
                        </asp:DropDownList>
                    </td>
                         </tr>


                    <tr>
                        <td >&#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; <br /> Password
                        </td>
                        <td >
                            <asp:TextBox ID="txtPassword" MaxLength="20" TextMode="Password" Width="200px" CssClass="txtbox reqirerd"  runat="server"> 
                            </asp:TextBox>



                        </td>
                    </tr>
                    <tr>
                        <td >&#2325;&#2344;&#2381;&#2347;&#2352;&#2381;&#2350; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; <br /> Confirm Password
                        </td>
                        <td >
                            <asp:TextBox ID="txtRePassword" MaxLength="20" TextMode="Password" Width="200px" CssClass="txtbox reqirerd" onblur="return ConfirmPwd();" runat="server">
                            </asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
