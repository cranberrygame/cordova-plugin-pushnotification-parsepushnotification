using System;
using System.Collections.Generic;
using Parse;
using WPCordovaClassLib.Cordova;

namespace WPCordovaClassLib.Cordova.Commands {
    public class ParsePlugin : BaseCommand {
		private string applicationId;
		private string clientKey;
	
		public void setUp(string args) {
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
		
        private void _setUp(string applicationId, string clientKey) {
			this.applicationId = applicationId;
			this.clientKey = clientKey;

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
		
        private void _subscribeToChannel(string channel) {
			await ParsePush.SubscribeAsync(channel);
			
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onSubscribeToChannelSucceeded");
			pr.KeepCallback = true;
			DispatchCommandResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.KeepCallback = true;
			//DispatchCommandResult(pr);			
        }
		
        private void _unsubscribe(string channel) {
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