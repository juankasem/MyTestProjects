<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagementSystem.Pages.UserAccounts.Login" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Login Page | Bootstrap Based Admin Template - Material Design</title>
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

</head>

<body class="login-page">
    <div class="login-box">
        <div class="logo">
            <a href="javascript:void(0);">Admin<b>BSB</b></a>
            <small>Admin BootStrap Based - Material Design</small>
        </div>
        <div class="card">
            <div class="body">
                <form id="sign_in" method="POST" runat="server">
                    <div class="msg"><h2>Sign in to start your session</h2></div>
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
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtPassword" CssClass="form-control TextFields" runat="server" TextMode="Password" placeholder="Password" onfocus="HideMessage()"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="reqFldValtxtPassword" CssClass="validators" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password please"></asp:RequiredFieldValidator>
                    </div>

                    <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false" >
                        <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                        <p><strong>Sorry!...</strong>Invalid Username/Password. </p>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                            <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
                        </div>
                        <div class="col-xs-4">
                         <asp:Button ID="btnLogin" CssClass="btn btn-block bg-pink waves-effect" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
                        <div class="col-xs-6">
                            <a href="SignUp.aspx">Register Now!</a>
                        </div>
                        <div class="col-xs-6 align-right">
                            <a href="ForgotPassword.aspx">Forgot Password?</a>
                        </div>
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
    <script src="../../bootstrapAdminTemplate/js/pages/examples/sign-in.js"></script>
     <!-- Custom Js -->
    <script type="text/javascript">
        function HideMessage() {
            document.getElementById("divFail").hidden = true;
        }
    </script>
</body>

</html>
