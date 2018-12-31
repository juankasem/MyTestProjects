<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LibraryManagementSystem.Pages.UserAccounts.SignUp" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Register New Account Page | Bootstrap Based Admin Template - Material Design</title>
    <!-- Favicon-->
    <link rel="icon" href="../../bootstrapAdminTemplate/favicon.ico" type="image/x-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

    <!-- Bootstrap Core Css -->
    <link href="../../bootstrapAdminTemplate/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <!-- Waves Effect Css -->
    <link href="../../bootstrapAdminTemplate/plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="../../bootstrapAdminTemplate/plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../../bootstrapAdminTemplate/css/style.css" rel="stylesheet">
    
    <!-- Custom Css -->
   <link href="../../Styles/StyleSheet.css" rel="stylesheet" />
    <script type="text/javascript">
        function HideMessage() {
            document.getElementById("divSuccess").hidden= true;
            document.getElementById("divFail").hidden = true;
          }

          function CheckPasswordStrength() {
              var passwordTextBox = document.getElementById("txtPassword");
              var password = passwordTextBox.value;
              var specialCharacters = "!@#$%^&*+?_~";
              var passwordScore = 0;

              for (i = 0; i < password.length; i++) {
                  if (specialCharacters.indexOf(password.charAt(i)) > -1) {
                      passwordScore += 20;
                      break;
                  }
              }
                  if (/[a-z]/.test(password)) {
                      passwordScore += 20;
                  }
                  if (/[A-Z]/.test(password)) {
                      passwordScore += 20;
                  }

                  if (/[\d]/.test(password)) {
                      passwordScore += 20;
                  }

                  if (password.length >= 6) {
                      passwordScore += 20;
                  }
                  var strength = "";
                  var backgroundColor = "";

                  if (passwordScore >= 100) {
                      strength = "Strong";
                      backgroundColor = "Green"
                  }
                  else if (passwordScore >= 80) {
                      strength = "Medium";
                      backgroundColor = "grey"
                  }
                  else if (passwordScore >= 60) {
                      strength = "Weak";
                      backgroundColor = "Maroon"
                  }
                  else {
                      strength = "Very Weak";
                      backgroundColor = "Red"
                  }
                  document.getElementById("lblPasswordStrength").innerText ="Password strength is: "+ strength;
                  passwordTextBox.style.color = "white";
                  passwordTextBox.style.backgroundColor = backgroundColor;
              }
    </script>
</head>

<body class="signup-page">
    <div class="signup-box">
        
    <div class="logo">
    <a href="javascript:void(0);">Admin<b>BSB</b></a>
    <small>Library Management System</small>
    </div>
    <div class="card">
        <div class="body">
            <form id="sign_up" method="POST" runat="server">
                <div class="msg"><h2>Register a new account</h2></div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">person</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox ID="txtUsername" CssClass="form-control TextFields" runat="server" placeholder="Username" onfocus="HideMessage()"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="reqFldValtxtUsername" CssClass="validators" runat="server" ControlToValidate="txtUsername" ErrorMessage="Enter Username please"></asp:RequiredFieldValidator>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">email</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox ID="txtEmail" CssClass="form-control TextFields" runat="server" placeholder="Email address" onfocus="HideMessage()"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="reqFldValtxtEmail" CssClass="validators" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Email address please"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpValtxtEmail" CssClass="validators" runat="server" ErrorMessage="Enter a Valid Email Address Please." ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                </div>

                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox ID="txtPassword" CssClass="form-control TextFields" runat="server" TextMode="Password" placeholder="Password" onfocus="HideMessage()" onkeyup="CheckPasswordStrength()"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblPasswordStrength" runat="server" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="reqFldValtxtPassword" CssClass="validators" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password please"></asp:RequiredFieldValidator>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox ID="txtConfirmPassword" CssClass="form-control TextFields" runat="server" TextMode="Password" placeholder="Confirm Password" onfocus="HideMessage()" ></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="reqFldValtxtConfirmPassword" CssClass="validators" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Confirm Password please"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="comValPassword" CssClass="validators" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
                </div>
                <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false" >
                    <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                    <p>
                        <strong>Well done!...</strong>a new user with Username: <asp:Label ID="lblNewUser" runat="server" Text="" Font-Bold="true"></asp:Label>
                        has been registered successfully!...
                    </p>
                </div>

                <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false" >
                    <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                    <p><strong>Sorry!...</strong>The Username/Email address is already in use. </p>
                </div>

                <div class="form-group">
                    <input type="checkbox" name="terms" id="terms" class="filled-in chk-col-pink">
                    <label for="terms">I read and agree to the <a href="javascript:void(0);">terms of usage</a>.</label>
                </div>
                <div class="form-group">
                  <asp:Button ID="btnRegister" CssClass="btn btn-block bg-pink waves-effect TextFields" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </div>
                <div class="m-t-25 m-b--5 align-center">
                    <a href="Login.aspx">You already have an account?</a>
                </div>
            </form>
        </div>
    </div>
    </div>

    <!-- Jquery Core Js -->
    <script src="../../bootstrapAdminTemplate/plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="../../bootstrapAdminTemplate/plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="../../bootstrapAdminTemplate/plugins/node-waves/waves.js"></script>

    <!-- Validation Plugin Js -->
    <script src="../../bootstrapAdminTemplate/plugins/jquery-validation/jquery.validate.js"></script>

    <!-- Custom Js -->
    <script src="../../bootstrapAdminTemplate/js/admin.js"></script>
    <script src="../../bootstrapAdminTemplate/js/pages/examples/sign-up.js"></script>
</body>

</html>

