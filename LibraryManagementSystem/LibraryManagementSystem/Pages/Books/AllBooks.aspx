<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Books/BooksMasterPage.Master" AutoEventWireup="true" CodeBehind="AllBooks.aspx.cs" Inherits="LibraryManagementSystem.Pages.Books.AllBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>JQUERY DATATABLES
                   
                    <small>Taken from <a href="https://datatables.net/" target="_blank">datatables.net</a></small>
                </h2>
            </div>
            <!-- Basic Examples -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>All Books Table
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
                            <div class="row">
                                <div class="col-sm-12 col-md-6">
                                    <div class="dataTables_length">
                                        <label>
                                            Show&nbsp<asp:DropDownList ID="ddlEntries" CssClass="inputs"  runat="server">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                <asp:ListItem Value="100">100</asp:ListItem>
                                            </asp:DropDownList>&nbsp Entries</label>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-6">
                                    <div class="dataTables_filter">
                                        <div class="form-line">
                                            <label>
                                            Search:
                                        <asp:TextBox ID="txtSearch" Style="padding: 5px;" runat="server" AutoPostBack="True"></asp:TextBox></label>
                                        </div>                               
                                    </div>
                                </div>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="gvBooks" CssClass="table table-bordered table-striped table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="sdsAllBooks" OnRowEditing="gvBooks_RowEditing">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                        <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                                        <asp:BoundField DataField="CoverImage" HeaderText="CoverImage" SortExpression="CoverImage" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" ReadOnly="True" />
                                        <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                                        <asp:BoundField DataField="PublicationDate" HeaderText="PublicationDate" SortExpression="PublicationDate" />
                                        <asp:BoundField DataField="Edition" HeaderText="Edition" SortExpression="Edition" />
                                        <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                                        <asp:BoundField DataField="PagesNumber" HeaderText="PagesNumber" SortExpression="PagesNumber" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                        <asp:BoundField DataField="RegistrationDate" HeaderText="RegistrationDate" SortExpression="RegistrationDate" />
                                    </Columns>
                                    <HeaderStyle CssClass="gridViewHeader" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsAllBooks" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT Book. ID, ISBN, Title, Gen.Name As Genre, CoverImage, Book.[Description], (Aut.FirstName + ' '+Aut.LastName) AS Author, Pub.Name AS Publisher, PublicationDate, Edition, [Language], PagesNumber, Price, RegistrationDate FROM Book

INNER JOIN Genre AS Gen
ON
Book.GenreID= Gen.ID
INNER JOIN Author AS Aut
ON
Book.AuthorID= Aut.ID
INNER JOIN Publisher AS Pub
ON
Book.PublisherID= Pub.ID
"></asp:SqlDataSource>
                                <%--<asp:GridView ID="gvPublishers" CssClass="table table-bordered table-striped table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="sdsAllPublishers">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="#ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                       <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" CommandName="Edit" />
                                                <asp:Button ID="btnDelete" CssClass="btn btn-primary" runat="server" Text="Delete" CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                    <HeaderStyle CssClass="gridViewHeader" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsAllPublishers" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT * FROM [Publisher]"></asp:SqlDataSource>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Basic Examples -->
</asp:Content>

