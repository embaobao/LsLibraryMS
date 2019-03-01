<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="BookTakePutPage.aspx.cs" Inherits="LsLibraryMS.Web.demo1.BookTakePutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: white;">





        <div class="row">
            <div class="col-sm-9 col-md-6 col-lg-0" style="text-align: center; padding: 6px 20px;">
            </div>
            <div class="col-sm-3 col-md-6 col-lg-12" style="text-align: center; padding: 3em 5%; margin: 0px auto;">

                <div class="panel panel-primary">
                    <div class="panel-heading">图书管理员--<i style="font-size: 24px; margin: 0px 10px 0px 0px;" class="fa ">&#xf2bb</i>图书借阅归还</div>
                    <div class="panel-body">
                    </div>
                    <ul class="list-group">

                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">图书编码</span>
                                <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                                <input id="putbookcode"  type="text" class="form-control" placeholder="请输入图书编码***|必填" />
                                <span id="bookdown" class="input-group-addon btn-outline-info">录入----></span>
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">读者编码</span>
                                <span class="input-group-addon"><i class="fa fa-home"></i></span>
                                <input id="putreadercode" type="text" class="form-control" placeholder="请输入读者编码***| 还书操作时可不录入" />
                                <span id="readerdown" class="input-group-addon btn-outline-info">录入----></span>
                            </div>
                        </li>

                        <li class="list-group-item">
                            <div class="input-group">
                                <span class="input-group-addon"><small style="text-align: left; color: darkgray">录入图书</small></span>
                                <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                            </div>

                            <ul class="list-group addbookbarcode">




                                <li class="list-group-item">
                                    <span class="badge">已还</span>
                                    测试图书
                                </li>
                                <li class="list-group-item">
                                    <span class="badge">未还</span>
                                    测试图书
                                </li>
                            </ul>

                        </li>

                        <li class="list-group-item list-group-item-success">
                            <div class="input-group">
                                <span id="bb_reader_tip" class="input-group-addon"><small>读者信息为空</small></span>
                                <input id="inreadercode" type="text" class="form-control" placeholder="...待录读者信息" disabled />
                            </div>
                        </li>

                        <li class="list-group-item">
                            <asp:Button ID="Button1" CssClass="btn btn-success btn-block" runat="server" Text="借阅" />
                            <br />
                            <asp:Button ID="Button2" CssClass="btn btn-primary  btn-block" runat="server" Text="归还" />

                        </li>



                        <li class="list-group-item"><small>EMB图书馆管理系统 是吃火星的宝宝ASP  AJAX技术 三层 等学习作品，不足之处请多多指教！</small></li>
                    </ul>
                </div>

            </div>
        </div>



    </div>



    <script>

        $(document).ready(function () {


            $("#bookdown").click(function () {
                $(".addbookbarcode").append('<li class="list-group-item">' + '<span class="badge">未还</span>' + $("#putbookcode").val() + '</li>');
                $("#putbookcode").val("");
            });

            $("#readerdown").click(function () {
                $('#inreadercode').val($("#putreadercode").val());
                $("#putreadercode").val("");
            });

       
            $(function () {
                $('#putreadercode').bind('input propertychange', function () {
                    $('#inreadercode').val($(this).val());
                });

            })





        });

    </script>


</asp:Content>
