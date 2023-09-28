<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookReturnOnDepo.aspx.cs" Inherits="Depo_BookReturnOnDepo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;&nbsp; / Book Return Details</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
             <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>--%>
                  <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                     <table width="100%">
                         <tr>
                             <td style="height: 32px">
                                 <asp:GridView ID="grdBook" runat="server" AutoGenerateColumns="False" CssClass="tab" OnSelectedIndexChanged="grdBook_SelectedIndexChanged1" DataKeyNames="orderno" >
                                     <Columns>
                                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                             <ItemTemplate>
                                                
                                              <%#Container.DataItemIndex+1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Seller Name" DataField="BooksellerName_V" />
                                         <asp:BoundField DataField="RetDate_D" HeaderText="&#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Return Request Date" />
                                         <asp:BoundField DataField="orderno" HeaderText="&#2357;&#2366;&#2346;&#2360;&#2367;  &#2344;&#2367;&#2357;&#2375;&#2342;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; /Return Request No" />
                                         <asp:CommandField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375; " ShowSelectButton="True" />
                                     </Columns>
                                     <PagerStyle CssClass="Gvpaging" />
                                     <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 </asp:GridView>
                             </td>

                         </tr><tr><td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                     CssClass="tab" DataKeyNames="bookRetrNo_I">
                                     <Columns>
                                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; /S.No.">
                                             <ItemTemplate>
                                                 <asp:HiddenField ID="HiddenField2" runat="server"  Value='<%# Eval("bookRetrNo_I") %>' />                                          <%#Container.DataItemIndex+1 %>
                                                 <asp:HiddenField ID="HiddenField1" runat="server" 
                                                     Value='<%# Eval("BandalNO") %>' />
                                                 <asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("TitalID") %>'  />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium "  DataField="Medium" />
                                         <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class " DataField="Classdet_V" />
                                         <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" />
                                         <asp:BoundField HeaderText="&#2325;&#2366;&#2352;&#2339;/ Reason" DataField="Reson_V"/>
                                         <asp:BoundField DataField="BookNo" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Book No." />
                                         <asp:TemplateField HeaderText="&#2344;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; ">
                                             <ItemTemplate>
                                                 &#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375;
                                                 <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" Width="148px" ></asp:TextBox>
                                                 <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="8">
                                                 </asp:CheckBoxList>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                     <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 </asp:GridView></td></tr>

                          <tr>
                             <td style="height: 32px">

                                 <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" Visible="False" />

                                 <asp:HiddenField ID="HiddenField5" runat="server" />

                             </td> </tr> 

                     </table> </div>

                 <%--</ContentTemplate> </asp:UpdatePanel> --%>
</asp:Content>

