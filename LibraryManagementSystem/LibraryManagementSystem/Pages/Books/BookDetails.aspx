<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Books/BooksMasterPage.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibraryManagementSystem.Pages.Books.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblResult" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgBook" runat="server" CssClass="bookDetailsImage" />
            </td>
            <td>
               <h4>Book Title</h4> 
                <asp:Label ID="lblTitle" runat="server" Text="" CssClass="labels"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <h4>Author Name</h4>
                <asp:Label ID="lblAuthor" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
        </tr>
               <tr>
            <td>
                <h4>Publisher</h4>
                <asp:Label ID="lblPublisher" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <h4>Publication Date</h4>
                <asp:Label ID="lblPublicationDate" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <h4>Description</h4>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br />
                <td>
                    <asp:Button ID="btnBorow"  runat="server" Text="Add Book To Borrow List" CssClass=" btn btn-link" PostBackUrl="~/Pages/Transactions/IssueBook.aspx" />
                </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Available" CssClass="productPrice"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
