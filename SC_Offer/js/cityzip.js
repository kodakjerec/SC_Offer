﻿function SubtypeBuild(num) {
    var ctr = 1;
    document.CodeForm.ddl_Subtype.selectedIndex = 0;
    document.CodeForm.tbx_Zipcode.value = "";
    document.CodeForm.ddl_Subtype.options[0] = new Option("請選擇區域", "");
    
    //避免頁面重新載入時出現錯誤
    if(num=="")
    document.CodeForm.ddl_City.selectedIndex = 0;
    /*
    定義二階選單內容
    if(num=="第一階下拉選單的值") {	document.CodeForm.ddl_Subtype.options[ctr]=new Option("第二階下拉選單的顯示名稱","第二階下拉選單的值");	ctr=ctr+1;	}
    */
    /*臺北市*/
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中正區", "100"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大同區", "103"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中山區", "104"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("松山區", "105"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大安區", "106"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("萬華區", "108"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("信義區", "110"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("士林區", "111"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北投區", "112"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("內湖區", "114"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南港區", "115"); ctr = ctr + 1; }
    if (num == "01") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("文山區", "116"); ctr = ctr + 1; }
    /*基隆市*/
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("仁愛區", "200"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("信義區", "201"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中正區", "202"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中山區", "203"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("安樂區", "204"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("暖暖區", "205"); ctr = ctr + 1; }
    if (num == "02") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("七堵區", "206"); ctr = ctr + 1; }
    /*臺北縣*/
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("萬里鄉", "207"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金山鄉", "208"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("板橋市", "220"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("汐止市", "221"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("深坑鄉", "222"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("石碇鄉", "223"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("瑞芳鎮", "224"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("平溪鄉", "226"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("雙溪鄉", "227"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("貢寮鄉", "228"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新店市", "231"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("坪林鄉", "232"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("烏來鄉", "233"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("永和市", "234"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中和市", "235"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("土城市", "236"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三峽鎮", "237"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("樹林市", "238"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鶯歌鎮", "239"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三重市", "241"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新莊市", "242"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("泰山鄉", "243"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("林口鄉", "244"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("蘆洲市", "247"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("五股鄉", "248"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("八里鄉", "249"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("淡水鎮", "251"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三芝鄉", "252"); ctr = ctr + 1; }
    if (num == "03") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("石門鄉", "253"); ctr = ctr + 1; }
    /*宜蘭縣*/
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("宜蘭市", "260"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("頭城鎮", "261"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("礁溪鄉", "262"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("壯圍鄉", "263"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("員山鄉", "264"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("羅東鎮", "265"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三星鄉", "266"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大同鄉", "267"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("五結鄉", "268"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("冬山鄉", "269"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("蘇澳鎮", "270"); ctr = ctr + 1; }
    if (num == "04") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南澳鄉", "272"); ctr = ctr + 1; }
    /*新竹縣市*/
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新竹市", "300"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹北市", "302"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("湖口鄉", "303"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新豐鄉", "304"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新埔鎮", "305"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("關西鎮", "306"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("芎林鄉", "307"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("寶山鄉", "308"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹東鎮", "310"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("五峰鄉", "311"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("橫山鄉", "312"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("尖石鄉", "313"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北埔鄉", "314"); ctr = ctr + 1; }
    if (num == "05") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("峨眉鄉", "315"); ctr = ctr + 1; }
    /*桃園縣*/
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中壢市", "320"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("平鎮市", "324"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("龍潭鄉", "325"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("楊梅鎮", "326"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新屋鄉", "327"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("觀音鄉", "328"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("桃園市", "330"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("龜山鄉", "330"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("龜山鄉", "333"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("八德市", "334"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大溪鎮", "335"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("復興鄉", "336"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大園鄉", "337"); ctr = ctr + 1; }
    if (num == "06") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("蘆竹鄉", "338"); ctr = ctr + 1; }
    /*苗栗縣*/
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹南鎮", "350"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("頭份鎮", "351"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三灣鄉", "352"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南庄鄉", "353"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("獅潭鄉", "354"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("後龍鎮", "356"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("通霄鎮", "357"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("苑裡鎮", "358"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("苗栗市", "360"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("造橋鄉", "361"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("頭屋鄉", "362"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("公館鄉", "363"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大湖鄉", "364"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("泰安鄉", "365"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("銅鑼鄉", "366"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三義鄉", "367"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西湖鄉", "368"); ctr = ctr + 1; }
    if (num == "07") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("卓蘭鎮", "369"); ctr = ctr + 1; }
    /*臺中市*/
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中　區", "400"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東　區", "401"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南　區", "402"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西　區", "403"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北　區", "404"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北屯區", "406"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西屯區", "407"); ctr = ctr + 1; }
    if (num == "08") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南屯區", "408"); ctr = ctr + 1; }
    /*臺中縣*/
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("太平市", "411"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大里市", "412"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("霧峰鄉", "413"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("烏日鄉", "414"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("豐原市", "420"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("后里鄉", "421"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("石岡鄉", "422"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東勢鎮", "423"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("和平鄉", "424"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新社鄉", "426"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("潭子鄉", "427"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大雅鄉", "428"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("神岡鄉", "429"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大肚鄉", "432"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("沙鹿鎮", "433"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("龍井鄉", "434"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("梧棲鎮", "435"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("清水鎮", "436"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大甲鎮", "437"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("外埔鄉", "438"); ctr = ctr + 1; }
    if (num == "09") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大安鄉", "439"); ctr = ctr + 1; }
    /*彰化縣*/
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("彰化市", "500"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("芬園鄉", "502"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("花壇鄉", "503"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("秀水鄉", "504"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹿港鎮", "505"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("福興鄉", "506"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("線西鄉", "507"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("和美鎮", "508"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("伸港鄉", "509"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("員林鎮", "510"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("社頭鄉", "511"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("永靖鄉", "512"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("埔心鄉", "513"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("溪湖鎮", "514"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大村鄉", "515"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("埔鹽鄉", "516"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("田中鎮", "520"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北斗鎮", "521"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("田尾鄉", "522"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("埤頭鄉", "523"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("溪州鄉", "524"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹塘鄉", "525"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("二林鎮", "526"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大城鄉", "527"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("芳苑鄉", "528"); ctr = ctr + 1; }
    if (num == "10") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("二水鄉", "530"); ctr = ctr + 1; }
    /*南投縣*/
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南投市", "540"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中寮鄉", "541"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("草屯鎮", "542"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("國姓鄉", "544"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("埔里鎮", "545"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("仁愛鄉", "546"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("名間鄉", "551"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("集集鎮", "552"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("水里鄉", "553"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("魚池鄉", "555"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("信義鄉", "556"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹山鎮", "557"); ctr = ctr + 1; }
    if (num == "11") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹿谷鄉", "558"); ctr = ctr + 1; }
    /*嘉義縣市*/
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("嘉義市", "600"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("番路鄉", "602"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("梅山鄉", "603"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹崎鄉", "604"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("阿里山", "605"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中埔鄉", "606"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大埔鄉", "607"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("水上鄉", "608"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹿草鄉", "611"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("太保市", "612"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("朴子市", "613"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東石鄉", "614"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("六腳鄉", "615"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新港鄉", "616"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("民雄鄉", "621"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大林鎮", "622"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("溪口鄉", "623"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("義竹鄉", "624"); ctr = ctr + 1; }
    if (num == "12") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("布袋鎮", "625"); ctr = ctr + 1; }
    /*雲林縣*/
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("斗南鎮", "630"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大埤鄉", "631"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("虎尾鎮", "632"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("土庫鎮", "633"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("褒忠鄉", "634"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東勢鄉", "635"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("台西鄉", "636"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("崙背鄉", "637"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("麥寮鄉", "638"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("斗六市", "640"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("林內鄉", "643"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("古坑鄉", "646"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("莿桐鄉", "647"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西螺鎮", "648"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("二崙鄉", "649"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北港鎮", "651"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("水林鄉", "652"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("口湖鄉", "653"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("四湖鄉", "654"); ctr = ctr + 1; }
    if (num == "13") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("元長鄉", "655"); ctr = ctr + 1; }
    /*臺南市*/
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("中西區", "700"); ctr = ctr + 1; }
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東　區", "701"); ctr = ctr + 1; }
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南　區", "702"); ctr = ctr + 1; }
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北　區", "704"); ctr = ctr + 1; }
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("安平區", "708"); ctr = ctr + 1; }
    if (num == "14") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("安南區", "709"); ctr = ctr + 1; }
    /*臺南縣*/
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("永康市", "710"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("歸仁鄉", "711"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新化鎮", "712"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("左鎮鄉", "713"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("玉井鄉", "714"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("楠西鄉", "715"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南化鄉", "716"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("仁德鄉", "717"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("關廟鄉", "718"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("龍崎鄉", "719"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("官田鄉", "720"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("麻豆鎮", "721"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("佳里鎮", "722"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西港鄉", "723"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("七股鄉", "724"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("將軍鄉", "725"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("學甲鎮", "726"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北門鄉", "727"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新營市", "730"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("後壁鄉", "731"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("白河鎮", "732"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東山鄉", "733"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("六甲鄉", "734"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("下營鄉", "735"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("柳營鄉", "736"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹽水鎮", "737"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("善化鎮", "741"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新市鄉", "741"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大內鄉", "742"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("山上鄉", "743"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新市鄉", "744"); ctr = ctr + 1; }
    if (num == "15") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("安定鄉", "745"); ctr = ctr + 1; }
    /*高雄市*/
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新興區", "800"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("前金區", "801"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("苓雅區", "802"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹽埕區", "803"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鼓山區", "804"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("旗津區", "805"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("前鎮區", "806"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三民區", "807"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("楠梓區", "811"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("小港區", "812"); ctr = ctr + 1; }
    if (num == "16") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("左營區", "813"); ctr = ctr + 1; }
    /*高雄縣*/
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("仁武鄉", "814"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大社鄉", "815"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("岡山鎮", "820"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("路竹鄉", "821"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("阿蓮鄉", "822"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("田寮鄉", "823"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("燕巢鄉", "824"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("橋頭鄉", "825"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("梓官鄉", "826"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("彌陀鄉", "827"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("永安鄉", "828"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("湖內鄉", "829"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鳳山市", "830"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大寮鄉", "831"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("林園鄉", "832"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鳥松鄉", "833"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大樹鄉", "840"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("旗山鎮", "842"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("美濃鎮", "843"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("六龜鄉", "844"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("內門鄉", "845"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("杉林鄉", "846"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("甲仙鄉", "847"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("桃源鄉", "848"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三民鄉", "849"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("茂林鄉", "851"); ctr = ctr + 1; }
    if (num == "17") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("茄萣鄉", "852"); ctr = ctr + 1; }
    /*澎湖縣*/
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("馬公市", "880"); ctr = ctr + 1; }
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("西嶼鄉", "881"); ctr = ctr + 1; }
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("望安鄉", "882"); ctr = ctr + 1; }
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("七美鄉", "883"); ctr = ctr + 1; }
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("白沙鄉", "884"); ctr = ctr + 1; }
    if (num == "18") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("湖西鄉", "885"); ctr = ctr + 1; }
    /*屏東縣*/
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("屏東市", "900"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("三地門", "901"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("霧台鄉", "902"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("瑪家鄉", "903"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("九如鄉", "904"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("里港鄉", "905"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("高樹鄉", "906"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹽埔鄉", "907"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("長治鄉", "908"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("麟洛鄉", "909"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("竹田鄉", "911"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("內埔鄉", "912"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("萬丹鄉", "913"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("潮州鎮", "920"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("泰武鄉", "921"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("來義鄉", "922"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("萬巒鄉", "923"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("崁頂鄉", "924"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新埤鄉", "925"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南州鄉", "926"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("林邊鄉", "927"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東港鎮", "928"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("琉球鄉", "929"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("佳冬鄉", "931"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新園鄉", "932"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("枋寮鄉", "940"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("枋山鄉", "941"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("春日鄉", "942"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("獅子鄉", "943"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("車城鄉", "944"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("牡丹鄉", "945"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("恆春鎮", "946"); ctr = ctr + 1; }
    if (num == "19") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("滿州鄉", "947"); ctr = ctr + 1; }
    /*臺東縣*/
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("台東市", "950"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("綠島鄉", "951"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("蘭嶼鄉", "952"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("延平鄉", "953"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("卑南鄉", "954"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鹿野鄉", "955"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("關山鎮", "956"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("海端鄉", "957"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("池上鄉", "958"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東河鄉", "959"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("成功鎮", "961"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("長濱鄉", "962"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("太麻里", "963"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金峰鄉", "964"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("大武鄉", "965"); ctr = ctr + 1; }
    if (num == "20") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("達仁鄉", "966"); ctr = ctr + 1; }
    /*花蓮縣*/
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("花蓮市", "970"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("新城鄉", "971"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("秀林鄉", "972"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("吉安鄉", "973"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("壽豐鄉", "974"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("鳳林鎮", "975"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("光復鄉", "976"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("豐濱鄉", "977"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("瑞穗鄉", "978"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("萬榮鄉", "979"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("玉里鎮", "981"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("卓溪鄉", "982"); ctr = ctr + 1; }
    if (num == "21") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("富里鄉", "983"); ctr = ctr + 1; }
    /*金門縣*/
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金沙鎮", "890"); ctr = ctr + 1; }
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金湖鎮", "891"); ctr = ctr + 1; }
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金寧鄉", "892"); ctr = ctr + 1; }
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("金城鎮", "893"); ctr = ctr + 1; }
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("烈嶼鄉", "894"); ctr = ctr + 1; }
    if (num == "22") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("烏坵鄉", "896"); ctr = ctr + 1; }
    /*連江縣*/
    if (num == "23") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南竿鄉", "209"); ctr = ctr + 1; }
    if (num == "23") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("北竿鄉", "210"); ctr = ctr + 1; }
    if (num == "23") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("莒光鄉", "211"); ctr = ctr + 1; }
    if (num == "23") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東引鄉", "212"); ctr = ctr + 1; }
    /*南海諸島*/
    if (num == "24") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("東　沙", "817"); ctr = ctr + 1; }
    if (num == "24") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("南　沙", "819"); ctr = ctr + 1; }
    /*釣魚台列嶼*/
    if (num == "25") { document.CodeForm.ddl_Subtype.options[ctr] = new Option("釣魚台列嶼", "290"); ctr = ctr + 1; }

    document.CodeForm.ddl_Subtype.length = ctr;
    document.CodeForm.ddl_Subtype.options[0].selected = true;
} 
