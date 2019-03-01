<%@ Page Title="" Language="C#" MasterPageFile="Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LsLibraryMS.Web.demo1.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Contentr" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--    -fluid--%>
    <div class="container" style="background-color: white;">


        <div class="row">





             <%--left content--%>


            <div class="col-sm-9 col-md-6 col-lg-4">
                <div class="card" style="width: 350px; margin: 6px;">
                    <img class="card-img-top img-fluid rounded" src="img/1.jpg" alt="Card image" style="width: 100%" />
                    <div class="card-body" style="margin: 8px;">
                        <h4 class="card-title">登录EMB图书管理系统</h4>

                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label" style="text-align: left">ID Number</label>
                                <div class="col-sm-9" style="margin: 10px 0;">
                                    <input class="form-control" id="" type="text"placeholder="请输入ID" value="" />
                                </div>

                                <label class="col-sm-3 control-label" style="text-align: left;">Pass   Word</label>
                                <div class="col-sm-9" style="margin: 10px 0;">
                                    <input class="form-control" id="" type="text" placeholder="请输入PassWord" />
                                </div>
                            </div>
                     


                            <div style="text-align: right; width: 100%;"><%--<a href="#" class="btn btn-success btn-sm" style="width: 20%; margin: 1em;">注册</a>--%>  <a href="#" class="btn btn-primary" style="width: 40%; margin: 1em;">登录</a></div>
                        </div>


                    </div>
                </div>



            </div>




            <%--right content--%>





            <div class="col-sm-3 col-md-6 col-lg-8" style="text-align: center;">
                <h4>EMB图书系统统计<small> 近期热门图书排行</small></h4>


                <div id="content" class="table-responsive" runat="server" style="margin: 0 auto;">

                    <asp:Repeater ID="Repeater1" runat="server">

                        <HeaderTemplate>
                            <table class="table">
                                <thead>


                                    <tr>
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
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor='lightgray'"
                                onmouseout="this.style.backgroundColor='white';">
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


                </div>
            </div>
       
            
            
            
             </div>

    </div>
<%--    <script>
        $(document).ready(function () {

           
            $("#navtop").hide();
           
        });
    </script>--%>
</asp:Content>
