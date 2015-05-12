Cordova Parse plugin
====================
# Overview #
parse push notification

[android, ios, wp8] [cordova cli] [xdk]

requires parse account http://parse.com

Parse android SDK 1.9.0
Parse ios SDK
Parse wp8 SDK

this is open source cordova plugin.

# Change log #
```c
```
# Install plugin #

## Cordova cli ##
```c
cordova plugin add com.cranberrygame.cordova.plugin.pushnotification.parse
```

## Xdk ##
```c
XDK PORJECTS - your_xdk_project - CORDOVA 3.X HYBRID MOBILE APP SETTINGS - PLUGINS AND PERMISSIONS - Third Party Plugins - Add a Third Party Plugin - Get Plugin from the Web -

Name: revmob
Plugin ID: com.cranberrygame.cordova.plugin.pushnotification.parse
[v] Plugin is located in the Apache Cordova Plugins Registry
```

## Phonegap build service (config.xml) ##
```c
<gap:plugin name="com.cranberrygame.cordova.plugin.pushnotification.parse" source="plugins.cordova.io" />
```

# Server setting #
```c
```

<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/1.png"><br>
<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/2.png"><br>
<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/3.png"><br>
<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/4.png"><br>
<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/5.png"><br>
<img src="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/doc/6.png">

# API #
```javascript
var applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
var clientKey = "REPLACE_THIS_WITH_YOUR_CLIENT_KEY";

/*
var applicationId;
var clientKey;
//android
if (navigator.userAgent.match(/Android/i)) {
	applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
	clientKey = "REPLACE_THIS_WITH_YOUR_CLIENT_KEY";
}
//ios
else if (navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPad/i)) {
	applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
	clientKey = "REPLACE_THIS_WITH_YOUR_CLIENT_KEY";
}
//wp8
else if( navigator.userAgent.match(/Windows Phone/i) ) {
	applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
	clientKey = "REPLACE_THIS_WITH_YOUR_CLIENT_KEY";
}
*/

document.addEventListener("deviceready", function(){

	//call registerAsPushNotificationClient internally
	window.parse.setUp(applicationId, clientKey);
	
	//registerAsPushNotificationClient callback
	window.parse.onRegisterAsPushNotificationClientSucceeded = function() {
		alert('onRegisterAsPushNotificationClientSucceeded');
	};
	window.parse.onRegisterAsPushNotificationClientFailed = function() {
		alert('onRegisterAsPushNotificationClientFailed');
	};
	
	//subscribe callback
	window.parse.onSubscribeToChannelSucceeded = function() {
		alert('onSubscribeToChannelSucceeded');
	};
	window.parse.onSubscribeToChannelFailed = function() {
		alert('onSubscribeToChannelFailed');
	};	
	//unsubscribe callback
	window.parse.onUnsubscribeSucceeded = function() {
		alert('onUnsubscribeSucceeded');
	};
	window.parse.onUnsubscribeFailed = function() {
		alert('onUnsubscribeFailed');
	};	
}, false);

//
window.parse.subscribeToChannel('Game');//parameter: channel

//
window.parse.unsubscribe('Game');//parameter: channel
```
# Examples #
<a href="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/example/basic/index.html">example/basic/index.html</a><br>
<a href="https://github.com/cranberrygame/com.cranberrygame.cordova.plugin.pushnotification.parse/blob/master/example/advanced/index.html">example/advanced/index.html</a><br>

# Test #

[![](http://img.youtube.com/vi/xX4znfZx8HE/0.jpg)](https://www.youtube.com/watch?v=xX4znfZx8HE&feature=youtu.be "Youtube")

You can also run following test apk.
https://dl.dropboxusercontent.com/u/186681453/pluginsforcordova/parse/parsetest.apk

# Useful links #

Plugin For Cordova<br>
http://cranberrygame.github.io?referrer=github

# Credits #

https://github.com/avivais/phonegap-parse-plugin
