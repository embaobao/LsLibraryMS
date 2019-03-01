<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LsLibraryMS.Web.demo1.Search" EnableEventValidation="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
          

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%--    -fluid--%>
    <div class="container" style="background-color: white;">

        <div class="row">





            <%--left content--%>


            <div class="col-sm-9 col-md-6 col-lg-3 top5em">

                <div style="width: 100%; text-align: center">

                    <h4 class="card-title">系统图书搜素</h4>
                </div>


                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="disabledSelect" class="col-sm-3 control-label">书名</label>
                        <div class="col-sm-9" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="bookname_input" type="text" placeholder="请输入书名" runat="server" />
                        </div>

                        <label for="disabledSelect" class="col-sm-3 control-label">编码</label>
                        <div class="col-sm-9" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="bookcode_input" type="text" placeholder="请输入图书编码" runat="server" />
                        </div>
                        <label for="disabledSelect" class="col-sm-3 control-label">类别</label>
                        <div class="col-sm-9" style="margin: 10px 0;">
                            <asp:DropDownList ID="Booktype_input" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="0" Text="请选择图书类型">
                                </asp:ListItem>
                            </asp:DropDownList>



                        </div>
                    </div>
                    <div class="btleft subbt">
                        <asp:Button ID="Button1" runat="server" Text="查找" CssClass="btn btn-primary btn-block" BorderStyle="None" OnClick="Button1_Click" />
                    </div>


                    <%--      style="width: 40%; margin: 1em;"--%>
                </div>
            </div>








            <%--right content--%>





            <div class="col-sm-3 col-md-6 col-lg-9" style="text-align: center;">
                <h4>查询信息如下：<small> 
                                
                </small></h4>


                <div id="content" class="table-responsive" runat="server" style="margin: 0 auto;">

                    <asp:Repeater ID="Repeater1" runat="server">

                        <HeaderTemplate>
                            <table class="table">
                                <thead>

                                    <tr>
                                        <%--  <th scope="col">顺序
                                        </th>--%>
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
                                        <th scope="col" class="btright">
                                            <a id="addbook" name="" data-toggle="modal" data-target="#tip" class="btn btn-sm btn-primary btn-sm">添加图书</a>
                                        </th>
                                    </tr>

                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor='lightgray'"
                                onmouseout="this.style.backgroundColor='white';">
                                <%-- <td>
                                    <%# Container.ItemIndex+1%>
                                </td>--%>
                                <td>
                                    <%#Eval("BookBarCode")%>
                                </td>
                                <td>
                                    <%#Eval("BookName")%>
                                </td>
                                <td name="<%#Eval("Book_Type.typeID")%>">
                                    <%#Eval("Book_Type.typeName")%>
                                </td>
                                <td name='<%#Eval("Book_Case.bookcaseID")%>'>
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
                                <td>
                                    <a id="" name="" data-toggle="modal" data-target="#tip" class="btn btn-xs btn-outline-info bt_changebook">修改</a>
                                    <a id="" name="" data-toggle="modal" data-target="#tipsm" class="btn btn-xs btn-outline-danger bt_deletebook">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                </table>

                           
  
                        </FooterTemplate>

                    </asp:Repeater>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="" UrlPaging="true" CssClass="pagination paginator"
                        LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                        PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>

                </div>
            </div>




        </div>

    </div>



</asp:Content>
