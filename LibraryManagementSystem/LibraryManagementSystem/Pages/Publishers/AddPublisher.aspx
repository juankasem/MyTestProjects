<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Publishers/PublisherMasterPage.Master" AutoEventWireup="true" CodeBehind="AddPublisher.aspx.cs" Inherits="LibraryManagementSystem.Pages.Publishers.AddPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Add New Publisher</h2>
            </div>

            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Publisher Info
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
                                <label for="publisherName" class="labels">Publisher Name*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtPublisherName" runat="server" class="form-control TextFields" placeholder="Enter Publisher Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtPublisherName" CssClass="validators" runat="server" ControlToValidate="txtPublisherName" ErrorMessage="Enter Publisher Name please" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                            <label for="origin" class="labels">Country*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlCountries" class="form-control TextFields show-tick" runat="server">
                                        <asp:ListItem>Select Country</asp:ListItem>
                                        <asp:ListItem>United States</asp:ListItem>
                                        <asp:ListItem>United Kingdom</asp:ListItem>
                                        <asp:ListItem>Russia</asp:ListItem>
                                        <asp:ListItem>France</asp:ListItem>
                                        <asp:ListItem>Germany</asp:ListItem>
                                        <asp:ListItem>Australia</asp:ListItem>
                                        <asp:ListItem>Canada</asp:ListItem>
                                        <asp:ListItem>Belgium</asp:ListItem>
                                        <asp:ListItem>Spain</asp:ListItem>
                                        <asp:ListItem>Japan</asp:ListItem>
                                        <asp:ListItem>Italy</asp:ListItem>
                                        <asp:ListItem>Greece</asp:ListItem>
                                        <asp:ListItem>Egypt</asp:ListItem>
                                        <asp:ListItem>Lebanon</asp:ListItem>
                                        <asp:ListItem>China</asp:ListItem>
                                        <asp:ListItem>Korea</asp:ListItem>
                                        <asp:ListItem>South Africa</asp:ListItem>
                                        <asp:ListItem>Brazil</asp:ListItem>
                                        <asp:ListItem>India</asp:ListItem>
                                        <asp:ListItem>Netherlands</asp:ListItem>
                                        <asp:ListItem>Ukraine</asp:ListItem>
                                        <asp:ListItem>Turkey</asp:ListItem>
                                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlCountries" CssClass="validators" runat="server" ControlToValidate="ddlCountries" ErrorMessage="Select Origin Country please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="description" class="labels">Description</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Description"></asp:TextBox>
                                </div>
                            </div>
                            
                           <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false">
                                <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                                <p>
                                    <strong>Well done!...</strong>a new Publisher: <asp:Label ID="lblNewPublisher" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    has been added successfully!...
                                </p>
                            </div>

                            <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false">
                                <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                                <p><strong>Sorry!...</strong>This Publisher does already exists. </p>
                            </div>
                            <br />
                            
                            <div class="form-group">
                                <asp:Button ID="Save" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>

