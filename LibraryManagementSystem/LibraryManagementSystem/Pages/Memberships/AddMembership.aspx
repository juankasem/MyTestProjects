<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Memberships/MembershipsMasterPage.Master" AutoEventWireup="true" CodeBehind="AddMembership.aspx.cs" Inherits="LibraryManagementSystem.Pages.Memberships.AddMembership1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="content" runat="server">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Library Membership Registration</h2>
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
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
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
                                <label for="lastName" class="labels">Last Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control TextFields" placeholder="Enter Last Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtLastName" CssClass="validators" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Last Name please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="lastName" class="labels">Nationality*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlNationalities" CssClass="form-cotrol TextFields" runat="server">
                                        <asp:ListItem>Select Nationality</asp:ListItem>
                                        <asp:ListItem>USA</asp:ListItem>
                                        <asp:ListItem>Russia</asp:ListItem>
                                        <asp:ListItem>Canada</asp:ListItem>
                                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                                        <asp:ListItem>Germany</asp:ListItem>
                                        <asp:ListItem>Great Britain</asp:ListItem>
                                        <asp:ListItem>Italy</asp:ListItem>
                                        <asp:ListItem>France</asp:ListItem>
                                        <asp:ListItem>Spain</asp:ListItem>
                                        <asp:ListItem>China</asp:ListItem>
                                        <asp:ListItem>Korea</asp:ListItem>
                                        <asp:ListItem>Belgium</asp:ListItem>
                                        <asp:ListItem>Portugal</asp:ListItem>
                                        <asp:ListItem>Argentina</asp:ListItem>
                                        <asp:ListItem>Brazil</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlNationalities" CssClass="validators" runat="server" ControlToValidate="ddlNationalities" ErrorMessage="Select Nationality please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="gender" class="labels">Gender*</label>
                                <div class="form-line">
                                    <asp:RadioButtonList ID="radBtnListGender" runat="server" CssClass="TextFields with-gap" RepeatDirection="Horizontal" ValidationGroup="Gender" Width="100%">
                                        <asp:ListItem Selected="True">Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <br />
                            </div>

                            <div class="form-group">
                                <label for="dateOfBirth" class="labels">Date Of Birth*</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">date_range</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox ID="txtDateOfBirth" runat="server" class="datepicker form-control TextFields" placeholder="Choose Date of Birth"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtDateOfBirth" CssClass="validators" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="Choose Date of Birth please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="photo" class="labels">Member Photo</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlPhotos" runat="server"></asp:DropDownList>
                                    <asp:FileUpload ID="fileUploadPhotos" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlPhotos" CssClass="validators" runat="server" ControlToValidate="ddlPhotos" Display="Dynamic" ErrorMessage="Select Member Photo please"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnUpload" CssClass="btn btn-default" runat="server" Text="Upload Photo" CausesValidation="false" OnClick="btnUpload_Click" />
                                <asp:Label ID="lblUploadResult" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Vertical Layout -->
            <%--Membership Card Info--%>

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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label for="membershipCardNo." class="labels">Library Membership Card No.*</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtLibraryCardNo" runat="server" class="form-control TextFields" Enabled="false" placeholder="Click on Button below to generate Membership Card Number"></asp:TextBox>
                                                </div>
                                                <asp:Button ID="btnGenerateCardNo" CssClass="btn btn-primary" runat="server" Text="Generate Card No." CausesValidation="false" OnClick="btnGenerateCardNo_Click" />
                                                <asp:RequiredFieldValidator ID="reqFldValtxtLibraryCardNo" CssClass="validators" runat="server" ControlToValidate="txtLibraryCardNo" ErrorMessage="Enter Library Card Number please"></asp:RequiredFieldValidator>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                            <asp:RadioButtonList ID="radBtnListMembershipDuration" runat="server" CssClass="TextFields with-gap" RepeatDirection="Horizontal" ValidationGroup="MembershipDuration" Width="100%" OnSelectedIndexChanged="radBtnListMembershipDuration_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Selected="True">6 Months</asp:ListItem>
                                                <asp:ListItem>1 Year</asp:ListItem>
                                                <asp:ListItem>18 Months</asp:ListItem>
                                                <asp:ListItem>2 Years</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <br />
                                    </div>

                                    <div class="row clearfix">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="validFromDate" class="labels">Membership Valid From Date*</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon">
                                                                <i class="material-icons">date_range</i>
                                                            </span>
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtValidFromDate" runat="server" class="datepicker form-control TextFields" placeholder="Enter Membership Valid From Date" AutoPostBack="true" Format="MMMM d, yyyy" OnTextChanged="txtValidFromDate_TextChanged"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="reqFldValtxtValidFromDate" CssClass="validators" runat="server" ControlToValidate="txtValidFromDate" ErrorMessage="Enter Membership Valid From Date please"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="expirationDate" class="labels">Membership Expiration Date*</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon">
                                                                <i class="material-icons">date_range</i>
                                                            </span>
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtExpirationDate" runat="server" class="datepicker form-control TextFields" placeholder="Enter Expiry Date" Format="MMMM d, yyyy" Enabled="false" ></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
        </div>
        </div>
                    </div>

                    <%--Member Contact Info--%>
                    <!-- Vertical Layout -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Member Contact Info
                                    </h2>
                                    <ul class="header-dropdown m-r--5">
                                        <li class="dropdown">
                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
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
                                        <label for="phone" class="labels">Phone Number*</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">phone*</i>
                                            </span>
                                            <div class="form-line">
                                                <asp:TextBox ID="txtPhone" runat="server" class="form-control TextFields" placeholder="Enter Phone Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtPhone" CssClass="validators" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Enter Phone Number"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regExpValtxtPhone" CssClass="validators" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" ErrorMessage="Enter a valid Phone Number please."></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <label for="email" class="labels">Email Address*</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">email</i>
                                            </span>
                                            <div class="form-line">
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control TextFields" placeholder="Enter Email Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtEmail" CssClass="validators" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Email Address please"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regExpValtxtEmail" CssClass="validators" runat="server" ErrorMessage="Enter a Valid Email Address Please." ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <label for="address" class="labels">Home/Work Address</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtAddress" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Address"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false">
                                        <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                                        <p>
                                           <strong>Well done!...</strong>a new membership of Member Name:
                                            <asp:Label ID="lblMemberName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            with Library card No:<asp:Label ID="lblcardNumber" runat="server" Text=""></asp:Label>
                                            has been created successfully!...
                                        </p>
                                    </div>

                                    <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false">
                                        <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                                        <p><strong>Sorry!...</strong>This membership does already exists </p>
                                        <div>
                                            <asp:LinkButton ID="lnkBtnRenew" runat="server" Text="Click Here to Renew Membership" BorderStyle="None" BackColor="White" ForeColor="#003399" Visible="false" CausesValidation="false" Font-Bold="True"></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="btnSave" CssClass="btn btn-primary m-t-15 waves-effect" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </div>
    </section>

    <!-- #END# Vertical Layout -->
</asp:Content>
