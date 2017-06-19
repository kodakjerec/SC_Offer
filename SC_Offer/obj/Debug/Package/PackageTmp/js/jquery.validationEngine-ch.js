

(function($) {
	$.fn.validationEngineLanguage = function() {};
	$.validationEngineLanguage = {
		newLang: function() {
			$.validationEngineLanguage.allRules = 	{"required":{    			// Add your regex rules here, you can take telephone as an example
						"regex":"none",
						"alertText":"* 這個欄位必須填寫",
						"alertTextCheckboxMultiple":"* 請挑選一個選項",
						"alertTextCheckboxe":"* 這個選項必須勾選"},
					"length":{
						"regex":"none",
						"alertText":"*長度必須在 ",
						"alertText2":" 至 ",
						"alertText3": " 之間"},
					"maxCheckbox":{
						"regex":"none",
						"alertText":"* 最多選擇"},	
					"minCheckbox":{
						"regex":"none",
						"alertText":"* 至少選擇 ",
						"alertText2":" 項"},	
					"confirm":{
						"regex":"none",
						"alertText":"* 兩次輸入不一致,請重新輸入"},		
					"telephone":{
						"regex":"/^[0-9\-\(\)\ ]+$/",
						"alertText":"* 請輸入有效的電話號碼"},	
					"email":{
						"regex":"/^[a-zA-Z0-9_\.\-]+\@([a-zA-Z0-9\-]+\.)+[a-zA-Z0-9]{2,4}$/",
						"alertText":"* 請輸入有效的Email"},	
					"date":{
                         "regex":"/^[0-9]{4}\-\[0-9]{1,2}\-\[0-9]{1,2}$/",
                         "alertText":"* 無效日期, 格式為 YYYY-MM-DD"},
					"onlyNumber":{
						"regex":"/^[0-9\ ]+$/",
						"alertText":"* 只能輸入數字"},	
					"noSpecialCaracters":{
						"regex":"/^[0-9a-zA-Z]+$/",
						"alertText":"* 不能有特殊符號"},	
					"ajaxUser":{
						"file":"validateUser.php",
						"extraData":"name=eric",
						"alertTextOk":"* 這個使用者是有效的",	
						"alertTextLoad":"* Loading, 請稍等",
						"alertText":"* 這個使用者已經使用"},	
					"ajaxName":{
						"file":"validateUser.php",
						"alertText":"* 這個名字已被使用",
						"alertTextOk":"* 這個名字是有效的",	
						"alertTextLoad":"* Loading, 請稍等"},		
					"onlyLetter":{
						"regex":"/^[a-zA-Z\ \']+$/",
						"alertText":"* 只能輸入英文文字"},
					"validate2fields":{
    					"nname":"validate2fields",
    					"alertText":"* You must have a firstname and a lastname"}	
					}	
					
		}
	}
})(jQuery);

$(document).ready(function() {	
	$.validationEngineLanguage.newLang()
});