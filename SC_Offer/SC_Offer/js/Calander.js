function chkdate(obj) {
    var strText = obj.innerText
    if (obj.innerText.length < 2) {
        strText = '0' + obj.innerText
    }
    if (obj.style.backgroundColor != 'red') {
        obj.style.backgroundColor = 'red';
        document.getElementById('hid_SelectDay').value += strText + ',';
    }
    else {
        document.getElementById('hid_SelectDay').value = document.getElementById('hid_SelectDay').value.replace(strText + ',', '');
        obj.style.backgroundColor = '';
    }
    //            alert(obj.innerText);
}