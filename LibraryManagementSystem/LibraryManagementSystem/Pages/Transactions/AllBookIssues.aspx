<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AllBookIssues.aspx.cs" Inherits="LibraryManagementSystem.Pages.Transactions.AllBookIssues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Add New Category</h2>
            </div>
        
          <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                                New Category Details
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

                  <label for="categoryName" class="labels">Category Name</label>
                  <div class="form-group">
                      <div class="form-line">
                          <asp:TextBox ID="txtCategoryName" runat="server" class="form-control TextFields" placeholder="Enter Category Name"></asp:TextBox>
                      </div>
                      <asp:RequiredFieldValidator ID="reqFldValtxtCategoryName" CssClass="validators" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Enter Category Name"></asp:RequiredFieldValidator>
                  </div>
                  <label for="description" class="labels">Description</label>
                  <div class="form-group">
                      <div class="form-line">
                          <asp:TextBox ID="txtDescription" runat="server" class="form-control TextFields" placeholder="Enter Description"></asp:TextBox>
                      </div>
                  </div>
                 <div>
                     <asp:Button ID="btnSave" CssClass="btn btn-primary m-t-15 waves-effect" runat="server" Text="Save" />
                 </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </section>
            <!-- #END# Vertical Layout -->
</asp:Content>

