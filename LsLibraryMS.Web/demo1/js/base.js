// window.addEventListener('online',  updateOnlineStatus);
// window.addEventListener('offline', updateOnlineStatus);
// var OnlineStatus=false;
window.onload=function ()
{


  window.addEventListener('online',  function(){
   OnlineStatus=true;
   alert("onLine");
 });
  window.addEventListener('offline', function(){
    OnlineStatus=false
    alert("offLine");
  });

}


// 获取连接状态
function get_status(){
  var connection = navigator.connection||navigator.mozConnection||navigator.webkitConnection||{tyep:'unknown'};
  var type_text = ['unknown','ethernet','wifi','2g','3g','4g','none'];

  if(typeof(connection.type) == "number"){
    connection.type_text = type_text[connection.type];
  }else{
    connection.type_text = connection.type;
  }
  if(typeof(connection.bandwidth) == "number"){
    if(connection.bandwidth > 10){
     connection.type = 'wifi';
   }else if(connection.bandwidth > 2){
     connection.type = '3g';
   }else if(connection.bandwidth > 0){
     connection.type = '2g';
   }else if(connection.bandwidth == 0){
     connection.type = 'none';
   }else{
     connection.type = 'unknown';
   }
 }

// alert(connection.type);
// var re_el = document.getElementById("re");
// var btn_el = document.getElementById("btn");

var html = 'Type : '+connection.type_text;
html += '\nBandwidth : '+connection.bandwidth;
html += '\nisOnline : '+navigator.onLine;
alert(html) ;
}


 // 获取getURL
 function getURL(url) {
  	// $("#msg").html("");
      var url = url;//请求的url
      var dateTime = disptime();
      var time2 = dateTime.DateTime; 
      // $("#msg1").html("发送时间：" + time2); 
      $.ajax({
      	type: 'get',
      	url: '\\'+url,
      	cache: false,
        dataType: "jsonp", //跨域采用jsonp方式 
        processData: false,
        timeout:10000, //超时时间，毫秒
        complete: function (data) {
        	var dateTime2 = disptime();
        	var time22 = dateTime2.DateTime;
        	var htmlTxt =[];
        	if (data.status==200) {
        		htmlTxt.push("成功<br/>");
        	} else {
        		htmlTxt.push("失败<br/>");
        	}        
        	htmlTxt.push("readyState=" + data.readyState + "<br/>status=" + data.status + "<br/>statusText=" + data.statusText + "<br/>响应时间：" + time22);
        	var htmlString = htmlTxt.join('');
          alert(htmlString);
        	// $("#msg").html(htmlString);
        }       
      });
    }

  // 获取时间
  function disptime() {
  	var date = new Date();
      var yyyy = date.getFullYear();//四位年份
      var month = date.getMonth() + 1;//月份 0-11
      var day = date.getDate();//日
      var HH = date.getHours();//时
      var minute = date.getMinutes();//分钟
      var second = date.getSeconds();//秒
      var milliseconds=date.getMilliseconds();//毫秒
      if (month < 10) {
      	month = "0" + month;
      }
      if (day < 10) {
      	day = "0" + day;
      }
      if (HH < 10) {
      	HH = "0" + HH;
      }
      if (minute < 10) {
      	minute = "0" + minute;
      }
      if (second < 10) {
      	second = "0" + second;
      }
      var time = yyyy + "-" + month + "-" + day + " " + HH + ":" + minute + ":" + second + " " + milliseconds;
      var timeTxt = yyyy + month + day + HH + minute + second;
      var time = {
      	DateTime: time,
      	TimeTxt: timeTxt
      }
      return time;
    }

// 浏览器检测，获取，弹出框提醒IE  返回浏览器详情
function GetbrowserSys()
{


  var BrowserMatch = {  
    init: function() {  
      this.browser = this.getBrowser().browser || "An Unknown Browser";  
      this.version = this.getBrowser().version || "An Unknown Version";  
      this.OS = this.getOS() || "An Unknown OS";  
    },  
    getOS: function() {  
      if (navigator.platform.indexOf("Win") != -1) return "Windows";  
      if (navigator.platform.indexOf("Mac") != -1) return "Mac";  
      if (navigator.platform.indexOf("Linux") != -1) return "Linux";  
      if (navigator.userAgent.indexOf("iPhone") != -1) return "iPhone/iPod";  
    },  
    getBrowser: function() {  
      var rMsie = /(msie\s|trident\/7)([\w\.]+)/;  
      var rTrident = /(trident)\/([\w.]+)/;  
      var rFirefox = /(firefox)\/([\w.]+)/;  
      var rOpera = /(opera).+version\/([\w.]+)/;  
      var rNewOpera = /(opr)\/(.+)/;  
      var rChrome = /(chrome)\/([\w.]+)/;  
      var rSafari = /version\/([\w.]+).*(safari)/;  
      var ua = navigator.userAgent.toLowerCase();  
      var matchBS, matchBS2;  
      matchBS = rMsie.exec(ua);  
      if (matchBS != null) {  
        matchBS2 = rTrident.exec(ua);  
        if (matchBS2 != null) {  
          switch (matchBS2[2]) {  
            case "4.0":  
            return {  
              browser:  
              "IE",  
              version: "8"  
            };  
            break;  
            case "5.0":  
            return {  
              browser:  
              "IE",  
              version: "9"  
            };  
            break;  
            case "6.0":  
            return {  
              browser:  
              "IE",  
              version: "10"  
            };  
            break;  
            case "7.0":  
            return {  
              browser:  
              "IE",  
              version: "11"  
            };  
            break;  
            default:  
            return {  
              browser:  
              "IE",  
              version: "Undefined"  
            };  
          }  
        } else {  
          return {  
            browser: "IE",  
            version: matchBS[2] || "0"  
          };  
        }  
      }  
      matchBS = rFirefox.exec(ua);  
      if ((matchBS != null) && (!(window.attachEvent)) && (!(window.chrome)) && (!(window.opera))) {  
        return {  
          browser: matchBS[1] || "",  
          version: matchBS[2] || "0"  
        };  
      }  
      matchBS = rOpera.exec(ua);  
      if ((matchBS != null) && (!(window.attachEvent))) {  
        return {  
          browser: matchBS[1] || "",  
          version: matchBS[2] || "0"  
        };  
      }  
      matchBS = rChrome.exec(ua);  
      if ((matchBS != null) && ( !! (window.chrome)) && (!(window.attachEvent))) {  
        matchBS2 = rNewOpera.exec(ua);  
        if (matchBS2 == null) {  
          return {  
            browser: matchBS[1] || "",  
            version: matchBS[2] || "0"  
          };  
        } else {  
          return {  
            browser: "Opera",  
            version: matchBS2[2] || "0"  
          };  
        }  
      }  
      matchBS = rSafari.exec(ua);  
      if ((matchBS != null) && (!(window.attachEvent)) && (!(window.chrome)) && (!(window.opera))) {  
        return {  
          browser: matchBS[2] || "",  
          version: matchBS[1] || "0"  
        };  
      }  
    }  
  };  
  BrowserMatch.init();  
      // 获取浏览器名:BrowserMatch.browser;  
      // 获取浏览器版本:BrowserMatch.version;  
      // 获取所处操作系统:BrowserMatch.OS;  
      
      if (BrowserMatch.browser=="IE"&&BrowserMatch.version<9) {

        alert("您当前浏览器为：" + BrowserMatch.browser +"\nVersion："+ BrowserMatch.version+".0" + "\n所处操作系统为："+BrowserMatch.OS

          +"\n你当前的浏览器不支持本网页大多功能，\n为了更好体验宝宝提供的服务，\n请点点你的小手手升级或换个更厉害的浏览器吧！"
          );  


      }
      return "您当前浏览器为：" + BrowserMatch.browser +"\nVersion："+ BrowserMatch.version+".0" + "\n所处操作系统为："+BrowserMatch.OS;

    }

// 浏览器动态数据检测未联机执行函数
function conectError(){
    //网络不可访问时加载
    //

    //document.write("<scr"+"ipt src=\"##.js\"></sc"+"ript>");
   alert(" 警告 : Network disconnect  在加载静态库会影响网页的加载速度，请在网络连接情况进行图书馆里!\n 如需清除 或 取消 静态库加载 请联系我们！ ");
  }
  // 浏览器动态数据检测 联机执行函数
  function conectSuccess(){
    //
    //网络可访问时加载
    //document.write("<scr"+"ipt src=\"##.js\"></sc"+"ript>");
  //alert("Network connect!");
  }
  // 浏览器动态数据检测
  function connectionLisner()
  {
    var imgPath = "https://www.baidu.com/img/bd_logo1.png";
    var timeStamp = Date.parse(new Date());
    $("#connect-test").attr("src", imgPath + "?timestamp=" + timeStamp);
      
  }

  $(document).ready(function () {
  });