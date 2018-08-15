<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="ExamRemuneration.aspx.cs" Inherits="UniversityProject.ExamRemuneration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <p>
        <br />
    </p>
    <p>
        <style>
            .btnCss {
                background-color: #323299;
                border: none;
                color: white;
                padding: 10px 16px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                font-size: 16px;
            }

            .lblStyle {
                font-family: "Lucida Fax","Times New Roman";
                color: #00688b;
            }

            .auto-style1 {
                height: 34px;
            }
        </style>

        <table style="width: 100%;">
            <tr>
                <td style="width: 199px">&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblExamRmn" runat="server" Text="EXAM REMUNERATION" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 199px">
                    <asp:Label ID="lblEmpno" runat="server" Text="EMPNO :"></asp:Label>
                    <asp:TextBox ID="txtSearchEmpno" runat="server"></asp:TextBox>
                </td>
                <td style="width: 187px">
                    <asp:Label ID="lblMonth" runat="server" Text="MONTH :"></asp:Label>
                    <asp:DropDownList ID="ddlSearchMonth" runat="server">
                        <asp:ListItem Selected="True" Value="">Select</asp:ListItem>
                        <asp:ListItem>JAN</asp:ListItem>
                        <asp:ListItem>FEB</asp:ListItem>
                        <asp:ListItem>MAR</asp:ListItem>
                        <asp:ListItem>APR</asp:ListItem>
                        <asp:ListItem>MAY</asp:ListItem>
                        <asp:ListItem>JUN</asp:ListItem>
                        <asp:ListItem>JUL</asp:ListItem>
                        <asp:ListItem>AUG</asp:ListItem>
                        <asp:ListItem>SEP</asp:ListItem>
                        <asp:ListItem>OCT</asp:ListItem>
                        <asp:ListItem>NOV</asp:ListItem>
                        <asp:ListItem>DEC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 169px">
                    <asp:Label ID="lblYear" runat="server" Text="YEAR :"></asp:Label>
                    <asp:DropDownList ID="ddlSearchYear" runat="server"></asp:DropDownList> <%-- DataSourceID="SqlDataSource2" DataTextField="YEAR" DataValueField="YEAR" --%>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT DISTINCT [YEAR] FROM [EXAMREMUNERATION$]"></asp:SqlDataSource>
                </td>
                <%--<td>
                    <asp:Label ID="lblBankTransferDate" runat="server" Text="BANK TRANSFER DATE :"></asp:Label>
                    <asp:DropDownList ID="ddlBankSearchDay" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBankSearchMonth" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBankSearchYear" runat="server">
                    </asp:DropDownList> 
                </td>--%>
            </tr>
            <tr>
                <td style="width: 199px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 169px">
                    <asp:Button ID="SEARCH" runat="server" Text="SEARCH" OnClick="SEARCH_Click" CssClass="btnCss" /><%-- OnCommand="ImgCalender_Command" CommandName="SearchCommandButton" --%>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lbInsert" runat="server" OnClick="lbInsert_Click">ADD NEW</asp:LinkButton>
                </td>
                <td colspan="3">

                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 199px">
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" OnClick="ButtonDelete_Click" CssClass="btnCss" /><%-- OnCommand="ImgCalender_Command" CommandName="DeleteCommandButton" --%>
                </td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 169px">&nbsp;</td>
            </tr>
        </table>

    </p>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!"><%-- OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  DataKeyNames="EMPNO,MONTH,YEAR,BANK_TRANDATE" DataSourceID="SqlDataSource1"--%>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="EMPNO" SortExpression="EMPNO">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EMPNO") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="MONTH" SortExpression="MONTH">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MONTH") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MONTH") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="YEAR" SortExpression="YEAR">
                <EditItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("YEAR") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("YEAR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="EXAM_RMN" SortExpression="EXAM_RMN">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EXAM_RMN") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("EXAM_RMN") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtExamRemuneration" runat="server" Text="0"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="INC_TAX" SortExpression="INC_TAX">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("INC_TAX") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("INC_TAX") %>'></asp:Label>
                </ItemTemplate>
                <%--<FooterTemplate>
                    <asp:TextBox ID="txtIncTax" runat="server" Text="0"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="NET_EXAMRMN" SortExpression="NET_EXAMRMN">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NET_EXAMRMN") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("NET_EXAMRMN") %>'></asp:Label>
                </ItemTemplate>
                <%--<FooterTemplate>
                    <asp:TextBox ID="txtNetExamRemuneration" runat="server" Text="0"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="BANK_TRANDATE" SortExpression="BANK_TRANDATE">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("BANK_TRANDATE") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("BANK_TRANDATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="ExamRemunerationModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Edit" Text="Edit" />

        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>"
        DeleteCommand="DELETE FROM [EXAMREMUNERATION$] WHERE [EMPNO] = @EMPNO AND [MONTH] = @MONTH AND [YEAR] = @YEAR"
        InsertCommand="INSERT INTO [EXAMREMUNERATION$] ([EMPNO], [MONTH], [YEAR], [EXAM_RMN], [INC_TAX], [NET_EXAMRMN], [BANK_TRANDATE]) VALUES (@EMPNO, @MONTH, @YEAR, @EXAM_RMN, @INC_TAX, @NET_EXAMRMN, @BANK_TRANDATE)"
        SelectCommand="SELECT * FROM [EXAMREMUNERATION$] WHERE (([EMPNO] =  @EMPNO or isnull(@EMPNO,'')='') AND ([MONTH] = @MONTH  or isnull(@month,'')='') AND ([YEAR] = @YEAR or isnull(@year,'')=''))"
        UpdateCommand="UPDATE [EXAMREMUNERATION$] SET [EXAM_RMN] = @EXAM_RMN, [INC_TAX] = @INC_TAX, [NET_EXAMRMN] = @NET_EXAMRMN WHERE [EMPNO] = @EMPNO AND [MONTH] = @MONTH AND [YEAR] = @YEAR AND [BANK_TRANDATE] = @BANK_TRANDATE"
        CancelSelectOnNullParameter="false">
        <DeleteParameters>
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
            <asp:Parameter Name="EXAM_RMN" Type="Double" />
            <asp:Parameter Name="INC_TAX" Type="Double" />
            <asp:Parameter Name="NET_EXAMRMN" Type="Double" />
            <asp:Parameter Name="BANK_TRANDATE" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearchEmpno" Name="EMPNO" PropertyName="Text" Type="Double" />
            <%--ConvertEmptyStringToNull="false" --%>
            <asp:ControlParameter ControlID="ddlSearchMonth" Name="MONTH" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter ControlID="ddlSearchYear" Name="YEAR" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="EXAM_RMN" Type="Double" />
            <asp:Parameter Name="INC_TAX" Type="Double" />
            <asp:Parameter Name="NET_EXAMRMN" Type="Double" />
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
            <asp:Parameter Name="BANK_TRANDATE" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <%--<div>
        <asp:LinkButton ID="LinkButtonInsert" ValidationGroup="INSERT" runat="server" OnClick="LinkButtonInsert_Click" OnCommand="ImgCalender_Command" CommandName="InsertCommandLinkButton">Insert</asp:LinkButton>
        <br />

        <br />
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="INSERT" ShowMessageBox="True" />--%>
</asp:Content>
