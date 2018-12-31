<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Transactions/TransactionsMasterPage.Master" AutoEventWireup="true" CodeBehind="ReturnBook.aspx.cs" Inherits="LibraryManagementSystem.Pages.Transactions.ReturnBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Add New Book Return Order</h2>
            </div>

            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Book Return Order
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

                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="returnOrder" class="labels">Return Order Number</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtReturnOrder" runat="server" class="form-control TextFields" placeholder="Enter Return Order Number"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtReturnOrder" CssClass="validators" runat="server" ControlToValidate="txtReturnOrder" ErrorMessage="Enter Issue Order Number please" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="cardID" class="labels">Membership Card ID*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtMembershipCardID" runat="server" class="form-control TextFields" placeholder="Enter Membership Card ID*"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtMembershipCardID" CssClass="validators" runat="server" ControlToValidate="txtMembershipCardID" ErrorMessage="Enter Membership Card ID please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="memberFullName" class="labels">Member Full Name</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtMemberFullName" runat="server" class="form-control TextFields" placeholder="Member Full Name" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookISBN" class="labels">Book ISBN*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtISBN" runat="server" class="form-control TextFields" placeholder="Enter Book ISBN*"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtISBN" CssClass="validators" runat="server" ControlToValidate="txtISBN" ErrorMessage="Enter Book ISBN please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookTitle" class="labels">Book Title</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBookTitle" runat="server" class="form-control TextFields" placeholder="Book Title"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
           
                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookIssueDate" class="labels">Book Issue Date*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtIssueDate" runat="server" class="datepicker form-control TextFields" placeholder="Choose Book Issue Date*"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtIssueDate" CssClass="validators" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="Choose Book Issue Date please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookDueReturnDate" class="labels">Book Due Return Date</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtDueReturnDate" runat="server" CssClass="form-control TextFields" placeholder="Book Due Return Date" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row clearfix">
                              <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookReturnDate" class="labels">Book Return Date*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtReturnDate" runat="server" CssClass="datepicker form-control TextFields" placeholder="Book Return Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookOverDueDays" class="labels">Book Return Overdue Days*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtOverDueDays" runat="server" CssClass="datepicker form-control TextFields" placeholder="Book Return Overdue Days"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                            <%--Book Fines Section--%>
                        <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Fines Summary Info
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
                                     <label for="gender" class="labels">Fines to Apply*</label>
                                        <div class="form-line">
                                            <asp:CheckBoxList ID="chKBoxLstFines" runat="server">
                                                <asp:ListItem>Over Due Return Date</asp:ListItem>
                                                <asp:ListItem>Partial/Complete Book Damage</asp:ListItem>
                                                <asp:ListItem>Losing Item</asp:ListItem>
                                                <asp:ListItem>Losing Membership Card ID</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                        <br/>
                                    </div>


                                    <div class="row clearfix">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="overDueDays" class="labels">Book Return Overdue Days Fine Amount</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtOverDueDaysFine" runat="server" class="form-control TextFields" placeholder="Book Return Overdue Days"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="issueDate" class="labels">Book Damage Fine Amount in US$ </label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtDamageFine" runat="server" class="datepicker form-control TextFields" placeholder="Enter Fine Amount"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                     </div>

                                    <div class="row clearfix">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="overDueDays" class="labels">Losing Book Fine Amount in US$</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtBookLosing" runat="server" class="form-control TextFields" placeholder="Book Return Overdue Days"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="issueDate" class="labels">Losing/Damage Membership ID Card  Fine Amount</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtCardLosing" runat="server" class="datepicker form-control TextFields" placeholder="Enter Issue Date"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                            <div>
                                <asp:Button ID="btnSave" CssClass="btn btn-primary waves-effect" runat="server" Text="Save" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>


