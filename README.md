Cordova ParsePushNotification plugin
====================
# Overview #
parse push notification

[android, ios, wp8] [crodova cli] [xdk] [cocoon] [phonegap build service]

Requires parse account http://parse.com

Parse android SDK (v1.9.4)
Parse ios SDK (v1.7.5)
Parse wp8 SDK (v1.5.3)

This is open source cordova plugin.

You can see Plugins For Cordova in one page: http://cranberrygame.github.io?referrer=github

# Change log #
```c
```
# Install plugin #

## Cordova cli ##
https://cordova.apache.org/docs/en/edge/guide_cli_index.md.html#The%20Command-Line%20Interface - npm install -g cordova@5.0.0
```c
cordova plugin add cordova-plugin-pushnotification-parsepushnotification
(when build error, use github url: cordova plugin add https://github.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification)
```

## Xdk ##
https://software.intel.com/en-us/intel-xdk - Download XDK - XDK PORJECTS - [specific project] - CORDOVA 3.X HYBRID MOBILE APP SETTINGS - PLUGINS - Third Party Plugins - Add a Third Party Plugin - Get Plugin from the Web -
```c
Name: parsepushnotification
Plugin ID: cordova-plugin-pushnotification-parsepushnotification
[v] Plugin is located in the Apache Cordova Plugins Registry
```

## Cocoon ##
https://cocoon.io - Create project - [specific project] - Setting - Plugins - Custom - Git Url: https://github.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification.git - INSTALL - Save<br>

## Phonegap build service (config.xml) ##
https://build.phonegap.com/ - Apps - [specific project] - Update code - Zip file including config.xml
```c
<gap:plugin name="cordova-plugin-pushnotification-parsepushnotification" source="npm" />
```

## Construct2 ##
Download construct2 plugin<br>
https://dl.dropboxusercontent.com/u/186681453/pluginsforcordova/index.html#paid<br>
How to install c2 native plugins in xdk, cocoon and cordova cli<br>
https://plus.google.com/102658703990850475314/posts/XS5jjEApJYV

# Server setting #
```c
```

## parse.com ##
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/1.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/2.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/3.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/4.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/5.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/6.png"><br>

## ios ##
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios1.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios2.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios3.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios4.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_1.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_2.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_3.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_4.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_5.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/master/doc/ios_cer_to_p12_6.png"><br>
Configuring your App ID for Development Push Notifications<br>
https://www.parse.com/tutorials/ios-push-notifications<br>
How do I make a .p12<br>
http://appfurnace.com/2015/01/how-do-i-make-a-p12-file/

# API #
```javascript
var applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
var clientKey = "REPLACE_THIS_WITH_YOUR_CLIENT_KEY";

document.addEventListener("deviceready", function(){

	window.parsepushnotification.setUp(applicationId, clientKey);
	
	//registerAsPushNotificationClient callback (called after setUp)
	window.parsepushnotification.onRegisterAsPushNotificationClientSucceeded = function() {
		alert('onRegisterAsPushNotificationClientSucceeded');
	};
	window.parsepushnotification.onRegisterAsPushNotificationClientFailed = function() {
		alert('onRegisterAsPushNotificationClientFailed');
	};
	
	//subscribe callback
	window.parsepushnotification.onSubscribeToChannelSucceeded = function() {
		alert('onSubscribeToChannelSucceeded');
	};
	window.parsepushnotification.onSubscribeToChannelFailed = function() {
		alert('onSubscribeToChannelFailed');
	};	
	//unsubscribe callback
	window.parsepushnotification.onUnsubscribeSucceeded = function() {
		alert('onUnsubscribeSucceeded');
	};
	window.parsepushnotification.onUnsubscribeFailed = function() {
		alert('onUnsubscribeFailed');
	};	
}, false);

//
window.parsepushnotification.subscribeToChannel('Game');//parameter: channel

//
window.parsepushnotification.unsubscribe('Game');//parameter: channel
```
# Examples #
<a href="https://github.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/blob/master/example/basic/index.html">example/basic/index.html</a><br>
<a href="https://github.com/cranberrygame/cordova-plugin-pushnotification-parsepushnotification/blob/master/example/advanced/index.html">example/advanced/index.html</a><br>

# Test #

[![](http://img.youtube.com/vi/xX4znfZx8HE/0.jpg)](https://www.youtube.com/watch?v=xX4znfZx8HE&feature=youtu.be "Youtube")

You can also run following test apk.
https://dl.dropboxusercontent.com/u/186681453/pluginsforcordova/parsepushnotification/apk.html

# Useful links #

Plugin For Cordova<br>
http://cranberrygame.github.io?referrer=github

# Credits #

https://github.com/avivais/phonegap-parse-plugin
