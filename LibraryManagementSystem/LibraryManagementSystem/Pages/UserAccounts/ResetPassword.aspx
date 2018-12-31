<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="LibraryManagementSystem.Pages.UserAccounts.ResetPassword" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Reset Password Page | Bootstrap Based Admin Template - Material Design</title>
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

<body class="fp-page">
    <div class="fp-box">
        <div class="logo">
            <a href="javascript:void(0);">Admin<b>BSB</b></a>
            <small>Admin BootStrap Based - Material Design</small>
        </div>
        <div class="card">
            <div class="body">
                <form id="forgot_password" method="POST" runat="server">
                    <div class="msg">
                        <h2>Reset Password
                        </h2>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtPassword" CssClass="form-control TextFields" runat="server" TextMode="Password" placeholder="New Password"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="reqFldValtxtPassword" CssClass="validators" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password please"></asp:RequiredFieldValidator>
                    </div>

                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtConfirmPassword" CssClass="form-control TextFields" runat="server" TextMode="Password" placeholder="Confirm New Password"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="reqFldValtxtConfirmPPassword" CssClass="validators" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Confirm New Password please"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comValPassword" CssClass="validators" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
                    </div>

                      <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false">
                        <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                        <p>
                            <strong>Well done!...</strong>Your Password 
                            has been reset successfully!...
                        </p>
                     </div>

                    <div class="form-group alert alert-danger" runat="server" id="divFail" visible="false">
                        <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                        <p><strong>Sorry!...</strong>Sorry!...Your Password link is expired or Invalid! </p>
                    </div>
                    <div class="form-group">
                       <asp:Button ID="btnSave" CssClass="btn btn-block bg-pink waves-effect" runat="server" Text="Save My New Password" OnClick="btnSave_Click"/>
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

