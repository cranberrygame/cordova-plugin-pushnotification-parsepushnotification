//Copyright (c) 2014 Sang Ki Kwon (Cranberrygame)
//Email: cranberrygame@yahoo.com
//Homepage: http://cranberrygame.github.io
//License: MIT (http://opensource.org/licenses/MIT)
using System;
using System.Windows;
using System.Runtime.Serialization;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using System.Diagnostics; //Debug.WriteLine
//
using System.Collections.Generic;
using Parse;

namespace WPCordovaClassLib.Cordova.Commands {
    public class ParsePushNotificationPlugin : BaseCommand {
		private string applicationId;
		private string clientKey;

        public async void setUp(string args)
        {
            //string adUnit = JsonHelper.Deserialize<string[]>(args)[0];
            //string adUnitFullScreen = JsonHelper.Deserialize<string[]>(args)[1];
            //bool isOverlap = Convert.ToBoolean(JsonHelper.Deserialize<string[]>(args)[2]);
            //bool isTest = Convert.ToBoolean(JsonHelper.Deserialize<string[]>(args)[3]);
            //Debug.WriteLine("adUnit: " + adUnit);
            //Debug.WriteLine("adUnitFullScreen: " + adUnitFullScreen);
            //Debug.WriteLine("isOverlap: " + isOverlap);
            //Debug.WriteLine("isTest: " + isTest);			
            string applicationId = JsonHelper.Deserialize<string[]>(args)[0];
            string clientKey = JsonHelper.Deserialize<string[]>(args)[1];
            Debug.WriteLine("applicationId: " + applicationId);
            Debug.WriteLine("clientKey: " + clientKey);

            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _setUp(applicationId, clientKey);
            }); 
         }
		
/*		
        public void registerAsPushNotificationClient(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _registerAsPushNotificationClient();
            });
        }

        public void unregister(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _unregister();
            });
        }
*/

        public void subscribeToChannel(string args) {
            string channel = JsonHelper.Deserialize<string[]>(args)[0];

            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _subscribeToChannel(channel);
            });
        }

        public void subscribe(string args) {
            string channel = JsonHelper.Deserialize<string[]>(args)[0];

            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _unsubscribe(channel);
            });
        }

        private async void _setUp(string applicationId, string clientKey)
        {
			this.applicationId = applicationId;
			this.clientKey = clientKey;

            Debug.WriteLine("000000000000000 ");

            try
            {
                ParseClient.Initialize(applicationId, clientKey);
                await ParseInstallation.CurrentInstallation.SaveAsync();
                //String installationId = ParseInstallation.CurrentInstallation.InstallationId.ToString();             
                //String objectId = ParseInstallation.CurrentInstallation.ObjectId.ToString();
                //var installation = ParseInstallation.CurrentInstallation;
                //IEnumerable<string> subscribedChannels = installation.Channels;
            }
            catch(Exception ex){
                Debug.WriteLine("ex: "+ ex.Message);
                /*
ex: [net_WebHeaderInvalidControlChars]
Arguments: 
Debugging resource strings are unavailable. Often the key and arguments provide sufficient information to diagnose the problem. See http://go.microsoft.com/fwlink/?linkid=106663&Version=4.7.60408.0&File=System.Net.dll&Key=net_WebHeaderInvalidControlChars
Parameter name: name                 
                 */				
            }

            Debug.WriteLine("11111111111111111111 ");

			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);
        }
		
/*		
        private void _registerAsPushNotificationClient() {
			ParseClient.Initialize(appId, clientKey);
			await ParseInstallation.CurrentInstallation.SaveAsync();
			//String installationId = ParseInstallation.CurrentInstallation.InstallationId.ToString();             
			//String objectId = ParseInstallation.CurrentInstallation.ObjectId.ToString();
			//var installation = ParseInstallation.CurrentInstallation;
			//IEnumerable<string> subscribedChannels = installation.Channels;
			
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);			
        }
		
        private void _unregister() {
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onUnregisterSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);			
        }
*/

        private async void _subscribeToChannel(string channel)
        {
            ParsePush.SubscribeAsync(channel);
			
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onSubscribeToChannelSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);			
        }

        private async void _unsubscribe(string channel)
        {
            await ParsePush.UnsubscribeAsync(channel);
			
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onUnsubscribeSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);			
        }		
    }
}