<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Genres/GenreMasterPage.Master" AutoEventWireup="true" CodeBehind="AddGenre.aspx.cs" Inherits="LibraryManagementSystem.Pages.Genres.AddGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../../Scripts/jquery-3.2.1.js"></script>
  <script type="text/javascript" >
      $(document).ready(function () {
          $('#<%=txtGenreName.ClientID%>').focus(function () {
              $('#divSuccess').hide();
              $('#divFail').hide();
          });
          $('#<%=txtDescription.ClientID%>').focus(function () {
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
                <h2>Add New Genre</h2>
            </div>

            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Genre Details
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
                            <div class="form-group">
                                <label for="genreName" class="labels">Genre Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtGenreName" runat="server" class="form-control TextFields" placeholder="Enter Genre Name" ></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtGenreName" CssClass="validators" runat="server" ControlToValidate="txtGenreName" ErrorMessage="Enter Genre Name"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="description" class="labels">Description</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Description"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false" >
                                <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                                <p>
                                    <strong>Well done!...</strong>a new Genre: <asp:Label ID="lblNewGenre" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    has been added successfully!...
                                </p>
                            </div>

                            <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false">
                                <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                                <p><strong>Sorry!...</strong>This genre does already exists </p>
                            </div>

                            <div class="form-group">
                           <asp:Button ID="btnSaveGenre" CssClass="btn btn-primary m-t-15 waves-effect" runat="server" Text="Save" OnClick="btnSaveGenre_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>

