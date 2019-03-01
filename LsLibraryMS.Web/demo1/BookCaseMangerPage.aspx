<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="BookCaseMangerPage.aspx.cs" Inherits="LsLibraryMS.Web.demo1.BookCaseMangerPage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






    <%--    -fluid--%>
    <div class="container" style="background-color: white;">

        <div class="row" style="padding: 5%">


            <%--left content--%>





            <div class="col-sm-3 col-md-6 col-lg-9" style="text-align: center;">
                <h4>图书存放管理<small> 
                                
                </small></h4>


                <div id="content" class="table-responsive" runat="server" style="margin: 0 auto;">

                    <asp:Repeater ID="Repeater1" runat="server">

                        <HeaderTemplate>
                            <table class="table">
                                <thead>

                                    <tr>
                                        <th scope="col">标记数
                                        </th>
                                        <th scope="col">标识码ID
                                        </th>
                                        <th scope="col">位置描述
                                        </th>
                                        <th scope="col" class="btright">
                                            <a id="addbookcase" name="" data-toggle="modal" data-target="#tip" class="btn btn-sm btn-primary btn-sm">添加图书位置</a>
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
                                    <%#Eval("bookcaseID")%>
                                </td>
                                <td>
                                    <%#Eval("bookcaseName")%>
                                </td>
                               
                                <td class="btright">
                                    <a id="" name="" data-toggle="modal" data-target="#tip" class="btn btn-xs btn-outline-info bt_changebookcase">修改</a>
                                    <a id="" name="" data-toggle="modal" data-target="#tipsm" class="btn btn-xs btn-outline-danger bt_deletebookcase">删除</a>
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

                    <h4 class="card-title">系统图书位置</h4>
                </div>


                <div class="form-horizontal" role="form">
                    <div class="form-group">

                        <label for="disabledselect" class="col-sm-6 control-label">位置描述:</label>
                        <div class="col-sm-6" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="booktypename_input" type="text" placeholder="系统图书位置" runat="server" />
                        </div>

                        <label for="disabledselect" class="col-sm-6 control-label">位置标识:</label>
                        <div class="col-sm-6" style="margin: 10px 0;">
                            <input class="form-control input-sm" id="bookcode_input" type="text" placeholder="请输入位置标识" runat="server" />
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
