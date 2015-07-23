#import "ParsePushNotificationPlugin.h"
#import <Cordova/CDV.h>
#import <Parse/Parse.h>
#import <objc/runtime.h>
#import <objc/message.h>

@implementation ParsePushNotificationPlugin

@synthesize callbackIdKeepCallback;
//
@synthesize applicationId;
@synthesize clientKey;

- (void)setUp: (CDVInvokedUrlCommand*)command {
    //self.viewController
	//NSString *adUnit = [command.arguments objectAtIndex: 0];
	//NSString *adUnitFullScreen = [command.arguments objectAtIndex: 1];
	//BOOL isOverlap = [[command.arguments objectAtIndex: 2] boolValue];
	//BOOL isTest = [[command.arguments objectAtIndex: 3] boolValue];
	//NSLog(@"%@", adUnit);
	//NSLog(@"%@", adUnitFullScreen);
	//NSLog(@"%d", isOverlap);
	//NSLog(@"%d", isTest);
    NSString* applicationId = [command.arguments objectAtIndex:0];
    NSString* clientKey = [command.arguments objectAtIndex:1];
	//NSLog(@"%@", applicationId);
	//NSLog(@"%@", clientKey);
	
    self.callbackIdKeepCallback = command.callbackId;
	
    [self.commandDelegate runInBackground:^{
		[self _setUp:applicationId aClientKey:clientKey];	
    }];
}

/*
- (void)registerAsPushNotificationClient: (CDVInvokedUrlCommand *)command {
    [self.commandDelegate runInBackground:^{
		[self _registerAsPushNotificationClient];
    }];
}

- (void)unregister: (CDVInvokedUrlCommand *)command {
    [self.commandDelegate runInBackground:^{
		[self _unregister];
    }];
}
*/

- (void)subscribeToChannel: (CDVInvokedUrlCommand *)command {
	NSString* channel = [command.arguments objectAtIndex:0];
	NSLog(@"%@", channel);
	
    [self.commandDelegate runInBackground:^{
		[self _subscribeToChannel:channel];
    }];
}

- (void)unsubscribe: (CDVInvokedUrlCommand *)command {
	NSString* channel = [command.arguments objectAtIndex:0];
	NSLog(@"%@", channel);
	
    [self.commandDelegate runInBackground:^{
		[self _unsubscribe:channel];
    }];
}

- (void) _setUp:(NSString *)applicationId aClientKey:(NSString *)clientKey {
	self.applicationId = applicationId;
	self.clientKey = clientKey;
	
    [Parse setApplicationId:applicationId clientKey:clientKey];
    PFInstallation *currentInstallation = [PFInstallation currentInstallation];
    [currentInstallation save];    
	//PFInstallation *currentInstallation = [PFInstallation currentInstallation];
	//NSString *installationId = currentInstallation.installationId;	
	//NSString *objectId = currentInstallation.objectId;
	//NSArray *channels = currentInstallation.channels;
	
	CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"onRegisterAsPushNotificationClientSucceeded"];
	[pr setKeepCallbackAsBool:YES];
	[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
	//CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR];
	//[pr setKeepCallbackAsBool:YES];
	//[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];	
}

/*
- (void) _registerAsPushNotificationClient {
    [Parse setApplicationId:applicationId clientKey:clientKey];
    PFInstallation *currentInstallation = [PFInstallation currentInstallation];
    [currentInstallation save];
	//PFInstallation *currentInstallation = [PFInstallation currentInstallation];
	//NSString *installationId = currentInstallation.installationId;	
	//NSString *objectId = currentInstallation.objectId;
	//NSArray *channels = currentInstallation.channels;
	
	CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"onRegisterAsPushNotificationClientSucceeded"];
	[pr setKeepCallbackAsBool:YES];
	[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
	//CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR];
	//[pr setKeepCallbackAsBool:YES];
	//[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];	
}

- (void) _unregister {
	CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"onUnregisterSucceeded"];
	[pr setKeepCallbackAsBool:YES];
	[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
	//CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR];
	//[pr setKeepCallbackAsBool:YES];
	//[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
}
*/

- (void) _subscribeToChannel:(NSString *)channel {
    // Register for Push Notitications iOS 8
    if ([[UIApplication sharedApplication] respondsToSelector:@selector(registerUserNotificationSettings:)]) {
        UIUserNotificationType userNotificationTypes = (UIUserNotificationTypeAlert |
                                                        UIUserNotificationTypeBadge |
                                                        UIUserNotificationTypeSound);        
        UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:userNotificationTypes categories:nil];
        
        [[UIApplication sharedApplication] registerUserNotificationSettings:settings];
        [[UIApplication sharedApplication] registerForRemoteNotifications];
    } else {
        // Register for Push Notifications before iOS 8
        [[UIApplication sharedApplication] registerForRemoteNotificationTypes:(UIRemoteNotificationTypeBadge | UIRemoteNotificationTypeAlert | UIRemoteNotificationTypeSound)];
    }
	
	
    PFInstallation *currentInstallation = [PFInstallation currentInstallation];
    [currentInstallation addUniqueObject:channel forKey:@"channels"];
    [currentInstallation save];

	CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"onSubscribeToChannelSucceeded"];
	[pr setKeepCallbackAsBool:YES];
	[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
	//CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR];
	//[pr setKeepCallbackAsBool:YES];
	//[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];	
}

- (void) _unsubscribe:(NSString *)channel {
    PFInstallation *currentInstallation = [PFInstallation currentInstallation];
    [currentInstallation removeObject:channel forKey:@"channels"];
    [currentInstallation save];

	CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"onUnsubscribeSucceeded"];
	[pr setKeepCallbackAsBool:YES];
	[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
	//CDVPluginResult* pr = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR];
	//[pr setKeepCallbackAsBool:YES];
	//[self.commandDelegate sendPluginResult:pr callbackId:callbackIdKeepCallback];
}

@end

@implementation AppDelegate (ParsePushNotificationPlugin)

void MethodSwizzle(Class c, SEL originalSelector) {
    NSString *selectorString = NSStringFromSelector(originalSelector);
    SEL newSelector = NSSelectorFromString([@"swizzled_" stringByAppendingString:selectorString]);
    SEL noopSelector = NSSelectorFromString([@"noop_" stringByAppendingString:selectorString]);
    Method originalMethod, newMethod, noop;
    originalMethod = class_getInstanceMethod(c, originalSelector);
    newMethod = class_getInstanceMethod(c, newSelector);
    noop = class_getInstanceMethod(c, noopSelector);
    if (class_addMethod(c, originalSelector, method_getImplementation(newMethod), method_getTypeEncoding(newMethod))) {
        class_replaceMethod(c, newSelector, method_getImplementation(originalMethod) ?: method_getImplementation(noop), method_getTypeEncoding(originalMethod));
    } else {
        method_exchangeImplementations(originalMethod, newMethod);
    }
}

+ (void)load
{
    MethodSwizzle([self class], @selector(application:didRegisterForRemoteNotificationsWithDeviceToken:));
    MethodSwizzle([self class], @selector(application:didReceiveRemoteNotification:));
}

- (void)noop_application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)newDeviceToken
{
}

- (void)swizzled_application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)newDeviceToken
{
    // Call existing method
    [self swizzled_application:application didRegisterForRemoteNotificationsWithDeviceToken:newDeviceToken];
    // Store the deviceToken in the current installation and save it to Parse.
    PFInstallation *currentInstallation = [PFInstallation currentInstallation];
    [currentInstallation setDeviceTokenFromData:newDeviceToken];
    [currentInstallation saveInBackground];
}

- (void)noop_application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo
{
}

- (void)swizzled_application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo
{
    // Call existing method
    [self swizzled_application:application didReceiveRemoteNotification:userInfo];
    [PFPush handlePush:userInfo];
}

@end
