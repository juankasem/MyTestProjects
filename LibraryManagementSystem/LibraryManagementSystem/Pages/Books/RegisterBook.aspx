<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Books/BooksMasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterBook.aspx.cs" Inherits="LibraryManagementSystem.Pages.Books.RegisterBook" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Register New Book</h2>
            </div>

            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Book Details
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
                                <label for="email_address" class="labels">ISBN (International Standard Book Number)*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtISBN" runat="server" class="form-control TextFields" placeholder="Enter ISBN"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtISBN" CssClass="validators" runat="server" ControlToValidate="txtISBN" ErrorMessage="Enter ISBN please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="title" class="labels">Book Title*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control TextFields" placeholder="Enter Book Title"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtTitle" CssClass="validators" runat="server" ControlToValidate="txtTitle" ErrorMessage="Enter Title please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="genre" class="labels">Book Genre*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlGenres" class="form-control TextFields" runat="server"  DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsGenres" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT [ID], [Name] FROM [Genre]"></asp:SqlDataSource>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlGenres" CssClass="validators" runat="server" ControlToValidate="ddlGenres" ErrorMessage="Select Genre please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="cover" class="labels">Cover Image</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlCoverImages" runat="server"></asp:DropDownList>
                                    <asp:FileUpload ID="fileUploadImages" runat="server" />
                                </div>
                                <asp:Button ID="btnUpload" CssClass="btn btn-default" runat="server" Text="Upload Cover Image" />
                            </div>

                            <div class="form-group">
                                <label for="description" class="labels">Description</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control TextFields" TextMode="MultiLine" Rows="5" placeholder="Enter Description"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="author" class="labels">Author Name*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlAuthors" class="form-control TextFields" runat="server" DataSourceID="sdsAuthors" DataTextField="AuthorName" DataValueField="ID"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsAuthors" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT ID,  FirstName +' '+LastName AS AuthorName FROM Author"></asp:SqlDataSource>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlAuthors" CssClass="validators" runat="server" ControlToValidate="ddlAuthors" ErrorMessage="Select Author please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="publisher" class="labels">Publisher*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlPublishers" class=" form-control show-tick TextFields" runat="server"  DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsPublishers" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT [ID], [Name] FROM [Publisher]"></asp:SqlDataSource>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValddlPublishers" runat="server" ControlToValidate="ddlPublishers" ErrorMessage="Select Publisher please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="publication" class="labels">Publication Date*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtPublicationDate" runat="server" class="datepicker form-control TextFields" placeholder="Enter Publication Date"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtPublicationDate" runat="server" ControlToValidate="txtPublicationDate" ErrorMessage="Enter Publication Date please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="edition" class="labels">Edition Number*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtEdition" runat="server" class="form-control TextFields" placeholder="Enter Edition Number"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtEdition" CssClass="validators" runat="server" ControlToValidate="txtEdition" ErrorMessage="Enter Edition Number please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="language" class="labels">Language*</label>
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlLanguages" class=" form-control show-tick TextFields" runat="server">
                                        <asp:ListItem>English</asp:ListItem>
                                        <asp:ListItem>French</asp:ListItem>
                                        <asp:ListItem>Chinese(Mandarin)</asp:ListItem>
                                        <asp:ListItem>Spanish</asp:ListItem>
                                        <asp:ListItem>Russian</asp:ListItem>
                                        <asp:ListItem>Arabic</asp:ListItem>
                                        <asp:ListItem>German</asp:ListItem>
                                        <asp:ListItem>Italian</asp:ListItem>
                                        <asp:ListItem>Latin</asp:ListItem>
                                        <asp:ListItem>Turkish</asp:ListItem>
                                        <asp:ListItem>Japanese</asp:ListItem>
                                        <asp:ListItem>Persian</asp:ListItem>
                                        <asp:ListItem>Dutch</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtLanguage" CssClass="validators" runat="server" ControlToValidate="ddlLanguages" ErrorMessage="Select Language please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="price" class="labels">Unit Price in US$*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtPrice" runat="server" class="form-control TextFields" placeholder="Enter Price"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtPrice" CssClass="validators" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Enter Price please"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PriceValidator" CssClass="validators" runat="server" ControlToValidate="txtPrice" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ErrorMessage="Enter valid Price value please" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label for="NumofPages" class="labels">No. of Pages*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtNumOfPages" runat="server" class="form-control TextFields" placeholder="Enter No. of Pages"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtPages" CssClass="validators" runat="server" ControlToValidate="txtNumOfPages" Display="Dynamic" ErrorMessage="Enter Initial No. of Copies please"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regExpValtxtNumOfPages" CssClass="validators" runat="server" ControlToValidate="txtNumOfPages" ValidationExpression="^[0-9]*$" ErrorMessage="Enter an Integer number please"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label for="entry" class="labels">Registration(Entry) Date*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtRegistrationDate" runat="server" class="datepicker form-control TextFields" placeholder="Enter Registration(Entry) Date"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtRegistrationDate" CssClass="validators" runat="server" ControlToValidate="txtRegistrationDate" ErrorMessage="Enter Registration(Entry) Date please"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <%--Inventory Info--%>
            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Book Inventory Info
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
                                <label for="NumofCopies" class="labels">Initial Number of Copies*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtTotalCopies" runat="server" class="form-control TextFields" placeholder="Enter Initial No. of Copies"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtTotalCopies" CssClass="validators" runat="server" ControlToValidate="txtTotalCopies" Display="Dynamic" ErrorMessage="Enter Initial No. of Copies please"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regExpValtxtTotalCopies" CssClass="validators" runat="server" ControlToValidate="txtTotalCopies" ValidationExpression="^[0-9]*$" ErrorMessage="Enter an Integer number please"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label for="section" class="labels">Section ID*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtSectionID" runat="server" class="form-control TextFields" placeholder="Enter Section ID"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtSectionID" CssClass="validators" runat="server" ControlToValidate="txtSectionID" ErrorMessage="Enter Section ID please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="rack" class="labels">Rack ID*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtRackID" runat="server" class="form-control TextFields" placeholder="Enter Rack ID"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtRackID" CssClass="validators" runat="server" ControlToValidate="txtRackID" ErrorMessage="Enter Rack ID  please"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="shelf" class="labels">Shelf ID*</label>
                                <div class="form-line">
                                    <asp:TextBox ID="txtShelfID" runat="server" class="form-control TextFields" placeholder="Enter Shelf ID"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="reqFldValtxtShelfID" CssClass="validators" runat="server" ControlToValidate="txtShelfID" ErrorMessage="Enter Shelf ID  please"></asp:RequiredFieldValidator>
                            </div>

                              <div class="form-group col-lg-6 alert alert-success" runat="server" id="divSuccess" visible="false">
                                <a href="#" id="linkCloseSuccess" class="close" data-dismiss="alert">&times;</a>
                                <p>
                                    <strong>Well done!...</strong>a new book: <asp:Label ID="lblNewBook" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    has been added successfully!...
                                </p>
                            </div>

                            <div class=" form-group col-lg-6 alert alert-danger" runat="server" id="divFail" visible="false">
                                <a id="linkCloseFail" class="close" data-dismiss="alert">&times;</a>
                                <p><strong>Sorry!...</strong>This book does already exists in the databse. </p>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary m-t-15 waves-effect" Text="Save" data-type="confirm" OnClick="btnSave_Click" />
                            </div>
                              
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>


