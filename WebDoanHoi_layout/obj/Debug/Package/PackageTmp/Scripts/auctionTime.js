CountActive = true;
 CountStepper = -1;
 DisplayFormat = "%%D%% Ngày, %%H%% Giờ, %%M%% Phút, %%S%% giây.";
 FinishMessage = "Phiên đấu giá đã kết thúc!";

var quickBidFlag = true;

CountStepper = Math.ceil(CountStepper);
if (CountStepper == 0)
 CountActive = false;
var SetTimeOutPeriod = (Math.abs(CountStepper)-1)*1000 + 990;

var updatedSeconds = false;
var secondsLeft;

function startTimer(auctionID, initialSecondsLeft) {
 CountBack(initialSecondsLeft, auctionID);
 setTimeout("updateTimer(" + auctionID + ")", 10000);
}

function updateTimer(auctionID) {

 /**
 getItemDetails(auctionID);

 url = "?page=auction:timer_ajax&auction_id=" + auctionID + "&escape=1";

 makeRequest(url, "timerHandler");
 */
}

function timerHandler(http_request) {

 if (http_request.readyState == 4) {
 if (http_request.status == 200) {
 var xmldoc = http_request.responseXML;
 secondsLeft = xmldoc.getElementsByTagName('auction-seconds-left')[0].firstChild.data;

auctionID = xmldoc.getElementsByTagName('auction-id')[0].firstChild.data;

 updatedSeconds = true;

 setTimeout("updateTimer(" + auctionID + ")", 10000);
 } else {
 alert('There was a problem with the request.');
 }
 }
}

function asynchUpdate(secs) {
 secondsLeft = secs;
 updatedSeconds = true;
}


function CountBack(secs, auctionID) {

 if(secondsLeft == "SUSPENDED" || secs == "SUSPENDED") {
 document.getElementById("auction_time_left").innerHTML = "Auction on Hold";
 hideQuickBidButton(auctionID);
 } else {

 if(updatedSeconds) {

 secs = secondsLeft;
 updatedSeconds = false;
 }

 if (secs < 0) {
 document.getElementById("auction_time_left").innerHTML = "Phiên đấu giá đã kết thúc !";
 return;
 }


 DisplayStr = DisplayFormat.replace(/%%D%%/g, calcage(secs,86400,100000));
 DisplayStr = DisplayStr.replace(/%%H%%/g, calcage(secs,3600,24));
 DisplayStr = DisplayStr.replace(/%%M%%/g, calcage(secs,60,60));
 DisplayStr = DisplayStr.replace(/%%S%%/g, calcage(secs,1,60));

document.getElementById("auction_time_left").innerHTML = DisplayStr;
 if (CountActive)
 setTimeout("CountBack(" + (secs+CountStepper) + "," + auctionID + ")", SetTimeOutPeriod);
 }
}



function calcage(secs, num1, num2) {
 s = ((Math.floor(secs/num1))%num2).toString();
 if (s.length < 2)
 s = "0" + s;
 return "<b>" + s + "</b>";
} 