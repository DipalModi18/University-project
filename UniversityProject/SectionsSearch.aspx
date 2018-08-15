<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="SectionsSearch.aspx.cs" Inherits="UniversityProject.SectionsSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    </style>
    <br />
    <br />
    <div align="center">
        <br />
        <br />
        <asp:Label ID="LblTitle" runat="server" Text="80C SECTION WITH AMOUNT SEARCH" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>
    <br />

    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="ANNUAL YEAR:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYear1" runat="server" OnTextChanged="txtYear1_TextChanged" AutoPostBack="true" CausesValidation="false" ValidationGroup="INSERTAMT"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYear2" runat="server" ValidationGroup="INSERTAMT"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="ENTER 80C LIMIT:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt80c" runat="server"  ValidationGroup="INSERTAMT"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn80c" runat="server" Text="INSERT" CssClass="lblStyle" ValidationGroup="INSERTAMT" OnClick="btn80c_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtYear1" ErrorMessage="Enter valid number Year1" ValidationExpression="[0-9]+" ValidationGroup="INSERTAMT"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt80c" ErrorMessage="Enter valid number 80C Amount" ValidationExpression="[0-9]+" ValidationGroup="INSERTAMT"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtYear2" ErrorMessage="Enter valid number Year2" ValidationExpression="[0-9]+" ValidationGroup="INSERTAMT"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="height: 30%">
        <div style="float: left; width: 40%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:Label ID="LblSecName" runat="server" Text="SECTION NAME:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtSEClName" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: right; width: 50%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btnCss" OnClick="BtnSearch_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

    </div>
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" CausesValidation="false">ADD NEW</asp:LinkButton>
    </div>
    <br />
    <div style="float: left; width: 70%">

        <%--<asp:LinkButton ID="LinkButton1" runat="server" Text="INSERT" ValidationGroup="INSERT" OnClick="LinkButton1_Click">INSERT</asp:LinkButton>--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NUMBER,NAME" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="821px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="NUMBER" SortExpression="NUMBER">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NUMBER") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NUMBER") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NAME" SortExpression="NAME">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AMOUNT" SortExpression="AMOUNT">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" 
            DeleteCommand="DELETE FROM [SECTIONS] WHERE [NUMBER] = @NUMBER AND [NAME] = @NAME" 
            InsertCommand="INSERT INTO [SECTIONS] ([NUMBER], [NAME], [AMOUNT]) VALUES (@NUMBER, @NAME, @AMOUNT)" 
            SelectCommand="SELECT * FROM [SECTIONS]" 
            UpdateCommand="UPDATE [SECTIONS] SET [AMOUNT] = @AMOUNT WHERE [NUMBER] = @NUMBER AND [NAME] = @NAME">
            <DeleteParameters>
                <asp:Parameter Name="NUMBER" Type="Decimal" />
                <asp:Parameter Name="NAME" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="NUMBER" Type="Decimal" />
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="AMOUNT" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AMOUNT" Type="Decimal" />
                <asp:Parameter Name="NUMBER" Type="Decimal" />
                <asp:Parameter Name="NAME" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
    </div>



</asp:Content>
