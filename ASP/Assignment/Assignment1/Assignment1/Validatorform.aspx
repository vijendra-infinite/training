﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validatorform.aspx.cs" Inherits="Assignment1.Validatorform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function checkDetails() {
            var name = document.getElementById("nameTextBox").value;
            var familyName = document.getElementById("familyNameTextBox").value;
            var address = document.getElementById("addressTextBox").value;
            var city = document.getElementById("cityTextBox").value;
            var zipCode = document.getElementById("zipCodeTextBox").value;
            var phone = document.getElementById("phoneTextBox").value;
            var email = document.getElementById("emailTextBox").value;
            var errors = [];

            // Client-side validation
            if (name.trim() === '') {
                errors.push("Name is required.");
                document.getElementById("nameValidator").style.display = "inline";
            } else {
                document.getElementById("nameValidator").style.display = "none";
            }
            if (familyName.trim() === '') {
                errors.push("Family name is required.");
                document.getElementById("familyNameValidator").style.display = "inline";
            } else {
                document.getElementById("familyNameValidator").style.display = "none";
            }
            if (familyName.trim() === name.trim()) {
                errors.push("Family name should differ from Name.");
            }
            if (address.trim().length < 2) {
                errors.push("Address should be at least 2 characters.");
                document.getElementById("addressValidator").style.display = "inline";
            } else {
                document.getElementById("addressValidator").style.display = "none";
            }
            if (city.trim().length < 2) {
                errors.push("City should be at least 2 characters.");
                document.getElementById("cityValidator").style.display = "inline";
            } else {
                document.getElementById("cityValidator").style.display = "none";
            }
            if (!/^\d{5}$/.test(zipCode)) {
                errors.push("Zip code should be 5 digits.");
                document.getElementById("zipCodeValidator").style.display = "inline";
            } else {
                document.getElementById("zipCodeValidator").style.display = "none";
            }
            if (!/^\d{2}-\d{7}$/.test(phone) && !/^\d{3}-\d{7}$/.test(phone)) {
                errors.push("Phone number should be in the format XX-XXXXXXX or XXX-XXXXXXX.");
                document.getElementById("phoneValidator").style.display = "inline";
            } else {
                document.getElementById("phoneValidator").style.display = "none";
            }
            if (!/\S+@\S+\.\S+/.test(email)) {
                errors.push("Email is invalid.");
                document.getElementById("emailValidator").style.display = "inline";
            } else {
                document.getElementById("emailValidator").style.display = "none";
            }

            var errorList = document.getElementById("errorList");
            errorList.innerHTML = "";
            if (errors.length > 0) {
                errors.forEach(function (error) {
                    var li = document.createElement("li");
                    li.textContent = error;
                    errorList.appendChild(li);
                });
                alert("Validation Errors:\n" + errors.join("\n"));
                return false;
            }
            return true; 
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>Insert Your Details:</h3>
        
       Name: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nameValidator" runat="server" ErrorMessage="Name is Required" ControlToValidate="nameTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>

        <br />
        <br />
        
        Family Name: &nbsp; &nbsp;&nbsp; <asp:TextBox ID="familyNameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="familyNameValidator" runat="server" ErrorMessage="Enter Family Name" ControlToValidate="familyNameTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidatorFamilyName" runat="server" ControlToValidate="familyNameTextBox" ControlToCompare="nameTextBox" Operator="NotEqual" ErrorMessage="Family name should differ from Name." ForeColor="Red"  ValidationGroup="regngrp"></asp:CompareValidator>

        <br />
        <br />
        
        Address: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addressValidator" runat="server" ErrorMessage="Enter Address" ControlToValidate="addressTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorAddress" runat="server" ErrorMessage="Address should have at least 2 characters." ControlToValidate="addressTextBox" ValidationExpression="^.{2,}$" ForeColor="Red"  ValidationGroup="regngrp"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        City: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="cityValidator" runat="server" ErrorMessage="Enter City" ControlToValidate="cityTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCity" runat="server" ErrorMessage="City should have at least 2 characters." ControlToValidate="cityTextBox" ValidationExpression="^.{2,}$" ForeColor="Red"  ValidationGroup="regngrp"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        Zip Code: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="zipCodeTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="zipCodeValidator" runat="server" ErrorMessage="*" ControlToValidate="zipCodeTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorZipCode" runat="server" ErrorMessage="Zip-code should be 5 digits." ControlToValidate="zipCodeTextBox" ValidationExpression="^\d{5}$" ForeColor="Red"  ValidationGroup="regngrp"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        Phone: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="phoneValidator" runat="server" ErrorMessage="*" ControlToValidate="phoneTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ErrorMessage="Phone should be in the format XX-XXXXXXXX or XXX-XXXXXXX." ControlToValidate="phoneTextBox" ValidationExpression="^\d{2,3}-?\d{7}$" ForeColor="Red"  ValidationGroup="regngrp"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        E-Mail: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ErrorMessage="*" ControlToValidate="emailTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Invalid Email Format." ControlToValidate="emailTextBox" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ForeColor="Red"  ValidationGroup="regngrp"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        <asp:ValidationSummary ID="validationSummary" runat="server" ForeColor="Red" ValidationGroup="regngrp"/>
        
        <asp:Label ID="lbl" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        
        <asp:Button ID="submitButton" runat="server" Text="Check" Style="float: right;" OnClientClick="return checkDetails();" ValidationGroup="regngrp" OnClick="btnSubmit_Click" Height="59px" Width="174px" />
        
        <ul id="errorList" style="color: red;"></ul>
    </form>
</body>
</html>