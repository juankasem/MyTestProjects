<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Transactions/TransactionsMasterPage.Master" AutoEventWireup="true" CodeBehind="BorrowBook.aspx.cs" Inherits="LibraryManagementSystem.Pages.Transactions.BorrowBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#lblAddBook2').click(function () {
                $('#<%=txtISBN2.ClientID%>').show();
                $('#<%=txtBookTitle2.ClientID%>').show();
                $('#lblAddBook3').show();
            });
            $('#lblAddBook3').click(function () {
                $('#<%=txtISBN3.ClientID%>').show();
                $('#<%=txtBookTitle3.ClientID%>').show();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content">
        <div class="container-fluid">
            <div class="block-header">
                <h2>Add New Borrow Book Order</h2>
            </div>
            <!-- Vertical Layout -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>New Borrow Book Order
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
                                        <label for="borrowOrder" class="labels">Borrow Order Number*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBorrowID" runat="server" class="form-control TextFields" placeholder=""></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtBorrowID" CssClass="validators" runat="server" ControlToValidate="txtBorrowID" ErrorMessage="Enter Borrow ID please" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row clearfix">

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="cardID" class="labels">Library Card Number*</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtLibraryCardNo" runat="server" class="form-control TextFields" placeholder="Enter Library Card Number*" OnTextChanged="txtLibraryCardNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="reqFldValtxtLibraryCardNo" CssClass="validators" runat="server" ControlToValidate="txtLibraryCardNo" ErrorMessage="Enter Library Card Number please"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="memberFullName" class="labels">Member Full Name*</label>
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtMemberFullName" runat="server" class="form-control TextFields" placeholder="Click here to show Memeber Full Name" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                
                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookISBN1" class="labels">Book ISBN*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtISBN1" runat="server" class="form-control TextFields" placeholder="Enter Book ISBN*" OnTextChanged="txtISBN1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="btnAddBook2" runat="server" Text="+ Add Book" BorderStyle="None" BackColor="White" ForeColor="Blue" CausesValidation="false" />
<%--                                        <label for="secondBook" id="lblAddBook2">+Add Another</label>--%>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtISBN1" CssClass="validators" runat="server" ControlToValidate="txtISBN1" Display="Dynamic" ErrorMessage="Enter Book ISBN please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookTitle1" class="labels">Book Title*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBookTitle1" runat="server" class="form-control TextFields" placeholder="Click here to show Book Title"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtBookTitle1" CssClass="validators" runat="server" ControlToValidate="txtBookTitle1" Display="Dynamic" ErrorMessage="Click here to show book Title please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookISBN2" class="labels" hidden="hidden">Book ISBN*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtISBN2" runat="server" class="form-control TextFields" placeholder="Enter Book ISBN*" Visible="false" OnTextChanged="txtISBN2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:Button ID="btnAddBook3" runat="server" Text="+Add Book" BorderStyle="None" BackColor="White" CausesValidation="false" ForeColor="Blue"/>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookTitle" class="labels" hidden="hidden">Book Title</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBookTitle2" runat="server" class="form-control TextFields" placeholder="Click here to show Book Title" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookISBN" class="labels" hidden="hidden">Book ISBN*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtISBN3" runat="server" class="form-control TextFields" placeholder="Enter Book ISBN*" Visible="false" OnTextChanged="txtISBN3_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                            <label for="secondBook" id="lblAddBook4" hidden="hidden">+Add Another</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookTitle" class="labels">Book Title</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBookTitle3" runat="server" class="form-control TextFields" placeholder="Click here to show Book Title"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <label for="bookBorrowDuration" class="labels">Book Issue Duration*</label>
                                <div class="form-line">
                                    <asp:RadioButtonList ID="radBtnLstBorrowDuration" CssClass="TextFields with-gap" runat="server" ValidationGroup="Duration" RepeatDirection="Horizontal" Width="100%" AutoPostBack="True">
                                        <asp:ListItem Selected="True">7 Days</asp:ListItem>
                                        <asp:ListItem>14 Days</asp:ListItem>
                                        <asp:ListItem>21 Days</asp:ListItem>
                                        <asp:ListItem>1 Month</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <br />
                            </div>

                            <div class="row clearfix">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookBorrowDate" class="labels">Book Borrow Date*</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtBorrowDate" runat="server" class="datepicker form-control TextFields" placeholder="Choose Book Borrow Date*" OnTextChanged="txtBorrowDate_TextChanged" Format="MMM dd, yyyy" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="reqFldValtxtBorrowDate" CssClass="validators" runat="server" ControlToValidate="txtBorrowDate" ErrorMessage="Choose Book Borrow Date please"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="bookDueReturnDate" class="labels">Book Due Return Date</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtDueReturnDate" runat="server" class="form-control TextFields" placeholder="Book Due Return Date" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div>
                                <asp:Button ID="btnSave" CssClass="btn btn-primary waves-effect" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
           
        </div>
    </section>
    <!-- #END# Vertical Layout -->
</asp:Content>
