<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="Savings.aspx.cs" Inherits="UniversityProject.Savings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <p>
        <br />
    </p>
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

    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblSavingsTitle" runat="server" Text="SAVINGS" Font-Bold="True" Font-Underline="True"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmpNo" runat="server" Text="EMPLOYEE NO :"></asp:Label>
                <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblSavingYear" runat="server" Text="SAVING YEAR :"></asp:Label>
                <asp:DropDownList ID="ddlSavingYear" runat="server" DataTextField="SAVING_YEAR" DataValueField="SAVING_YEAR">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" CssClass="btnCss" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 327px">
                <asp:HyperLink ID="HyperLinkCreateNew" NavigateUrl="~/SavingsInsertion.aspx" runat="server">Create New</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 327px" colspan="3">
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" OnClick="ButtonDelete_Click" CssClass="btnCss" />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
                        <asp:BoundField DataField="SAVING_YEAR" HeaderText="SAVING_YEAR" SortExpression="SAVING_YEAR" />
                        <asp:BoundField DataField="CONTTOPENSION" HeaderText="CONTTOPENSION" SortExpression="CONTTOPENSION" />
                        <asp:BoundField DataField="MEDICLAIM" HeaderText="MEDICLAIM" SortExpression="MEDICLAIM" />
                        <asp:BoundField DataField="MEDICAL" HeaderText="MEDICAL" SortExpression="MEDICAL" />
                        <asp:BoundField DataField="EDULOAN" HeaderText="EDULOAN" SortExpression="EDULOAN" />
                        <asp:HyperLinkField DataNavigateUrlFields="EMPNO,SAVING_YEAR" DataNavigateUrlFormatString="SavingsModification.aspx?EMPNO={0}&amp;SAVING_YEAR={1}" HeaderText="Click to Edit" Text="Edit" />
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
            </td>
        </tr>
    </table>

</asp:Content>
