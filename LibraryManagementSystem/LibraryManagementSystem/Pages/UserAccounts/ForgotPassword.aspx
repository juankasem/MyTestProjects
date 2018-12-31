<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LibraryManagementSystem.Pages.UserAccounts.ForgotPassword1" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Forgot PasswordPage  | Bootstrap Based Admin Template - Material Design</title>
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
              document.getElementById("divFail").hidden = true;
        }
    </script>
</head>

<body class="fp-page">
    <div class="fp-box">
        <div class="logo">
            <a href="javascript:void(0);">Admin<b>BSB</b></a>
            <small>Admin BootStrap Based - Material Design</small>
        </div>
        <div class="card">
            <div class="body">
                <form id="forgot_password" method="POST" runat="server">
                    <div class="msg labels">
                        Enter your Email address that you used to register. We'll send you an email with your Username and a
                        link to reset your Password.
                                    
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
                    <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false" >
                        <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                        <p><strong>Sorry!...</strong>Invalid Email Address. </p>
                    </div>
                    <div class="form-group">
                    <asp:Button ID="btnResetPassword" CssClass="btn btn-block bg-pink waves-effect" runat="server" Text="Reset My Password"  OnClick="btnResetPassword_Click" />
                    </div>
                    <div class="row m-t-20 m-b--5 align-center">
                        <a href="Login.aspx">Login!</a>
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
    <script src="../../bootstrapAdminTemplate/js/pages/examples/forgot-password.js"></script>
</body>

</html>

