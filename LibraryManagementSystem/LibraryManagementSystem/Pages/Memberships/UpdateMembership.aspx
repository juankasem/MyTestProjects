<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Memberships/MembershipsMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMembership.aspx.cs" Inherits="LibraryManagementSystem.Pages.Memberships.UpdateMembership1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content" runat="server" >
        <div class="container-fluid">
            <div class="block-header">
                <h2>Update Membership</h2>
            </div>
            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>Basic Member Info
                            </h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="#">Action</a></li>
                                        <li><a href="#">Another action</a></li>
                                        <li><a href="#">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="body">
                            <div class="form-group">
                                <label for="firstName" class="labels">First Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control TextFields" placeholder="Enter First Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtFirstName" CssClass="validators" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="middleName" class="labels">Middle Name</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtMiddleName" runat="server" class="form-control TextFields" placeholder="Enter Middle Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="lastName" class="labels">Last Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control TextFields" placeholder="Enter Last Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtLastName" CssClass="validators" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Last Name please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="dateofBirth" class="labels">Date of Birth*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtDateOfBirth" runat="server" class="form-control TextFields" placeholder="Enter Date of Birth"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="Enter Date of Birth please"></asp:RequiredFieldValidator>
                                <asp:CalendarExtender ID="calExtDateOfBirth" CssClass="validators" runat="server" TargetControlID="txtDateOfBirth" Format="MMMM d, yyyy"></asp:CalendarExtender>
                            </div>

                            <div class="form-group">
                                <label for="gender" class="labels">Gender</label>
                                <div class="form-line">
                                    <asp:RadioButtonList ID="radBtnListGender" CssClass="TextFields" runat="server" ValidationGroup="Gender" RepeatDirection="Horizontal" Width="50%">
                                        <asp:ListItem> Male</asp:ListItem>
                                        <asp:ListItem> Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="photo" class="labels">Member Photo</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlPhotos" runat="server"></asp:DropDownList>
                                    <asp:FileUpload ID="fileUploadPhoto" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValfilUplPhoto" CssClass="validators" runat="server" ControlToValidate="fileUploadPhoto" Display="Dynamic" ErrorMessage="Select Member Photo please"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnUpload" CssClass="btn btn-default" runat="server" Text="Upload Photo" CausesValidation="false" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <%--Membership Card Info--%>
            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>Library Membership Card Info
                            </h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="#">Action</a></li>
                                        <li><a href="#">Another action</a></li>
                                        <li><a href="#">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                        <div class="body">
                            <div class="form-group">
                                <label for="membershipCardNo." class="labels">Library Membership Card No.*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtLibraryCardNo" runat="server" class="form-control TextFields" placeholder="Click on Button below to generate Membership Card Number"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnGenerateCardNo" CssClass="btn btn-primary" runat="server" Text="Generate Card No." CausesValidation="false" />
                                <asp:RequiredFieldValidator ID="reqFldValtxtLibraryCardNo" CssClass="validators" runat="server" ControlToValidate="txtLibraryCardNo" ErrorMessage="Enter Library Card Number please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="membershipType" class="labels">Membership Type*</label>
                                <div class="form-line">
                                    <asp:RadioButtonList ID="radBtnMembershipType" runat="server" CssClass="TextFields with-gap" RepeatDirection="Horizontal" ValidationGroup="MembershipType" Width="100%">
                                        <asp:ListItem Selected="True">Individual</asp:ListItem>
                                        <asp:ListItem>Family</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <br />
                            </div>

                            <div class="form-group">
                            <label for="duration" class="labels">Membership Duration*</label>
                            <div class="form-line">
                                <asp:RadioButtonList ID="rsdBtnLstDuration" runat="server" CssClass="TextFields with-gap" RepeatDirection="Horizontal" ValidationGroup="MembershipDuration" Width="100%">
                                    <asp:ListItem Selected="True">6 Months</asp:ListItem>
                                    <asp:ListItem>1 Year</asp:ListItem>
                                    <asp:ListItem>18 Months</asp:ListItem>
                                    <asp:ListItem>2 Years</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <br />
                        </div>

                        <div class="row clearfix">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="issueDate" class="labels">Membership Valid From Date*</label>
                                    <div class="form-line">
                                        <asp:TextBox ID="txtValidFromDate" runat="server" class="datepicker form-control TextFields" placeholder="Enter Membership Valid From Date"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="reqFldValtxtCardIssueingDate" CssClass="validators" runat="server" ControlToValidate="txtValidFromDate" ErrorMessage="Enter Membership Valid From Date please"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="expirationDate" class="labels">Membership Expiration Date*</label>
                                    <div class="form-line">
                                        <asp:TextBox ID="txtExpirationDate" runat="server" class="form-control TextFields" placeholder="Enter Expiry Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
              <%--Membership Card Info--%>
            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2> Member Contact Info
                            </h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);">Action</a></li>
                                        <li><a href="javascript:void(0);">Another action</a></li>
                                        <li><a href="javascript:void(0);">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="body">
                            <label for="phone" class="labels">Phone Number</label>
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control TextFields" placeholder="Enter Phone Number"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Enter Membership Card ID"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regExpValtxtPhone" runat="server" CssClass="labels" ControlToValidate="txtPhone" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" ErrorMessage="Enter a valid Phone Number please." ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>

                            <label for="email" class="labels">Email Address</label>
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control TextFields" placeholder="Enter Email Address"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email Address please"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="regExpValtxtEmail" runat="server" ErrorMessage="Enter a Valid Email Address Please." ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ForeColor="Red"></asp:RegularExpressionValidator>
                         
                                </div>

                             <label for="address" class="labels">Home/Work Address</label>
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Address"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Enter Address please"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Button ID="Button1" CssClass="btn btn-primary m-t-15 waves-effect" runat="server" Text="Save" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>


