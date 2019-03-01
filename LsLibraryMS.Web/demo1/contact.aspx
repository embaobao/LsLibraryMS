<%@ Page Title="" Language="C#" MasterPageFile="~/demo1/Main.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="LsLibraryMS.Web.demo1.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container" style="background-color: white;">

        <div class="row">





            <%--left content--%>

            <div class="col-sm-9 col-md-6 col-lg-4">
                <div class="card" style="width: 350px; margin: 6px;">
                    <img class="card-img-top img-fluid rounded" src="img/1.jpg" alt="Card image" style="width: 100%" />
                    <div class="card-body" style="margin: 8px;">
                        <h4 class="card-title">EMB图书管理系统</h4>

                    </div>


                </div>
            </div>

        <%--right content--%>





        <div class="col-sm-3 col-md-6 col-lg-8">


            <h3>My page.</h3>
            <address>
               <p style="float:left">We Chat:</p>
                <img style="float:left" src="../Images/wechat.jpg" height="" width=""><br />
                Commuinity ID Number,T&Q 1132067567<br />
                <abbr title="Phone">P:</abbr>
                155-1536-5219
            </address>

            <address>
                <strong>Support:</strong>   <a href="mailto:chihuoxingdebaobao@163.com">chihuoxingdebaobao@163.com</a><br />
                <strong>Marketing:</strong> <a href="mailto:1132067567@qq.com">1132067567@qq.com</a>
            </address>

        </div>


    </div>
   
    </div>








</asp:Content>
