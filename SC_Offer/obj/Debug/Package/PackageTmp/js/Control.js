/******************************************************
Version: 2010/07/15 1.0
Use:GridView 全選
input:CheckBox
output:
******************************************************/
function ckcheck(obj) {
    var chkcol = document.all.tags("input");
    for (i = 0; i < chkcol.length; i++) {
        if (chkcol[i].type == "checkbox") {
            if (obj.checked) chkcol[i].checked = true;
            else chkcol[i].checked = false;
        }
    }
}

/******************************************************
Version: 2010/07/15 1.0
Use:清除TextBox
input:
output:
******************************************************/
function doClear() {
    var formsNum = 0;
    var elementsNum = 0;
    for (formsNum = 0; formsNum < window.document.forms.length; formsNum++) {
        for (elementsNum = 0; elementsNum < window.document.forms[formsNum].elements.length; elementsNum++) {
            if (window.document.forms[formsNum].elements[elementsNum].type == "text") {
                window.document.forms[formsNum].elements[elementsNum].value = "";
            }
            if (window.document.forms[formsNum].elements[elementsNum].type == "password") {
                window.document.forms[formsNum].elements[elementsNum].value = "";
            }
        }
    }
}

/******************************************************
Version: 2010/08/06 1.0
Use:判斷是否顯示該列tr
input:
output:
******************************************************/
function ApplyDisplay() {
    var exam;
    //取得網址中第一個變數
    getUrl = window.location.search.substring(1);

    if (getUrl.length > 0) {
        exam = getUrl.substring(getUrl.search("=") + 1, getUrl.length);

        if (exam == "A") {
            tr_Type.style.display = "none";     //報名類組
            tr_Qual.style.display = "none";     //抵免資格
            tr_License.style.display = "none";  //證書
            tr_Subject.style.display = "block";  //報名科目
            tr_Date.style.display = "none";     //人身業務員登錄日
            tr_ID.style.display = "block";       //身分證影本
        }
        else if (exam == "B") {
            tr_Type.style.display = "none";
            tr_Qual.style.display = "none";
            tr_License.style.display = "none";
            tr_Subject.style.display = "block";
            tr_Date.style.display = "none";
            tr_ID.style.display = "block";
        }
        else if (exam == "C") {
            tr_Type.style.display = "block";
            tr_Qual.style.display = "block";
            tr_License.style.display = "none";
            tr_Subject.style.display = "none";
            tr_Date.style.display = "block";
            tr_ID.style.display = "none";
        }
        else if (exam == "D") {
            tr_Type.style.display = "none";
            tr_Qual.style.display = "none";
            tr_License.style.display = "none";
            tr_Subject.style.display = "none";
            tr_Date.style.display = "block";
            tr_ID.style.display = "none";
        }
    }
}

function onUpdating() {
    // 取得顯示訊息的Div 
    var updateProgressDiv = $get('updateProgressDiv');
    //  取得GridView
    var gridView = $get('" + this.gv_Sign.ClientID + "');
    // 顯示查詢訊息 
    updateProgressDiv.style.display = '';
    // 計算GridView及訊息Div的位置 
    var gridViewBounds = Sys.UI.DomElement.getBounds(gridView);
    var updateProgressDivBounds = Sys.UI.DomElement.getBounds(updateProgressDiv);
    var x;
    var y;
    x = gridViewBounds.x + Math.round(gridViewBounds.width / 2) - Math.round(updateProgressDivBounds.width / 2);
    y = gridViewBounds.y + Math.round(gridViewBounds.height / 2) - Math.round(updateProgressDivBounds.height / 2);
    //	設定訊息顯示的位置
    Sys.UI.DomElement.setLocation(updateProgressDiv, x, y);
}

function onUpdated() {
    // 取得顯示訊息的Div 
    var updateProgressDiv = $get('updateProgressDiv');
    // 設定隱藏  
    updateProgressDiv.style.display = 'none';
}
