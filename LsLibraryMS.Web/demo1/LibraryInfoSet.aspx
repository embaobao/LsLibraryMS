<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="LibraryInfoSet.aspx.cs" Inherits="LsLibraryMS.Web.demo1.LibraryInfoSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.bootcss.com/font-awesome/4.7.0/css/font-awesome.css" />
    <style>
        .list-group-item {
            margin: 0em 2em;
        }

            .list-group-item span {
                margin-left: 2em;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: white;">



        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading"><i class="fa fa-paperclip" style="font-size: 24px"></i>EMB图书馆信息 </div>
                <div class="panel-body">

                    <div class="container">
                        <div class="row">
                            <div class="col-sm-4">

                                <h5>图书馆照片:</h5>
                                <div class="fakeimg ">
                                    <img class="img-responsive" width="356" height="280" src="img/banner.jpg" />

                                </div>


                                <p>EMB云图书馆 网络管理系统 EMB-云管理提供技术支持 </p>
                                <ul class="nav nav-pills nav-stacked">
                                    <li class="active"><a href="#">官方网站</a></li>
                                    <li><a href="#">云电子书</a></li>
                                    <li><a href="#">云图书系统技术支持</a></li>
                                </ul>
                                <hr class="hidden-sm hidden-md hidden-lg" />
                            </div>
                            <div class="col-sm-8">

                                <div class="row">
                                    <div class="col-sm-1 col-md-1">
                                        <img class="img-responsive" width="45" height="40" src="img/logo1.jpg" />
                                    </div>

                                    <div class="col-sm-11 col-md-11">
                                        <h2 id="library_name" runat="server" style="float: left">EMB图书馆</h2>
                                        <i class="fa fa-send-o" style="font-size: 36px"></i>
                                    </div>

                                </div>
                                <div style="padding: 1em 3em">

                                    <h5>图书馆建立 <span id="library_time" runat="server"></span></h5>
                                    <h6 id="library_txt" runat="server">关于图书馆介绍..</h6>
                                    <p>详情</p>
                                </div>


                            </div>
                        </div>
                    </div>

                </div>
                <ul class="list-group">
                    <li class="list-group-item">管理人员:<span id="library_man" runat="server"></span></li>
                    <li class="list-group-item">地址:<span id="library_address" runat="server"></span></li>
                    <li class="list-group-item">电话: <span id="library_phone" runat="server"></span></li>
                    <li class="list-group-item">邮箱:<span id="library_emil" runat="server"></span></li>
                    <li class="list-group-item">网站:<span id="library_website" runat="server"></span></li>
                </ul>
            </div>








        </div>

        <div class="row">
            <div class="col-sm-9 col-md-6 col-lg-0" style="text-align: center; padding: 6px 20px;">
            </div>
            <div class="col-sm-3 col-md-6 col-lg-12" style="text-align: center; padding: 3em 5%; margin: 0px auto;">

                <div class="panel panel-primary">
                    <div class="panel-heading"><i style="font-size: 24px; margin: 0px 10px 0px 0px;" class="fa ">&#xf2bb</i>图书馆信息 ------ <small>设置</small><i style="font-size: 16px" class="fa fa-spin">&#xf013</i> </div>
                    <div class="panel-body">
                    </div>
                    <ul class="list-group">

                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon" >名称</span>
                                <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                                <input id="l_name" runat="server" type="text" class="form-control" placeholder="***图书馆" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">地址</span>
                                <span class="input-group-addon"><i class="fa fa-home"></i></span>
                                <input id="l_address" runat="server" type="text" class="form-control" placeholder="河南省洛阳市---" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">管理人</span>
                                <span class="input-group-addon"><i class="fa fa-group"></i></span>
                                <input id="l_admin" runat="server" type="text" class="form-control" placeholder="EMB" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">邮箱</span>
                                <span class="input-group-addon">@</span>
                                <input id="l_emil" runat="server" type="text" class="form-control" placeholder="1132067567@qq.com" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">建立时间</span>
                                <span class="input-group-addon"><i class="fa fa-history"></i></span>
                                <input id="l_time" runat="server" type="text" class="form-control" placeholder="2018-6-20" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">网站</span>
                                <span class="input-group-addon"><i class="fa fa-globe fa-spin"></i></span>
                                <input id="l_web" runat="server" type="text" class="form-control" placeholder="www.embaobao.imwork.cn" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-addon">描述</span>
                                <span class="input-group-addon"><i class="fa fa-heart-o "></i></span>
                                <input id="l_txt" runat="server" type="text" class="form-control" placeholder="这是--图书馆信息,本图书馆----深受读者好评！欢迎读者来访！" />
                            </div>
                        </li>
                        <li class="list-group-item">

                            <div class="input-group">
                                <span class="input-group-btn">
                                    <span class="input-group-addon">联系电话</span>
                                    <span class="input-group-addon"><i class="fa fa-phone"></i></span>
                                </span>
                                <input id="l_phonenum" runat="server" type="text" class="form-control" placeholder="15515365219" />
                            </div>
                        </li>


                        <li class="list-group-item">
                            <asp:Button ID="Button1" CssClass="btn btn-primary btn-block" runat="server" Text="保存" OnClick="Button1_Click" />

                        </li>



                        <li class="list-group-item"><small>EMB图书馆管理系统 是吃火星的宝宝ASP  AJAX技术 三层 等学习作品，不足之处请多多指教！</small></li>
                    </ul>
                </div>

            </div>
        </div>
    </div>




</asp:Content>
