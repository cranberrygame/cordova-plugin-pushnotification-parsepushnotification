package com.cranberrygame.cordova.plugin.pushnotification.parsepushnotification;

import org.apache.cordova.CordovaPlugin;
import org.apache.cordova.PluginResult;
import org.apache.cordova.CallbackContext;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONException;
import org.apache.cordova.CordovaInterface;
import org.apache.cordova.CordovaWebView;
import android.app.Activity;
import android.util.Log;
//
import com.parse.*;
//
import android.content.SharedPreferences;
import android.content.Context;

public class ParsePushNotificationPlugin extends CordovaPlugin {
	private static final String LOG_TAG = "ParsePushNotificationPlugin";
	private CallbackContext callbackContextKeepCallback;
	//
	private String applicationId;
	private String clientKey;	
	//
	private static boolean destroyed;
		
    @Override
	public void pluginInitialize() {
		super.pluginInitialize();
		//
    }	
	
	//@Override
	//public void onCreate(Bundle savedInstanceState) {//build error
	//	super.onCreate(savedInstanceState);
	//	//
	//}
	
	//@Override
	//public void onStart() {//build error
	//	super.onStart();
	//	//
	//}
	
  	@Override
    public void onPause(boolean multitasking) {		
        super.onPause(multitasking);
		//	
    }
      
    @Override
    public void onResume(boolean multitasking) {
        super.onResume(multitasking);
        //
    }
  	
	//@Override
	//public void onStop() {//build error
	//	super.onStop();
	//	//
	//}
	
    @Override
    public void onDestroy() {
        super.onDestroy();
		//
        destroyed = true;
    }
    
    public static boolean destroyed() {
    	return destroyed;
    }
    
	@Override
	public boolean execute(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {

		if (action.equals("setUp")) {
			setUp(action, args, callbackContext);

			return true;
		}			
/*		
		else if (action.equals("registerAsPushNotificationClient")) {
			registerAsPushNotificationClient(action, args, callbackContext);
			
			return true;
		}
		else if (action.equals("unregister")) {
			unregister(action, args, callbackContext);
						
			return true;
		}
*/		
		else if (action.equals("subscribeToChannel")) {
			subscribeToChannel(action, args, callbackContext);
			
			return true;
		}
		else if (action.equals("unsubscribe")) {
			unsubscribe(action, args, callbackContext);
						
			return true;
		}
		
		return false; // Returning false results in a "MethodNotFound" error.
	}
	
	private void setUp(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
		//Activity activity=cordova.getActivity();
		//webView
		//args.length()
		//args.getString(0)
		//args.getString(1)
		//args.getInt(0)
		//args.getInt(1)
		//args.getBoolean(0)
		//args.getBoolean(1)
		//JSONObject json = args.optJSONObject(0);
		//json.optString("adUnit")
		//json.optString("adUnitFullScreen")
		//JSONObject inJson = json.optJSONObject("inJson");
		//final String adUnit = args.getString(0);
		//final String adUnitFullScreen = args.getString(1);				
		//final boolean isOverlap = args.getBoolean(2);				
		//final boolean isTest = args.getBoolean(3);				
		//Log.d(LOG_TAG, String.format("%s", adUnit));			
		//Log.d(LOG_TAG, String.format("%s", adUnitFullScreen));
		//Log.d(LOG_TAG, String.format("%b", isOverlap));
		//Log.d(LOG_TAG, String.format("%b", isTest));		
		final String applicationId = args.getString(0);
		final String clientKey = args.getString(1);		
		Log.d(LOG_TAG, String.format("%s", applicationId));			
		Log.d(LOG_TAG, String.format("%s", clientKey));
		
		callbackContextKeepCallback = callbackContext;
			
		cordova.getActivity().runOnUiThread(new Runnable() {
			@Override
			public void run() {
				_setUp(applicationId, clientKey);
			}
		});
	}
	
/*	
	private void registerAsPushNotificationClient(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
		cordova.getActivity().runOnUiThread(new Runnable(){
			@Override
			public void run() {
				_registerAsPushNotificationClient();
			}
		});
	}

	private void unregister(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
		cordova.getActivity().runOnUiThread(new Runnable(){
			@Override
			public void run() {
				_unregister();
			}
		});
	}	
*/

	private void subscribeToChannel(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
		final String channel = args.getString(0);
		Log.d(LOG_TAG, String.format("%s", channel));
		
		cordova.getActivity().runOnUiThread(new Runnable(){
			@Override
			public void run() {
				_subscribeToChannel(channel);
			}
		});
	}

	private void unsubscribe(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
		final String channel = args.getString(0);
		Log.d(LOG_TAG, String.format("%s",channel));
		
		cordova.getActivity().runOnUiThread(new Runnable(){
			@Override
			public void run() {
				_unsubscribe(channel);
			}
		});
	}
	
    private void _setUp(String appId, String clientKey) {
		this.applicationId = appId;
		this.clientKey = clientKey;

       try {
           	Parse.initialize(cordova.getActivity(), applicationId, clientKey);
    	   	ParseInstallation.getCurrentInstallation().save();

			SharedPreferences sharedPref = cordova.getActivity().getSharedPreferences("cordova-plugin-pushnotification-parse", Context.MODE_PRIVATE);
			SharedPreferences.Editor editor = sharedPref.edit();
			editor.putString("applicationId", applicationId);
			editor.putString("clientKey", clientKey);
			editor.commit();
		
			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			pr.setKeepCallback(true);
			callbackContextKeepCallback.sendPluginResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.setKeepCallback(true);
			//callbackContextKeepCallback.sendPluginResult(pr);
        } 
        catch (ParseException e) {
			//PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			//pr.setKeepCallback(true);
			//callbackContextKeepCallback.sendPluginResult(pr);
			PluginResult pr = new PluginResult(PluginResult.Status.ERROR, "onRegisterAsPushNotificationClientFailed");
			pr.setKeepCallback(true);
			callbackContextKeepCallback.sendPluginResult(pr);		
        }		
    }

/*
    private void _registerAsPushNotificationClient() {
       try {
           	Parse.initialize(cordova.getActivity(), applicationId, clientKey);
    	   	ParseInstallation.getCurrentInstallation().save();

			PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			pr.setKeepCallback(true);
			callbackContextKeepCallback.sendPluginResult(pr);
			//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
			//pr.setKeepCallback(true);
			//callbackContextKeepCallback.sendPluginResult(pr);
        } 
        catch (ParseException e) {
			//PluginResult pr = new PluginResult(PluginResult.Status.OK, "onRegisterAsPushNotificationClientSucceeded");
			//pr.setKeepCallback(true);
			//callbackContextKeepCallback.sendPluginResult(pr);
			PluginResult pr = new PluginResult(PluginResult.Status.ERROR, "onRegisterAsPushNotificationClientFailed");
			pr.setKeepCallback(true);
			callbackContextKeepCallback.sendPluginResult(pr);		
        }

		//String installationId = ParseInstallation.getCurrentInstallation().getInstallationId();
		//String objectId = ParseInstallation.getCurrentInstallation().getObjectId();
		//Set<String> subscriptions = PushService.getSubscriptions(cordova.getActivity());
		//subscriptions.toString();
    }

    private void _unregister() {
		PluginResult pr = new PluginResult(PluginResult.Status.OK, "onUnregisterSucceeded");
		pr.setKeepCallback(true);
		callbackContextKeepCallback.sendPluginResult(pr);
		//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
		//pr.setKeepCallback(true);
		//callbackContextKeepCallback.sendPluginResult(pr);
    }
*/

    private void _subscribeToChannel(String channel) {
        ParsePush.subscribeInBackground(channel, new SaveCallback() {
            @Override
            public void done(ParseException e) {
                if (e == null) {
            		PluginResult pr = new PluginResult(PluginResult.Status.OK, "onSubscribeToChannelSucceeded");
            		pr.setKeepCallback(true);
            		callbackContextKeepCallback.sendPluginResult(pr);
            		//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
            		//pr.setKeepCallback(true);
            		//callbackContextKeepCallback.sendPluginResult(pr);                    
                } 
                else {
            		//PluginResult pr = new PluginResult(PluginResult.Status.OK, "onSubscribeToChannelSucceeded");
            		//pr.setKeepCallback(true);
            		//callbackContextKeepCallback.sendPluginResult(pr);
            		PluginResult pr = new PluginResult(PluginResult.Status.ERROR, "onSubscribeToChannelFailed");
            		pr.setKeepCallback(true);
            		callbackContextKeepCallback.sendPluginResult(pr);                    
                }
            }
        });
    }

    private void _unsubscribe(String channel) {
        ParsePush.unsubscribeInBackground(channel, new SaveCallback() {
            @Override
            public void done(ParseException e) {
                if (e == null) {
            		PluginResult pr = new PluginResult(PluginResult.Status.OK, "onUnsubscribeSucceeded");
            		pr.setKeepCallback(true);
            		callbackContextKeepCallback.sendPluginResult(pr);
            		//PluginResult pr = new PluginResult(PluginResult.Status.ERROR);
            		//pr.setKeepCallback(true);
            		//callbackContextKeepCallback.sendPluginResult(pr);	
                } 
                else {
            		//PluginResult pr = new PluginResult(PluginResult.Status.OK, "onUnsubscribeSucceeded");
            		//pr.setKeepCallback(true);
            		//callbackContextKeepCallback.sendPluginResult(pr);
            		PluginResult pr = new PluginResult(PluginResult.Status.ERROR, "onUnsubscribeFailed");
            		pr.setKeepCallback(true);
            		callbackContextKeepCallback.sendPluginResult(pr);	
                }
            }
        });
    }	
}

