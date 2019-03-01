<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchBook.aspx.cs" Inherits="LsLibraryMS.Web.SearchBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Repeater ID="rptBookList" runat="server">
            <HeaderTemplate>
                <table width="800px">
                    <tr>
                        <td>
                            条码
                        </td>
                        <td>
                            书名
                        </td>
                        <td>
                            类别
                        </td>
                        <td>
                            书架
                        </td>
                        <td>
                            出版社
                        </td>
                        <td>
                            作者
                        </td>
                        <td>
                            价格
                        </td>
                        <td>
                            借阅次数
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
             <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor='lightBlue'"
                onmouseout="this.style.backgroundColor=Color;" style="background-color: #EFF3FB;">
                    <td>
                        <%#Eval("BookBarCode")%>
                    </td>
                    <td>
                        <%#Eval("BookName")%>
                    </td>
                    <td>
                        <%#Eval("BookType")%>
                    </td>
                    <td>
                        <%#Eval("Bookcase")%>
                    </td>
                    <td>
                        <%#Eval("BookConcern")%>
                    </td>
                    <td>
                        <%#Eval("Author")%>
                    </td>
                    <td>
                        <%#Eval("Price", "${0:F2}")%>
                    </td>
                    <td>
                        <%#Eval("BorrowSum")%>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color: Gray;">
                    <td>
                        <%#Eval("BookBarCode")%>
                    </td>
                    <td>
                        <%#Eval("BookName")%>
                    </td>
                    <td>
                        <%#Eval("BookType")%>
                    </td>
                    <td>
                        <%#Eval("Bookcase")%>
                    </td>
                    <td>
                        <%#Eval("BookConcern")%>
                    </td>
                    <td>
                        <%#Eval("Author")%>
                    </td>
                    <td>
                        <%#Eval("Price", "${0:F2}")%>
                    </td>
                    <td>
                        <%#Eval("BorrowSum")%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>


</asp:Content>
