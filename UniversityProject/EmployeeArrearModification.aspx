<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="EmployeeArrearModification.aspx.cs" Inherits="UniversityProject.EmployeeArrearModification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!--<link rel="stylesheet" type="text/css" href="UniStyle.css" />-->
    <style>
        .btn {
            display: block;
            padding: 12px;
            color: white;
            cursor: pointer;
            width: auto;
            text-align: center;
            text-decoration: none;
            float: left;
            margin: 0px;
            top: 0px;
        }

        .lblStyle {
            font-family: "Lucida Fax","Times New Roman";
            color: #00688b;
        }

        .HeadLabel {
            font-size: x-large;
            font-family: sans-serif;
            font-family: SimSun;
        }

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
    </style>

    <div style="height: 20%">

        <div style="float: right; width: 50%; text-decoration: underline; height: 50%">
            <div align="center">
                <asp:label id="lblEmpInfo" runat="server" text="EMPLOYEE ARREAR MODIFICATION" cssclass="HeadLabel"></asp:label>
            </div>
        </div>
        <div style="float: right; width: 50%;">
            <div style="width: 45%; float: right; display: block">
            </div>
            <div style="width: 55%; float: left;">
                <table>
                    <tr>
                        <td>
                            <asp:label id="lblEmpID" runat="server" text="EMPLOYEE ID :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td style="width: 80px">
                            <asp:label id="ShowEmpId" runat="server" text="Label"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 80px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="width: 80px">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>

        <div>
            <!-- this tag is around employee details and earnings,deduction,advrec-->
            <div style="float: left; width: 50%; height: 65%">
                <asp:label id="lblEmpDeatails" runat="server" text="EMPLOYEE'S DETAILS :" cssclass="HeadLabel"></asp:label>

                <table cellspacing="17px" style="border: medium solid #C0C0C0;">
                    <tr>
                        <td>
                            <asp:label id="lblName" runat="server" text="NAME :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtName" runat="server"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtName" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                            <asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" controltovalidate="txtName" validationexpression="[a-zA-Z ]*$" errormessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblDesignation" runat="server" text="DESIGNATION :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtDesignation" runat="server"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtDesignation" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                            <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" controltovalidate="txtDesignation" validationexpression="[a-zA-Z ]*$" errormessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblDepartment" runat="server" text="DEPARTMENT :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtDept" runat="server"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtDept" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                            <asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" controltovalidate="txtDept" validationexpression="[0-9]+" errormessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblFac" runat="server" text="FACULTY :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtFac" runat="server"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtFac" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                            <asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" controltovalidate="txtFac" validationexpression="[0-9]+" errormessage="Enter Alphabets and space." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblBill" runat="server" text="BILL NO :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtBill" runat="server"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="txtBill" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                            <asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" controltovalidate="txtBill" validationexpression="[0-9]+" errormessage="Enter Alphabets only." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblRateOfPay" runat="server" text="RATE OF PAY :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtRateOfPay" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblEffectiveDays" runat="server" text="EFFECTIVE DAYS :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtEffectiveDays" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblMonth" runat="server" text="MONTH :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:label id="ShowMonth" runat="server" text="Label"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="lblYear" runat="server" text="YEAR :" cssclass="lblStyle"></asp:label>
                        </td>
                        <td>
                            <asp:label id="ShowYear" runat="server" text="Label"></asp:label>
                        </td>
                    </tr>
                </table>
                <div id="NetPayDiv" runat="server">
                    <table style="border: medium solid #C0C0C0;">
                        <tr>
                            <td>
                                <asp:label id="lblGrossPay" runat="server" text="GROSS PAY:" cssclass="lblStyle"></asp:label>
                            </td>
                            <td>
                                <asp:textbox id="txtGrossPay" runat="server"></asp:textbox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:label id="lblNetDeduction" runat="server" text="NET DEDUCTIONS :" cssclass="lblStyle"></asp:label>
                            </td>
                            <td>
                                <asp:textbox id="txtNetDeduction" runat="server"></asp:textbox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:label id="lblNetPay" runat="server" text="NET PAY :" cssclass="lblStyle"></asp:label>
                            </td>
                            <td>
                                <asp:textbox id="txtNetPay" runat="server"></asp:textbox>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <div style="float: right; width: 50%; height: 65%">

                <div align="center" style="width: auto; text-decoration: none; display: inline;">
                    <ul style="width: 60%; text-decoration: none; display: inline; list-style: none;">
                        <li style="text-decoration: none">
                            <asp:button id="btnEarning" runat="server" text="EARNINGS" backcolor="#30415d" cssclass="btn" onclick="btnEarning_Click" causesvalidation="false" />
                        </li>
                        <li style="text-decoration: none">
                            <asp:button id="btnDeduction" runat="server" text="DEDUCTIONS" backcolor="#30415d" cssclass="btn" onclick="btnDeduction_Click" causesvalidation="false" />
                        </li>
                        <li style="text-decoration: none">
                            <asp:button id="btnAdvRec" runat="server" text="ADV. & RECOVERY" backcolor="#30415d" cssclass="btn" onclick="btnAdvRec_Click" causesvalidation="false" />
                        </li>
                    </ul>
                </div>
                <br />
                <br />
                <br />

                <div style="border: medium solid #C0C0C0">
                    <asp:multiview id="MultiView1" runat="server" activeviewindex="0">
               <asp:View ID="ViewEarning" runat="server">
                   <div>   
                   <div style="float:left; width:50%">
                   <table cellspacing="21px">
                       <tr>
                           <td>
                               <asp:Label ID="lblBasic" runat="server" Text="BASIC :" CssClass="lblStyle"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtBasic" runat="server"></asp:TextBox>
                           </td>
                           <td>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="This is a required field" ControlToValidate="txtBasic"></asp:RequiredFieldValidator>
                           </td>
                           <td>
                                <asp:RegularExpressionValidator runat="server" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ControlToValidate="txtBasic"></asp:RegularExpressionValidator>
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
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDa" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtHra" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCla" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtSpAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator ID="RegularExpressionValijjjator6" runat="server" ControlToValidate="txtLtcEncashment" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" />
                           </td>
                       </tr>
                   </table>
                   </div>
                   <div style="float:right; width:50%">
                       <table cellspacing="15px">
                           <tr>
                               <td>
                                   <asp:Label ID="lblConveyAllowance" runat="server" Text="CONVEYANCE ALLOWANCE :" CssClass="lblStyle"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtConveyAllowance" runat="server"></asp:TextBox>
                               </td>
                               <td>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtConveyAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtExamAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtWasgAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMedAllowance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtAdhoc" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDp" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:Button ID="btnTotEarning" runat="server" Text="TOTAL EARNINGS" CssClass="btnCss" OnClick="btnTotEarning_Click" CausesValidation="false" />
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
               <div style="float:left; width:50%">
                   <table cellspacing="15px">
                       <tr>
                           <td>
                               <asp:Label ID="lblPf" runat="server" Text="P.F. :" CssClass="lblStyle"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtPf" runat="server"></asp:TextBox>
                            </td>
                           <td>
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUcpf1" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtGpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLic" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtIncomeTax" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtProfTax" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRent" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtGpfArrear" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                           </td>
                       </tr>
                       <tr>
                           <td>
                               <asp:Label ID="lblWc" runat="server" Text="W/C :" CssClass="lblStyle"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtWc" runat="server"></asp:TextBox>
                            </td>
                           <td>
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtWc" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                           </td>
                       </tr>
                       <tr>
                           <td>

                           </td>
                       </tr>
                       <tr>
                           <td>

                           </td>
                       </tr>
                   </table>
               </div>    
               <div style="float:right; width:50%">
                   <table cellspacing="15px">
                       <tr>
                           <td>
                               <asp:Label ID="lblSocSaving" runat="server" Text="SOCIETY SAVING :" CssClass="lblStyle"></asp:Label>
                           </td>
                           <td>
                               <asp:TextBox ID="txtSocSaving" runat="server"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtSocSaving" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFurniture" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtGgs" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtGpInsurance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPmCmRelief" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmpDeathHelp" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtOther" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCtd" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRd" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                           </td>
                       </tr>
                   </table>
               </div>
               </div>
                   <div align="center">
                   <table>
                       <tr>
                           <td>
                               <asp:Button ID="btnTotDeduction" runat="server" Text="TOTAL DEDUCTIONS" CssClass="btnCss" OnClick="btnTotDeduction_Click" CausesValidation="false" />
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
                   <div style="width:50%; float:left;">
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFestival" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtSociety" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFood" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtHousing" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtVehicle" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                   <div style="width:50%; float:right;">
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecCpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecFestival" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecNcpf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecSociety" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecFoodGrain" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecHousing" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
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
                                   <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecVehicle" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Button ID="btnRecGovtInst" runat="server" Text="GOVT. INST." CssClass="btnCss" OnClick="btnRecGovtInst_Click"  CausesValidation="false"/>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtRecGovInst" runat="server"></asp:TextBox>
                               </td>
                           </tr>
                       </table>
                   </div>
               </div>
              </asp:View>
            </asp:multiview>
                </div>

            </div>
        </div>

        <br />
        <br />
        <br />
        <br />
    </div>
    <br />
    <div style="height:48em; width:100%"></div>
    <div align="center" style="height: 15%; width: 100%;">
        <div style="float: left; width: 50%">
            <div style="float: right; margin-right: 15px">
                    <asp:button id="btnCalculate" runat="server" text="CALCULATE" onclick="btnCalculate_Click" cssclass="btnCss" />
            </div>
        </div>
        <div style="float: right; width: 50%">
            <div style="float: left; margin-left: 15px">
                    <asp:button id="btnCancel" runat="server" text="CANCEL" onclick="btnCancel_Click" cssclass="btnCss" causesvalidation="false" />
            </div>
        </div>
    </div>




</asp:Content>
