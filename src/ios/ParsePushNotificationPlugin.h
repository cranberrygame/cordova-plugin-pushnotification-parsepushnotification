#import <Cordova/CDV.h>
#import "AppDelegate.h"

@interface ParsePushNotificationPlugin: CDVPlugin

@property NSString *callbackIdKeepCallback;
//
@property NSString *applicationId;
@property NSString *clientKey;

- (void)setUp: (CDVInvokedUrlCommand*)command;
/*
- (void)registerAsPushNotificationClient: (CDVInvokedUrlCommand *)command;
- (void)unregister: (CDVInvokedUrlCommand *)command;
*/
- (void)subscribeToChannel: (CDVInvokedUrlCommand *)command;
- (void)unsubscribe: (CDVInvokedUrlCommand *)command;

@end

@interface AppDelegate (ParsePushNotificationPlugin)
@end
