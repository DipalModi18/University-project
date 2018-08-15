<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="EmployeeArrear.aspx.cs" Inherits="UniversityProject.EmployeeArrear" %>
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

    <table style="width:100%;">
        <tr>
            <td colspan="3" style="float:center; text-align:center; height:10%;" >
                <asp:Label ID="LabelFaculty" runat="server" Text="EMPLOYEE ARREAR" Font-Bold="True" Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 245px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 239px">
                <asp:Label ID="LabelEmployeeId" runat="server" Text="EMPLOYEE ID :"></asp:Label>
                <asp:TextBox ID="TextBoxEmployeeID" runat="server"></asp:TextBox>
            </td>
            <td style="width: 245px">
                <asp:Label ID="LabelMonth" runat="server" Text="MONTH :"></asp:Label>
                <asp:DropDownList ID="DropDownListMonth" runat="server" DataTextField="MONTH" DataValueField="MONTH"><%-- DataSourceID="SqlDataSource2" --%>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT DISTINCT [MONTH] FROM [EMP_ARREAR$]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Label ID="LabelYear" runat="server" Text="YEAR :"></asp:Label>
                <asp:DropDownList ID="DropDownListYear" runat="server" DataTextField="YEAR" DataValueField="YEAR"><%-- DataSourceID="SqlDataSource1" --%>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT DISTINCT [YEAR] FROM [EMP_ARREAR$]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 245px">
                <asp:Button ID="ButtonSearch" runat="server" Text="SEARCH" OnClick="ButtonSearch_Click"  CssClass="btnCss" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 239px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EmployeeArrearInsertion.aspx">Create New</asp:HyperLink>
            </td>
            <td style="width: 245px">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 245px">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" OnClick="ButtonDelete_Click"  CssClass="btnCss" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
                        <asp:BoundField DataField="BILL_NO" HeaderText="BILL_NO" SortExpression="BILL_NO" />
                        <asp:BoundField DataField="RATE_OF_PAY" HeaderText="RATE_OF_PAY" SortExpression="RATE_OF_PAY" />
                        <asp:BoundField DataField="EFFECTIVE_DAYS" HeaderText="EFFECTIVE_DAYS" SortExpression="EFFECTIVE_DAYS" />
                        <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                        <asp:BoundField DataField="YEAR" HeaderText="YEAR" SortExpression="YEAR" />
                        <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="EmployeeArrearModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Click to Edit" Text="Edit" />
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
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [EMPNO], [BILL_NO], [RATE_OF_PAY], [EFFECTIVE_DAYS], [MONTH], [YEAR] FROM [EMP_ARREAR$]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>



</asp:Content>
