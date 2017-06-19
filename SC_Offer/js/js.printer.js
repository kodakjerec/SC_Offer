/**
 * @package js.printer
 * @author wenchi
 * @version 20080821
 * 
 * IE 5.5 6.0 7.0 測試OK
 * firefox 部份功能不適用
 * Opera , Safari 未測試
 * 
 */

/**
 * HOWTO:
 * 
 * 第一種方式：
 * 
 * 1. 於 <head></head> 之間加入 
 * 		<script src="js.printer.js"></script>
 * 	
 *		<script>
 *			var JsPrinter=new JsPrinter();
 *		</script>
 * 
 * 2. 於 <body></body> 之間 加入
 * 
 * 		<a href="#" onclick="JsPrinter.splitPage();">分頁</a> &nbsp;
 *		<a href="#" onclick="JsPrinter.prview();">預覽列印</a> &nbsp;
 *		<a href="#" onclick="JsPrinter.print();">列印</a> &nbsp;
 *		<a href="#" onclick="JsPrinter.setPrint();">設定印表機</a> &nbsp;
 *
 * 3. 於要分頁的節點加入 <div id="JsPrintSplit"></div>
 *  	
 * 
 * 
 * 第二種方式：
 * 
 * 1. 於要分頁的節點加入 <div id="JsPrintSplit"></div>
 * 
 * 2. 於 </body> 之前 加入
 * 		<script src="js.printer.js"></script>
 *		<script>
 *			var JsPrinter=new JsPrinter(1,1);	//	自動分頁，自動列印
 *			var JsPrinter=new JsPrinter(1);		//	自動分頁，自動列印
 *		</script>
 * 
 * 
 * 
 *  Object Public Method :
 *  1. JsPrinter.print(); 			//	列印
 *  2. JsPrinter.prview();			//	預覽列印	
 *  以上 IE && FireFox 適用
 *  
 *  3. JsPrinter.splitPage();		//	分頁
 *  4. JsPrinter.setPrint();		//	設定印表機
 *  以上 IE 適用 ， FireFox 不適用
 * 
 * 
 * 
 *  註：
 *  1. 如果要使用完整功能，請於<body> 之後加入 
 *  <object id="WebBrowser" width=0 height=0 classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object>
 *  2. Firefox 如果要使用完整功能 請安裝 Firefox IE核心
 *  
 *  
 */


/**
 * WebBrowser 說明
 * IE 5.5 6.0 7.0 測試OK
 * firefox不適用
 * Opera , Safari 未測試
 * 
 * 
 * WebBrowser.ExecWB(1,1) 打開
 * WebBrowser.ExecWB(2,1) 關閉現在所有的IE窗口，並打開一個新窗口
 * WebBrowser.ExecWB(4,1) 保存網頁
 * WebBrowser.ExecWB(6,1) 打印
 * WebBrowser.ExecWB(7,1) 打印預覽
 * WebBrowser.ExecWB(8,1) 打印頁面設置
 * WebBrowser.ExecWB(10,1) 查看頁面屬性
 * WebBrowser.ExecWB(15,1) 好像是撤銷，有待確認
 * WebBrowser.ExecWB(17,1) 全選
 * WebBrowser.ExecWB(22,1) 刷新
 * WebBrowser.ExecWB(45,1) 關閉窗體無提示
 * 
 */

/**
 * @param {int} autoSplit		自動分頁，預設為0 
 * @param {int} autoPrint		自動打印，預設為0 
 * @see http://nievor.wordpress.com/2008/07/31/javascript_print_preview/
 */
function JsPrinter (autoSplit,autoPrint){
	
	var autoSplilt,autoPrint;

	if (!autoSplit) this.autoSplilt=0;
	else this.autoSplilt=Math.max(eval(autoSplit),0);
	
	if (!autoPrint) this.autoPrint=0;
	else this.autoPrint=Math.max(eval(autoSplit),0);
	
	
	if (this.autoSplilt==1) this.__splitPage();
	if (this.autoPrint==1)  this.print();
	
	return true;
	
}

/** private member **/
JsPrinter.prototype.__tag="JsPrintSplit";
//JsPrint.prototype.autoSplilt=1;
//JsPrint.prototype.autoPrint=1;



/**
 *  do change it
 */
JsPrinter.prototype.isIE  = document.all ? 1 : 0
JsPrinter.prototype.isNs4 = document.layers ? 1 : 0
JsPrinter.prototype.isDom = document.getElementById ? 1 : 0
JsPrinter.prototype.isMac = navigator.platform == "MacPPC"
JsPrinter.prototype.isMo5 = document.getElementById && !document.all ? 1 : 0
JsPrinter.prototype.isWebBrowser=false;
JsPrinter.prototype.totalPage=0;


JsPrinter.prototype.print = function (){
	window.print();
}

JsPrinter.prototype.prview = function (){
	
	if (this.isWebBrowser==false) this.__getWebBrowser();
	
	if (this.isMo5 == 1 || this.isWebBrowser==0) {
		alert("WebBrowser not support print View");
		return false;
	}
	WebBrowser.ExecWB(7,1);
}

JsPrinter.prototype.setPrint = function (){
	
	if (this.isWebBrowser==false) this.__getWebBrowser();

	if (this.isMo5 == 1 || this.isWebBrowser==0) {
		alert("WebBrowser not support this function");
		return false;
	}	
	WebBrowser.ExecWB(8,1);
	
}

JsPrinter.prototype.splitPage = function (){
	this.__splitPage();
}

JsPrinter.prototype.unSplitPage = function (){
	this.__splitPage(false);
}

JsPrinter.prototype.setTag = function (tag){
	this.__tag=tag;
}


/**
 * private method
 */
JsPrinter.prototype.__getWebBrowser = function (){
	this.isWebBrowser = document.getElementById("WebBrowser") ? 1 : 0
}


/**
 * private method
 * @see http://www.w3schools.com/HTMLDOM/prop_style_pagebreakbefore.asp
 */
JsPrinter.prototype.__splitPage = function (disable){
	
	if (!disable) var isSpilt="always";
	else var isSpilt="avoid";
	
	var rows=document.getElementsByTagName("div");
	
	for (var i=0;i<rows.length;i++){
		if (rows[i].id==this.__tag){
			rows[i].style.pageBreakBefore="always";
			this.totalPage++;
		}
	}
	
}

