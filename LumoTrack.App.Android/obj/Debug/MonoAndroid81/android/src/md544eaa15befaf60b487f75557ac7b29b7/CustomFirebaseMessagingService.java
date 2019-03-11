package md544eaa15befaf60b487f75557ac7b29b7;


public class CustomFirebaseMessagingService
	extends com.google.firebase.messaging.FirebaseMessagingService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMessageReceived:(Lcom/google/firebase/messaging/RemoteMessage;)V:GetOnMessageReceived_Lcom_google_firebase_messaging_RemoteMessage_Handler\n" +
			"";
		mono.android.Runtime.register ("LumoTrack.App.Android.Helpers.CustomFirebaseMessagingService, LumoTrack.App.Android", CustomFirebaseMessagingService.class, __md_methods);
	}


	public CustomFirebaseMessagingService ()
	{
		super ();
		if (getClass () == CustomFirebaseMessagingService.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Helpers.CustomFirebaseMessagingService, LumoTrack.App.Android", "", this, new java.lang.Object[] {  });
	}


	public void onMessageReceived (com.google.firebase.messaging.RemoteMessage p0)
	{
		n_onMessageReceived (p0);
	}

	private native void n_onMessageReceived (com.google.firebase.messaging.RemoteMessage p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
