<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="DaArrears.aspx.cs" Inherits="UniversityProject.DaArrears" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br />

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
        <asp:label id="LblTitle" runat="server" text="D.A. ARREARS SEARCH" font-bold="True" font-names="Copperplate Gothic Bold" font-size="X-Large" font-underline="True"></asp:label>
    </div>
    <br />
    <div style="width:100%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:label id="LblEmpid" runat="server" text="EMPLOYEE ID:" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="TxtEmpid" runat="server"></asp:textbox>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" controltovalidate="TxtEmpid" errormessage="Enter valid number" validationexpression="[0-9]+"></asp:regularexpressionvalidator>
                    </td>
                    <td>

                    </td>
                    <td>
                        <asp:label id="LblMth" runat="server" text="MONTH" cssclass="lblStyle"></asp:label>
                    </td>
                    <td class="auto-style2">
                        <asp:dropdownlist id="DropDownListMonth" runat="server"></asp:dropdownlist>
                    </td>
                    <td>

                    </td>
                    <td>
                        <asp:label id="LblYear" runat="server" text="YEAR" cssclass="lblStyle"></asp:label>
                    </td>
                    <td class="auto-style2">
                        <asp:dropdownlist id="DropDownListYear" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
            </table>
    </div>
    <div align="center" style="width: 100%; align-content: center">
        <asp:button id="BtnSearch" runat="server" text="Search" cssclass="btnCss" onclick="BtnSearch_Click" />
    </div>
    <div>
        <asp:linkbutton id="LinkButtonLogIn" runat="server" onclick="LinkButtonLogIn_Click">ADD NEW</asp:linkbutton>
    </div>

    <asp:Button ID="buttonDelete" runat="server" Text="Delete Records" cssclass="btnCss" OnClick="buttonDelete_Click"  />

    <br />
    <div style="float: left; width: 70%">
        <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" cellpadding="4" forecolor="#333333" emptydatatext="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" gridlines="None" width="142%" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="YEAR" HeaderText="YEAR" SortExpression="YEAR" />
                <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="DAArrearsModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Click To Edit" Text="Edit" />
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
        </asp:gridview>
    </div>
</asp:Content>
