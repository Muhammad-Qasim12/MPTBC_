<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllChallan.aspx.cs" Inherits="AllChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header" id="a" runat="server"  >
            <h2> &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
         <table width="100%">
                <tr>
                  <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; 
                         </td>
                   <td colspan="2">
                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                             <asp:ListItem Selected="True" Value="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2330;&#2366;&#2354;&#2366;&#2344; </asp:ListItem>
                             <asp:ListItem Value="1">&#2350;&#2367;&#2354; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2330;&#2366;&#2354;&#2366;&#2344; </asp:ListItem>
                         </asp:RadioButtonList>
                         </td>
                </tr>
                <tr>
                  <td>&#2337;&#2367;&#2346;&#2379;/&#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                   <td>
                         <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox">
                         </asp:DropDownList>
                         </td>
                   <td>
                         <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375; " OnClick="Button1_Click" />
                         </td>
                </tr>
                <tr>
                  <td colspan="3">
                      <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="PriTransID"  >
                          <Columns>
                              <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                  <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleID_I") %>' />
                                      <asp:HiddenField ID="Medium_I" runat="server" Value='<%# Eval("Medium_I") %>' />
                                      <asp:HiddenField ID="ClassTrno_I" runat="server" Value='<%# Eval("ClassTrno_I") %>' />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                  <ItemTemplate>
                                                     <%#Eval("DepoName") %>
                                                 </ItemTemplate>
                              </asp:TemplateField>
                                               <%-- <asp:BoundField DataField="DepoName" HeaderText="DepoName" />--%>

                                                <asp:BoundField DataField="BookType" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                              <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer Name">
                                  <ItemTemplate>
                                      <%# Eval("NameofPress_V")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Challan No.">
                                  <ItemTemplate>
                                      <%# Eval("ChalanNo")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Challan Date">
                                  <ItemTemplate>
                                      <%# Eval("ChalanDate")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Book Name">
                                  <ItemTemplate>
                                      <%# Eval("TitleHindi_V")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="bookno" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; " />
                              <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;   /Total No. of Books ">
                                  <ItemTemplate>
                                      <%# Eval("TotalNoOfBooks")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366; ) / Book No. (Scheme) " Visible="false">
                                  <ItemTemplate>
                                      <%# Eval("TotalNoOfBooksYoj")%>

                                                                                                                                                                                          </ItemTemplate>
                              </asp:TemplateField>
                                                
                                         
                                               <%-- <asp:BoundField DataField="TotalAvantan" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344;" />--%>
                                                
                                         
                                                </Columns>
                      </asp:GridView>

                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                          <Columns>
                               <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                  <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                   
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="PaperVendorName_V" HeaderText="&#2350;&#2367;&#2354;  &#2325;&#2366; &#2344;&#2366;&#2350; " />
                              <asp:BoundField DataField="ChallanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; " />
                              <asp:BoundField DataField="ChallanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                              <asp:BoundField DataField="CoverInformation" HeaderText="&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " />
                              <asp:BoundField DataField="Dta" HeaderText="&#2350;&#2367;&#2354; &#2360;&#2375; &#2349;&#2375;&#2332;&#2368; &#2327;&#2312; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; " />
                          </Columns>
                      </asp:GridView>
                         </td>
                </tr>
                <tr>
                  <td colspan="3">
                      &nbsp;</td>
                </tr></table> 
        </div> 
</asp:Content>

