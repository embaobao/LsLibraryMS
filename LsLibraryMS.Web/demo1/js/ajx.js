
/// <reference path="model.js" />
/// <reference path="dialog.js" />

$(document).ready(function () {


    var BookInfo, BookCase, BookType;
    BookCase = {
        "bookcaseID": 1,
        "bookcaseName": ""
    };
    BookType = {
        "typeID": 1,
        "typeName": "",
        "borrowDay": 0
    };
    BookInfo = {
        "Count": 0,
        "BookBarCode": 0,
        "BookName": "",
        "Book_Type": BookType,
        "Book_Case": BookCase,
        "BookConcern": "",
        "Author": "",
        "Price": "",
        "BorrowSum": ""
    };

    function DataOut(str) {
        var obj = JSON.parse(str);
        console.log(obj);
        return obj["d"];
    }

    //提交结果是否成功，1 真确执行的函数， 执行的
    function IsTrueForCsWebMethod(data, T, F) {
        if (data == '{"d":true}') {  //注意判断条件  
            T();
        } else {
            F();
        }
    }
    // 是否可写 1是否可写的对象 ， 2能用吗？
    function Isable(obj, isable) {
        $(obj).attr("disabled", !isable);
    }

    function GetBookCase(obj, fun) {
        $.ajax({
            url: "Search.aspx/GetBookCase",  //调用后台方法  
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {
                //IsTrueForCsWebMethod(data, function () { alert("ok"); },
                //function () { alert("更新失败"); }  );
                var html = "";
                var bookcaselist = DataOut(data)
                for (x in bookcaselist) {
                    html += " <option value='" + bookcaselist[x].bookcaseID + "'>" + bookcaselist[x].bookcaseName + "</option>";
                    console.log(bookcaselist[x]);
                }
                $(obj).html(html);
                fun();



                // alert(DataOut(data));
                console.log(DataOut(data));
            }
        });
    }
    function GetBookType(obj, fun) {
        $.ajax({
            url: "Search.aspx/GetBookType",  //调用后台方法  
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {
                //IsTrueForCsWebMethod(data, function () { alert("ok"); },
                //function () { alert("更新失败"); }  );
                var html = "";
                var booktypelist = DataOut(data)
                for (x in booktypelist) {
                    html += " <option value='" + booktypelist[x].typeID + "'>" + booktypelist[x].typeName + "</option>";
                    console.log(booktypelist[x]);
                }

                $(obj).html(html);
                fun();


                // alert(DataOut(data));
                console.log(DataOut(data));
            }
        });
    }





    //发送更新BookInfo请求
    function UpBookInfo(params) {
        $.ajax({
            url: "Search.aspx/UpBookInfo",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("更新成功");
                    window.location.reload();
                },
                    function () { alert("更新失败"); }
                );

                //alert(data);
            }
        });

    }
    //发送添加图书BookInfo请求
    function AddBookInfo(params) {
        $.ajax({
            url: "Search.aspx/AddBookInfo",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("添加成功");
                    window.location.reload();
                },
                    function () { alert("信息格式有误 或ID重复，网络不畅通等 添加失败 请尝试修改后再添加！"); }
                );


            }
        });

    }

    //发送删除BookInfo请求
    function DeleteBookInfo(params) {
        $.ajax({
            url: "Search.aspx/DeleteBookInfo",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("删除成功");
                    window.location.reload();
                },
                    function () { alert("删除失败"); }
                );
                //alert(data);
            }
        });

    }

    //发送更新BookTyppe请求
    function UpBookType(params) {
        $.ajax({
            url: "BookTypeMangerPage.aspx/UpBookType",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("更新成功");
                    window.location.reload();
                },
                    function () { alert("更新失败"); }
                );

                alert(data);
            }
        });

    }

    //发送添加BookTyppe请求
    function AddBookType(params) {
        $.ajax({
            url: "BookTypeMangerPage.aspx/AddBookType",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("添加成功");
                    window.location.reload();
                },
                    function () { alert("添加失败"); }
                );

                alert(data);
            }
        });

    }

    //发送删除BookTyppe请求
    function DeleteBookType(params) {
        $.ajax({
            url: "BookTypeMangerPage.aspx/DeleteBookType",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("删除成功");
                    window.location.reload();
                },
                    function () { alert("删除失败"); }
                );

                alert(data);
            }
        });

    }

    //发送修改BookCase请求
    function UpBookCase(params) {
        $.ajax({
            url: "BookCaseMangerPage.aspx/UpBookCase",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("修改成功");
                    window.location.reload();
                },
                    function () { alert("修改失败"); }
                );

                alert(data);
            }
        });

    }


    //发送添加BookCase请求
    function AddBookCase(params) {
        $.ajax({
            url: "BookCaseMangerPage.aspx/AddBookCase",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("添加成功");
                    window.location.reload();
                },
                    function () { alert("添加失败"); }
                );

                alert(data);
            }
        });

    }

    //发送删除BookCase请求
    function DeleteBookCase(params) {
        $.ajax({
            url: "BookCaseMangerPage.aspx/DeleteBookCase",  //调用后台方法  
            data: "{jsonStr:'" + params + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {

                IsTrueForCsWebMethod(data, function () {
                    alert("删除成功");
                    window.location.reload();
                },
                    function () { alert("删除失败"); }
                );

                alert(data);
            }
        });

    }

    //Postjson
    function PostData(url, Data) {
        $.ajax({
            url: url,  //调用后台方法  
            data: "{jsonStr:'" + Data + "'}",
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {
                return data;
            }
        });

    }










    //捕捉BookInfo数据 修改图书事件监听
    $(".bt_changebook").click(function () {
        TipModel("bookinfo");
        setTipTitle("", "----图书信息修改----");

        $("#book_add").hide();
        $("#book_change").show();
        Isable("#booknum", false);

        $("#booknum").val($($(this).parent().parent().find('td')[0]).text().trim());
        $("#bookname").val($($(this).parent().parent().find('td')[1]).text().trim());
        var booktypeid = Number($($(this).parent().parent().find('td')[2]).attr("name"));
        GetBookType("#book_type", function () {
            $("#book_type").val(booktypeid);
        });
        var bookcaseid = Number($($(this).parent().parent().find('td')[3]).attr("name"))
        GetBookCase("#book_case", function () {
            $("#book_case").val(bookcaseid);
        });
        $("#bookcbs").val($($(this).parent().parent().find('td')[4]).text().trim());
        $("#bookzz").val($($(this).parent().parent().find('td')[5]).text().trim());
        $("#bookprice").val($($(this).parent().parent().find('td')[6]).text().trim().replace('$', ''));
        $("#bookreadnum").val($($(this).parent().parent().find('td')[7]).text().trim());

        //绑定更新事件
        $("#book_change").click(function () {
            BookInfo.BookBarCode = Number($("#booknum").val());
            BookInfo.BookName = $("#bookname").val();
            BookType.typeID = Number($("#book_type").val());;
            BookType.typeName = $("#book_type option:selected").text();
            BookInfo.Book_Type = BookType;
            BookCase.bookcaseID = Number($("#book_case").val());
            BookCase.bookcaseName = $("#book_case option:selected").text();
            BookInfo.Book_Case = BookCase;
            BookInfo.BookConcern = $("#bookcbs").val();
            BookInfo.Price = $("#bookprice").val();
            BookInfo.Author = $("#bookzz").val();
            BookInfo.BorrowSum = $("#bookreadnum").val();
            var params = JSON.stringify(BookInfo);
            TipClearText();
            //更新 发送bookinfo对象字符
            UpBookInfo(params);
            //     alert("{jsonStr:'" + params + "'}");
        });

        //  alert($($(this).parent().parent().find('td')[2]).attr("name").trim());

    });


    //捕捉 BookInfo数据 删除图书事件监听
    $(".bt_deletebook").click(function () {
        TipModel("bookinfo");

        $("#book_add").hide();
        $("#book_change").show();
        Isable("#booknum", false);
        $("#booknum").val($($(this).parent().parent().find('td')[0]).text().trim());
        $("#bookname").val($($(this).parent().parent().find('td')[1]).text().trim());
        var booktypeid = Number($($(this).parent().parent().find('td')[2]).attr("name"));
        GetBookType("#book_type", function () {
            $("#book_type").val(booktypeid);
        });
        var bookcaseid = Number($($(this).parent().parent().find('td')[3]).attr("name"))
        GetBookCase("#book_case", function () {
            $("#book_case").val(bookcaseid);
        });
        $("#bookcbs").val($($(this).parent().parent().find('td')[4]).text().trim());
        $("#bookzz").val($($(this).parent().parent().find('td')[5]).text().trim());
        $("#bookprice").val($($(this).parent().parent().find('td')[6]).text().trim().replace('$', ''));
        $("#bookreadnum").val($($(this).parent().parent().find('td')[7]).text().trim());

        //绑定 删除事件
        $("#book_delete").click(function () {
            BookInfo.BookBarCode = Number($("#booknum").val());
            BookInfo.BookName = $("#bookname").val();
            BookType.typeID = Number($("#book_type").val());;
            BookType.typeName = $("#book_type option:selected").text();
            BookInfo.Book_Type = BookType;
            BookCase.bookcaseID = Number($("#book_case").val());
            BookCase.bookcaseName = $("#book_case option:selected").text();
            BookInfo.Book_Case = BookCase;
            BookInfo.BookConcern = $("#bookcbs").val();
            BookInfo.Price = $("#bookprice").val();
            BookInfo.Author = $("#bookzz").val();
            BookInfo.BorrowSum = $("#bookreadnum").val();
            var params = JSON.stringify(BookInfo);
            TipClearText();
            //更新 发送bookinfo对象字符
            DeleteBookInfo(params);
            //     alert("{jsonStr:'" + params + "'}");
        });

        setTip("sm", "是否删除《" + $("#bookname").val() + "》此书信息？", "<h5>删除图书信息简述如下：</h5> <br/>编号:" + $("#booknum").val() +
            "<br/>书名:" + $("#bookname").val() + "<br/>出版社:" + $("#bookcbs").val() +
            "<br/>作者:" + $("#bookzz").val(), null
        );
    });

    //捕捉 BookInfo数据 添加图书事件监听
    $("#addbook").click(function () {
        TipModel("bookinfo");
        setTipTitle("", "----图书信息添加----");
        GetBookCase("#book_case", function () { });
        GetBookType("#book_type", function () { });
        $("#book_change").hide();
        $("#book_add").show();
        TipClearText();
        Isable("#booknum", true);

        //绑定 添加图书事件
        $("#book_add").click(function () {

            BookInfo.BookBarCode = Number($("#booknum").val());
            BookInfo.BookName = $("#bookname").val();
            BookType.typeID = Number($("#book_type").val());;
            BookType.typeName = $("#book_type option:selected").text();
            BookInfo.Book_Type = BookType;
            BookCase.bookcaseID = Number($("#book_case").val());
            BookCase.bookcaseName = $("#book_case option:selected").text();
            BookInfo.Book_Case = BookCase;
            BookInfo.BookConcern = $("#bookcbs").val();
            BookInfo.Price = $("#bookprice").val();
            BookInfo.Author = $("#bookzz").val();
            BookInfo.BorrowSum = $("#bookreadnum").val();
            var params = JSON.stringify(BookInfo);
            //添加 发送bookinfo对象字符
            AddBookInfo(params);
            //     alert("{jsonStr:'" + params + "'}");

        });

    });



    //捕捉type数据 修改图书type事件监听
    $(".bt_changebooktype").click(function () {
        TipModel("type");
        setTipTitle("", "----图书类别修改----");

        $("#booktype_add").hide();
        $("#booktype_change").show();
        Isable("#booktype_id", false);

        $("#booktype_id").val($($(this).parent().parent().find('td')[1]).text().trim());
        $("#booktype_name").val($($(this).parent().parent().find('td')[2]).text().trim());
        $("#booktype_readnum").val($($(this).parent().parent().find('td')[3]).text().trim());

        //绑定更新事件
        $("#booktype_change").click(function () {

            var bt = BookType;
            bt.typeID = Number($("#booktype_id").val());
            bt.typeName = $("#booktype_name").val();
            bt.borrowDay = Number($("#booktype_readnum").val())
            //alert($("#booktype_id").val());
            //alert($("#booktype_name").val());

            var params = JSON.stringify(bt);
            //更新 发送bookinfo对象字符
            //  alert(params);
            UpBookType(params)
            // alert("{jsonStr:'" + params + "'}");
        });

        //  alert($($(this).parent().parent().find('td')[2]).attr("name").trim());

    });


    //捕捉 type数据 添加图书type事件监听
    $("#addbooktype").click(function () {
        TipModel("type");
        setTipTitle("", "----图书类别添加----");
        $("#booktype_add").show();
        $("#booktype_change").hide();
        TipClearText();
        Isable("#booknum", false);
        //绑定 添加图书事件
        $("#booktype_add").click(function () {

            var bt = BookType;
            bt.typeID = Number($("#booktype_id").val());
            bt.typeName = $("#booktype_name").val();
            bt.borrowDay = Number($("#booktype_readnum").val())
            //alert($("#booktype_id").val());
            //alert($("#booktype_name").val());

            var params = JSON.stringify(bt);
            //更新 发送bookinfo对象字符
            alert(params);
            var params = JSON.stringify(bt);
            //添加 发送bookinfo对象字符
            AddBookType(params);
            //     alert("{jsonStr:'" + params + "'}");

        });

    });

    //捕捉type数据 删除图书type事件监听
    $(".bt_deletebooktype").click(function () {
        TipModel("type");

        $("#booktype_id").val($($(this).parent().parent().find('td')[1]).text().trim());
        $("#booktype_name").val($($(this).parent().parent().find('td')[2]).text().trim());
        $("#booktype_readnum").val($($(this).parent().parent().find('td')[3]).text().trim());
        setTip("sm", "是否图书类别-" + $("#booktype_name").val() + "? 删除后将无法挽回...三丝~",
            '类别详情<br/>' + '<small>ID: ' + $("#booktype_id").val() +
            '</br>NAME:' + $("#booktype_name").val()
            + '</small><br/> ' +
            '<label for="booktype">选择继承此类图书的类型</label> <select id="book_type" class="form-control"></select>', null
        );
        GetBookType("#book_type")
        //绑定删除事件
        $("#booktype_delete").click(function () {

            var bt = BookType;
            bt.typeID = Number($("#booktype_id").val());
            bt.typeName = $("#booktype_name").val();
            bt.borrowDay = Number($("#book_type").val())
            //alert($("#booktype_id").val());
            //alert($("#booktype_name").val());

            var params = JSON.stringify(bt);
            //更新 发送bookinfo对象字符
            alert(params);
            DeleteBookType(params)
            // alert("{jsonStr:'" + params + "'}");
        });

        //  alert($($(this).parent().parent().find('td')[2]).attr("name").trim());

    });




    //捕捉Case数据 修改图书Case事件监听

    $(".bt_changebookcase").click(function () {
        TipModel("case");
        setTipTitle("", "----图书位置修改----");

        $("#bookcase_add").hide();
        $("#bookcase_change").show();
        Isable("#bookcase_id", false);

        $("#bookcase_id").val($($(this).parent().parent().find('td')[1]).text().trim());
        $("#bookcase_name").val($($(this).parent().parent().find('td')[2]).text().trim());

        //绑定更新事件
        $("#bookcase_change").click(function () {

            var bc = BookCase;
            bc.bookcaseID = Number($("#bookcase_id").val());
            bc.bookcaseName = $("#bookcase_name").val();
            //alert($("#bookcase_id").val());


            var params = JSON.stringify(bc);
            //更新 发送bookinfo对象字符
            alert(params);
            UpBookCase(params);
            // alert("{jsonStr:'" + params + "'}");
        });



    });


    //捕捉Case数据 添加图书Case事件监听
    $("#addbookcase").click(function () {
        TipModel("case");
        setTipTitle("", "----图书位置添加----");
        $("#bookcase_add").show();
        $("#bookcase_change").hide();
        TipClearText();
        Isable("#booknum", false);
        //绑定 添加图书事件
        $("#bookcase_add").click(function () {
            var bc = BookCase;
            bc.bookcaseID = Number($("#bookcase_id").val());
            bc.bookcaseName = $("#bookcase_name").val();
            var params = JSON.stringify(bc);
            //更新 发送bookinfo对象字符
            alert(params);
            AddBookCase(params);
        });

    });

    //捕捉Case数据 删除图书Case事件监听
    $(".bt_deletebookcase").click(function () {
        TipModel("case");
        $("#bookcase_id").val($($(this).parent().parent().find('td')[1]).text().trim());
        $("#bookcase_name").val($($(this).parent().parent().find('td')[2]).text().trim());

        setTip("sm", "是否图书位置-" + $("#bookcase_name").val() + "? 删除后将无法挽回...三丝~",
            '位置详情<br/>' + '<small>ID: ' + $("#bookcase_id").val() +
            '</br>NAME:' + $("#bookcase_name").val()
            + '</small><br/> ', null
        );

        //绑定更新事件
        $("#bookcase_delete").click(function () {

            var bc = BookCase;
            bc.bookcaseID = Number($("#bookcase_id").val());
            bc.bookcaseName = $("#bookcase_name").val();
            //alert($("#bookcase_id").val());
            var params = JSON.stringify(bc);
            //更新 发送bookinfo对象字符
            alert(params);
            DeleteBookCase(params);
            // alert("{jsonStr:'" + params + "'}");
        });

        //  alert($($(this).parent().parent().find('td')[2]).attr("name").trim());

    });



    function TipClearText() {
        $("#booknum").val("");
        $("#bookname").val("");
        $("#book_type").val(1);
        $("#book_case").val(1);
        $("#bookcbs").val("");
        $("#bookzz").val("");
        $("#bookprice").val("");
        $("#bookreadnum").val("");
        $("#booktype_id").val("");
        $("#booktype_name").val("");
        $("#booktype_readnum").val("");
    }

    function setTip(size, title, body, foot) {
        if (title != null) {
            $("#tip" + size + "-h").html(title);
        }
        if (body != null) {
            $("#tip" + size + "-b").html(body);
        } if (foot != null) {
            $("#tip" + size + "-f").html(foot);
        }

    }
    function setTipTitle(size, title) {
        if (title != null) {
            $("#tip" + size + "-h").html(title);
        }
    }
    function showTip(size) {
        $("#tip" + size).modal("show");
    }
    function closeTip(size) {
        $("#tip" + size).modal("hide");
    }
    function closeAllTip(size) {
        $("#tipsm").modal("hide");
        $("#tiplg").modal("hide");
        $("#tip").modal("hide");
    }
    function setAllTip(title, body, foot) {
        setTip("", title, body, foot);
        setTip("sm", title, body, foot);
        setTip("lg", title, body, foot);
    }
    function doTime(func, time) {
        setInterval(function () {
            func();
        }, time);
    }
    function doTimeOut(func, time) {
        setTimeout(function () {
            func();
        }, time);
    }
    function TipModel(model) {
        tipClear();
        var CancelBT = '<button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>';
        var BooktypeSelect = '<label for="booktype">图书类型</label>' +
            '<select id="book_type" class="form-control"></select>';
        var BookcaseSelect = '<label for="booksit">图书书架  <small>书架位置:-请选择</small></label>' +
            '<select id="book_case" class="form-control"></select>';

        var bookInfoTipBodyHtml =
            '<div class="form-group">' +
            '<label for= "booknum" > 图书条形码</label >' +
            '<input type="text" class="form-control" id="booknum" placeholder="请输入图书条形码" disabled />' +
            '<label for="bookname">图书名称</label>' +
            '<input type="text" class="form-control" id="bookname" placeholder="请输入图书名称" />' +
            BooktypeSelect +
            BookcaseSelect +
            '<label for="bookcbs">出版社</label>' +
            '<input type="text" class="form-control" id="bookcbs" placeholder="请输入出版社名称" />' +
            '<label for="bookzz">作者</label>' +
            '<input type="text" class="form-control" id="bookzz" placeholder="请输入作者名" />' +
            '<label for="bookprice">图书定价</label>' +
            '<input type="text" class="form-control" id="bookprice" placeholder="请输入图书定价" />' +
            '<label for="bookreadnum">借阅次数</label>' +
            '<input type="text" class="form-control" id="bookreadnum" placeholder="请输入借阅次数" />' +
            '</div>';
        var bookinfoTipfoot = CancelBT +
            '<button id="book_change" type="button" class="btn btn-secondary" data-dismiss="modal"> 修改</button >' +
            '<button id="book_add" type="button" class="btn btn-secondary" data-dismiss="modal">添加</button>';

        var bookinfoTipsmfoot = CancelBT +
            '<button id="book_delete" type="button" class="btn btn-secondary" data-dismiss="modal"> 确定</button >';
        var typeTipbody =
            '<label for="booktype_id">图书类型识别码(ID)</label>' +
            '<input type="text" class="form-control" id="booktype_id" placeholder="请输入类型码" disabled />' +
            '<label for="booktype_name">图书类型名称</label>' +
            '<input type="text" class="form-control" id="booktype_name" placeholder="请输入类型名称" />' +
            '<label for="booktype_readnum">图书类型可阅天数</label>' +
            '<input type="text" class="form-control" id="booktype_readnum" placeholder="请输入图书可阅天数" />';
        var typeTipfoot = CancelBT +
            '<button id="booktype_change" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>' +
            ' <button id="booktype_add" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>';
        var typeTipsmfoot = CancelBT +
            '<button id="booktype_delete" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>';

        var caseTipBody = '<label for="bookcase_id"> 图书位置识别码(ID)</label>' +
            '<input type="text" class="form-control" id="bookcase_id" placeholder="请输入类型码" disabled />' +
            '<label for="bookcase_name">图书位置描述</label>' +
            '<input type="text" class="form-control" id="bookcase_name" placeholder="请输入类型名称" />';
        var caseTipFoot = '<button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>' +
            ' <button id="bookcase_change" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>' +
            ' <button id="bookcase_add" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>';
        var caseTipsmfoot = CancelBT+
            '<button id="bookcase_delete" type="button" class="btn btn-secondary" data-dismiss="modal">确定</button>';






        if (model == "bookinfo") {
            setTip("", null, bookInfoTipBodyHtml, bookinfoTipfoot);
            setTip("sm", "", "", bookinfoTipsmfoot);
        }
        else if (model =="type") {
            setTip("", null, typeTipbody, typeTipfoot);
            setTip("sm", null, null, typeTipsmfoot);
        }
        else if (model=="case")
        {
            setTip("", null, caseTipBody, caseTipFoot);
            setTip("sm", null, null, caseTipsmfoot);
        }
        else {

        }

    }
    function tipClear() {
        setAllTip("", "");
    }



















    function ajx_post(url, data, fun) {
        $.ajax({
            url: url,  //调用后台方法  
            data: data,
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {
                fun();
            }
        });
    }

    function addbook() {
        $.ajax({
            url: "BookTypeMgr.aspx/BTAdd",  //调用后台方法  
            data: params,
            type: "post",
            dataType: 'text',
            contentType: "application/json; charset=utf-8",  //设置类型，注意一定不能丢  
            success: function (data) {
                if (data == '{"d":true}') {  //注意判断条件  
                    alert('chenggong');
                } else {
                    alert('shibai');
                }
                $("#dialog-form").dialog("close");
            }
        });

    }




});
