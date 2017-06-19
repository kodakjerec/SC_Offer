


/// obj1 身分帳欄位ID
/// obj2 輸入完指向地欄位ID
/// obj3 身份證下拉選單ID
function checkid(obj1,obj2,obj3) {
    var cid = obj1.value;
    if (cid.length == 10) {
        var bool = true;

        if (IsID(cid)) {
            alert('身分證格式不正確');
            bool = false;
        }
        if (bool) {
            var ddl_Sex = obj3;

            var SexValue = cid.charAt(1);
            ddl_Sex[SexValue].selected = true;
            obj2.focus();
        }
    }
}

var isid; //用來判斷 TextBoxEqual 是否執行
//id驗證2 請配合 TextBoxEqual使用
function checkid2(obj1, checkname) {
    var cid = obj1.value;
    if (cid.length == 10) {

        if (IsID(cid)) {
            alert(checkname + '身分證格式不正確');
            isid = 'noPass';
        }
        else {
            isid = 'Pass';
        }
    }
    else {
        isid = 'noPass';
    }
}

//同XX使用者的使用
function TextBoxEqual(checkbox, obj1, obj2, obj3, obj4, obj5, obj6) {

    if (isid == 'Pass') {
        if (checkbox.checked) {
            if (obj2 != null) { obj2.value = obj1.value; }
            if (obj4 != null) { obj4.value = obj3.value; }
            if (obj6 != null) { obj6.innerHTML = obj5.value; }
        }
        else {
            if (obj2 != null) { obj2.value = "" };
            if (obj4 != null) { obj4.value = "" };
            if (obj6 != null) { obj6.innerHTML = ""};
        }
    }
    else {
        alert('身分正格式不正確!');
        checkbox.checked = false;
    }

}

//勾選要保人與被保人同一人
function equaluser(obj,OwnerID,OwnerName,InsID,InsName)
{
        if (obj.checked){ 
            if (InsID != null) { InsID.value = OwnerID.value; }
            if (InsName != null) { InsName.value = OwnerName.value; }
        }
        else{
            if (InsID != null) { InsID.value = ""; }
            if (InsName != null) { InsName.value = ""; }
        } 
}


//計算金額 當obj1和obj2 同為符合正整數 (格式有誤 請修改function中 isnum 變數)
function count_rate(obj1, obj2,obj3) {
    var amount = obj1.value;
    var rate = obj2.value;
    var newamount = 0;
    var now_amount = obj3
     //isnum = /^[0-9]+$/g;
     isnum = /^\d+(\.\d+)?$/;
     if (isnum.test(amount) && isnum.test(rate)) {
         newamount = accMul(amount, rate);
         
         now_amount.innerHTML = changeamont(newamount);
     }
     else {
         now_amount.innerHTML = "";
     }

 }


 //乘法函?，用?得到精确的乘法?果
 //?明：javascript的乘法?果?有?差，在??浮??相乘的?候?比?明?。??函?返回??精确的乘法?果。
 //?用：accMul(arg1,arg2)
 //返回值：arg1乘以arg2的精确?果
 function accMul(arg1, arg2) {
     var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
     try { m += s1.split(".")[1].length } catch (e) { }
     try { m += s2.split(".")[1].length } catch (e) { }
     return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
 }
 //?Number?型增加一?mul方法，?用起?更加方便。
 Number.prototype.mul = function(arg) {
     return accMul(arg, this);
 }

//轉千分位
 function changeamont(amount) {


         amount = amount + "";
         var re = /(-?\d+)(\d{3})/
         while (re.test(amount)) {
             amount = amount.replace(re, "$1,$2")
         }
         return amount;

 }


//身份證驗證邏輯
function IsID(nowID) {
    // 依照字母的編號排列，存入陣列備用。
    var letters = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'W', 'Z', 'I', 'O');
    // 儲存各個乘數
    var multiply = new Array(1, 9, 8, 7, 6, 5, 4, 3, 2, 1);
    var nums = new Array(2);
    var firstChar;
    var firstNum;
    var lastNum;
    var total = 0;

    // 取出第一個字元和最後一個數字。
    firstChar = nowID.charAt(0).toUpperCase();
    lastNum = nowID.charAt(9);
    // 找出第一個字母對應的數字，並轉換成兩位數數字。
    //身分證邏輯

    for (var i = 0; i < 26; i++) {
        if (firstChar == letters[i]) {
            firstNum = i + 10;
            nums[0] = Math.floor(firstNum / 10);
            nums[1] = firstNum - (nums[0] * 10);
            break;
        }
    }
    // 執行加總計算
    for (var i = 0; i < multiply.length; i++) {
        if (i < 2) {
            total += nums[i] * multiply[i];
        } else {
            total += parseInt(nowID.charAt(i - 1)) * multiply[i];
        }
    }

    return (10 - (total % 10)) != lastNum;

}

//群組驗證
function GroupReq(school,space,entertime,outtime,class1) {
    if (school != "" && space != "" && entertime != "" && outtime != "" && class1 != "") {
        alert('有問題');        
    }
}
//勾選同戶籍地址
function adduser(obj, tbx_Addr, tbx_Addrs) {
    if (obj.checked) {
        if (tbx_Addr != null) { tbx_Addrs.value = tbx_Addr.value; }
    }
    else {
        if (tbx_Addr != null) { tbx_Addr.value = ""; }
        if (tbx_Addrs != null) { tbx_Addrs.value = ""; }
    }
}