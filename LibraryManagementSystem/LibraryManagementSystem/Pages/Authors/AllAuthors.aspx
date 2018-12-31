<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Authors/AuthorMaster.Master" AutoEventWireup="true" CodeBehind="AllAuthors.aspx.cs" Inherits="LibraryManagementSystem.Pages.Authors.AllAuthors" %>

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
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2></h2>
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
                                <%--<table class="table table-bordered table-striped table-hover js-basic-example dataTable">
                                   
                                </table>--%>
                                <asp:GridView ID="gvAuthors" CssClass="table table-bordered table-striped table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" DataSourceID="sdsAllAuthors" OnRowEditing="gvAuthors_RowEditing">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="#ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                        <asp:BoundField DataField="Origin" HeaderText="Origin Country" SortExpression="Origin" />
                                        <asp:BoundField DataField="Photo" HeaderText="Photo" SortExpression="Photo" />
                                        <asp:BoundField DataField="Biography" HeaderText="Biography" SortExpression="Biography" />
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" CommandName="Edit" />
                                                <asp:Button ID="btnDelete" CssClass="btn btn-primary" runat="server" Text="Delete" CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridViewHeader" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsAllAuthors" runat="server" ConnectionString="<%$ ConnectionStrings:LibrarydbConnection %>" SelectCommand="SELECT * FROM [Author]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- #END# Basic Examples -->
</asp:Content>
