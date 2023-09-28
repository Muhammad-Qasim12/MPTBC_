<%@ Page Title="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewTitleMaster.aspx.cs" Inherits="Academic_ViewTitleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines" style="width: 100%">
            <h2>
                <span>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Title Information</span></h2>
        </div>
        <div style="padding: 0 10px; width: 80%;">
            <table>
                <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lblmsg" class="notification" runat="server">
                
                    </asp:Label>
                </asp:Panel>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; /Add New Title " OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="tab" runat="server" id="tabTitleFilter">
                            <tr id="tr1">
                                <th>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year
                                </th>
                                <th colspan="3">
                                    <asp:Label ID="lblAcademicYear" runat="server" Text="--"></asp:Label>
                                    <asp:HiddenField ID="hdnAcademicYearID" runat="server" />
                                </th>

                            </tr>

                            <tr id="tr2">

                                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMedium" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged"
                                        CssClass="txtbox" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&#2325;&#2325;&#2381;&#2359;&#2366;/Class
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged"
                                        CssClass="txtbox" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr3">
                                <td>&#2346;&#2367;&#2331;&#2354;&#2375; &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2379; &#2342;&#2369;&#2361;&#2352;&#2366;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369; / Repeat last Academic Year Title</td>
                                <td>
                                    <asp:Button ID="btnRepeatTitle" OnClick="btnRepeatTitle_Click" class="btn" runat="server" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2379; &#2342;&#2369;&#2361;&#2352;&#2366;&#2319;&#2306; / Repeat Title" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdTitle" runat="server" CssClass="tab" DataKeyNames="TitleID_I"
                            PageSize="30" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GrdTitle_PageIndexChanging"
                            OnRowDeleting="GrdTitle_RowDeleting" EmptyDataText="No Title Found For Current Academic Year" Width="70%">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No. &lt;br/&gt;&lt;br/&gt;1">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2358;&#2368;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; &lt;br/&gt;&lt;br/&gt; 2">
                                    <ItemTemplate>
                                        <%#Eval("MachineType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class &lt;br/&gt;&lt;br/&gt; (3)">
                                    <ItemTemplate>
                                        <%#Eval("Classdet_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title &lt;br/&gt;&lt;br/&gt; (4)">
                                    <ItemTemplate>
                                        <%#Eval("TitleEnglish_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; / Publication Department &lt;br/&gt;&lt;br/&gt; (5)">
                                    <ItemTemplate>
                                        <%#Eval("DepName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2310;&#2325;&#2366;&#2352; (&#2360;&#2375;.&#2350;&#2368;. x &#2360;&#2375;.&#2350;&#2368;.) / Size(CMxCM)&lt;br/&gt;&lt;br/&gt; (6)">
                                    <ItemTemplate>
                                        <%#Eval("Size_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2370;&#2346;&#2319;) / Price(Rs.) &lt;br/&gt;&lt;br/&gt; (7)">
                                    <ItemTemplate>
                                        <%#Eval("Rate_N")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2371;&#2359;&#2381;&#2336; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Pages &lt;br/&gt;&lt;br/&gt; (8)">
                                    <ItemTemplate>
                                        <%#Eval("Pages_N")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2332; 1 &#2319;&#2357;&#2306; 4 / Colour Scheme Coverpage 1 &amp; 4 &lt;br/&gt;&lt;br/&gt; (9)">
                                    <ItemTemplate>
                                        <%#Eval("ColourCover1n4_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2332; 2 &#2319;&#2357;&#2306; 3 / Colour Scheme Coverpage 2 &amp; 3&lt;br/&gt;&lt;br/&gt; (10)">
                                    <ItemTemplate>
                                        <%#Eval("ColourCover2n3_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2350;&#2376;&#2335;&#2352; / Colour Scheme Matter &lt;br/&gt;&lt;br/&gt; (11)">
                                    <ItemTemplate>
                                        <%#Eval("ColorText_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Printing Paper Details &lt;br/&gt;&lt;br/&gt; (12)">
                                    <ItemTemplate>
                                        <%#Eval("PrintingPaperDetails")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Cover paper Details &lt;br/&gt;&lt;br/&gt; (13)">
                                    <ItemTemplate>
                                        <%#Eval("CoverpaperDetails")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2348;&#2366;&#2311;&#2306;&#2337;&#2367;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Binding Details&lt;br/&gt;&lt;br/&gt; (14)">
                                    <ItemTemplate>
                                        <%#Eval("BindingDetails")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351; &#2360;&#2370;&#2330;&#2368; &#2319;&#2357;&#2306; &#2350;&#2366;&#2306;&#2327; &#2346;&#2340;&#2381;&#2352;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Rate List &amp; Demand Form S.No.&lt;br/&gt;&lt;br/&gt; (15)">
                                    <ItemTemplate>
                                        <%#Eval("RateListSNo_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <a href="TitleMaster.aspx?ID=<%#new APIProcedure().Encrypt(Eval("TitleID_I").ToString()) %>" class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" ItemStyle-Width="60">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" class="btn btn-sm btn-danger" Text='<i class="bi bi-trash"></i>' OnClientClick="return confirm('The item will be deleted. Are you sure want to continue?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
