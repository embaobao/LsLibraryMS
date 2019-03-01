<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="AdministratorMangerPage.aspx.cs" Inherits="LsLibraryMS.Web.demo1.AdministratorMangerPage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">







    <%--    -fluid--%>
    <div class="container" style="background-color: white;">

        <div class="row" style="padding: 5%">


            <%--left content--%>





            <div class="col-sm-3 col-md-6 col-lg-9" style="text-align: center;">
                <h4>管理员信息管理<small> 
                                
                </small></h4>


                <div id="content" class="table-responsive" runat="server" style="margin: 0 auto;">

                    <asp:Repeater ID="Repeater1" runat="server">

                        <HeaderTemplate>
                            <table class="table">
                                <thead>

                                    <tr>
                                        <th scope="col">管理员姓名
                                        </th>

                                        <th scope="col">系统设置
                                        </th>

                                        <th scope="col">读者管理
                                        </th>
                                        <th scope="col">图书管理
                                        </th>
                                        <th scope="col">图书浏览
                                        </th>
                                        <th scope="col">系统查找
                                        </th>

                                        <th scope="col" class="btright">
                                            <a id="addreader" name="" data-toggle="modal" data-target="#tip" class="btn btn-sm btn-primary btn-sm">添加读者类型</a>
                                        </th>

                                    </tr>

                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor='lightgray'"
                                onmouseout="this.style.backgroundColor='white';">



                                <td>
                                    <p id="userName" runat="server"><%#Eval("userName")%></p>
                                </td>

                                <td>
                                    <asp:CheckBox ID="systemSet" runat="server" Checked='<%#Eval("systemSet")%>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="readerManage" runat="server" Checked='<%#Eval("readerManage")%>' />

                                </td>
                                <td>
                                    <asp:CheckBox ID="bookManage" runat="server" Checked='<%#Eval("bookManage")%>' />

                                </td>
                                <td>
                                    <asp:CheckBox ID="bookBorrow" runat="server" Checked='<%#Eval("bookBorrow")%>' />

                                </td>
                    
                                <td>
                                    <asp:CheckBox ID="systemSearch" runat="server" Checked='<%#Eval("systemSearch")%>' />

                                </td>

                                <td class="btright">
                                    <a id="" name="" data-toggle="modal" data-target="#tip" class="btn btn-xs btn-outline-info bt_changereader">修改</a>
                                    <a id="" name="" data-toggle="modal" data-target="#tipsm" class="btn btn-xs btn-outline-danger bt_deletereader">删除</a>
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






            <%-- right content   style="width: 40%; margin: 1em;"--%>


            <div class="col-sm-9 col-md-6 col-lg-3 top5em">

                <div style="width: 100%; text-align: center">

                    <h4 class="card-title">管理员信息</h4>
                </div>


                <div class="form-horizontal" role="form">
                    <div class="form-group">

                        <label for="disabledselect" class="col-sm-6 control-label">管理员姓名:</label>
                        <div class="col-sm-6" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="booktypename_input" type="text" placeholder="请输入书名" runat="server" />
                        </div>

                        <label for="disabledselect" class="col-sm-6 control-label">管理员ID:</label>
                        <div class="col-sm-6" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="bookcode_input" type="text" placeholder="请输入图书编码" runat="server" />
                        </div>
                        <label for="disabledselect" class="col-sm-6 control-label">权限:</label>
                        <div class="col-sm-6" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="Text1" type="text" placeholder="请输入图书编码" runat="server" />
                        </div>

                    </div>

                    <div class="subbt">
                        <asp:Button ID="Button1" runat="server" Text="查看" CssClass="btn btn-primary btn-block" BorderStyle="None" />
                    </div>



                </div>
            </div>







        </div>




    </div>
</asp:Content>
