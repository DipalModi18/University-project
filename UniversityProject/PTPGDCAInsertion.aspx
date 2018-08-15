<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="PTPGDCAInsertion.aspx.cs" Inherits="UniversityProject.PTPGDCAInsertion" %>
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
    <br /><br /><br />
    <div style="text-align:center; text-decoration:underline; height:10%">
       <asp:label ID="LblTitle" runat="server" text="PART TIME POST GRADUATION COURSE INFORMATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="Large"></asp:label>
    </div>
    <br />
    <div style="height:20%">
       
            <table cellspacing="2em">
                <tr>
                    <td>
                        <asp:Label ID="Lblempid" runat="server" Text="EMPLOYEE ID :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtempid" runat="server"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtempid" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
               <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtempid" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>  
                </td>
                </tr>
            </table>
    </div>
    <br />
    <br />
    <div style="height:50%">
        <div style="float:left; width:50%">
            <table cellspacing="10em">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Lblmth" runat="server" Text="MONTH :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListMonth" runat="server">
                                    <asp:ListItem Value="JAN"> JAN </asp:ListItem>
                                    <asp:ListItem Value="FEB"> FEB </asp:ListItem>
                                    <asp:ListItem Value="MAR"> MAR </asp:ListItem>
                                    <asp:ListItem Value="APR"> APR </asp:ListItem>
                                    <asp:ListItem Value="MAY"> MAY </asp:ListItem>
                                    <asp:ListItem Value="JUN"> JUN </asp:ListItem>
                                    <asp:ListItem Value="JUL"> JUL </asp:ListItem>
                                    <asp:ListItem Value="AUG"> AUG </asp:ListItem>
                                    <asp:ListItem Value="SEPT"> SEPT </asp:ListItem>
                                    <asp:ListItem Value="OCT"> OCT </asp:ListItem>
                                    <asp:ListItem Value="NOV"> NOV </asp:ListItem>
                                    <asp:ListItem Value="DEC"> DEC </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblyear" runat="server" Text="YEAR :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtYear" runat="server"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtYear" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblBanktrasnfer" runat="server" Text="BANK TRANSFER ON :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="LblCal" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calender.jpg" OnClick="ImageButton1_Click" CausesValidation="false" />
                </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar1_SelectionChanged" Width="330px" OnDayRender="Calendar1_DayRender">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                </tr>
            </table>
        </div>

        <div style="float:right;width:50%">
            <table cellspacing="10em">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Lblptpgdca" runat="server" Text="PT PGDCA :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txtptpgdca" runat="server"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txtptpgdca" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
               <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Txtptpgdca" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>  
                </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblincometax" runat="server" Text="INCOME TAX :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txtincometax" runat="server"></asp:TextBox>
                    </td>
                    <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtincometax" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
               <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Txtincometax" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>  
                </td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="BtnPtpgdca" runat="server" Text="NET PTPGDCA" CssClass="btnCss" OnClick="netptpgdca_Click" CausesValidation="false"/>
                    </td>
                    <td>
                        <asp:Label ID="Lblnetptpgdca" runat="server" Text="Label"></asp:Label>
                    </td>
                    
                </tr>
            </table>
        </div>
    </div>

    <br />
    <br />
    <div align="center">
        
            <asp:Button ID="Btnsave" runat="server" Text="SAVE" CssClass="btnCss" OnClick="Btnsave_Click"/>
           &nbsp;&nbsp;&nbsp;

            <asp:Button ID="Btncancel" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="Btnclr_Click"/>
        </div>

</asp:Content>
