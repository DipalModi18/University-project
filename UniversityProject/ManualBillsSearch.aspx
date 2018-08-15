<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="ManualBillsSearch.aspx.cs" Inherits="UniversityProject.ManualBillsSearch" %>

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
    <table style="width: 100%;">
        <tr>
            <td colspan="3" style="float: center; text-align: center; height: 10%;">
                <asp:label id="LabelFaculty" runat="server" text="MANUAL BILLS SEARCH" font-bold="True" font-underline="True"></asp:label>
            </td>
        </tr>
        <tr>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 245px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 239px">
                <asp:label id="LabelEmployeeId" runat="server" text="EMPLOYEE ID :"></asp:label>
                <asp:textbox id="TxtEmpid" runat="server"></asp:textbox>
            </td>
            <td style="width: 245px">
                <asp:label id="LabelMonth" runat="server" text="MONTH :"></asp:label>
                <asp:dropdownlist id="DropDownListMonth" runat="server">
                    
                </asp:dropdownlist>

            </td>
            <td>
                <asp:label id="LabelYear" runat="server" text="YEAR :"></asp:label>
                <asp:dropdownlist id="DropDownListYear" runat="server"><%--  --%>
                </asp:dropdownlist>

            </td>
        </tr>
        <tr>
            <td>
                <td>
                    <asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" controltovalidate="TxtEmpid" errormessage="Enter valid number" validationexpression="[0-9]+"></asp:regularexpressionvalidator>
                </td>
            </td>
        </tr>
        <tr>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 245px">
                <asp:button id="ButtonSearch" runat="server" text="SEARCH" cssclass="btnCss" onclick="ButtonSearch_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 239px">
                <asp:linkbutton id="LinkButtonAddNem" runat="server" onclick="LinkButtonAddNem_Click">ADD NEW</asp:linkbutton>
            </td>
            <td style="width: 245px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 239px">
                <asp:button id="ButtonDelete" runat="server" text="Delete Records" onclick="ButtonDelete_Click" cssclass="btnCss" />
            </td>
            <td style="width: 245px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:gridview id="GridView1" runat="server" cellpadding="4" width="100%" emptydatatext="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" forecolor="#333333" gridlines="None" showheaderwhenempty="True" autogeneratecolumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                        <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
                        <asp:BoundField DataField="BILL_NO" HeaderText="BILL_NO" SortExpression="BILL_NO" />
                        <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                        <asp:BoundField DataField="YEAR" HeaderText="YEAR" SortExpression="YEAR" />
                        <asp:BoundField DataField="RATE_OF_PAY" HeaderText="RATE_OF_PAY" SortExpression="RATE_OF_PAY" />
                        <asp:BoundField DataField="EFFECTIVE_DAYS" HeaderText="EFFECTIVE_DAYS" SortExpression="EFFECTIVE_DAYS" />
                        <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="ManualBillsModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Click to Edit" Text="Edit" />
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

            </td>
        </tr>
    </table>

</asp:Content>
