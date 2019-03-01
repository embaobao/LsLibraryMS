<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LsLibraryMS.Web.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Repeater ID="Repeater1" runat="server">

        <HeaderTemplate>
            <table cellspacing="0" cellpadding="0" border="0" id="gvBookTaxis" style="color: #333333; width: 815px; border-collapse: collapse;">
                <tbody>
                    <tr style="color: White; background-color: #99C89D; font-weight: bold;">
                        <th scope="col">排名
                        </th>
                        <th scope="col">图书条形码
                        </th>
                        <th scope="col">图书名称
                        </th>
                        <th scope="col">图书类型
                        </th>
                        <th scope="col">图书书架
                        </th>
                        <th scope="col">出版社
                        </th>
                        <th scope="col">作者
                        </th>
                        <th scope="col">图书定价
                        </th>
                        <th scope="col">借阅次数
                        </th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor='lightBlue'"
                onmouseout="this.style.backgroundColor=Color;" style="background-color: #EFF3FB;">
                    <td>
                        <%# Container.ItemIndex+1%>
                    </td>
                    <td>
                        <%#Eval("BookBarCode")%>
                    </td>
                    <td>
                        <%#Eval("BookName")%>
                    </td>
                    <td>
                        <%#Eval("Book_Type.typeName")%>
                    </td>
                    <td>
                        <%#Eval("Book_Case.bookcaseName")%>
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
                    <td></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                                </table>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>
