<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="UniversityProject.Department" %>

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

    <div style="height: 30%">
        <div style="float: left; width: 40%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:label id="LblDeptId" runat="server" text="DEPARTMENT ID:" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="TxtDeptId" runat="server"></asp:textbox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: right; width: 50%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:label id="LblDeptName" runat="server" text="DEPARTMENT NAME:" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="TxtDeptlName" runat="server"></asp:textbox>
                    </td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td><span>
                    <asp:button id="BtnSearch" runat="server" text="Search" onclick="BtnSearch_Click" cssclass="btnCss" /> 
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><span>
                    <asp:linkbutton id="LinkButtonLogIn" runat="server" onclick="LinkButtonLogIn_Click">ADD NEW</asp:linkbutton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <div style="align:center">
                    <span>
    <asp:button id="ButtonDelete" runat="server" text="Delete Records" onclick="ButtonDelete_Click" cssclass="btnCss" />
                    </span> 
    </div>          
    <div style="float: left; width: 50%">
    </div>

    <br />
    <br />
    <div style="float: left; width: 70%">
        <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datakeynames="DEPTNO" cellpadding="4" forecolor="#333333" gridlines="None" Width="100%" emptydatatext="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!"  ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:BoundField DataField="DEPTNO" HeaderText="DEPTNO" ReadOnly="True" SortExpression="DEPTNO" />
                <asp:BoundField DataField="DEPTNAME" HeaderText="DEPTNAME" SortExpression="DEPTNAME" />
                <asp:BoundField DataField="FACID" HeaderText="FACID" SortExpression="FACID" />
                <asp:BoundField DataField="ABBRE" HeaderText="ABBRE" SortExpression="ABBRE" />
                <asp:BoundField DataField="ADDR1" HeaderText="ADDR1" SortExpression="ADDR1" />
                <asp:BoundField DataField="ADDR2" HeaderText="ADDR2" SortExpression="ADDR2" />
                <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                <asp:BoundField DataField="PINCODE" HeaderText="PINCODE" SortExpression="PINCODE" />
                <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
                <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                <asp:BoundField DataField="HOD" HeaderText="HOD" SortExpression="HOD" />
                <asp:HyperLinkField DataNavigateUrlFields="DEPTNO" DataNavigateUrlFormatString="DepartmentModification.aspx?DEPTNO={0}" HeaderText="Click To Edit" Text="Edit" />
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
    <script>
        function DeleteConfirm(facid) {
            var confirmation = document.createElement("INPUT");
            confirmation.type = "hidden";
            confirmation.name = "confirm_value";

            if (confirm("Are you sure want to delete Department =" + DEPTNO + "?"))
                confirmation.value = "Yes";
            else
                confirmation.value = "no";
        }
    </script>

</asp:Content>
