<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="SalaryModification.aspx.cs" Inherits="UniversityProject.SalaryModification" %>

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

        .auto-style1 {
            height: 34px;
        }
    </style>
    <div style="height: 20%">
        <br />
        <div style="float: right; width: 50%; text-decoration: underline; height: 50%">
            <div align="center">
                <asp:Label ID="lblEmpInfo" runat="server" Text="SALARY MODIFICATION" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div style="float: right; width: 50%;">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblEmpID" runat="server" Text="EMPLOYEE ID :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="ShowEmpId" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>
            </table>
        </div>
    </div>

    <table cellspacing="5em">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>

    <div>
        <!-- this tag is around employee details and earnings,deduction,advrec-->
        <div style="float: left; width: 50%; height: 65%">
            <div>
                <asp:Label ID="lblEmpDeatails" runat="server" Text="EMPLOYEE'S DETAILS :" CssClass="HeadLabel"></asp:Label>
                <table cellspacing="15px" style="border: medium solid #C0C0C0;">
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text="NAME :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDesignation" runat="server" Text="DESIGNATION :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesignation" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDesignation" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDepartment" runat="server" Text="DEPARTMENT :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDept" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDept" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDept" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFac" runat="server" Text="FACULTY :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFac" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFac" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFac" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBill" runat="server" Text="BILL NO :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBill" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBill" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtBill" ValidationExpression="[0-9]+" ErrorMessage="Enter Numbers Only." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRateOfPay" runat="server" Text="RATE OF PAY :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRateOfPay" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRateOfPay" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtRateOfPay" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEffectiveDays" runat="server" Text="EFFECTIVE DAYS :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEffectiveDays" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEffectiveDays" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtEffectiveDays" ValidationExpression="[0-9]+" ErrorMessage="Enter Numbers Only." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMonth" runat="server" Text="MONTH :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="ShowMonth" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblYear" runat="server" Text="YEAR :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="ShowYear" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="NetPayDiv" runat="server">
                <table style="border: medium solid #C0C0C0;">
                    <tr>
                        <td>
                            <asp:Label ID="lblGrossPay" runat="server" Text="GROSS PAY:" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGrossPay" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNetDeduction" runat="server" Text="NET DEDUCTIONS :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNetDeduction" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNetPay" runat="server" Text="NET PAY :" CssClass="lblStyle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNetPay" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="float: right; width: 50%; height: 65%">

            <div align="center" style="width: auto">

                <asp:Button ID="btnEarning" runat="server" Text="EARNINGS" BackColor="#30415d" CssClass="btnCss" OnClick="btnEarning_Click" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnDeduction" runat="server" Text="DEDUCTIONS" BackColor="#30415d" CssClass="btnCss" OnClick="btnDeduction_Click" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnAdvRec" runat="server" Text="ADV. & RECOVERY" BackColor="#30415d" CssClass="btnCss" OnClick="btnAdvRec_Click" />



            </div>

            <div style="border: medium solid #C0C0C0">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewEarning" runat="server">
                        <div>
                            <div style="float: left; width: 50%">
                                <table cellspacing="21px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBasic" runat="server" Text="BASIC :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBasic" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBasic" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtBasic" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDa" runat="server" Text="D.A. :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDa" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtDa" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblHra" runat="server" Text="H.R.A. :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHra" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtHra" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCla" runat="server" Text="CLA :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCla" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtCla" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUcpf" runat="server" Text="UCPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUcpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtUcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSpAllowance" runat="server" Text="SPECIAL ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSpAllowance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtSpAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="L.T.C. ENCASHMENT :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtLtcEncashment"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtLtcEncashment" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="float: right; width: 50%">
                                <table cellspacing="15px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblConveyAllowance" runat="server" Text="CONVEYANCE ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConveyAllowance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtConveyAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblExamAllowance" runat="server" Text="EXAMINATION ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExamAllowance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtExamAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWasgAllowance" runat="server" Text="WASHING ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWasgAllowance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtWasgAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMedAllowance" runat="server" Text="MEDICAL ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMedAllowance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtMedAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAdHoc" runat="server" Text="AD-HOC BONUS :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdhoc" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtAdhoc" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDp" runat="server" Text="D.P. :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDp" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtDp" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOtherAllowances" runat="server" Text="OTHER ALLOWANCES :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOtherAllowances" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" ControlToValidate="txtOtherAllowances" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnTotEarning" runat="server" Text="TOTAL EARNINGS" CssClass="btnCss" OnClick="btnTotEarning_Click" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotEarning" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewDeduction" runat="server">
                        <div>
                            <div style="float: left; width: 50%">
                                <table cellspacing="15px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPf" runat="server" Text="P.F. :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtPf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUcpf1" runat="server" Text="UCPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUcpf1" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtUcpf1" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGpf" runat="server" Text="GPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtGpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLic" runat="server" Text="L.I.C. :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLic" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtLic" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblIncomeTax" runat="server" Text="INCOME TAX :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIncomeTax" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtIncomeTax" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProfTax" runat="server" Text="PROF. TAX :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProfTax" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtProfTax" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRent" runat="server" Text="RENT :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRent" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="txtRent" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGpfArrear" runat="server" Text="GPF ARREAR :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGpfArrear" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="txtGpfArrear" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWc" runat="server" Text="W/C :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWc" runat="server" Width="124px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtWc" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStandardDeduction" runat="server" Text="STANDARD DEDUCTION :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStandardDeduction" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator55" runat="server" ControlToValidate="txtStandardDeduction" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                            <div style="float: right; width: 50%">
                                <table cellspacing="15px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSocSaving" runat="server" Text="SOCIETY SAVING :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSocSaving" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtSocSaving" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFurniture" runat="server" Text="FURNITURE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFurniture" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="txtFurniture" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGgs" runat="server" Text="GGS :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGgs" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="txtGgs" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGpInsurance" runat="server" Text="GROUP INSURANCE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGpInsurance" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ControlToValidate="txtGpInsurance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPmCmRelief" runat="server" Text="PM/CM RELIEF FUND :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPmCmRelief" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ControlToValidate="txtPmCmRelief" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEmpDeathHelp" runat="server" Text="EMPLOYEE DEATH HELP :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmpDeathHelp" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ControlToValidate="txtEmpDeathHelp" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOther" runat="server" Text="OTHER :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOther" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" ControlToValidate="txtOther" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCtd" runat="server" Text="CTD :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCtd" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" ControlToValidate="txtCtd" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRd" runat="server" Text="RD :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRd" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" ControlToValidate="txtRd" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnTotDeduction" runat="server" Text="TOTAL DEDUCTIONS" CssClass="btnCss" OnClick="btnTotDeduction_Click" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotDeduction" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewAdvRecovery" runat="server">
                        <div>
                            <div style="width: 50%; float: left;">
                                <div align="center">
                                    <asp:Label ID="lblAdvances" runat="server" Text="ADVANCES" Font-Bold="True" Font-Underline="True" Font-Size="Large"></asp:Label>
                                </div>
                                <table cellspacing="15px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCpf" runat="server" Text="CPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server" ControlToValidate="txtCpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFestival" runat="server" Text="FESTIVAL :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFestival" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ControlToValidate="txtFestival" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNcpf" runat="server" Text="NCPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNcpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ControlToValidate="txtNcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSociety" runat="server" Text="SOCIETY :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSociety" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ControlToValidate="txtSociety" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFood" runat="server" Text="FOOD :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFood" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ControlToValidate="txtFood" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblHousing" runat="server" Text="HOUSING :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHousing" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ControlToValidate="txtHousing" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblVehicle" runat="server" Text="VEHICLE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVehicle" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" ControlToValidate="txtVehicle" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnGovtBal" runat="server" Text="GOVT. BAL." CssClass="btnCss" OnClick="btnGovtBal_Click" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGovtBal" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 50%; float: right;">
                                <div align="center">
                                    <asp:Label ID="lblRecovery" runat="server" Text="RECOVERY" Font-Bold="True" Font-Underline="True" Font-Size="Large"></asp:Label>
                                </div>
                                <table cellspacing="15px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecCpf" runat="server" Text="CPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecCpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" ControlToValidate="txtRecCpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecFestival" runat="server" Text="FESTIVAL :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecFestival" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" ControlToValidate="txtRecFestival" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecNcpf" runat="server" Text="NCPF :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecNcpf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator49" runat="server" ControlToValidate="txtRecNcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecSociety" runat="server" Text="SOCIETY :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecSociety" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator50" runat="server" ControlToValidate="txtRecSociety" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecFoodGrain" runat="server" Text="FOOD GRAIN :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecFoodGrain" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator51" runat="server" ControlToValidate="txtRecFoodGrain" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecHousing" runat="server" Text="HOUSING :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecHousing" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator52" runat="server" ControlToValidate="txtRecHousing" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRecVehicle" runat="server" Text="VEHICLE :" CssClass="lblStyle"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecVehicle" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator53" runat="server" ControlToValidate="txtRecVehicle" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnRecGovtInst" runat="server" Text="GOVT. INST." CssClass="btnCss" OnClick="btnRecGovtInst_Click" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecGovInst" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>

    <table cellspacing="15px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    <br />
    <br />
    <br />

   <div style="height:20em; width:100%"></div>
    <div align="center" style="height: 15%; width: 100%">
        <div style="float: left; width: 50%">
            <div style="float: right; margin-right: 15px">
                <asp:Button ID="btnCalculate" runat="server" Text="CALCULATE" CssClass="btnCss" OnClick="btnCalculate_Click" />
            </div>
        </div>
        <div style="float: right; width: 50%">
            <div style="float: left; margin-left: 15px">
                 <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    </div>


</asp:Content>
