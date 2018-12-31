<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Genres/GenreMasterPage.Master" AutoEventWireup="true" CodeBehind="AllGenres.aspx.cs" Inherits="LibraryManagementSystem.Pages.Genres.AllGenres" %>

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
                            <h2>BASIC EXAMPLE
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
                            <div class="table-responsive">
                                <div class="row">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="dataTables_length">
                                            <label>
                                                Show&nbsp<asp:DropDownList ID="ddlEntries" CssClass="inputs" Style="padding: 5px; width: 100px;" runat="server">
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                    <asp:ListItem Value="100">100</asp:ListItem>
                                                </asp:DropDownList>&nbsp Entries</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="dataTables_filter form-group ">
                                            <label>
                                                Search:
                                        <asp:TextBox ID="txtSearch" CssClass="inputs" Style="padding: 5px;" runat="server" AutoPostBack="True"></asp:TextBox></label>
                                        </div>
                                    </div>
                                </div>
                                <asp:GridView ID="gvGenres" CssClass="table table-bordered table-striped table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="sdsAllGenres" OnRowEditing="gvGenres_RowEditing">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="#ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
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
                                <asp:SqlDataSource ID="sdsAllGenres" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT * FROM [Genre]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Basic Examples -->
</asp:Content>
