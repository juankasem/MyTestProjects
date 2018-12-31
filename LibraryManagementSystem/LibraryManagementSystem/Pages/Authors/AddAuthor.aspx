<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Authors/AuthorMaster.Master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="LibraryManagementSystem.Pages.Authors.AddAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add New Author</title>
    <script src="../../Scripts/jquery-3.2.1.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $('#<%=txtFirstName.ClientID%>').focus(function () {
              $('#divSuccess').hide();
              $('#divFail').hide();
          });
          $('#<%=txtLastName.ClientID%>').focus(function () {
              $('#divSuccess').hide();
              $('#divFail').hide();
          });
      });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Add New Author</h2>
            </div>

            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Author Details
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
                                <asp:RequiredFieldValidator ID="reqFldValtxtFirstName" CssClass="validators" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name please" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                            <label for="lastName" class="labels">Last Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control TextFields" placeholder="Enter Last Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtLastName" CssClass="validators" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Last Name please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                            <label for="origin" class="labels">Origin Country*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlCountries" class="form-control TextFields show-tick" runat="server">
                                        <asp:ListItem>Select Origin Country</asp:ListItem>
                                        <asp:ListItem>United States</asp:ListItem>
                                        <asp:ListItem>United Kingdom</asp:ListItem>
                                        <asp:ListItem>Russia</asp:ListItem>
                                        <asp:ListItem>France</asp:ListItem>
                                        <asp:ListItem>Germany</asp:ListItem>
                                        <asp:ListItem>Spain</asp:ListItem>
                                        <asp:ListItem>Japan</asp:ListItem>
                                        <asp:ListItem>Italy</asp:ListItem>
                                        <asp:ListItem>Greece</asp:ListItem>
                                        <asp:ListItem>Egypt</asp:ListItem>
                                        <asp:ListItem>Lebanon</asp:ListItem>
                                        <asp:ListItem>Switzerland</asp:ListItem>
                                        <asp:ListItem>Syria</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlCountries" CssClass="validators" runat="server" ControlToValidate="ddlCountries" ErrorMessage="Select Origin Country please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                            <label for="photo" class="labels">Author Photo</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlPhotos" runat="server"></asp:DropDownList>
                                    <asp:FileUpload ID="filUplPhoto" runat="server" />
                                </div>
                                <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload Photo" CausesValidation="false" OnClick="btnUploadPhoto_Click" />
                                <asp:Label ID="lblUploadResult" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                            <label for="biography" class="labels">Biography</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtBiography" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Biography"></asp:TextBox>
                                </div>
                            </div>
                              <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false">
                                <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                                <p>
                                    <strong>Well done!...</strong>a new author: <asp:Label ID="lblNewAuthor" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    has been added successfully!...
                                </p>
                            </div>

                            <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false">
                                <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                                <p><strong>Sorry!...</strong>The author does already exists </p>
                            </div>
                            <div class="form-group js-sweetalert">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary waves-effect" runat="server" Text="Save" data-type="confirm" OnClick="btnSave_Click"   />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>
